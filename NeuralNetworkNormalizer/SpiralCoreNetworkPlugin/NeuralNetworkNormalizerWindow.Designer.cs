using System.Diagnostics.Eventing.Reader;
using System.Reflection;

namespace SpiralCoreNetworkPlugin
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
            batchPathTextBox = new TextBox();
            loadBatchButton = new Button();
            normalizeTypeBox = new ComboBox();
            normalizeButton = new Button();
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
            controlsPanel.Name = "controlsPanel";
            controlsPanel.Size = new Size(250, 40);
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
            titleLabel.Size = new Size(163, 40);
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
            closeButton.Location = new Point(210, 0);
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
            panel1.Size = new Size(5, 206);
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
            panel2.Location = new Point(5, 241);
            panel2.Name = "panel2";
            panel2.Size = new Size(240, 5);
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
            panel3.Location = new Point(245, 40);
            panel3.Name = "panel3";
            panel3.Size = new Size(5, 206);
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
            // batchPathTextBox
            // 
            batchPathTextBox.BackColor = Color.FromArgb(13, 27, 42);
            batchPathTextBox.BorderStyle = BorderStyle.FixedSingle;
            batchPathTextBox.ForeColor = Color.FromArgb(224, 224, 224);
            batchPathTextBox.Location = new Point(25, 67);
            batchPathTextBox.Name = "batchPathTextBox";
            batchPathTextBox.ReadOnly = true;
            batchPathTextBox.Size = new Size(200, 23);
            batchPathTextBox.TabIndex = 3;
            // 
            // loadBatchButton
            // 
            loadBatchButton.BackColor = Color.FromArgb(26, 26, 26);
            loadBatchButton.FlatAppearance.BorderColor = Color.DeepSkyBlue;
            loadBatchButton.FlatAppearance.MouseDownBackColor = Color.DeepSkyBlue;
            loadBatchButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(22, 46, 56);
            loadBatchButton.FlatStyle = FlatStyle.Flat;
            loadBatchButton.ForeColor = Color.White;
            loadBatchButton.Location = new Point(25, 125);
            loadBatchButton.Name = "loadBatchButton";
            loadBatchButton.Size = new Size(200, 25);
            loadBatchButton.TabIndex = 12;
            loadBatchButton.Text = "Load batch";
            loadBatchButton.UseVisualStyleBackColor = false;
            loadBatchButton.Click += loadBatchButton_Click;
            // 
            // normalizeTypeBox
            // 
            normalizeTypeBox.BackColor = Color.FromArgb(13, 27, 42);
            normalizeTypeBox.ForeColor = Color.White;
            normalizeTypeBox.FormattingEnabled = true;
            normalizeTypeBox.Items.AddRange(new object[] { "Min-Max Scaling", "Min-Max Scaling with logaritmic output" });
            normalizeTypeBox.Location = new Point(25, 96);
            normalizeTypeBox.Name = "normalizeTypeBox";
            normalizeTypeBox.Size = new Size(200, 23);
            normalizeTypeBox.TabIndex = 13;
            // 
            // normalizeButton
            // 
            normalizeButton.BackColor = Color.FromArgb(26, 26, 26);
            normalizeButton.FlatAppearance.BorderColor = Color.DeepSkyBlue;
            normalizeButton.FlatAppearance.MouseDownBackColor = Color.DeepSkyBlue;
            normalizeButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(22, 46, 56);
            normalizeButton.FlatStyle = FlatStyle.Flat;
            normalizeButton.ForeColor = Color.White;
            normalizeButton.Location = new Point(25, 195);
            normalizeButton.Name = "normalizeButton";
            normalizeButton.Size = new Size(200, 25);
            normalizeButton.TabIndex = 14;
            normalizeButton.Text = "Normalize";
            normalizeButton.UseVisualStyleBackColor = false;
            normalizeButton.Click += normalizeButton_Click;
            // 
            // NeuralNetworkNormalizerWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 30, 40);
            Controls.Add(normalizeButton);
            Controls.Add(normalizeTypeBox);
            Controls.Add(loadBatchButton);
            Controls.Add(batchPathTextBox);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(controlsPanel);
            DoubleBuffered = true;
            Name = "NeuralNetworkNormalizerWindow";
            Size = new Size(250, 246);
            controlsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
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

        private TextBox batchPathTextBox;
        private Button loadBatchButton;
        private ComboBox normalizeTypeBox;
        private Button normalizeButton;
    }
}
