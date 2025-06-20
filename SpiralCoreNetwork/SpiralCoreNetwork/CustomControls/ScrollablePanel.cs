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
    public partial class ScrollablePanel : UserControl
    {
        private Panel contentPanel;
        private CustomScrollBar customScrollBar;

        private const int ScrollStep = 20; // pasul de scroll la mousewheel

        public ScrollablePanel()
        {
            InitializeComponent();
            this.BackColor = Color.Transparent;

            contentPanel = new Panel();
            contentPanel.BackColor = this.BackColor;
            contentPanel.Location = new Point(0, 0);
            contentPanel.Size = new Size(this.Width - 20, this.Height);
            contentPanel.AutoScroll = false;

            customScrollBar = new CustomScrollBar();
            customScrollBar.Dock = DockStyle.Right;
            customScrollBar.ValueChanged += CustomScrollBar_ValueChanged;

            this.Controls.Add(contentPanel);
            this.Controls.Add(customScrollBar);

            this.Resize += (s, e) => AdjustLayout();
        }

        private void AdjustLayout()
        {
            contentPanel.Size = new Size(this.Width - customScrollBar.Width, this.Height);
            UpdateScrollbar();
        }

        private void CustomScrollBar_ValueChanged(object? sender, EventArgs e)
        {
            contentPanel.Location = new Point(0, -customScrollBar.Value);
        }

        public void AddControl(Control ctrl)
        {
            contentPanel.Controls.Add(ctrl);
            UpdateScrollbar();
        }

        private void UpdateScrollbar()
        {
            int totalHeight = 0;
            foreach (Control ctrl in contentPanel.Controls)
            {
                totalHeight = Math.Max(totalHeight, ctrl.Bottom);
            }

            contentPanel.Height = totalHeight;

            int scrollableHeight = totalHeight - this.Height;

            if (scrollableHeight > 0)
            {
                customScrollBar.Maximum = scrollableHeight;
                customScrollBar.LargeChange = this.Height;
                customScrollBar.SmallChange = ScrollStep;
                customScrollBar.Visible = true;
            }
            else
            {
                customScrollBar.Maximum = 0;
                customScrollBar.Value = 0;
                customScrollBar.Visible = false;
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (!customScrollBar.Visible) return;

            int newValue = customScrollBar.Value - Math.Sign(e.Delta) * customScrollBar.SmallChange;
            newValue = Math.Max(0, Math.Min(newValue, customScrollBar.Maximum));

            customScrollBar.Value = newValue;
            customScrollBar.Invalidate();
            contentPanel.Location = new Point(0, -customScrollBar.Value);
        }
    }

}
