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
    public partial class ResultView : UserControl
    {
        Control parent;
        public ResultView(Control parent,double grad_overload,double cpuLoad)
        {
            InitializeComponent();
            this.parent = parent;
            this.resultUserControl1.SetGradOverload(grad_overload);
            this.resultUserControl1.SetCpuLoad(cpuLoad);
        }

        private void BackButtonClick(object sender, EventArgs e)
        {
            parent.Controls.Remove(this);
            this.Dispose();
        }
    }
}
