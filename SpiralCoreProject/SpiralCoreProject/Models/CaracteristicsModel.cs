namespace SpiralCoreProject.Models
{
    public class CaracteristicsModel
    {
        public required int ID {  get; set; }
        public required string Manufacturer {  get; set; }
        public required string Model {  get; set; }
        public required string Architecture {  get; set; }
        public required string Frequency_MHz {  get; set; }
        public required string Flash_Memory_KB {  get; set; }
        public required string RAM_Memory_KB { get; set; }
        public required string EEPROM_Memory_KB { get; set; }
        public required string Buses {  get; set; }
        public required string Price_USD {  get; set; }
        public required string TDP_W {  get; set; }
        public required string IO_Pins { get; set; }
        public required string Voltage {  get; set; }
        public required string Bundle {  get; set; }
        public required string Launch_Year {  get; set; }
    }
}
