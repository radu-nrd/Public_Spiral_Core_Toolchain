import pandas as pd
import random
import os
import model as m
import zipfile
import io

EST_CAN_CYCLES_COUNT_PER_FRAME = 1500
EST_LIN_CYCLES_COUNT_PER_FRAME = 400
EST_ETH_CYCLES_COUNT_PER_FRAME = 65000


source_dir = "MCU_DATA"
model_list = []

fileIndex = 1
files_count = len(os.listdir(source_dir))
for file_name in os.listdir(source_dir):
    if file_name.endswith(".csv"):
        df = pd.read_csv(os.path.join(source_dir, file_name))
        for _, row in df.iterrows():
                model = m.Model(
                     model_name=row.get('Model'),
                     architecture= row.get('Arhitectura'),
                     frequency= int(row.get('Frecventa_MHz')) * 1e6
                )
                if model not in model_list:
                    model_list.append(model)
    print(f'Parsing {fileIndex}/{files_count} files')
    fileIndex+=1
    break

model_list = list(set(model_list))

output_dir = "generated_mcu_batches"
os.makedirs(output_dir, exist_ok=True)

def generate_row(mcu_model): 
    can_count = random.randint(0, 10)
    lin_count = random.randint(0, 10)
    eth_count = random.randint(0, 10)
    freq = mcu_model.Frequency

    can_load = 0
    lin_load = 0
    eth_load = 0

    total_can_frame_count = 0
    total_lin_frame_count = 0
    total_eth_frame_count = 0

    for i in range(can_count):
        can_frame_count = random.randint(0, 10_000)
        total_can_frame_count += can_frame_count
        can_load += (can_frame_count * EST_CAN_CYCLES_COUNT_PER_FRAME) / freq

    for i in range(lin_count):
        lin_frame_count = random.randint(0, 10_000)
        total_lin_frame_count += lin_frame_count
        lin_load += (lin_frame_count * EST_LIN_CYCLES_COUNT_PER_FRAME) / freq
    
    for i in range(eth_count):
        eth_frame_count = random.randint(0, 10_000)
        total_eth_frame_count += eth_frame_count
        eth_load += (eth_frame_count * EST_ETH_CYCLES_COUNT_PER_FRAME) / freq

    load = can_load + lin_load + eth_load

    if load < 100.0:
        grad_overload = 0
    elif load < 250.0:
        grad_overload = 1
    elif load < 500.0:
        grad_overload = 2
    elif load < 750.0:
        grad_overload = 3
    elif load < 1000.0:
        grad_overload = 4
    else:
        grad_overload = 5

    return {
        "Magistrale CAN": can_count,
        "Magistrale LIN": lin_count,
        "Magistrale ETH": eth_count,
        "CAN Bus frames": total_can_frame_count,
        "LIN Bus frames": total_lin_frame_count,
        "ETH Bus frames": total_eth_frame_count,
        "Grad Overload": grad_overload,
        "Grad incarcare MCU (In procente)": f"{load}%"
    }

def generate_batch_file(idx, numberOfBatchesPerModel=1, num_rows=128):
    model = model_list[idx]
    zip_filename = f"mcu_batches_{model.Name}.batch"
    zip_path = os.path.join(output_dir, zip_filename)
    with zipfile.ZipFile(zip_path, 'w', zipfile.ZIP_DEFLATED) as zipf:
        for i in range(numberOfBatchesPerModel):
            rows = []
            for _ in range(num_rows):
              
                row = generate_row(model)
                rows.append(row)

            batch_df = pd.DataFrame(rows)

            csv_buffer = io.StringIO()
            batch_df.to_csv(csv_buffer, index=False)
            csv_data = csv_buffer.getvalue()

            filename_in_zip = f"mcu_mini-batch_{i+1}.csv"
            zipf.writestr(filename_in_zip, csv_data)
            print(f'Created {i}/{numberOfBatchesPerModel} mini-batches')

N=1 #Number of models
for i in range(N):
    generate_batch_file(i,numberOfBatchesPerModel=100,num_rows=128)
    print(f'Generated {i}/{N} batches of data')
print("Done!")
