using ClosedXML.Excel;
using FinalNeuralNetwork.Interfaces;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurboTrainer
{
    internal class Trainer
    {
        List<TrainingElement> trainingList;
        INeuralNetwork network;
        Config cfg;
        List<string> logs;

        public Trainer(Config cfg)
        {
            this.trainingList = new List<TrainingElement>();
            this.network = INeuralNetwork.Load(cfg.MachineLearnModelFilePath);
            this.cfg = cfg;
            this.logs = new List<string>();
            Parse(cfg.NormalizedBatchFilePath);
        }

        public void Start()
        {
            var mlmName = Path.GetFileNameWithoutExtension(cfg.MachineLearnModelFilePath);
            Console.WriteLine($"Starting training for the {mlmName} MLM \n");
            double error = 0.0;
            for(int i = 1; i <= cfg.Iterations; i++)
            {
                foreach(var trainingElement in trainingList)
                {
                    logs.Clear();

                    for (int ep = 0; ep < cfg.Epochs; ep++)
                        error = network.TrainStep(trainingElement.Batch, trainingElement.Predictions, cfg.LearningRate);

                    logs.Add("");
                    logs.Add($"{mlmName} => Mini-Batch Trained: {trainingElement.Name}");
                    logs.Add($"{mlmName} => Iteration: {i}");
                    logs.Add($"{mlmName} => Epochs: {cfg.Epochs}");
                    logs.Add($"{mlmName} => MSE: {error}");
                    Console.WriteLine(string.Join("\n", logs));

                }

                network.Save(cfg.MachineLearnModelFilePath);
                Console.WriteLine($"{mlmName} => Model Saved");
            }
        }

        void Parse(string batchFile)
        {
            trainingList = new List<TrainingElement>();
            using (FileStream zipToOpen = new FileStream(batchFile, FileMode.Open))
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
                        trainingList.Add(new TrainingElement
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

    }
}
