using System.Diagnostics.Eventing.Reader;
using System.Reflection;

namespace NeuralNetworkNormalizerV2
{
    partial class NeuralNetworkNormalizerWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NeuralNetworkNormalizerWindow));
            controlsPanel = new Panel();
            titleLabel = new Label();
            closeButton = new Button();
            logoPictureBox = new PictureBox();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            resizeTimer = new System.Windows.Forms.Timer(components);
            batchFilesListBox = new ListBox();
            label1 = new Label();
            panel4 = new Panel();
            normalizeBtn = new Button();
            loadBatchButton = new Button();
            normalizeTypeBox = new ComboBox();
            progressBar1 = new ProgressBar();
            worker = new System.ComponentModel.BackgroundWorker();
            countLabel = new Label();
            controlsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            panel4.SuspendLayout();
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
            controlsPanel.Size = new Size(500, 40);
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
            titleLabel.Size = new Size(199, 40);
            titleLabel.TabIndex = 8;
            titleLabel.Text = "Neural Network Normalizer";
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
            closeButton.Location = new Point(460, 0);
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
            panel1.Size = new Size(5, 260);
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
            panel2.Location = new Point(5, 295);
            panel2.Name = "panel2";
            panel2.Size = new Size(490, 5);
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
            panel3.Location = new Point(495, 40);
            panel3.Name = "panel3";
            panel3.Size = new Size(5, 260);
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
            // batchFilesListBox
            // 
            batchFilesListBox.BackColor = Color.FromArgb(18, 30, 40);
            batchFilesListBox.Font = new Font("Segoe UI", 10F);
            batchFilesListBox.ForeColor = Color.White;
            batchFilesListBox.FormattingEnabled = true;
            batchFilesListBox.ItemHeight = 17;
            batchFilesListBox.Location = new Point(11, 80);
            batchFilesListBox.Name = "batchFilesListBox";
            batchFilesListBox.SelectionMode = SelectionMode.None;
            batchFilesListBox.Size = new Size(200, 208);
            batchFilesListBox.TabIndex = 10;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 52);
            label1.Name = "label1";
            label1.Size = new Size(241, 23);
            label1.TabIndex = 12;
            label1.Text = "Neural Network Normalizer";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            panel4.Controls.Add(normalizeBtn);
            panel4.Controls.Add(loadBatchButton);
            panel4.Controls.Add(normalizeTypeBox);
            panel4.Controls.Add(progressBar1);
            panel4.Controls.Add(label1);
            panel4.Dock = DockStyle.Right;
            panel4.Location = new Point(245, 40);
            panel4.Name = "panel4";
            panel4.Size = new Size(250, 255);
            panel4.TabIndex = 13;
            // 
            // normalizeBtn
            // 
            normalizeBtn.BackColor = Color.FromArgb(26, 26, 26);
            normalizeBtn.FlatAppearance.BorderColor = Color.DeepSkyBlue;
            normalizeBtn.FlatAppearance.MouseDownBackColor = Color.DeepSkyBlue;
            normalizeBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(22, 46, 56);
            normalizeBtn.FlatStyle = FlatStyle.Flat;
            normalizeBtn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            normalizeBtn.ForeColor = Color.White;
            normalizeBtn.Location = new Point(125, 166);
            normalizeBtn.Name = "normalizeBtn";
            normalizeBtn.Size = new Size(100, 30);
            normalizeBtn.TabIndex = 16;
            normalizeBtn.Text = "Normalize";
            normalizeBtn.UseVisualStyleBackColor = false;
            normalizeBtn.Click += normalizeBtn_Click;
            // 
            // loadBatchButton
            // 
            loadBatchButton.BackColor = Color.FromArgb(26, 26, 26);
            loadBatchButton.FlatAppearance.BorderColor = Color.DeepSkyBlue;
            loadBatchButton.FlatAppearance.MouseDownBackColor = Color.DeepSkyBlue;
            loadBatchButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(22, 46, 56);
            loadBatchButton.FlatStyle = FlatStyle.Flat;
            loadBatchButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            loadBatchButton.ForeColor = Color.White;
            loadBatchButton.Location = new Point(25, 166);
            loadBatchButton.Name = "loadBatchButton";
            loadBatchButton.Size = new Size(100, 30);
            loadBatchButton.TabIndex = 15;
            loadBatchButton.Text = "Load";
            loadBatchButton.UseVisualStyleBackColor = false;
            loadBatchButton.Click += loadBatchButton_Click;
            // 
            // normalizeTypeBox
            // 
            normalizeTypeBox.BackColor = Color.FromArgb(13, 27, 42);
            normalizeTypeBox.ForeColor = Color.White;
            normalizeTypeBox.FormattingEnabled = true;
            normalizeTypeBox.Items.AddRange(new object[] { "Min-Max Scaling" });
            normalizeTypeBox.Location = new Point(25, 137);
            normalizeTypeBox.Name = "normalizeTypeBox";
            normalizeTypeBox.Size = new Size(200, 23);
            normalizeTypeBox.TabIndex = 14;
            // 
            // progressBar1
            // 
            progressBar1.BackColor = SystemColors.Control;
            progressBar1.Location = new Point(25, 108);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(200, 23);
            progressBar1.TabIndex = 13;
            // 
            // worker
            // 
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            // 
            // countLabel
            // 
            countLabel.BorderStyle = BorderStyle.Fixed3D;
            countLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            countLabel.ForeColor = Color.White;
            countLabel.Location = new Point(11, 54);
            countLabel.Name = "countLabel";
            countLabel.Size = new Size(200, 23);
            countLabel.TabIndex = 14;
            countLabel.Text = "Count: 0";
            countLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // NeuralNetworkNormalizerWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 30, 40);
            Controls.Add(countLabel);
            Controls.Add(panel4);
            Controls.Add(batchFilesListBox);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(controlsPanel);
            DoubleBuffered = true;
            Name = "NeuralNetworkNormalizerWindow";
            Size = new Size(500, 300);
            controlsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            panel4.ResumeLayout(false);
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

        private ListBox batchFilesListBox;
        private Label label1;
        private Panel panel4;
        private ProgressBar progressBar1;
        private Button loadBatchButton;
        private ComboBox normalizeTypeBox;
        private Button normalizeBtn;
        private System.ComponentModel.BackgroundWorker worker;
        private Label countLabel;
    }
}
