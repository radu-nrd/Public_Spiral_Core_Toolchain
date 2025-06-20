using SpiralCoreNetwork.CustomControls;
using SpiralCoreNetwork.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpiralCoreNetwork
{
    public partial class ImportModelWindow : Form
    {
        Form1 _main;
        public ImportModelWindow(Form1 main)
        {
            InitializeComponent();
            this._main = main;
            var models = Directory.GetFiles("MachineLearnModels", "*.nn", SearchOption.AllDirectories);
            _AddModels(models);
        }
        private void _AddModels(string[] models)
        {
            int row = 1;
            int col = 1;

            foreach (var model in models)
            {
                SquareButton button = new SquareButton();
                button.Text = Path.GetFileNameWithoutExtension(model);
                button.Width = 100;
                button.Location = new Point(50 + 110 * (row - 1), 50 + 110 * (col - 1));
                button.Click += (s, e) => { 
                    SpiralCoreEntryPoint.SetMainObj(model);
                    _main.SetCurrentMachineModel(Path.GetFileName(model));
                    this.Close();
                    this.Dispose();
                    MessageBox.Show("Neural network model was successfully load","Info",MessageBoxButtons.OK,MessageBoxIcon.Information); };
                scrollablePanel1.AddControl(button);

                if (row != 1 && row % 6 == 0)
                {
                    col++;
                    row = 1;
                    continue;
                }
                row++;
            }
        }
    }
}
