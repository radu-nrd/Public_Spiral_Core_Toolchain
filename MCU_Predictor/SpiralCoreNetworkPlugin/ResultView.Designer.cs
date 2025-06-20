namespace MCU_Predictor
{
    partial class ResultView
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
            panel1 = new Panel();
            resultUserControl1 = new ResultUserControl();
            backButton = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DeepSkyBlue;
            panel1.Controls.Add(resultUserControl1);
            panel1.Location = new Point(42, 108);
            panel1.Name = "panel1";
            panel1.Size = new Size(220, 220);
            panel1.TabIndex = 1;
            // 
            // resultUserControl1
            // 
            resultUserControl1.BackColor = Color.FromArgb(0, 17, 33);
            resultUserControl1.Location = new Point(10, 10);
            resultUserControl1.Name = "resultUserControl1";
            resultUserControl1.Size = new Size(200, 200);
            resultUserControl1.TabIndex = 0;
            // 
            // backButton
            // 
            backButton.BackColor = Color.FromArgb(184, 140, 106);
            backButton.FlatStyle = FlatStyle.Flat;
            backButton.Font = new Font("Segoe UI", 20F);
            backButton.ForeColor = Color.White;
            backButton.Location = new Point(3, 3);
            backButton.Name = "backButton";
            backButton.Size = new Size(50, 50);
            backButton.TabIndex = 9;
            backButton.Text = "←";
            backButton.UseVisualStyleBackColor = false;
            backButton.Click += BackButtonClick;
            // 
            // ResultView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(217, 221, 230);
            Controls.Add(backButton);
            Controls.Add(panel1);
            Name = "ResultView";
            Size = new Size(303, 436);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private ResultUserControl resultUserControl1;
        private Button backButton;
    }
}
