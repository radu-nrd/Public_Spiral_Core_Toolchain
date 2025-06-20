using SpiralCoreNetwork.CustomControls;

namespace SpiralCoreNetwork
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            controlsPanel = new Panel();
            label1 = new Label();
            minimizeButton = new Button();
            maximizeButton = new Button();
            closeButton = new Button();
            logoPictureBox = new PictureBox();
            animatedPanel1 = new AnimatedPanel();
            panel1 = new Panel();
            currentModelLabelValue = new Label();
            pluginsButton = new Button();
            fileButton = new Button();
            borderPanel1 = new BorderPanel();
            borderPanel2 = new BorderPanel();
            borderPanel3 = new BorderPanel();
            borderPanel4 = new BorderPanel();
            controlsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // controlsPanel
            // 
            controlsPanel.BackColor = Color.FromArgb(0, 17, 33);
            controlsPanel.Controls.Add(label1);
            controlsPanel.Controls.Add(minimizeButton);
            controlsPanel.Controls.Add(maximizeButton);
            controlsPanel.Controls.Add(closeButton);
            controlsPanel.Controls.Add(logoPictureBox);
            controlsPanel.Dock = DockStyle.Top;
            controlsPanel.Location = new Point(0, 3);
            controlsPanel.Name = "controlsPanel";
            controlsPanel.Size = new Size(1170, 40);
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
            label1.Text = "Spiral Core Network";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // minimizeButton
            // 
            minimizeButton.Dock = DockStyle.Right;
            minimizeButton.FlatAppearance.BorderSize = 0;
            minimizeButton.FlatStyle = FlatStyle.Flat;
            minimizeButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            minimizeButton.ForeColor = Color.White;
            minimizeButton.Location = new Point(1050, 0);
            minimizeButton.Name = "minimizeButton";
            minimizeButton.Size = new Size(40, 40);
            minimizeButton.TabIndex = 7;
            minimizeButton.Text = "─";
            minimizeButton.UseVisualStyleBackColor = true;
            minimizeButton.Click += minimizeButton_Click;
            minimizeButton.MouseEnter += MouseEnterControlButton;
            minimizeButton.MouseLeave += MouseLeaveControlButton;
            // 
            // maximizeButton
            // 
            maximizeButton.Dock = DockStyle.Right;
            maximizeButton.FlatAppearance.BorderSize = 0;
            maximizeButton.FlatStyle = FlatStyle.Flat;
            maximizeButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            maximizeButton.ForeColor = Color.White;
            maximizeButton.Location = new Point(1090, 0);
            maximizeButton.Name = "maximizeButton";
            maximizeButton.Size = new Size(40, 40);
            maximizeButton.TabIndex = 7;
            maximizeButton.Text = "▢";
            maximizeButton.UseVisualStyleBackColor = true;
            maximizeButton.Click += maximizeButton_Click;
            maximizeButton.MouseEnter += MouseEnterControlButton;
            maximizeButton.MouseLeave += MouseLeaveControlButton;
            // 
            // closeButton
            // 
            closeButton.Dock = DockStyle.Right;
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.Font = new Font("Segoe UI", 10F);
            closeButton.ForeColor = Color.White;
            closeButton.Location = new Point(1130, 0);
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
            // animatedPanel1
            // 
            animatedPanel1.Dock = DockStyle.Fill;
            animatedPanel1.Location = new Point(3, 83);
            animatedPanel1.Name = "animatedPanel1";
            animatedPanel1.Size = new Size(1167, 519);
            animatedPanel1.TabIndex = 6;
            animatedPanel1.SetBackgroundImage(Image.FromFile("lib/img/body_background.gif"));
            animatedPanel1.Overlay.Click += Overlay_Click;
            animatedPanel1.SetOpacity(125);
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 17, 33);
            panel1.Controls.Add(currentModelLabelValue);
            panel1.Controls.Add(pluginsButton);
            panel1.Controls.Add(fileButton);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(3, 43);
            panel1.Name = "panel1";
            panel1.Size = new Size(1167, 40);
            panel1.TabIndex = 1;
            // 
            // currentModelLabelValue
            // 
            currentModelLabelValue.Dock = DockStyle.Right;
            currentModelLabelValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            currentModelLabelValue.ForeColor = Color.White;
            currentModelLabelValue.Location = new Point(967, 0);
            currentModelLabelValue.MaximumSize = new Size(200, 40);
            currentModelLabelValue.Name = "currentModelLabelValue";
            currentModelLabelValue.Size = new Size(200, 40);
            currentModelLabelValue.TabIndex = 9;
            currentModelLabelValue.Text = "Current Model: None";
            currentModelLabelValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pluginsButton
            // 
            pluginsButton.Dock = DockStyle.Left;
            pluginsButton.FlatAppearance.BorderSize = 0;
            pluginsButton.FlatStyle = FlatStyle.Flat;
            pluginsButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            pluginsButton.ForeColor = Color.White;
            pluginsButton.Location = new Point(75, 0);
            pluginsButton.Name = "pluginsButton";
            pluginsButton.Size = new Size(75, 40);
            pluginsButton.TabIndex = 1;
            pluginsButton.Tag = "";
            pluginsButton.Text = "Plugins";
            pluginsButton.UseVisualStyleBackColor = true;
            pluginsButton.Click += pluginsButton_Click;
            pluginsButton.MouseEnter += MouseEnterControlButton;
            pluginsButton.MouseLeave += MouseLeaveControlButton;
            // 
            // fileButton
            // 
            fileButton.Dock = DockStyle.Left;
            fileButton.FlatAppearance.BorderSize = 0;
            fileButton.FlatStyle = FlatStyle.Flat;
            fileButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            fileButton.ForeColor = Color.White;
            fileButton.Location = new Point(0, 0);
            fileButton.Name = "fileButton";
            fileButton.Size = new Size(75, 40);
            fileButton.TabIndex = 0;
            fileButton.Tag = "closed";
            fileButton.Text = "File";
            fileButton.UseVisualStyleBackColor = true;
            fileButton.Click += fileButton_Click;
            fileButton.MouseEnter += MouseEnterControlButton;
            fileButton.MouseLeave += MouseLeaveControlButton;
            // 
            // borderPanel1
            // 
            borderPanel1.BackColor = Color.FromArgb(0, 17, 33);
            borderPanel1.Dock = DockStyle.Right;
            borderPanel1.Location = new Point(1170, 3);
            borderPanel1.Name = "borderPanel1";
            borderPanel1.Size = new Size(3, 602);
            borderPanel1.TabIndex = 7;
            // 
            // borderPanel2
            // 
            borderPanel2.BackColor = Color.FromArgb(0, 17, 33);
            borderPanel2.Dock = DockStyle.Bottom;
            borderPanel2.Location = new Point(3, 602);
            borderPanel2.Name = "borderPanel2";
            borderPanel2.Size = new Size(1167, 3);
            borderPanel2.TabIndex = 8;
            // 
            // borderPanel3
            // 
            borderPanel3.BackColor = Color.FromArgb(0, 17, 33);
            borderPanel3.Dock = DockStyle.Left;
            borderPanel3.Location = new Point(0, 43);
            borderPanel3.Name = "borderPanel3";
            borderPanel3.Size = new Size(3, 562);
            borderPanel3.TabIndex = 9;
            // 
            // borderPanel4
            // 
            borderPanel4.BackColor = Color.FromArgb(0, 17, 33);
            borderPanel4.Dock = DockStyle.Top;
            borderPanel4.Location = new Point(0, 0);
            borderPanel4.Name = "borderPanel4";
            borderPanel4.Size = new Size(1173, 3);
            borderPanel4.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1173, 605);
            Controls.Add(animatedPanel1);
            Controls.Add(panel1);
            Controls.Add(borderPanel2);
            Controls.Add(borderPanel3);
            Controls.Add(controlsPanel);
            Controls.Add(borderPanel1);
            Controls.Add(borderPanel4);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Spiral Core Network";
            controlsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel controlsPanel;
        private Button closeButton;
        private Button minimizeButton;
        private Button maximizeButton;
        private Label label1;
        private CustomControls.AnimatedPanel animatedPanel1;

        #region Custom Controls UI
        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
                this.Size = new Size(1280, 800);
                this.Location = new Point(100, 100);
                this.Tag = null;

                foreach (Control control in animatedPanel1.Controls)
                    if(control is UserControl)
                    {
                        control.Size = new Size(600, 400);
                        control.Location = new Point(20, 20);
                    }
            }
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

        private CustomControls.BorderPanel borderPanel1;

        #region Custom WinApi Calls
        protected override void WndProc(ref Message m)
        {
            const int RESIZE_HANDLE_SIZE = 10;
            const int WM_NCHITTEST = 0x84;
            //const int HTCLIENT = 1;
            const int HTLEFT = 10;
            const int HTRIGHT = 11;
            const int HTTOP = 12;
            const int HTTOPLEFT = 13;
            const int HTTOPRIGHT = 14;
            const int HTBOTTOM = 15;
            const int HTBOTTOMLEFT = 16;
            const int HTBOTTOMRIGHT = 17;

            if (m.Msg == WM_NCHITTEST)
            {
                base.WndProc(ref m);

                Point cursor = PointToClient(Cursor.Position);

                if (cursor.X <= RESIZE_HANDLE_SIZE && cursor.Y <= RESIZE_HANDLE_SIZE)
                    m.Result = (IntPtr)HTTOPLEFT;
                else if (cursor.X >= Width - RESIZE_HANDLE_SIZE && cursor.Y <= RESIZE_HANDLE_SIZE)
                    m.Result = (IntPtr)HTTOPRIGHT;
                else if (cursor.X <= RESIZE_HANDLE_SIZE && cursor.Y >= Height - RESIZE_HANDLE_SIZE)
                    m.Result = (IntPtr)HTBOTTOMLEFT;
                else if (cursor.X >= Width - RESIZE_HANDLE_SIZE && cursor.Y >= Height - RESIZE_HANDLE_SIZE)
                    m.Result = (IntPtr)HTBOTTOMRIGHT;
                else if (cursor.X <= RESIZE_HANDLE_SIZE)
                    m.Result = (IntPtr)HTLEFT;
                else if (cursor.X >= Width - RESIZE_HANDLE_SIZE)
                    m.Result = (IntPtr)HTRIGHT;
                else if (cursor.Y <= RESIZE_HANDLE_SIZE)
                    m.Result = (IntPtr)HTTOP;
                else if (cursor.Y >= Height - RESIZE_HANDLE_SIZE)
                    m.Result = (IntPtr)HTBOTTOM;

                return;
            }

            base.WndProc(ref m);
        }

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
            if((sender as Button).Text == "Plugins" && fileButton.Tag.ToString() == "open")
            {
                fileMenu.Dispose();
                fileButton.Tag = "closed";
            }
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
        private Panel panel1;
        private Button fileButton;
        private FileMenu fileMenu;

        private void Overlay_Click(object sender, EventArgs e)
        {
            if(fileMenu is not null)
            {
                this.Controls.Remove(fileMenu);
                fileMenu.Dispose();
                fileButton.Tag = "closed";
            }
        }

        private void fileButton_Click(object sender, EventArgs e)
        {
            if (fileButton.Tag!.ToString() == "closed")
            {
                fileMenu = new FileMenu(this);
                fileMenu.Location = new Point(fileButton.Location.X, fileButton.Location.Y + fileButton.Height + controlsPanel.Height);
                this.Controls.Add(fileMenu);
                fileMenu.Show();
                fileMenu.BringToFront();
                fileButton.Tag = "open";
                return;
            }

            if (fileButton.Tag!.ToString() == "open")
            {
                this.Controls.Remove(fileMenu);
                fileMenu.Dispose();
                fileButton.Tag = "closed";
                return;
            }
        }

        public void SetFilebuttonTag(string tag)
        {
            this.fileButton.Tag = tag;
        }

        private Button pluginsButton;
        private Label currentModelLabelValue;
    }
}
