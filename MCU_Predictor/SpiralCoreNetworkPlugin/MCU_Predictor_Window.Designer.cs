using System.Diagnostics.Eventing.Reader;
using System.Reflection;

namespace MCU_Predictor
{
    partial class MCU_Predictor_Window
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MCU_Predictor_Window));
            controlsPanel = new Panel();
            titleLabel = new Label();
            closeButton = new Button();
            logoPictureBox = new PictureBox();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            resizeTimer = new System.Windows.Forms.Timer(components);
            userPanel = new Panel();
            ethFramesTextBox = new TextBox();
            ethFramesLabel = new Label();
            linFramesTextBox = new TextBox();
            linFramesLabel = new Label();
            canFramesTextBox = new TextBox();
            canFramesLabel = new Label();
            loadCfgBtn = new Button();
            predictBtn = new Button();
            ethBusTextBox = new TextBox();
            ethBusLabel = new Label();
            linBusTextBox = new TextBox();
            linBusLabel = new Label();
            canBusTextBox = new TextBox();
            canBusLabel = new Label();
            frequencyTextBox = new TextBox();
            frequencyLabel = new Label();
            ramTextBox = new TextBox();
            ramLabel = new Label();
            controlsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            userPanel.SuspendLayout();
            SuspendLayout();
            // 
            // controlsPanel
            // 
            controlsPanel.BackColor = Color.DeepSkyBlue;
            controlsPanel.Controls.Add(titleLabel);
            controlsPanel.Controls.Add(closeButton);
            controlsPanel.Controls.Add(logoPictureBox);
            controlsPanel.Dock = DockStyle.Top;
            controlsPanel.Location = new Point(0, 0);
            controlsPanel.Name = "controlsPanel";
            controlsPanel.Size = new Size(313, 40);
            controlsPanel.TabIndex = 6;
            controlsPanel.MouseDown += controlsPanel_MouseDown;
            controlsPanel.MouseMove += controlsPanel_MouseMove;
            controlsPanel.MouseUp += controlsPanel_MouseUp;
            // 
            // titleLabel
            // 
            titleLabel.Dock = DockStyle.Left;
            titleLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(40, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(144, 40);
            titleLabel.TabIndex = 8;
            titleLabel.Text = "MCU Predictor";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            titleLabel.MouseDown += controlsPanel_MouseDown;
            titleLabel.MouseMove += controlsPanel_MouseMove;
            titleLabel.MouseUp += controlsPanel_MouseUp;
            // 
            // closeButton
            // 
            closeButton.Dock = DockStyle.Right;
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.Font = new Font("Segoe UI", 10F);
            closeButton.ForeColor = Color.FromArgb(255, 76, 76);
            closeButton.Location = new Point(273, 0);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(40, 40);
            closeButton.TabIndex = 6;
            closeButton.Text = "✖";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // logoPictureBox
            // 
            logoPictureBox.Dock = DockStyle.Left;
            logoPictureBox.Image = (Image)resources.GetObject("logoPictureBox.Image");
            logoPictureBox.Location = new Point(0, 0);
            logoPictureBox.Name = "logoPictureBox";
            logoPictureBox.Size = new Size(40, 40);
            logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            logoPictureBox.TabIndex = 11;
            logoPictureBox.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DeepSkyBlue;
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 40);
            panel1.Name = "panel1";
            panel1.Size = new Size(5, 441);
            panel1.TabIndex = 7;
            panel1.Tag = "left";
            panel1.MouseDown += Border_MouseDown;
            panel1.MouseLeave += Border_MouseLeave;
            panel1.MouseMove += Border_MouseMove;
            panel1.MouseUp += Border_MouseUp;
            // 
            // panel2
            // 
            panel2.BackColor = Color.DeepSkyBlue;
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(5, 476);
            panel2.Name = "panel2";
            panel2.Size = new Size(303, 5);
            panel2.TabIndex = 8;
            panel2.Tag = "bottom";
            panel2.MouseDown += Border_MouseDown;
            panel2.MouseLeave += Border_MouseLeave;
            panel2.MouseMove += Border_MouseMove;
            panel2.MouseUp += Border_MouseUp;
            // 
            // panel3
            // 
            panel3.BackColor = Color.DeepSkyBlue;
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(308, 40);
            panel3.Name = "panel3";
            panel3.Size = new Size(5, 441);
            panel3.TabIndex = 9;
            panel3.Tag = "right";
            panel3.MouseDown += Border_MouseDown;
            panel3.MouseLeave += Border_MouseLeave;
            panel3.MouseMove += Border_MouseMove;
            panel3.MouseUp += Border_MouseUp;
            // 
            // resizeTimer
            // 
            resizeTimer.Enabled = true;
            resizeTimer.Interval = 15;
            resizeTimer.Tick += ResizeTimer_Tick;
            // 
            // userPanel
            // 
            userPanel.BackColor = Color.FromArgb(217, 221, 230);
            userPanel.Controls.Add(ramTextBox);
            userPanel.Controls.Add(ramLabel);
            userPanel.Controls.Add(frequencyTextBox);
            userPanel.Controls.Add(frequencyLabel);
            userPanel.Controls.Add(ethFramesTextBox);
            userPanel.Controls.Add(ethFramesLabel);
            userPanel.Controls.Add(linFramesTextBox);
            userPanel.Controls.Add(linFramesLabel);
            userPanel.Controls.Add(canFramesTextBox);
            userPanel.Controls.Add(canFramesLabel);
            userPanel.Controls.Add(loadCfgBtn);
            userPanel.Controls.Add(predictBtn);
            userPanel.Controls.Add(ethBusTextBox);
            userPanel.Controls.Add(ethBusLabel);
            userPanel.Controls.Add(linBusTextBox);
            userPanel.Controls.Add(linBusLabel);
            userPanel.Controls.Add(canBusTextBox);
            userPanel.Controls.Add(canBusLabel);
            userPanel.Dock = DockStyle.Fill;
            userPanel.Location = new Point(5, 40);
            userPanel.Name = "userPanel";
            userPanel.Size = new Size(303, 436);
            userPanel.TabIndex = 10;
            // 
            // ethFramesTextBox
            // 
            ethFramesTextBox.BackColor = Color.White;
            ethFramesTextBox.Font = new Font("Segoe UI", 10F);
            ethFramesTextBox.Location = new Point(132, 234);
            ethFramesTextBox.Name = "ethFramesTextBox";
            ethFramesTextBox.Size = new Size(150, 25);
            ethFramesTextBox.TabIndex = 6;
            ethFramesTextBox.Tag = "ETH_FRAMES";
            ethFramesTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // ethFramesLabel
            // 
            ethFramesLabel.AutoSize = true;
            ethFramesLabel.Font = new Font("Segoe UI", 10F);
            ethFramesLabel.ForeColor = Color.FromArgb(112, 79, 56);
            ethFramesLabel.Location = new Point(20, 234);
            ethFramesLabel.Name = "ethFramesLabel";
            ethFramesLabel.Size = new Size(77, 19);
            ethFramesLabel.TabIndex = 14;
            ethFramesLabel.Text = "Eth Frames";
            ethFramesLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // linFramesTextBox
            // 
            linFramesTextBox.BackColor = Color.White;
            linFramesTextBox.Font = new Font("Segoe UI", 10F);
            linFramesTextBox.Location = new Point(131, 194);
            linFramesTextBox.Name = "linFramesTextBox";
            linFramesTextBox.Size = new Size(150, 25);
            linFramesTextBox.TabIndex = 5;
            linFramesTextBox.Tag = "LIN_FRAMES";
            linFramesTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // linFramesLabel
            // 
            linFramesLabel.AutoSize = true;
            linFramesLabel.Font = new Font("Segoe UI", 10F);
            linFramesLabel.ForeColor = Color.FromArgb(112, 79, 56);
            linFramesLabel.Location = new Point(19, 194);
            linFramesLabel.Name = "linFramesLabel";
            linFramesLabel.Size = new Size(75, 19);
            linFramesLabel.TabIndex = 12;
            linFramesLabel.Text = "Lin Frames";
            linFramesLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // canFramesTextBox
            // 
            canFramesTextBox.BackColor = Color.White;
            canFramesTextBox.Font = new Font("Segoe UI", 10F);
            canFramesTextBox.Location = new Point(131, 154);
            canFramesTextBox.Name = "canFramesTextBox";
            canFramesTextBox.Size = new Size(150, 25);
            canFramesTextBox.TabIndex = 4;
            canFramesTextBox.Tag = "CAN_FRAMES";
            canFramesTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // canFramesLabel
            // 
            canFramesLabel.AutoSize = true;
            canFramesLabel.Font = new Font("Segoe UI", 10F);
            canFramesLabel.ForeColor = Color.FromArgb(112, 79, 56);
            canFramesLabel.Location = new Point(19, 154);
            canFramesLabel.Name = "canFramesLabel";
            canFramesLabel.Size = new Size(81, 19);
            canFramesLabel.TabIndex = 10;
            canFramesLabel.Text = "Can Frames";
            canFramesLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // loadCfgBtn
            // 
            loadCfgBtn.BackColor = Color.FromArgb(184, 140, 106);
            loadCfgBtn.FlatStyle = FlatStyle.Flat;
            loadCfgBtn.Font = new Font("Segoe UI", 12F);
            loadCfgBtn.ForeColor = Color.White;
            loadCfgBtn.Location = new Point(156, 363);
            loadCfgBtn.Name = "loadCfgBtn";
            loadCfgBtn.Size = new Size(125, 40);
            loadCfgBtn.TabIndex = 9;
            loadCfgBtn.Text = "Load CFG";
            loadCfgBtn.UseVisualStyleBackColor = false;
            loadCfgBtn.Click += loadCfgBtn_Click;
            // 
            // predictBtn
            // 
            predictBtn.BackColor = Color.FromArgb(184, 140, 106);
            predictBtn.FlatStyle = FlatStyle.Flat;
            predictBtn.Font = new Font("Segoe UI", 12F);
            predictBtn.ForeColor = Color.White;
            predictBtn.Location = new Point(20, 363);
            predictBtn.Name = "predictBtn";
            predictBtn.Size = new Size(125, 40);
            predictBtn.TabIndex = 8;
            predictBtn.Text = "Predict";
            predictBtn.UseVisualStyleBackColor = false;
            predictBtn.Click += predictBtn_Click;
            // 
            // ethBusTextBox
            // 
            ethBusTextBox.BackColor = Color.White;
            ethBusTextBox.Font = new Font("Segoe UI", 10F);
            ethBusTextBox.Location = new Point(131, 114);
            ethBusTextBox.Name = "ethBusTextBox";
            ethBusTextBox.Size = new Size(150, 25);
            ethBusTextBox.TabIndex = 3;
            ethBusTextBox.Tag = "ETH";
            ethBusTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // ethBusLabel
            // 
            ethBusLabel.AutoSize = true;
            ethBusLabel.Font = new Font("Segoe UI", 10F);
            ethBusLabel.ForeColor = Color.FromArgb(112, 79, 56);
            ethBusLabel.Location = new Point(20, 114);
            ethBusLabel.Name = "ethBusLabel";
            ethBusLabel.Size = new Size(101, 19);
            ethBusLabel.TabIndex = 4;
            ethBusLabel.Text = "Magistrale ETH";
            ethBusLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // linBusTextBox
            // 
            linBusTextBox.BackColor = Color.White;
            linBusTextBox.Font = new Font("Segoe UI", 10F);
            linBusTextBox.Location = new Point(131, 74);
            linBusTextBox.Name = "linBusTextBox";
            linBusTextBox.Size = new Size(150, 25);
            linBusTextBox.TabIndex = 2;
            linBusTextBox.Tag = "LIN";
            linBusTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // linBusLabel
            // 
            linBusLabel.AutoSize = true;
            linBusLabel.Font = new Font("Segoe UI", 10F);
            linBusLabel.ForeColor = Color.FromArgb(112, 79, 56);
            linBusLabel.Location = new Point(20, 76);
            linBusLabel.Name = "linBusLabel";
            linBusLabel.Size = new Size(98, 19);
            linBusLabel.TabIndex = 2;
            linBusLabel.Text = "Magistrale LIN";
            linBusLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // canBusTextBox
            // 
            canBusTextBox.BackColor = Color.White;
            canBusTextBox.Font = new Font("Segoe UI", 10F);
            canBusTextBox.Location = new Point(131, 34);
            canBusTextBox.Name = "canBusTextBox";
            canBusTextBox.Size = new Size(150, 25);
            canBusTextBox.TabIndex = 1;
            canBusTextBox.Tag = "CAN";
            canBusTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // canBusLabel
            // 
            canBusLabel.AutoSize = true;
            canBusLabel.Font = new Font("Segoe UI", 10F);
            canBusLabel.ForeColor = Color.FromArgb(112, 79, 56);
            canBusLabel.Location = new Point(20, 36);
            canBusLabel.Name = "canBusLabel";
            canBusLabel.Size = new Size(105, 19);
            canBusLabel.TabIndex = 0;
            canBusLabel.Text = "Magistrale CAN";
            canBusLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frequencyTextBox
            // 
            frequencyTextBox.BackColor = Color.White;
            frequencyTextBox.Font = new Font("Segoe UI", 10F);
            frequencyTextBox.Location = new Point(132, 274);
            frequencyTextBox.Name = "frequencyTextBox";
            frequencyTextBox.Size = new Size(150, 25);
            frequencyTextBox.TabIndex = 7;
            frequencyTextBox.Tag = "FREQ";
            frequencyTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // frequencyLabel
            // 
            frequencyLabel.AutoSize = true;
            frequencyLabel.Font = new Font("Segoe UI", 10F);
            frequencyLabel.ForeColor = Color.FromArgb(112, 79, 56);
            frequencyLabel.Location = new Point(20, 274);
            frequencyLabel.Name = "frequencyLabel";
            frequencyLabel.Size = new Size(68, 19);
            frequencyLabel.TabIndex = 16;
            frequencyLabel.Text = "Frecventa";
            frequencyLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ramTextBox
            // 
            ramTextBox.BackColor = Color.White;
            ramTextBox.Font = new Font("Segoe UI", 10F);
            ramTextBox.Location = new Point(131, 314);
            ramTextBox.Name = "ramTextBox";
            ramTextBox.Size = new Size(150, 25);
            ramTextBox.TabIndex = 8;
            ramTextBox.Tag = "RAM";
            ramTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // ramLabel
            // 
            ramLabel.AutoSize = true;
            ramLabel.Font = new Font("Segoe UI", 10F);
            ramLabel.ForeColor = Color.FromArgb(112, 79, 56);
            ramLabel.Location = new Point(19, 314);
            ramLabel.Name = "ramLabel";
            ramLabel.Size = new Size(39, 19);
            ramLabel.TabIndex = 18;
            ramLabel.Text = "RAM";
            ramLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MCU_Predictor_Window
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 30, 40);
            Controls.Add(userPanel);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(controlsPanel);
            DoubleBuffered = true;
            Name = "MCU_Predictor_Window";
            Size = new Size(313, 481);
            controlsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            userPanel.ResumeLayout(false);
            userPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel controlsPanel;
        private Label titleLabel;
        private Button closeButton;
        private PictureBox logoPictureBox;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;

        #region Custom Mechanics
        private bool dragging = false;
        private bool resizing = false;
        private Point dragCursorPoint;
        private Point dragControlPoint;
        private Size resizeStartSize;
        private Point resizeStartCursor;
        private System.Windows.Forms.Timer resizeTimer;
        private bool resizePending = false;
        private Size pendingResizeSize;
        private Point resizeStartLocation;

        private void controlsPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragControlPoint = this.Location;
            }
        }

        private void controlsPanel_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void controlsPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                Point newLocation = Point.Add(dragControlPoint, new Size(dif));

                if (this.Parent != null)
                {
                    int maxY = (this.Parent.ClientSize.Height - this.Height) + (int)Math.Floor(0.9 * this.Height);
                    newLocation.Y = Math.Max(0, Math.Min(newLocation.Y, maxY));
                }

                this.Location = newLocation;
            }
        }
        private void ResizeTimer_Tick(object sender, EventArgs e)
        {

            if (resizePending)
            {
                if (this.Size != pendingResizeSize)
                {
                    this.SuspendLayout();
                    this.Size = pendingResizeSize;
                    this.ResumeLayout();
                }
                resizePending = false;
            }
        }

        private void SetDoubleBuffered(Control c)
        {
            typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.SetValue(c, true, null);
        }

        private void Border_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
            var border = sender as Panel;
            if (border.Tag.ToString() == "bottom")
                this.Cursor = Cursors.SizeNS;
            else
                this.Cursor = Cursors.SizeWE;

            if (resizing)
            {
                var diff = new Point(Cursor.Position.X - resizeStartCursor.X, Cursor.Position.Y - resizeStartCursor.Y);
                if (border.Tag.ToString() == "left")
                {
                    Point cursorInParent = this.Parent.PointToClient(Cursor.Position);
                    int diffX = resizeStartLocation.X - cursorInParent.X;
                    pendingResizeSize = new Size(
                        resizeStartSize.Width + diffX,
                        resizeStartSize.Height);
                    this.Left = resizeStartLocation.X - diffX;
                }
                if (border.Tag.ToString() == "right")
                {
                    pendingResizeSize = new Size(
                        Math.Max(this.MinimumSize.Width, resizeStartSize.Width + diff.X),
                        Math.Max(this.MinimumSize.Height, resizeStartSize.Height));
                }
                if (border.Tag.ToString() == "bottom")
                {
                    pendingResizeSize = new Size(
                        Math.Max(this.MinimumSize.Width, resizeStartSize.Width),
                        Math.Max(this.MinimumSize.Height, resizeStartSize.Height + diff.Y));
                }
                resizePending = true;
            }
        }

        private void Border_MouseUp(object sender, MouseEventArgs e)
        {
            resizing = false;
        }

        private void Border_MouseDown(object sender, MouseEventArgs e)
        {
            resizing = true;
            resizeStartCursor = Cursor.Position;
            resizeStartSize = this.Size;
            resizeStartLocation = this.Location;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
        }

        #endregion

        private Panel userPanel;
        private TextBox canBusTextBox;
        private Label canBusLabel;
        private TextBox ethBusTextBox;
        private Label ethBusLabel;
        private TextBox linBusTextBox;
        private Label linBusLabel;
        private Button predictBtn;
        private Button loadCfgBtn;
        private TextBox ethFramesTextBox;
        private Label ethFramesLabel;
        private TextBox linFramesTextBox;
        private Label linFramesLabel;
        private TextBox canFramesTextBox;
        private Label canFramesLabel;
        private TextBox frequencyTextBox;
        private Label frequencyLabel;
        private TextBox ramTextBox;
        private Label ramLabel;
    }
}
