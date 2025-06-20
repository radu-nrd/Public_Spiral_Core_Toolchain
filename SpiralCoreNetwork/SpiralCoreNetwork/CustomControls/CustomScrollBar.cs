using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiralCoreNetwork.CustomControls
{
    public class CustomScrollBar : Control
    {
        public int Maximum { get; set; } = 100;
        public int Value { get; set; } = 0;
        public int LargeChange { get; set; } = 10;
        public int SmallChange { get; set; } = 20;

        private bool isDragging = false;
        private int dragOffsetY = 0;

        public event EventHandler? ValueChanged;

        public CustomScrollBar()
        {
            this.Width = 15;
            this.BackColor = Color.FromArgb(0, 17, 33);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.Clear(this.BackColor);

            if (Maximum <= 0) return;

            float percentVisible = (float)LargeChange / (Maximum + LargeChange);
            int thumbHeight = Math.Max((int)(Height * percentVisible), 20);

            int trackHeight = Height - thumbHeight;
            int thumbY = (int)((float)Value / Maximum * trackHeight);

            Rectangle thumbRect = new Rectangle(0, thumbY, Width, thumbHeight);

            using (Brush b = new SolidBrush(Color.DeepSkyBlue))
            {
                g.FillRectangle(b, thumbRect);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (Maximum <= 0) return;

            float percentVisible = (float)LargeChange / (Maximum + LargeChange);
            int thumbHeight = Math.Max((int)(Height * percentVisible), 20);
            int trackHeight = Height - thumbHeight;

            int thumbY = (int)((float)Value / Maximum * trackHeight);
            Rectangle thumbRect = new Rectangle(0, thumbY, Width, thumbHeight);

            if (thumbRect.Contains(e.Location))
            {
                isDragging = true;
                dragOffsetY = e.Y - thumbY;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (isDragging && Maximum > 0)
            {
                float percentVisible = (float)LargeChange / (Maximum + LargeChange);
                int thumbHeight = Math.Max((int)(Height * percentVisible), 20);
                int trackHeight = Height - thumbHeight;

                int newThumbY = e.Y - dragOffsetY;
                newThumbY = Math.Max(0, Math.Min(newThumbY, trackHeight));

                Value = (int)((float)newThumbY / trackHeight * Maximum);
                ValueChanged?.Invoke(this, EventArgs.Empty);
                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            isDragging = false;
        }
    }

}
