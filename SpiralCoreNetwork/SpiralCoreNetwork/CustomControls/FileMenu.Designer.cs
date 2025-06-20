namespace SpiralCoreNetwork.CustomControls
{
    partial class FileMenu
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
            importButton = new Button();
            saveButton = new Button();
            exitButton = new Button();
            SuspendLayout();
            // 
            // importButton
            // 
            importButton.Dock = DockStyle.Top;
            importButton.FlatAppearance.BorderSize = 0;
            importButton.FlatStyle = FlatStyle.Flat;
            importButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            importButton.ForeColor = Color.White;
            importButton.Location = new Point(0, 0);
            importButton.Name = "importButton";
            importButton.Size = new Size(150, 61);
            importButton.TabIndex = 0;
            importButton.Text = "Import";
            importButton.UseVisualStyleBackColor = true;
            importButton.Click += importButton_Click;
            importButton.MouseEnter += MouseEnterControlButton;
            importButton.MouseLeave += MouseLeaveControlButton;
            // 
            // saveButton
            // 
            saveButton.Dock = DockStyle.Top;
            saveButton.FlatAppearance.BorderSize = 0;
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            saveButton.ForeColor = Color.White;
            saveButton.Location = new Point(0, 61);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(150, 61);
            saveButton.TabIndex = 1;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            saveButton.MouseEnter += MouseEnterControlButton;
            saveButton.MouseLeave += MouseLeaveControlButton;
            // 
            // exitButton
            // 
            exitButton.Dock = DockStyle.Top;
            exitButton.FlatAppearance.BorderSize = 0;
            exitButton.FlatStyle = FlatStyle.Flat;
            exitButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            exitButton.ForeColor = Color.White;
            exitButton.Location = new Point(0, 122);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(150, 61);
            exitButton.TabIndex = 2;
            exitButton.Text = "Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            exitButton.MouseEnter += MouseEnterControlButton;
            exitButton.MouseLeave += MouseLeaveControlButton;
            // 
            // FileMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 17, 33);
            Controls.Add(exitButton);
            Controls.Add(saveButton);
            Controls.Add(importButton);
            Name = "FileMenu";
            Size = new Size(150, 180);
            ResumeLayout(false);
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

        private Button importButton;
        private Button saveButton;
        private Button exitButton;
    }
}
