import os
from known_types import known_types as kt;
import csv
from typing import TextIO,Dict
import json

BASE_DIRECTORY = os.path.dirname(os.path.abspath(__file__))
INPUT_DIRECTORY = f'{BASE_DIRECTORY}\\MCU_DATA'
OUTPUT_DIRECTORY = f'{BASE_DIRECTORY}\\Output'

class Api_Data_Parser:

    def __init__(self):
        files = os.listdir(INPUT_DIRECTORY)
        self.__files = []
        for file in files:
            self.__files.append(f'{INPUT_DIRECTORY}\\{file}')

    def Parse(self):
        acc_dict = self.__BuildAccessDict()
        idx = 0
        for file in self.__files:
            with open(file,'r',newline='') as fileHandler:
                csvFile = csv.DictReader(fileHandler)
                for row in csvFile:
                    caracteristics_entry_tuple = self.__BuildJsonCaracteristicsEntry(idx,row)
                    caracteristics_key = caracteristics_entry_tuple[0]+"_Caracteristics"
                    
                    generic_entry_tuple = self.__BuildJsonGenericEntry(idx,row)
                    generic_key = generic_entry_tuple[0] + "_Generic"

                    json.dump(caracteristics_entry_tuple[1],acc_dict[caracteristics_key],indent=4)
                    acc_dict[caracteristics_key].flush()
                    acc_dict[caracteristics_key].write(",\n")
                    acc_dict[caracteristics_key].flush()

                    json.dump(generic_entry_tuple[1],acc_dict[generic_key],indent=4)
                    acc_dict[generic_key].flush()
                    acc_dict[generic_key].write(",\n")
                    acc_dict[generic_key].flush()

                    idx+=1
                    if idx%100 == 0:
                        print(f'Writed {idx} objects')
        
        for key in acc_dict.keys():
            acc_dict[key].close()
        
        for type in kt:
            with open(f'{OUTPUT_DIRECTORY}\\_{type.name.lower()}_caracteristics.json','rb+') as f:
                f.seek(-2,os.SEEK_END)
                f.truncate()
                f.seek(-1, os.SEEK_END)
                f.write(b']')

            with open(f'{OUTPUT_DIRECTORY}\\_{type.name.lower()}_generic.json','rb+') as f:
                f.seek(-2,os.SEEK_END)
                f.truncate()
                f.seek(-1, os.SEEK_END)
                f.write(b']')
                


    def __BuildAccessDict(self)-> Dict[str, TextIO]:
        acc_dict = dict()
        for type in kt:
            acc_dict[type.name + "_Caracteristics"] = open(f'{OUTPUT_DIRECTORY}\\_{type.name.lower()}_caracteristics.json','w+')
            acc_dict[type.name + "_Caracteristics"].write("[\n")
            acc_dict[type.name + "_Caracteristics"].flush()

            acc_dict[type.name + "_Generic"] = open(f'{OUTPUT_DIRECTORY}\\_{type.name.lower()}_generic.json','w+')
            acc_dict[type.name + "_Generic"].write("[\n")
            acc_dict[type.name + "_Generic"].flush()
        return acc_dict
    
    def __BuildJsonCaracteristicsEntry(self,idx,row_data):
        new_entry = {
            "ID":idx,
            "Manufacturer": row_data["Producator"],
            "Model":row_data["Model"],
            "Architecture": row_data["Arhitectura"],
            "Frequency_MHz": row_data["Frecventa_MHz"],
            "Flash_Memory_KB": row_data["Flash_KB"],
            "RAM_Memory_KB":row_data["RAM_KB"],
            "EEPROM_Memory_KB": row_data["EEPROM_KB"],
            "Buses": row_data["Magistrale"],
            "Price_USD": row_data["Pret_USD"],
            "TDP_W": row_data["Consum_W"],
            "IO_Pins":row_data["IO_Pins"],
            "Voltage":row_data["Tensiune_V"],
            "Bundle": row_data["Pachet"],
            "Launch_Year": row_data["An_Lansare"],
        }
        return (str(row_data["Aplicatie"]).upper(), new_entry)
    
    def __BuildJsonGenericEntry(self,idx,row_data):
        new_entry = {
            "ID":idx,
            "Title":row_data["Model"],
            "Description":row_data["Arhitectura"],
            "CategoryName":row_data["Aplicatie"]
        }
        return (str(row_data["Aplicatie"]).upper(), new_entry)

obj = Api_Data_Parser()
obj.Parse()