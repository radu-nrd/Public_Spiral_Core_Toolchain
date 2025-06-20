namespace MCU_Predictor
{
    partial class ResultUserControl
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
            grad_overload_label = new Label();
            grad_overload_value_label = new Label();
            cpu_load_label = new Label();
            cpu_load_value_label = new Label();
            SuspendLayout();
            // 
            // grad_overload_label
            // 
            grad_overload_label.Dock = DockStyle.Top;
            grad_overload_label.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            grad_overload_label.ForeColor = Color.FromArgb(112, 79, 56);
            grad_overload_label.Location = new Point(0, 0);
            grad_overload_label.Name = "grad_overload_label";
            grad_overload_label.Size = new Size(200, 50);
            grad_overload_label.TabIndex = 3;
            grad_overload_label.Text = "Grad Overload:";
            grad_overload_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // grad_overload_value_label
            // 
            grad_overload_value_label.Dock = DockStyle.Top;
            grad_overload_value_label.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            grad_overload_value_label.ForeColor = Color.DeepSkyBlue;
            grad_overload_value_label.Location = new Point(0, 50);
            grad_overload_value_label.Name = "grad_overload_value_label";
            grad_overload_value_label.Size = new Size(200, 50);
            grad_overload_value_label.TabIndex = 4;
            grad_overload_value_label.Text = "0,00000";
            grad_overload_value_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cpu_load_label
            // 
            cpu_load_label.Dock = DockStyle.Top;
            cpu_load_label.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            cpu_load_label.ForeColor = Color.FromArgb(112, 79, 56);
            cpu_load_label.Location = new Point(0, 100);
            cpu_load_label.Name = "cpu_load_label";
            cpu_load_label.Size = new Size(200, 50);
            cpu_load_label.TabIndex = 5;
            cpu_load_label.Text = "CPU Load";
            cpu_load_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cpu_load_value_label
            // 
            cpu_load_value_label.Dock = DockStyle.Top;
            cpu_load_value_label.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            cpu_load_value_label.ForeColor = Color.DeepSkyBlue;
            cpu_load_value_label.Location = new Point(0, 150);
            cpu_load_value_label.Name = "cpu_load_value_label";
            cpu_load_value_label.Size = new Size(200, 50);
            cpu_load_value_label.TabIndex = 6;
            cpu_load_value_label.Text = "0,00000";
            cpu_load_value_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ResultUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cpu_load_value_label);
            Controls.Add(cpu_load_label);
            Controls.Add(grad_overload_value_label);
            Controls.Add(grad_overload_label);
            Name = "ResultUserControl";
            Size = new Size(200, 200);
            ResumeLayout(false);
        }

        #endregion

        private Label grad_overload_label;
        private Label grad_overload_value_label;
        private Label cpu_load_label;
        private Label cpu_load_value_label;
    }
}
