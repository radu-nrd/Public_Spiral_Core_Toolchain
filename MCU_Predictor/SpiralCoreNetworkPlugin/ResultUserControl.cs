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
    public partial class ResultUserControl : UserControl
    {
        public ResultUserControl()
        {
            InitializeComponent();
        }

        public void SetGradOverload(double grad_overload)
        {
            this.grad_overload_value_label.Text = $"{grad_overload:F5}";
        }

        public void SetCpuLoad(double cpuLoad)
        {
            this.cpu_load_value_label.Text = $"{cpuLoad:F5}";
        }
    }
}
