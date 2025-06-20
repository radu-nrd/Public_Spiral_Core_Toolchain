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

namespace SpiralCoreNetwork.CustomControls
{
    public partial class FileMenu : UserControl
    {
        Form1 _main;
        public FileMenu(Form1 main)
        {
            InitializeComponent();
            this._main = main;
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            var window = new ImportModelWindow(_main);
            window.ShowDialog();
            _main.SetFilebuttonTag("closed");
            this.Dispose();

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SpiralCoreEntryPoint.Save();
            MessageBox.Show("Model was successfully saved!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
