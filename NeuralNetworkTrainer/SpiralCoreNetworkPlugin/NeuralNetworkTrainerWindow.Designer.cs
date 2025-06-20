using System.Diagnostics.Eventing.Reader;
using System.Reflection;

namespace NeuralNetworkTrainer
{
    partial class NeuralNetworkTrainerWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NeuralNetworkTrainerWindow));
            controlsPanel = new Panel();
            titleLabel = new Label();
            closeButton = new Button();
            logoPictureBox = new PictureBox();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            resizeTimer = new System.Windows.Forms.Timer(components);
            dataTextBox = new TextBox();
            panel4 = new Panel();
            iterationsTextBox = new TextBox();
            iterationsLabel = new Label();
            learningRateLabel = new Label();
            learningRateTextBox = new TextBox();
            processTypeComboBox = new ComboBox();
            startTrainingBtn = new Button();
            loadBatchButton = new Button();
            epochsTextBox = new TextBox();
            epochsLabel = new Label();
            importDataLabel = new Label();
            panel5 = new Panel();
            currentMiniBatchLabel = new Label();
            customProgressBar1 = new CustomProgressBar();
            abortProcessButton = new Button();
            label1 = new Label();
            panel6 = new Panel();
            errorValueLabel = new Label();
            errorTextLabel = new Label();
            trainerWorker = new System.ComponentModel.BackgroundWorker();
            parserWorker = new System.ComponentModel.BackgroundWorker();
            userPanel = new Panel();
            iterationsValueLabel = new Label();
            controlsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
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
            controlsPanel.Size = new Size(600, 40);
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
            titleLabel.Size = new Size(155, 40);
            titleLabel.TabIndex = 8;
            titleLabel.Text = "Neural Network Trainer";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // closeButton
            // 
            closeButton.Dock = DockStyle.Right;
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.Font = new Font("Segoe UI", 10F);
            closeButton.ForeColor = Color.FromArgb(255, 76, 76);
            closeButton.Location = new Point(560, 0);
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
            panel1.Size = new Size(5, 460);
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
            panel2.Location = new Point(5, 495);
            panel2.Name = "panel2";
            panel2.Size = new Size(590, 5);
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
            panel3.Location = new Point(595, 40);
            panel3.Name = "panel3";
            panel3.Size = new Size(5, 460);
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
            // dataTextBox
            // 
            dataTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataTextBox.BackColor = Color.FromArgb(13, 27, 42);
            dataTextBox.Font = new Font("Segoe UI", 10F);
            dataTextBox.ForeColor = Color.White;
            dataTextBox.Location = new Point(22, 78);
            dataTextBox.Margin = new Padding(3, 2, 3, 2);
            dataTextBox.Name = "dataTextBox";
            dataTextBox.Size = new Size(167, 25);
            dataTextBox.TabIndex = 10;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.None;
            panel4.BackColor = Color.FromArgb(32, 32, 32);
            panel4.BorderStyle = BorderStyle.Fixed3D;
            panel4.Controls.Add(iterationsTextBox);
            panel4.Controls.Add(iterationsLabel);
            panel4.Controls.Add(learningRateLabel);
            panel4.Controls.Add(learningRateTextBox);
            panel4.Controls.Add(processTypeComboBox);
            panel4.Controls.Add(startTrainingBtn);
            panel4.Controls.Add(loadBatchButton);
            panel4.Controls.Add(epochsTextBox);
            panel4.Controls.Add(epochsLabel);
            panel4.Controls.Add(dataTextBox);
            panel4.Controls.Add(importDataLabel);
            panel4.Location = new Point(366, 49);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(214, 358);
            panel4.TabIndex = 12;
            // 
            // iterationsTextBox
            // 
            iterationsTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            iterationsTextBox.BackColor = Color.FromArgb(13, 27, 42);
            iterationsTextBox.ForeColor = Color.White;
            iterationsTextBox.Location = new Point(22, 209);
            iterationsTextBox.Margin = new Padding(3, 2, 3, 2);
            iterationsTextBox.Name = "iterationsTextBox";
            iterationsTextBox.Size = new Size(167, 23);
            iterationsTextBox.TabIndex = 20;
            iterationsTextBox.Text = "10";
            iterationsTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // iterationsLabel
            // 
            iterationsLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            iterationsLabel.Font = new Font("Segoe UI", 10F);
            iterationsLabel.ForeColor = Color.White;
            iterationsLabel.Location = new Point(23, 188);
            iterationsLabel.Name = "iterationsLabel";
            iterationsLabel.Size = new Size(166, 19);
            iterationsLabel.TabIndex = 19;
            iterationsLabel.Text = "Iterations";
            iterationsLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // learningRateLabel
            // 
            learningRateLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            learningRateLabel.Font = new Font("Segoe UI", 10F);
            learningRateLabel.ForeColor = Color.White;
            learningRateLabel.Location = new Point(22, 239);
            learningRateLabel.Name = "learningRateLabel";
            learningRateLabel.Size = new Size(166, 19);
            learningRateLabel.TabIndex = 18;
            learningRateLabel.Text = "Learning Rate";
            learningRateLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // learningRateTextBox
            // 
            learningRateTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            learningRateTextBox.BackColor = Color.FromArgb(13, 27, 42);
            learningRateTextBox.ForeColor = Color.White;
            learningRateTextBox.Location = new Point(21, 260);
            learningRateTextBox.Margin = new Padding(3, 2, 3, 2);
            learningRateTextBox.Name = "learningRateTextBox";
            learningRateTextBox.Size = new Size(167, 23);
            learningRateTextBox.TabIndex = 17;
            learningRateTextBox.Text = "0.1";
            learningRateTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // processTypeComboBox
            // 
            processTypeComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            processTypeComboBox.BackColor = Color.FromArgb(13, 27, 42);
            processTypeComboBox.ForeColor = Color.White;
            processTypeComboBox.FormattingEnabled = true;
            processTypeComboBox.Items.AddRange(new object[] { "CPU", "GPU" });
            processTypeComboBox.Location = new Point(21, 287);
            processTypeComboBox.Margin = new Padding(3, 2, 3, 2);
            processTypeComboBox.Name = "processTypeComboBox";
            processTypeComboBox.Size = new Size(167, 23);
            processTypeComboBox.TabIndex = 16;
            processTypeComboBox.Text = "Select Process Type";
            // 
            // startTrainingBtn
            // 
            startTrainingBtn.Anchor = AnchorStyles.Top;
            startTrainingBtn.BackColor = Color.FromArgb(26, 26, 26);
            startTrainingBtn.FlatAppearance.BorderColor = Color.DeepSkyBlue;
            startTrainingBtn.FlatAppearance.MouseDownBackColor = Color.DeepSkyBlue;
            startTrainingBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(22, 46, 56);
            startTrainingBtn.FlatStyle = FlatStyle.Flat;
            startTrainingBtn.ForeColor = Color.White;
            startTrainingBtn.Location = new Point(63, 319);
            startTrainingBtn.Name = "startTrainingBtn";
            startTrainingBtn.Size = new Size(88, 25);
            startTrainingBtn.TabIndex = 15;
            startTrainingBtn.Text = "Start Training";
            startTrainingBtn.UseVisualStyleBackColor = false;
            startTrainingBtn.Click += startTrainingBtn_Click;
            // 
            // loadBatchButton
            // 
            loadBatchButton.Anchor = AnchorStyles.Top;
            loadBatchButton.BackColor = Color.FromArgb(26, 26, 26);
            loadBatchButton.FlatAppearance.BorderColor = Color.DeepSkyBlue;
            loadBatchButton.FlatAppearance.MouseDownBackColor = Color.DeepSkyBlue;
            loadBatchButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(22, 46, 56);
            loadBatchButton.FlatStyle = FlatStyle.Flat;
            loadBatchButton.ForeColor = Color.White;
            loadBatchButton.Location = new Point(63, 106);
            loadBatchButton.Name = "loadBatchButton";
            loadBatchButton.Size = new Size(88, 25);
            loadBatchButton.TabIndex = 14;
            loadBatchButton.Text = "Load";
            loadBatchButton.UseVisualStyleBackColor = false;
            loadBatchButton.Click += loadBatchButton_Click;
            // 
            // epochsTextBox
            // 
            epochsTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            epochsTextBox.BackColor = Color.FromArgb(13, 27, 42);
            epochsTextBox.ForeColor = Color.White;
            epochsTextBox.Location = new Point(21, 161);
            epochsTextBox.Margin = new Padding(3, 2, 3, 2);
            epochsTextBox.Name = "epochsTextBox";
            epochsTextBox.Size = new Size(167, 23);
            epochsTextBox.TabIndex = 13;
            epochsTextBox.Text = "10000";
            epochsTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // epochsLabel
            // 
            epochsLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            epochsLabel.Font = new Font("Segoe UI", 10F);
            epochsLabel.ForeColor = Color.White;
            epochsLabel.Location = new Point(22, 140);
            epochsLabel.Name = "epochsLabel";
            epochsLabel.Size = new Size(166, 19);
            epochsLabel.TabIndex = 12;
            epochsLabel.Text = "Epochs";
            epochsLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // importDataLabel
            // 
            importDataLabel.BorderStyle = BorderStyle.Fixed3D;
            importDataLabel.Dock = DockStyle.Top;
            importDataLabel.Font = new Font("Segoe UI", 10F);
            importDataLabel.ForeColor = Color.White;
            importDataLabel.Location = new Point(0, 0);
            importDataLabel.Name = "importDataLabel";
            importDataLabel.Size = new Size(210, 46);
            importDataLabel.TabIndex = 0;
            importDataLabel.Text = "Import Data";
            importDataLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.None;
            panel5.BorderStyle = BorderStyle.Fixed3D;
            panel5.Controls.Add(iterationsValueLabel);
            panel5.Controls.Add(currentMiniBatchLabel);
            panel5.Controls.Add(customProgressBar1);
            panel5.Controls.Add(abortProcessButton);
            panel5.Controls.Add(label1);
            panel5.Controls.Add(panel6);
            panel5.Location = new Point(10, 49);
            panel5.Margin = new Padding(3, 2, 3, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(350, 358);
            panel5.TabIndex = 13;
            // 
            // currentMiniBatchLabel
            // 
            currentMiniBatchLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            currentMiniBatchLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            currentMiniBatchLabel.ForeColor = Color.White;
            currentMiniBatchLabel.Location = new Point(23, 143);
            currentMiniBatchLabel.Name = "currentMiniBatchLabel";
            currentMiniBatchLabel.Size = new Size(305, 52);
            currentMiniBatchLabel.TabIndex = 17;
            currentMiniBatchLabel.Text = "Current mini-batch:";
            currentMiniBatchLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // customProgressBar1
            // 
            customProgressBar1.Location = new Point(22, 197);
            customProgressBar1.Margin = new Padding(3, 2, 3, 2);
            customProgressBar1.Maximum = 250;
            customProgressBar1.Name = "customProgressBar1";
            customProgressBar1.Size = new Size(306, 38);
            customProgressBar1.TabIndex = 16;
            // 
            // abortProcessButton
            // 
            abortProcessButton.BackColor = Color.FromArgb(26, 26, 26);
            abortProcessButton.FlatAppearance.BorderColor = Color.DeepSkyBlue;
            abortProcessButton.FlatAppearance.MouseDownBackColor = Color.DeepSkyBlue;
            abortProcessButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(22, 46, 56);
            abortProcessButton.FlatStyle = FlatStyle.Flat;
            abortProcessButton.ForeColor = Color.White;
            abortProcessButton.Location = new Point(66, 279);
            abortProcessButton.Name = "abortProcessButton";
            abortProcessButton.Size = new Size(219, 38);
            abortProcessButton.TabIndex = 15;
            abortProcessButton.Text = "Abort Process";
            abortProcessButton.UseVisualStyleBackColor = false;
            abortProcessButton.Click += AbortProcessOnClickEvent;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(0, 46);
            label1.Name = "label1";
            label1.Size = new Size(346, 85);
            label1.TabIndex = 0;
            label1.Text = "Training";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            panel6.BorderStyle = BorderStyle.Fixed3D;
            panel6.Controls.Add(errorValueLabel);
            panel6.Controls.Add(errorTextLabel);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Margin = new Padding(3, 2, 3, 2);
            panel6.Name = "panel6";
            panel6.Size = new Size(346, 46);
            panel6.TabIndex = 14;
            // 
            // errorValueLabel
            // 
            errorValueLabel.BackColor = Color.DeepSkyBlue;
            errorValueLabel.Dock = DockStyle.Fill;
            errorValueLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            errorValueLabel.ForeColor = Color.White;
            errorValueLabel.Location = new Point(110, 0);
            errorValueLabel.Name = "errorValueLabel";
            errorValueLabel.Size = new Size(232, 42);
            errorValueLabel.TabIndex = 1;
            errorValueLabel.Text = "0.0000000000000000";
            errorValueLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // errorTextLabel
            // 
            errorTextLabel.BackColor = Color.DarkRed;
            errorTextLabel.Dock = DockStyle.Left;
            errorTextLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            errorTextLabel.ForeColor = Color.White;
            errorTextLabel.Location = new Point(0, 0);
            errorTextLabel.Name = "errorTextLabel";
            errorTextLabel.Size = new Size(110, 42);
            errorTextLabel.TabIndex = 0;
            errorTextLabel.Text = "Error";
            errorTextLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // trainerWorker
            // 
            trainerWorker.WorkerReportsProgress = true;
            trainerWorker.WorkerSupportsCancellation = true;
            trainerWorker.DoWork += worker_DoWork;
            trainerWorker.ProgressChanged += worker_ProgressChanged;
            trainerWorker.RunWorkerCompleted += worker_RunWorkerCompleted;
            // 
            // parserWorker
            // 
            parserWorker.WorkerReportsProgress = true;
            parserWorker.WorkerSupportsCancellation = true;
            parserWorker.DoWork += parserWorker_DoWork;
            parserWorker.ProgressChanged += parserWorker_ProgressChanged;
            parserWorker.RunWorkerCompleted += parserWorker_RunWorkerCompleted;
            // 
            // userPanel
            // 
            userPanel.Controls.Add(panel4);
            userPanel.Controls.Add(panel5);
            userPanel.Dock = DockStyle.Fill;
            userPanel.Location = new Point(5, 40);
            userPanel.Name = "userPanel";
            userPanel.Size = new Size(590, 455);
            userPanel.TabIndex = 14;
            // 
            // iterationsValueLabel
            // 
            iterationsValueLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            iterationsValueLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            iterationsValueLabel.ForeColor = Color.White;
            iterationsValueLabel.Location = new Point(23, 244);
            iterationsValueLabel.Name = "iterationsValueLabel";
            iterationsValueLabel.Size = new Size(305, 19);
            iterationsValueLabel.TabIndex = 18;
            iterationsValueLabel.Text = "Iteration 0";
            iterationsValueLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // NeuralNetworkTrainerWindow
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
            Name = "NeuralNetworkTrainerWindow";
            Size = new Size(600, 500);
            controlsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            userPanel.ResumeLayout(false);
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

        private TextBox dataTextBox;
        private Panel panel4;
        private Label importDataLabel;
        private Label epochsLabel;
        private TextBox epochsTextBox;
        private Button loadBatchButton;
        private Panel panel5;
        private Button startTrainingBtn;
        private Label label1;
        private Button abortProcessButton;
        private ComboBox processTypeComboBox;
        private CustomProgressBar customProgressBar1;
        private System.ComponentModel.BackgroundWorker trainerWorker;
        private Panel panel6;
        private Label errorValueLabel;
        private Label errorTextLabel;
        private System.ComponentModel.BackgroundWorker parserWorker;
        private Label learningRateLabel;
        private TextBox learningRateTextBox;
        private Panel userPanel;
        private Label currentMiniBatchLabel;
        private TextBox iterationsTextBox;
        private Label iterationsLabel;
        private Label iterationsValueLabel;
    }
}
