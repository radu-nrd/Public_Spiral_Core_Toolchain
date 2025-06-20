using SpiralCoreNetwork.CustomControls;

namespace SpiralCoreNetwork
{
    partial class ImportModelWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            controlsPanel = new Panel();
            label1 = new Label();
            closeButton = new Button();
            logoPictureBox = new PictureBox();
            borderPanel1 = new BorderPanel();
            borderPanel2 = new BorderPanel();
            borderPanel3 = new BorderPanel();
            borderPanel4 = new BorderPanel();
            scrollablePanel1 = new ScrollablePanel();
            controlsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            SuspendLayout();
            // 
            // controlsPanel
            // 
            controlsPanel.BackColor = Color.FromArgb(0, 17, 33);
            controlsPanel.Controls.Add(label1);
            controlsPanel.Controls.Add(closeButton);
            controlsPanel.Controls.Add(logoPictureBox);
            controlsPanel.Dock = DockStyle.Top;
            controlsPanel.Location = new Point(0, 3);
            controlsPanel.Name = "controlsPanel";
            controlsPanel.Size = new Size(800, 40);
            controlsPanel.TabIndex = 5;
            controlsPanel.MouseDown += controlsPanel_MouseDown;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Left;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(40, 0);
            label1.Name = "label1";
            label1.Size = new Size(144, 40);
            label1.TabIndex = 8;
            label1.Text = "Machine Learn Models";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // closeButton
            // 
            closeButton.Dock = DockStyle.Right;
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.Font = new Font("Segoe UI", 10F);
            closeButton.ForeColor = Color.White;
            closeButton.Location = new Point(760, 0);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(40, 40);
            closeButton.TabIndex = 6;
            closeButton.Text = "✖";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            closeButton.MouseEnter += MouseEnterControlButton;
            closeButton.MouseLeave += MouseLeaveControlButton;
            // 
            // logoPictureBox
            // 
            logoPictureBox.Dock = DockStyle.Left;
            logoPictureBox.Image = Properties.Resources.spiral_core_logoo;
            logoPictureBox.Location = new Point(0, 0);
            logoPictureBox.Name = "logoPictureBox";
            logoPictureBox.Size = new Size(40, 40);
            logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            logoPictureBox.TabIndex = 11;
            logoPictureBox.TabStop = false;
            // 
            // borderPanel1
            // 
            borderPanel1.BackColor = Color.FromArgb(0, 17, 33);
            borderPanel1.Dock = DockStyle.Right;
            borderPanel1.Location = new Point(797, 43);
            borderPanel1.Name = "borderPanel1";
            borderPanel1.Size = new Size(3, 354);
            borderPanel1.TabIndex = 7;
            // 
            // borderPanel2
            // 
            borderPanel2.BackColor = Color.FromArgb(0, 17, 33);
            borderPanel2.Dock = DockStyle.Bottom;
            borderPanel2.Location = new Point(3, 397);
            borderPanel2.Name = "borderPanel2";
            borderPanel2.Size = new Size(797, 3);
            borderPanel2.TabIndex = 8;
            // 
            // borderPanel3
            // 
            borderPanel3.BackColor = Color.FromArgb(0, 17, 33);
            borderPanel3.Dock = DockStyle.Left;
            borderPanel3.Location = new Point(0, 43);
            borderPanel3.Name = "borderPanel3";
            borderPanel3.Size = new Size(3, 357);
            borderPanel3.TabIndex = 9;
            // 
            // borderPanel4
            // 
            borderPanel4.BackColor = Color.FromArgb(0, 17, 33);
            borderPanel4.Dock = DockStyle.Top;
            borderPanel4.Location = new Point(0, 0);
            borderPanel4.Name = "borderPanel4";
            borderPanel4.Size = new Size(800, 3);
            borderPanel4.TabIndex = 10;
            // 
            // scrollablePanel1
            // 
            scrollablePanel1.BackColor = Color.FromArgb(18, 51, 79);
            scrollablePanel1.Dock = DockStyle.Fill;
            scrollablePanel1.Location = new Point(3, 43);
            scrollablePanel1.Name = "scrollablePanel1";
            scrollablePanel1.Size = new Size(794, 354);
            scrollablePanel1.TabIndex = 11;
            // 
            // ImportModelWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 51, 79);
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 400);
            Controls.Add(scrollablePanel1);
            Controls.Add(borderPanel1);
            Controls.Add(borderPanel2);
            Controls.Add(borderPanel3);
            Controls.Add(controlsPanel);
            Controls.Add(borderPanel4);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "ImportModelWindow";
            Text = "Spiral Core Network";
            controlsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel controlsPanel;
        private Button closeButton;
        private Label label1;

        #region Custom Controls UI
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void maximizeButton_Click(object sender, EventArgs e)
        {
            if (this.Tag as string != "maximized")
            {
                var workingArea = Screen.FromControl(this).WorkingArea;
                this.Location = workingArea.Location;
                this.Size = workingArea.Size;
                this.Tag = "maximized";
            }
            else
            {
                this.Size = new Size(800, 600);
                this.Location = new Point(100, 100);
                this.Tag = null;
            }
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private CustomControls.BorderPanel borderPanel1;

        private void controlsPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Utils.Utils.ReleaseCapture();
                Utils.Utils.SendMessage(this.Handle, Utils.Utils.WM_NCLBUTTONDOWN, Utils.Utils.HTCAPTION, 0);
            }
        }

        private void MouseEnterControlButton(object sender, EventArgs e)
        {
            (sender as Button)!.BackColor = Color.FromArgb(50, 173, 216, 230);
        }

        private void MouseLeaveControlButton(object sender, EventArgs e)
        {
            (sender as Button)!.BackColor = Color.Transparent;
        }
        #endregion

        private CustomControls.BorderPanel borderPanel2;
        private CustomControls.BorderPanel borderPanel3;
        private BorderPanel borderPanel4;
        private PictureBox logoPictureBox;
        private ScrollablePanel scrollablePanel1;
    }
}