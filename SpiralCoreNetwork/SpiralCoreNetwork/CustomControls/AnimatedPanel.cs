using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpiralCoreNetwork.CustomControls
{
    public class AnimatedPanel : Panel
    {
        private PictureBox _backPictureBox;
        private Panel _overlayPanel;

        public Panel Overlay => _overlayPanel;
        public AnimatedPanel() : base()
        {
            _backPictureBox = new PictureBox();
            _backPictureBox.Dock = DockStyle.Fill;

            this.Controls.Add(_backPictureBox);
            _backPictureBox.SendToBack();

            _overlayPanel = new Panel();
            _overlayPanel.Dock = DockStyle.Fill;
            _overlayPanel.BackColor = Color.FromArgb(0,0, 0, 0);
            //_overlayPanel.BackColor = Color.FromArgb(46, 46, 46);
            _overlayPanel.Parent = _backPictureBox;
            _overlayPanel.BringToFront();

            _doubleBufferedEnable();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

        }

        private void _doubleBufferedEnable()
        {
            typeof(Panel).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
               ?.SetValue(this, true, null);

            typeof(PictureBox).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
               ?.SetValue(_backPictureBox, true, null);

            typeof(Panel).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
              ?.SetValue(_overlayPanel, true, null);
        }

        public void SetOpacity(int opacity)
        {
            _overlayPanel.BackColor = Color.FromArgb(opacity, 0, 0, 0);
        }

        public void SetBackgroundImage(Image image)
        {
            this._backPictureBox.Image = image;
            this._backPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }


    }
}
