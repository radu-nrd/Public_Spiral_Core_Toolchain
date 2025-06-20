using ClosedXML.Excel;
using ISpiralCoreNetworkPluginInterface;
using SpiralCoreNetworkPlugin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace NeuralNetworkPredictor
{
    public partial class NeuralNetworkPredictorWindow : UserControl
    {
        private List<TestElement> _data;
        private ISpiralCoreObj __mainObj;
        private Raport? _raport;
        private string? cfgPath;
        private IEnumerable<ConfigElement> config;

        private string? _testBatchPath;
        public NeuralNetworkPredictorWindow(ISpiralCoreObj main)
        {
            if (main.ActiveNeuralNetwork is false)
                throw new NoMachineLearnModelLoadedException();
            InitializeComponent();
            this._data = new List<TestElement>();
            this.__mainObj = main;
            CheckForIllegalCrossThreadCalls = false;
            this.startBtn.Enabled = false;
            this.config = new List<ConfigElement>();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "HTML Files (*.html)|*.html";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, _raport!.GetContent());
                    MessageBox.Show("Raport saved successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void loadDataBtn_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Batch File (*.batch)|*.batch";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    this.startBtn.Enabled = false;
                    DebugLine($"Start parsing {Path.GetFileName(ofd.FileName)}");
                    _testBatchPath = ofd.FileName;
                    parserWorker.RunWorkerAsync(ofd.FileName);
                }

            }
        }

        private void parserWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var filePath = e.Argument as string;

            using (FileStream zipToOpen = new FileStream(filePath!, FileMode.Open))
            using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Read))
            {
                foreach (var entry in archive.Entries)
                {
                    using (var stream = entry.Open())
                    {
                        var normalizedExcel = new XLWorkbook(stream);
                        var workSheet = normalizedExcel.Worksheet(1);
                        List<IEnumerable<double>> _tmpBtch = new List<IEnumerable<double>>();
                        List<IEnumerable<double>> _tmpPrd = new List<IEnumerable<double>>();

                        var inputColumns = ExtractColumns("[INPUT]", workSheet);
                        var outputColumns = ExtractColumns("[OUTPUT]", workSheet);
                        //var noUseColumns = ExtractColumns("[NO_USE]", workSheet);

                        for (int row = 2; row <= workSheet.LastRowUsed()!.RowNumber(); row++)
                        {
                            List<double> batchCache = new List<double>();
                            List<double> predCache = new List<double>();

                            foreach (var inputCol in inputColumns)
                                batchCache.Add(inputCol.Cell(row).GetDouble());

                            foreach (var outCol in outputColumns)
                                predCache.Add(outCol.Cell(row).GetDouble());

                            _tmpBtch.Add(batchCache);
                            _tmpPrd.Add(predCache);
                        }
                        _data.Add(new TestElement
                        {
                            Batch = _tmpBtch.Select(e => e.ToArray()).ToArray(),
                            Predictions = _tmpPrd.Select(e => e.ToArray()).ToArray(),
                            Name = Path.GetFileName(entry.FullName)
                        });
                    }
                }
            }
        }

        private IEnumerable<IXLColumn> ExtractColumns(string type, IXLWorksheet worksheet)
        {
            var noUseColumns = worksheet.Row(1).CellsUsed().Where(c => c.GetString().Trim().ToUpper().Contains(type)).Select(c => c.WorksheetColumn());
            if (!noUseColumns.Any())
                return Enumerable.Empty<IXLColumn>();
            return noUseColumns;
        }

        private void parserWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DebugLine("Done Parsing!");

            this.startBtn.Enabled = true;
        }

        private void AutoScrollListBox()
        {
            if (listBox1.Items.Count > 0)
                listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        private void DebugLine(string line)
        {
            this.listBox1.Items.Add(line);
            AutoScrollListBox();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            _raport = new Raport();
            _raport.SetTitle(Path.GetFileNameWithoutExtension(_testBatchPath!));
            foreach (var elem in _data)
            {
                DebugLine($"Starting predictions for {elem.Name}");
                ProcessSection(elem);
                DebugLine($"Done predictions for {elem.Name}");
            }

        }

        private void ProcessSection(TestElement data)
        {
            var section = new Section(data.Name);
            for (int i = 0; i < data.Batch.Length; i++)
            {
                var inputData = GetProcessedBatch(data.Batch[i]);
                var predictionData = GetProcessedPrediction(__mainObj.Predict(data.Batch[i]));
                var realPredictionData = GetProcessedPrediction(data.Predictions[i]);

                section.AddEntry(new DataEntry(
                    row_id: $"{i}",
                    inputData: inputData,
                    predictionData: predictionData,
                    realValueData: realPredictionData
                    ));
            }
            _raport!.AddSection(section);
        }

        private string GetProcessedBatch(double[] data)
        {
            //result[0] = grad_overload_elem.Min + ((result[0] - 0.001) / (0.9999 - 0.001)) * (grad_overload_elem.Max - grad_overload_elem.Min);
            double[] cache = new double[data.Length];
            for(int i = 0; i< data.Length; i++)
            {
                var cfgElem = config.ElementAt(i);
                cache[i] = cfgElem.Min + ((data[i] - 0.001) / ((0.9999 - 0.001)) * (cfgElem.Max - cfgElem.Min));
                cache[i] = Math.Round(cache[i]);
            }
            return $"[{string.Join(',', cache)}]";
        }
        private string GetProcessedPrediction(double[] prediction)
        {
            double[] cache = new double[prediction.Length];
            var cfgIdx = config.Count() - prediction.Length;
            for(int i = 0; i < prediction.Length; i++)
            {
                var cfgElem = config.ElementAt(cfgIdx+i);
                cache[i] = cfgElem.Min + ((prediction[i] - 0.001) / ((0.9999 - 0.001)) * (cfgElem.Max - cfgElem.Min));
                //cache[i] = Math.Round(cache[i]);
            }
            return $"[{string.Join(',', cache.Select(e=>e.ToString("F5")))}]";
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            if(cfgPath is null)
                if (MessageBox.Show("No config file was loaded." +
                   " Prediction will be in normalization format. " +
                   " Are you sure you want to continue?", "Warning",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Warning) == DialogResult.No)
                    return;

            worker.RunWorkerAsync();
        }

        private void loadCfgButton_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Config file *.cfg|*.cfg";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    DebugLine($"Start parsing config {Path.GetFileName(ofd.FileName)}");
                    config = ParseConfig(ofd.FileName);
                    DebugLine("Done parsing config!");
                }
                    
            }
        }

        private IEnumerable<ConfigElement> ParseConfig(string path)
        {
            cfgPath = path;
            var cache = new List<ConfigElement>();
            using (var sr = new StreamReader(cfgPath))
            {
                string? line;
                ConfigElement? elem = new ConfigElement { ColumnName = "NA" };
                while ((line = sr.ReadLine()) is not null)
                {
                    if (line.Trim().StartsWith('$') && line.Trim().EndsWith("$"))
                    {
                        if (elem.ColumnName != "NA")
                            cache.Add(elem);
                        elem = new ConfigElement { ColumnName = line.Replace("$", "") };
                    }

                    if (line.ToLower().Contains("min"))
                        elem.Min = double.Parse(line.Split("=>")[1].Trim());

                    if (line.ToLower().Contains("max"))
                        elem.Max = double.Parse(line.Split("=>")[1].Trim());
                }
                //fetch last element
                if (elem.ColumnName is not null)
                    cache.Add(elem);
            }
            return cache;
        }
    }
}
