using ISpiralCoreNetworkPluginInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiralCoreNetwork.CustomControls
{
    internal class SquareButton : Button
    {
        public SquareButton() : base()
        {
            this.FlatAppearance.BorderSize = 2;
            this.FlatAppearance.BorderColor = Color.DeepSkyBlue;
            this.FlatAppearance.MouseOverBackColor = Color.FromArgb(22, 46, 56);
            this.FlatAppearance.MouseDownBackColor = Color.DeepSkyBlue;
            this.FlatStyle = FlatStyle.Flat;
            this.AutoSize = false;
            this.ForeColor = Color.White;
            this.Height = 100;
            this.BackColor = Color.FromArgb(26, 26, 26);
        }
    }
}
