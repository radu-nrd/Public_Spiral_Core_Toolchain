import pandas as pd
import random
import os
import model as m
import zipfile
import io
import numpy as np

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
                     frequency= int(row.get('Frecventa_MHz')),
                     ram= int(row.get('RAM_KB'))
                )
                if model not in model_list:
                    model_list.append(model)
        print(f'Parsing {fileIndex}/{files_count} files')
        fileIndex+=1
    else:
        print(f'File {file_name} is not a csv file!')

model_list = list(set(model_list))

output_dir = "generated_mcu_batches"
os.makedirs(output_dir, exist_ok=True)

def generate_row(mcu_model):
    freq = mcu_model.Frequency
    
    # Estimare: frecvența în MHz * 1000 cadre/sec + RAM/alte toleranțe
    max_frames = min((freq * 1000) + (mcu_model.Ram * 500), 500000)

    # Număr de magistrale per tip (randomizat)
    can = np.random.randint(1, 6)
    lin = np.random.randint(1, 6)
    eth = np.random.randint(1, 6)

    # Cadre per magistrală (plajă variabilă pentru realism)
    can_frames = can * np.random.randint(1, 12000)
    lin_frames = lin * np.random.randint(1, 9000)
    eth_frames = eth * np.random.randint(1, 15000)

    # Total cadre și procentaj de încărcare
    total_frames = can_frames + lin_frames + eth_frames
    grad_incarcare = np.clip((total_frames / max_frames) * 100, 0, 101)

    # Overload logic
    if grad_incarcare> 101:
        overload = 5
    elif grad_incarcare > 90:
        overload = 4
    elif grad_incarcare > 80:
        overload = 3
    elif grad_incarcare > 70:
        overload = 2
    elif grad_incarcare > 60:
        overload = 1
    else:
        overload = 0
    return {
        "[INPUT]Magistrale CAN": can,
        "[INPUT]Magistrale LIN": lin,
        "[INPUT]Magistrale ETH": eth,
        "[INPUT]CAN Bus frames": can_frames,
        "[INPUT]LIN Bus frames": lin_frames,
        "[INPUT]ETH Bus frames": eth_frames,
        "[INPUT]Frecventa": mcu_model.Frequency,
        "[INPUT]RAM": mcu_model.Ram,
        "[OUTPUT]Grad Overload": overload,
        "[OUTPUT]Grad incarcare MCU (In procente)": grad_incarcare,
        "[NO_USE]Model":mcu_model.Name
    }

def generate_batch_file(idx, numberOfBatchesPerModel=1, num_rows=128):
    
    zip_filename = f"test_mcu_batches_{idx+1}.batch"
    zip_path = os.path.join(output_dir, zip_filename)
    with zipfile.ZipFile(zip_path, 'w', zipfile.ZIP_DEFLATED) as zipf:
        for i in range(numberOfBatchesPerModel):
            rows = []
            for _ in range(num_rows):
                model = random.choice(model_list)
                row = generate_row(model)
                rows.append(row)

            batch_df = pd.DataFrame(rows)

            csv_buffer = io.StringIO()
            batch_df.to_csv(csv_buffer, index=False)
            csv_data = csv_buffer.getvalue()

            filename_in_zip = f"mcu_mini-batch_{i+1}.csv"
            zipf.writestr(filename_in_zip, csv_data)
            print(f'Created {i}/{numberOfBatchesPerModel} mini-batches')

N=5 #Number of batches
for i in range(N):
    generate_batch_file(i,numberOfBatchesPerModel=1000,num_rows=100)
    print(f'Generated {i}/{N} batches of data')
print("Done!")
