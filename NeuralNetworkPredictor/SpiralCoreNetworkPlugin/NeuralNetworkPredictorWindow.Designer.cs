using System.Reflection;

namespace NeuralNetworkPredictor
{
    partial class NeuralNetworkPredictorWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NeuralNetworkPredictorWindow));
            controlsPanel = new Panel();
            titleLabel = new Label();
            closeButton = new Button();
            logoPictureBox = new PictureBox();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            resizeTimer = new System.Windows.Forms.Timer(components);
            loadDataBtn = new Button();
            startBtn = new Button();
            saveBtn = new Button();
            listBox1 = new ListBox();
            parserWorker = new System.ComponentModel.BackgroundWorker();
            worker = new System.ComponentModel.BackgroundWorker();
            loadCfgButton = new Button();
            controlsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
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
            controlsPanel.Margin = new Padding(3, 4, 3, 4);
            controlsPanel.Name = "controlsPanel";
            controlsPanel.Size = new Size(851, 53);
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
            titleLabel.Location = new Point(46, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(165, 53);
            titleLabel.TabIndex = 8;
            titleLabel.Text = "Predictor";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // closeButton
            // 
            closeButton.Dock = DockStyle.Right;
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.Font = new Font("Segoe UI", 10F);
            closeButton.ForeColor = Color.FromArgb(255, 76, 76);
            closeButton.Location = new Point(805, 0);
            closeButton.Margin = new Padding(3, 4, 3, 4);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(46, 53);
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
            logoPictureBox.Margin = new Padding(3, 4, 3, 4);
            logoPictureBox.Name = "logoPictureBox";
            logoPictureBox.Size = new Size(46, 53);
            logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            logoPictureBox.TabIndex = 11;
            logoPictureBox.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DeepSkyBlue;
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 53);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(6, 434);
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
            panel2.Location = new Point(6, 480);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(839, 7);
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
            panel3.Location = new Point(845, 53);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(6, 434);
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
            // loadDataBtn
            // 
            loadDataBtn.BackColor = Color.FromArgb(184, 140, 106);
            loadDataBtn.FlatStyle = FlatStyle.Flat;
            loadDataBtn.Font = new Font("Segoe UI", 12F);
            loadDataBtn.ForeColor = Color.White;
            loadDataBtn.Location = new Point(12, 105);
            loadDataBtn.Margin = new Padding(3, 4, 3, 4);
            loadDataBtn.Name = "loadDataBtn";
            loadDataBtn.Size = new Size(285, 53);
            loadDataBtn.TabIndex = 8;
            loadDataBtn.Text = "Load Data";
            loadDataBtn.UseVisualStyleBackColor = false;
            loadDataBtn.Click += loadDataBtn_Click;
            // 
            // startBtn
            // 
            startBtn.BackColor = Color.FromArgb(184, 140, 106);
            startBtn.FlatStyle = FlatStyle.Flat;
            startBtn.Font = new Font("Segoe UI", 12F);
            startBtn.ForeColor = Color.White;
            startBtn.Location = new Point(12, 224);
            startBtn.Margin = new Padding(3, 4, 3, 4);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(285, 53);
            startBtn.TabIndex = 10;
            startBtn.Text = "Predict";
            startBtn.UseVisualStyleBackColor = false;
            startBtn.Click += startBtn_Click;
            // 
            // saveBtn
            // 
            saveBtn.BackColor = Color.FromArgb(184, 140, 106);
            saveBtn.FlatStyle = FlatStyle.Flat;
            saveBtn.Font = new Font("Segoe UI", 12F);
            saveBtn.ForeColor = Color.White;
            saveBtn.Location = new Point(12, 376);
            saveBtn.Margin = new Padding(3, 4, 3, 4);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(285, 53);
            saveBtn.TabIndex = 11;
            saveBtn.Text = "Save Raport";
            saveBtn.UseVisualStyleBackColor = false;
            saveBtn.Click += saveBtn_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(341, 105);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(472, 324);
            listBox1.TabIndex = 12;
            // 
            // parserWorker
            // 
            parserWorker.WorkerReportsProgress = true;
            parserWorker.WorkerSupportsCancellation = true;
            parserWorker.DoWork += parserWorker_DoWork;
            parserWorker.RunWorkerCompleted += parserWorker_RunWorkerCompleted;
            // 
            // worker
            // 
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += worker_DoWork;
            // 
            // loadCfgButton
            // 
            loadCfgButton.BackColor = Color.FromArgb(184, 140, 106);
            loadCfgButton.FlatStyle = FlatStyle.Flat;
            loadCfgButton.Font = new Font("Segoe UI", 12F);
            loadCfgButton.ForeColor = Color.White;
            loadCfgButton.Location = new Point(12, 163);
            loadCfgButton.Margin = new Padding(3, 4, 3, 4);
            loadCfgButton.Name = "loadCfgButton";
            loadCfgButton.Size = new Size(285, 53);
            loadCfgButton.TabIndex = 13;
            loadCfgButton.Text = "Load CFG";
            loadCfgButton.UseVisualStyleBackColor = false;
            loadCfgButton.Click += loadCfgButton_Click;
            // 
            // NeuralNetworkPredictorWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(217, 221, 230);
            Controls.Add(loadCfgButton);
            Controls.Add(listBox1);
            Controls.Add(saveBtn);
            Controls.Add(startBtn);
            Controls.Add(loadDataBtn);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(controlsPanel);
            DoubleBuffered = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "NeuralNetworkPredictorWindow";
            Size = new Size(851, 487);
            controlsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
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

        private Button loadDataBtn;
        private Button startBtn;
        private Button saveBtn;
        private ListBox listBox1;
        private System.ComponentModel.BackgroundWorker parserWorker;
        private System.ComponentModel.BackgroundWorker worker;
        private Button loadCfgButton;
    }
}
