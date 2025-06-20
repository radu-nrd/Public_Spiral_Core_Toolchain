using NeuralNetworkNormalizerV2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using ClosedXML;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Wordprocessing;

namespace NeuralNetworkNormalizerV2
{
    public partial class NeuralNetworkNormalizerWindow : UserControl
    {
        string[]? batchFiles;
        public NeuralNetworkNormalizerWindow()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void loadBatchButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Batch File (*.batch)|*.batch";
                ofd.Multiselect = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    batchFiles = ofd.FileNames;
                    var count = 0;
                    foreach(var batchFile in batchFiles)
                    {
                        using (FileStream zipToOpen = new FileStream(batchFile, FileMode.Open))
                        using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Read))
                        {
                            batchFilesListBox.Items.Add($"[{Path.GetFileNameWithoutExtension(batchFile)}]");
                            foreach (var entry in archive.Entries)
                                batchFilesListBox.Items.Add(Path.GetFileName(entry.FullName));
                            count += archive.Entries.Count;
                            countLabel.Text = $"Count: {count}";
                        }
                    }
                }
            }
        }

        private void normalizeBtn_Click(object sender, EventArgs e)
        {
            if (normalizeTypeBox.SelectedItem is null)
            {
                MessageBox.Show("Please select a normalizing algorithm!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (normalizeTypeBox.SelectedItem.ToString() == "Min-Max Scaling")
                worker.RunWorkerAsync();
        }

        private void WriteCFG(MinMaxScaler scaler)
        {
            var directory = Path.GetDirectoryName(batchFiles![0]);
            var cfg_path = $"{directory}/config.cfg";
            using(var sw =  new StreamWriter(cfg_path))
                foreach (var elem in scaler.Data)
                    if (!elem.Header.ToUpper().Contains("[NO_USE]"))
                    {
                        sw.WriteLine($"${elem.Header}$");
                        sw.WriteLine($"Min=>{elem.Min}");
                        sw.WriteLine($"Max=>{elem.Max}");
                        sw.WriteLine();
                    }
        }

        private void NormalizeFiles(string batchFile,MinMaxScaler scaler)
        {
            using (FileStream zipToOpen = new FileStream(batchFile!, FileMode.Open))
            using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Read))
            {
                var new_zip_file_path = $"{Path.GetDirectoryName(batchFile)}/{Path.GetFileNameWithoutExtension(batchFile)}_normalized.batch";

                var createFileStream = File.Create(new_zip_file_path);
                createFileStream.Dispose();

                this.progressBar1.Value = 0;
                this.progressBar1.Minimum = 0;
                this.progressBar1.Maximum = archive.Entries.Count;

                foreach (var entry in archive.Entries)
                {
                    var wb = GetNormalizedWorkbook(entry, scaler);

                    using (FileStream newZipStream = new FileStream(new_zip_file_path!, FileMode.Open))
                    using (ZipArchive newZip = new ZipArchive(newZipStream, ZipArchiveMode.Update))
                    {
                        var newEntry = newZip.CreateEntry($"{Path.GetFileNameWithoutExtension(entry.FullName)}_normalized.xlsx");
                        using (var stream = newEntry.Open())
                            wb.SaveAs(stream);
                    }

                    worker.ReportProgress(1);
                }
            }
        }

        private XLWorkbook GetNormalizedWorkbook(ZipArchiveEntry entry, MinMaxScaler scaler)
        {
            var wb = new XLWorkbook();
            wb.AddWorksheet("min_max_scaling_data");
            var ws = wb.Worksheet(1);
            var rowIdx = 1;

            using (var sr = new StreamReader(entry.Open()))
            {
                var header = sr.ReadLine()!.Split(',');
                for (int i = 0; i < header.Length; i++)
                    ws.Cell(rowIdx, i + 1).Value = header[i];
                rowIdx++;
                string? line = string.Empty;
                var mapping = scaler.Mapping;
                while ((line = sr.ReadLine()) != null)
                {
                    var data = line.Split(',');
                    for (int i = 0; i < data.Length; i++)
                    {
                        var dataDouble = GetFilteredValue(data[i], ref mapping);
                        var min = scaler.Data.ElementAt(i).Min;
                        var max = scaler.Data.ElementAt(i).Max;
                        ws.Cell(rowIdx, i + 1).Value = 0.001 + ((dataDouble - min) / (max - min)) * (0.9999 - 0.001);
                    }
                    rowIdx++;
                }
            }
            return wb;
        }

        private void BuildMinMaxScaler(string batchFile,ref MinMaxScaler scaler)
        {
            if (string.IsNullOrEmpty(batchFile))
            {
                MessageBox.Show("Please provide a valid batch file path!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var header = ExtractHeader(batchFile);
            var (minArray, maxArray, map) = ExtractMinMax(batchFile,header);
            scaler.SetMap(map);

            for (var i = 0; i < header.Length; i++)
                scaler.AddElement(new MinMaxElement { Header = header[i], Min = minArray[i], Max = maxArray[i] });

        }
        private string[] ExtractHeader(string batchFile)
        {
            using (FileStream zipToOpen = new FileStream(batchFile!, FileMode.Open))
            using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Read))
            using (var sr = new StreamReader(archive.Entries.ElementAt(0).Open()))
                return sr.ReadLine()!.Split(',');
        }
        private (double[], double[], Dictionary<string, double>) ExtractMinMax(string batchFile, string[] header)
        {
            using (FileStream zipToOpen = new FileStream(batchFile!, FileMode.Open))
            using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Read))
            {
                string? line = string.Empty;
                double[] minArray = Enumerable.Repeat(double.MaxValue, header.Length).ToArray();
                double[] maxArray = Enumerable.Repeat(double.MinValue, header.Length).ToArray();
                Dictionary<string, double> map = new Dictionary<string, double>();
                foreach (var entry in archive.Entries)
                {
                    using (var sr = new StreamReader(entry.Open()))
                    {
                        sr.ReadLine(); //skip header;
                        while ((line = sr.ReadLine()) != null)
                        {
                            var data = line.Split(',');
                            for (int i = 0; i < data.Length; i++)
                            {
                                var dataDouble = GetFilteredValue(data[i], ref map);
                                if (minArray[i] > dataDouble)
                                    minArray[i] = dataDouble;

                                if (maxArray[i] < dataDouble)
                                    maxArray[i] = dataDouble;
                            }
                        }
                    }
                }
                return (minArray, maxArray, map);
            }
        }
        private double GetFilteredValue(string value, ref Dictionary<string, double> map)
        {
            value = value.Trim().Replace("%", "");
            var valueType = GetValueType(value);
            if (valueType == typeof(double))
                return Convert.ToDouble(value);
            if (valueType == typeof(string))
            {
                if (!map.Any())
                {
                    map.Add(value, 1);
                    return 1;
                }

                if (map.ContainsKey(value))
                    return map[value];

                if (!map.ContainsKey(value))
                {
                    var lastValue = map.Values.Last();
                    map.Add(value, lastValue + 1);
                    return lastValue + 1;
                }
            }
            throw new ArgumentException("Something went wrong! Cannot parse the value");

        }

        private Type GetValueType(string value)
        {
            if (double.TryParse(value, out var result))
                return typeof(double);
            return typeof(string);
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var cfg = BuildAllCfg();
            WriteCFG(cfg);

            foreach (var batchFile in batchFiles!)
                NormalizeFiles(batchFile, cfg!);
        }

        private MinMaxScaler BuildAllCfg()
        {
            List<MinMaxScaler> scallers = new List<MinMaxScaler>();
            foreach(var batchFile in batchFiles!)
            {
                var scaller = new MinMaxScaler();
                BuildMinMaxScaler(batchFile, ref scaller);
                scallers.Add(scaller);
            }

            var allDataValidScaled = new MinMaxScaler();
            var allElements = GetAllElemenets(scallers);
            var uniqueHeaders = allElements.Select(e => e.Header).Distinct().ToList();

            foreach(var header in uniqueHeaders)
            {
                var min = double.MaxValue;
                var max = double.MinValue;
                foreach(var element in allElements)
                    if(element.Header.Trim() == header.Trim())
                    {
                        if (element.Min < min)
                            min = element.Min;
                        if (element.Max > max)
                            max = element.Max;
                    }
                allDataValidScaled.AddElement(new MinMaxElement { Header = header, Min = min, Max = max });
            }
            return allDataValidScaled;
        }

        private List<MinMaxElement> GetAllElemenets(List<MinMaxScaler> scalers)
        {
            var cache = new List<MinMaxElement>();
            foreach (var scaler in scalers)
                cache.AddRange(scaler.Data);
            return cache;
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (this.progressBar1.Value < this.progressBar1.Maximum)
                this.progressBar1.Value = this.progressBar1.Value + 1;
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Process of normalization is over!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
