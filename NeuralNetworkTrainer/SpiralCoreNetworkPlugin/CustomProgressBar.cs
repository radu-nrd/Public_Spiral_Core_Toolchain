using System;
using System.Drawing;
using System.Windows.Forms;

namespace NeuralNetworkTrainer
{
    public class CustomProgressBar : ProgressBar
    {
        public CustomProgressBar()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);   
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rect = this.ClientRectangle;
            e.Graphics.FillRectangle(Brushes.White, rect);

            rect.Width = (int)(rect.Width * ((double)this.Value / this.Maximum));

            e.Graphics.FillRectangle(Brushes.DeepSkyBlue, rect);

            e.Graphics.DrawRectangle(Pens.Black, 0, 0, this.Width - 1, this.Height - 1);
        }
    }
}
