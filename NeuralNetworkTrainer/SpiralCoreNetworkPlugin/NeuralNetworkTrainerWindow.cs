using ClosedXML.Excel;
using ISpiralCoreNetworkPluginInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralNetworkTrainer
{
    public partial class NeuralNetworkTrainerWindow : UserControl
    {
        ISpiralCoreObj __mainObj;
        List<TrainingElement> _trainer;
        double error;

        LoadingScreen loadingScreen;
        public NeuralNetworkTrainerWindow(ISpiralCoreObj obj)
        {
            if (obj.ActiveNeuralNetwork is false)
                throw new NoMachineLearnModelLoadedException();
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            __mainObj = obj;
            loadingScreen = new LoadingScreen();
            this._trainer = new List<TrainingElement>();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var epochs = int.Parse(epochsTextBox.Text);
            var lr = double.Parse(learningRateTextBox.Text);
            var iterations = int.Parse(iterationsTextBox.Text);

            this.customProgressBar1.Maximum = epochs;

            if (!_trainer.Any())
            {
                MessageBox.Show("Please load the batch file first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (processTypeComboBox.SelectedItem!.ToString() == "CPU")
            {
                for(int i = 0;i<iterations;i++)
                {
                    foreach(var trainingElement in _trainer)
                    {
                        currentMiniBatchLabel.Text = $"Current mini-batch: {trainingElement.Name}";
                        iterationsValueLabel.Text = $"Iteration {i + 1}";
                        this.customProgressBar1.Value = 0;
                        this.customProgressBar1.Minimum = 0;

                        for (int ep = 0; ep < epochs; ep++)
                        {
                            error = __mainObj.TrainStep(trainingElement.Batch, trainingElement.Predictions, lr);
                            trainerWorker.ReportProgress(1);

                            if (trainerWorker.CancellationPending)
                            {
                                e.Cancel = true;
                                return;
                            }
                        }
                    }
                }
            }

            if (processTypeComboBox.SelectedItem!.ToString() == "GPU")
            {
                for (int i = 0; i < iterations; i++)
                {
                    foreach (var trainingElement in _trainer)
                    {
                        currentMiniBatchLabel.Text = $"Current mini-batch: {trainingElement.Name}";
                        iterationsValueLabel.Text = $"Iteration {i + 1}";
                        this.customProgressBar1.Value = 0;
                        this.customProgressBar1.Minimum = 0;

                        __mainObj.InitializeGPU(trainingElement.Batch, trainingElement.Predictions);
                        for (int ep = 0; ep < epochs; ep++)
                        {
                            error = __mainObj.TrainStepGpu(trainingElement.Batch, lr);
                            trainerWorker.ReportProgress(1);

                            if (trainerWorker.CancellationPending)
                            {
                                e.Cancel = true;
                                return;
                            }
                        }
                    }
                }
            }
        }

        private void UpdateErrorLabel(double error)
        {
            errorValueLabel.BackColor = GetColorFromValue(error);
            if (error < 1e-05)
                errorValueLabel.Text = error.ToString("e6");
            else
                errorValueLabel.Text = error.ToString("f8");
        }

        private double NormalizeError(double error)
        {
            return 1.0 - 1.0 / (1.0 + error);
        }

        private Color GetColorFromValue(double value)
        {
            double t = NormalizeError(value);
            Color badColor = Color.DarkRed;
            Color goodColor = Color.DeepSkyBlue;
            return LerpColor(badColor, goodColor, 1.0 - t);
        }
        private Color LerpColor(Color from, Color to, double t)
        {
            if(double.IsNaN(t))
                return from;
            int r = (int)(from.R + (to.R - from.R) * t);
            int g = (int)(from.G + (to.G - from.G) * t);
            int b = (int)(from.B + (to.B - from.B) * t);
            return Color.FromArgb(r, g, b);
        }


        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            UpdateErrorLabel(error);
            if (this.customProgressBar1.Value < this.customProgressBar1.Maximum)
                this.customProgressBar1.Value++;
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.startTrainingBtn.Enabled = true;

            if (e.Cancelled)
            {
                MessageBox.Show("Training process was cancelled!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show("Training process is over!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void loadBatchButton_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Batch File (*.batch)|*.batch";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    loadingScreen = new LoadingScreen();
                    userPanel.Controls.Add(loadingScreen);
                    loadingScreen.BringToFront();
                    loadingScreen.Dock = DockStyle.Fill;
                    loadingScreen.Show();
                    parserWorker.RunWorkerAsync(ofd.FileName);
                    dataTextBox.Text = Path.GetFileName(ofd.FileName);
                }
                   
            }
        }

        private void startTrainingBtn_Click(object sender, EventArgs e)
        {
            if (processTypeComboBox.SelectedItem is null)
            {
                MessageBox.Show("Please select a process type!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            trainerWorker.RunWorkerAsync();
            this.startTrainingBtn.Enabled = false;
        }

        private void AbortProcessOnClickEvent(object sender, EventArgs e)
        {
            trainerWorker.CancelAsync();
        }

        private void parserWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var filePath = e.Argument as string;
            _trainer = new List<TrainingElement>();
            using (FileStream zipToOpen = new FileStream(filePath!, FileMode.Open))
            using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Read))
            {
                foreach (var entry in archive.Entries)
                {
                    using(var stream = entry.Open())
                    {
                        var normalizedExcel = new XLWorkbook(stream);
                        var workSheet = normalizedExcel.Worksheet(1);
                        List<IEnumerable<double>> _tmpBtch = new List<IEnumerable<double>>();
                        List<IEnumerable<double>> _tmpPrd = new List<IEnumerable<double>>();

                        var inputColumns = ExtractColumns("[INPUT]", workSheet);
                        var outputColumns = ExtractColumns("[OUTPUT]", workSheet);
                        var noUseColumns = ExtractColumns("[NO_USE]", workSheet);

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
                        _trainer.Add(new TrainingElement
                        {
                            Batch = _tmpBtch.Select(e => e.ToArray()).ToArray(),
                            Predictions = _tmpPrd.Select(e => e.ToArray()).ToArray(),
                            Name = Path.GetFileName(entry.FullName)
                        });
                    }
                }
            }
        }

        private IEnumerable<IXLColumn> ExtractColumns(string type,IXLWorksheet worksheet)
        {
            var noUseColumns = worksheet.Row(1).CellsUsed().Where(c => c.GetString().Trim().ToUpper().Contains(type)).Select(c=>c.WorksheetColumn());
            if (!noUseColumns.Any())
                return Enumerable.Empty<IXLColumn>();
            return noUseColumns;
        }

        private void parserWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void parserWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            loadingScreen.Dispose();
        }
    }
}
