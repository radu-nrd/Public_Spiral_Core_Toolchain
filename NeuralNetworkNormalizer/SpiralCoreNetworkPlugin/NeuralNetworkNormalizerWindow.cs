using ClosedXML.Excel;
using ISpiralCoreNetworkPluginInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpiralCoreNetworkPlugin
{
    public partial class NeuralNetworkNormalizerWindow : UserControl
    {
        string? batchFile;
        ISpiralCoreObj main;
        public NeuralNetworkNormalizerWindow(ISpiralCoreObj main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void loadBatchButton_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "CSV or Excel File (*.csv, *.xlsx)|*.csv;*.xlsx|All files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                    batchFile = ofd.FileName;
            }
            batchPathTextBox.Text = Path.GetFileName(batchFile);
        }
        private void normalizeButton_Click(object sender, EventArgs e)
        {
            if(normalizeTypeBox.SelectedIndex == 0 || normalizeTypeBox.SelectedIndex == 1)
            {
                NormalizeWorksheet();
                MessageBox.Show("Process of normalization is over!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                

        }
        private StreamWriter CreateConfig(string filePath)
        {
            return new StreamWriter(File.Create(filePath));
        }

        private void NormalizeWorksheet()
        {
            XLWorkbook workBook;
            if (Path.GetExtension(batchFile)!.Trim().Equals(".csv"))
                ConvertCsvToExcel(out workBook);
            else
                workBook = new XLWorkbook(batchFile);
            var ws = workBook.Worksheet(1);

            var normalizedWorkBook = new XLWorkbook();
            normalizedWorkBook.Worksheets.Add("data_normalized");
            var normalizedWs = normalizedWorkBook.Worksheet(1);

            var cfgWriter = CreateConfig($"{Path.GetDirectoryName(batchFile)}/{Path.GetFileNameWithoutExtension(batchFile)}_config.cfg");
            cfgWriter.WriteLine($"#{normalizeTypeBox.SelectedItem!.ToString()}#");
            cfgWriter.WriteLine();

            if(normalizeTypeBox.SelectedIndex == 0 || normalizeTypeBox.SelectedIndex == 1)
                MinMaxScaling(ref ws,ref normalizedWs,ref cfgWriter);

            normalizedWorkBook.SaveAs($"{Path.GetDirectoryName(batchFile)}/{Path.GetFileNameWithoutExtension(batchFile)}_normalized.xlsx");
            cfgWriter.Flush();
            cfgWriter.Close();

        }

        private void MinMaxScaling(ref IXLWorksheet ws,ref IXLWorksheet normalizedWs,ref StreamWriter cfgWriter)
        {
            for (int i = 1; i <= ws.LastColumnUsed()!.ColumnNumber(); i++)
            {
                var normalizedColumn = NormalizeColumn(ws.Column(i), cfgWriter);
                if (normalizedColumn.HasValue)
                {
                    normalizedWs.Column(i).Cell(1).Value = normalizedColumn.Value.Item2;
                    int idx = 2;
                    foreach (var item in normalizedColumn.Value.Item1)
                    {
                        normalizedWs.Column(i).Cell(idx).Value = item;
                        idx++;
                    }
                }
            }
        }

        private (IEnumerable<double>,string)? NormalizeColumn(IXLColumn column,StreamWriter sw)
        {
            var data = column.CellsUsed().Skip(1).ToList();
            var typeOfData = _GetTypeOfData(data.ElementAt(0));

            var cache = new List<double>();
            var min = 0.0;
            var max = 0.0;
            var formatted_data = FormatData(data);

            if (typeOfData == typeof(string))
                NormalizeStringType(column,formatted_data, ref min, ref max, ref cache);
            if (typeOfData == typeof(double))
                NormalizeDoubleType(column,formatted_data, ref min,ref max, ref cache);

            sw.WriteLine($"[{column.FirstCell().GetString().Trim()}]");
            switch (normalizeTypeBox.SelectedIndex)
            {
                case 0:
                    sw.WriteLine($"Min=>{min}");
                    sw.WriteLine($"Max=>{max}");
                    break;
                case 1:
                    if (column.ColumnNumber() == column.Worksheet.LastColumnUsed()!.ColumnNumber())
                        sw.WriteLine("LOG=>1+x");
                    else
                    {
                        sw.WriteLine($"Min=>{min}");
                        sw.WriteLine($"Max=>{max}");
                    }
                    break;
            }
            sw.WriteLine();

            return (cache, column.Cell(1).GetString().Trim());
        }
        private void NormalizeDoubleType(IXLColumn column,IEnumerable<string> formatted_data, ref double min, ref double max, ref List<double> cache)
        {
            var encodingData = formatted_data.Select(c => double.Parse(c)).ToList();
            min = encodingData.Min();
            max = encodingData.Max();
            switch (normalizeTypeBox.SelectedIndex)
            {
                case 0:
                     for (int i = 0; i < formatted_data.Count(); i++)
                        cache.Add(
                            0.001 + (((double.Parse(formatted_data.ElementAt(i)) - min) / (max - min)) * (0.9999 - 0.001)));
                    break;
                case 1:
                    if (column.ColumnNumber() == column.Worksheet.LastColumnUsed()!.ColumnNumber())
                    {
                        for (int i = 0; i < formatted_data.Count(); i++)
                            cache.Add(Math.Log(1 + double.Parse(formatted_data.ElementAt(i))));
                        break;
                    }
                    for (int i = 0; i < formatted_data.Count(); i++)
                        cache.Add(
                            0.001 + (((double.Parse(formatted_data.ElementAt(i)) - min) / (max - min)) * (0.9999 - 0.001)));
                    break;
                default:
                    throw new InvalidOperationException("No Normalization method was selected!");
            }
        }
        private void NormalizeStringType(IXLColumn column, IEnumerable<string> formatted_data,ref double min,ref double max,ref List<double> cache)
        {
            var labelEncoding = GetLabelEncoded(formatted_data);
            min = labelEncoding.Values.Min();
            max = labelEncoding.Values.Max();
            switch (normalizeTypeBox.SelectedIndex)
            {
                case 0:
                    for (int i = 0; i < formatted_data.Count(); i++)
                        cache.Add((double)(
                            0.001 +
                            ((labelEncoding[formatted_data.ElementAt(i)] - min) / (max - min))
                            * (0.9999 - 0.001))
                            );
                    break;
                case 1:

                    if (column.ColumnNumber() == column.Worksheet.LastColumnUsed()!.ColumnNumber())
                    {
                        for (int i = 0; i < formatted_data.Count(); i++)
                            cache.Add(Math.Log(1 + labelEncoding[formatted_data.ElementAt(i)]));
                        break;
                    }
                       
                    for (int i = 0; i < formatted_data.Count(); i++)
                        cache.Add((double)(
                            0.001 +
                            ((labelEncoding[formatted_data.ElementAt(i)] - min) / (max - min))
                            * (0.9999 - 0.001))
                            );
                    break;
                default:
                    throw new InvalidOperationException("No Normalization method was selected!");
            }
        }
        private IEnumerable<string> FormatData(IEnumerable<IXLCell> data)
        {
            var cache = new List<string>();
            foreach(var elem in data)
                cache.Add(elem.GetString().Trim().Replace("%",""));
            return cache;
        }
        private Dictionary<string,int> GetLabelEncoded(IEnumerable<string> data)
        {
            var cache = new Dictionary<string,int>();
            var idx = 0;
            foreach(var elem in data)
                if (!cache.ContainsKey(elem))
                {
                    cache.Add(elem, idx);
                    idx++;
                }
            return cache;
                    
        }
        private Type _GetTypeOfData(IXLCell cell)
        {
            if(double.TryParse(cell.GetString().Trim().Replace("%",""),out var data))
                return typeof(double);
            return typeof(string);
        }
        private void ConvertCsvToExcel(out XLWorkbook workbook)
        {
            workbook = new XLWorkbook();
            workbook.Worksheets.Add("data");

            using(StreamReader sr = new StreamReader(batchFile!))
            {
                int row = 1;
                string? currentLine = string.Empty;
                while((currentLine = sr.ReadLine()) != null)
                {
                    var columns = currentLine.Split(',');
                    for (int col = 0; col < columns.Length; col++)
                        workbook.Worksheets.ElementAt(0).Cell(row, col + 1).Value = columns[col];
                    row++;
                }
            }
        }
    }
}
