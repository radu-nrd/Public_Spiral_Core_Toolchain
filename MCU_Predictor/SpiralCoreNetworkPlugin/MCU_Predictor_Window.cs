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

namespace MCU_Predictor
{
    public partial class MCU_Predictor_Window : UserControl
    {
        string? cfgPath;
        IEnumerable<ConfigElement> config;
        ISpiralCoreObj main;
        public MCU_Predictor_Window(ISpiralCoreObj main)
        {
            if(main.ActiveNeuralNetwork is false)
                throw new NoMachineLearnModelLoadedException();
            InitializeComponent();
            config = new List<ConfigElement>();
            this.main = main;
        }

        private void predictBtn_Click(object sender, EventArgs e)
        {
            if (cfgPath is null)
            {
                MessageBox.Show("No config file was loaded. If you want to get a valid result please insert config.","Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var canElem = GetElem("CAN")!;
            var linElem = GetElem("LIN")!;
            var ethElem = GetElem("ETH")!;

            var canFrames = GetElem("CAN BUS FRAMES")!;
            var linFrames = GetElem("LIN BUS FRAMES")!;
            var ethFrames = GetElem("ETH BUS FRAMES")!;

            var freqElem = GetElem("FRECVENTA")!;
            var ramElem = GetElem("[INPUT]RAM")!;

            double[] data = [
                0.001 + ((double.Parse(canBusTextBox.Text) - canElem.Min)/
                (canElem.Max - canElem.Min)) * (0.9999-0.001),

                0.001 + ((double.Parse(linBusTextBox.Text) - linElem.Min)/
                (linElem.Max - linElem.Min)) * (0.9999-0.001),

                0.001 + ((double.Parse(ethBusTextBox.Text) - ethElem.Min)/
                (ethElem.Max - ethElem.Min)) * (0.9999-0.001),

                0.001 + ((double.Parse(canFramesTextBox.Text) - canFrames.Min)/
                (canFrames.Max - canFrames.Min)) * (0.9999-0.001),

                0.001 + ((double.Parse(linFramesTextBox.Text) - linFrames.Min)/
                (linFrames.Max - linFrames.Min)) * (0.9999-0.001),

                0.001 + ((double.Parse(ethFramesTextBox.Text) - ethFrames.Min)/
                (ethFrames.Max - ethFrames.Min)) * (0.9999-0.001),

                 0.001 + ((double.Parse(frequencyTextBox.Text) - freqElem.Min)/
                (freqElem.Max - freqElem.Min)) * (0.9999-0.001),

                 0.001 + ((double.Parse(ramTextBox.Text) - ramElem.Min)/
                (ramElem.Max - ramElem.Min)) * (0.9999-0.001)

                ];

            //MessageBox.Show($"Data is: {string.Join(',', data)}");

            var resultElem = GetElem("GRAD INCARCARE")!;
            var grad_overload_elem = GetElem("GRAD OVERLOAD")!;

            var result = main.Predict(data);

            var predictionStr = string.Empty;
            for (int i = 0; i < result.Length; i++)
                predictionStr += $"{result[i].ToString("f5")}\n";

            //MessageBox.Show($"Prediction is: {predictionStr}",
            //    "Prediction",
            //    MessageBoxButtons.OK,
            //    MessageBoxIcon.Information);

            result[0] = grad_overload_elem.Min + ((result[0] - 0.001) / (0.9999 - 0.001)) * (grad_overload_elem.Max - grad_overload_elem.Min);
            result[1] = resultElem.Min + ((result[1] - 0.001) / (0.9999 - 0.001)) * (resultElem.Max - resultElem.Min);

            var resultControl = new ResultView(this.userPanel, result[0], result[1]);
            this.userPanel.Controls.Add(resultControl);
            resultControl.BringToFront();
            resultControl.Dock = DockStyle.Fill;
            resultControl.Show();

            //predictionStr = string.Empty;
            //for (int i = 0; i < result.Length; i++)
            //    predictionStr += $"{result[i].ToString("f5")}\n";

            //MessageBox.Show($"Prediction is: {predictionStr}",
            //    "Prediction",
            //    MessageBoxButtons.OK,
            //    MessageBoxIcon.Information);
        }

        private void loadCfgBtn_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Config file *.cfg|*.cfg";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    config = ParseConfig(ofd.FileName);
                    SetupToolTip();
                }

            }
        }
        void SetupToolTip()
        {
            if (config.Any())
            {
                var canElem = GetElem("CAN");
                var linElem = GetElem("LIN");
                var ethElem = GetElem("ETH");
                var canFrames = GetElem("CAN BUS FRAMES");
                var linFrames = GetElem("LIN BUS FRAMES");
                var ethFrames = GetElem("ETH BUS FRAMES");
                var freqElem = GetElem("FRECVENTA");
                var ramElem = GetElem("[INPUT]RAM");

                canBusTextBox.Text = $"Range: [{canElem?.Min:F2},{canElem?.Max:F2}]";
                linBusTextBox.Text = $"Range: [{linElem?.Min:F2},{linElem?.Max:F2}]";
                ethBusTextBox.Text = $"Range: [{ethElem?.Min:F2},{ethElem?.Max:F2}]";
                canFramesTextBox.Text = $"Range: [{canFrames?.Min:F2},{canFrames?.Max:F2}]";
                linFramesTextBox.Text = $"Range: [{linFrames?.Min:F2},{linFrames?.Max:F2}]";
                ethFramesTextBox.Text = $"Range: [{ethFrames?.Min:F2},{ethFrames?.Max:F2}]";
                frequencyTextBox.Text = $"Range: [{freqElem?.Min:F2},{freqElem?.Max:F2}]";
                ramTextBox.Text = $"Range: [{ramElem?.Min:F2},{ramElem?.Max:F2}]";
            }
        }

        ConfigElement? GetElem(string key)
        {
            if (config is null)
                return null;
            return config.FirstOrDefault(c => c.ColumnName is not null && c.ColumnName.ToUpper().Contains(key.ToUpper()));
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
                        if (elem.ColumnName!="NA")
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

        //private void TextChangedEvent(object sender, EventArgs e)
        //{
        //    var tb = sender as TextBox;
        //    if(tb is null) return;
        //    if (string.IsNullOrEmpty(tb.Text))
        //    {
        //        var elem = GetElem(tb.Tag!.ToString()!);
        //        tb.Text = $"Range: [{elem?.Min:F2},{elem?.Max:F2}]";
        //    }
        //}
    }
}
