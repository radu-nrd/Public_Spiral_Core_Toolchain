namespace NeuralNetworkBuilderPlugin
{
    partial class AppendLayerWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            headerLabel = new Label();
            neuronsNumericUpDown = new NumericUpDown();
            label2 = new Label();
            label3 = new Label();
            actFctComboBox = new ComboBox();
            layerTypeComboBox = new ComboBox();
            label4 = new Label();
            addLayerButton = new Button();
            ((System.ComponentModel.ISupportInitialize)neuronsNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // headerLabel
            // 
            headerLabel.Dock = DockStyle.Top;
            headerLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            headerLabel.Location = new Point(0, 0);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(284, 42);
            headerLabel.TabIndex = 0;
            headerLabel.Text = "Label Index";
            headerLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // neuronsNumericUpDown
            // 
            neuronsNumericUpDown.Font = new Font("Segoe UI", 10F);
            neuronsNumericUpDown.Location = new Point(119, 53);
            neuronsNumericUpDown.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            neuronsNumericUpDown.Name = "neuronsNumericUpDown";
            neuronsNumericUpDown.Size = new Size(154, 25);
            neuronsNumericUpDown.TabIndex = 1;
            neuronsNumericUpDown.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(12, 45);
            label2.Name = "label2";
            label2.Size = new Size(101, 36);
            label2.TabIndex = 2;
            label2.Text = "Neurons";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(12, 85);
            label3.Name = "label3";
            label3.Size = new Size(101, 40);
            label3.TabIndex = 3;
            label3.Text = "Activation Function";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // actFctComboBox
            // 
            actFctComboBox.Font = new Font("Segoe UI", 10F);
            actFctComboBox.FormattingEnabled = true;
            actFctComboBox.Items.AddRange(new object[] { "None", "Sigmoid", "ReLu", "Softmax" });
            actFctComboBox.Location = new Point(119, 94);
            actFctComboBox.Name = "actFctComboBox";
            actFctComboBox.Size = new Size(152, 25);
            actFctComboBox.TabIndex = 4;
            // 
            // layerTypeComboBox
            // 
            layerTypeComboBox.Font = new Font("Segoe UI", 10F);
            layerTypeComboBox.FormattingEnabled = true;
            layerTypeComboBox.Items.AddRange(new object[] { "Input", "Hidden", "Output" });
            layerTypeComboBox.Location = new Point(119, 138);
            layerTypeComboBox.Name = "layerTypeComboBox";
            layerTypeComboBox.Size = new Size(152, 25);
            layerTypeComboBox.TabIndex = 6;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.Location = new Point(12, 129);
            label4.Name = "label4";
            label4.Size = new Size(101, 40);
            label4.TabIndex = 5;
            label4.Text = "Layer Type";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // addLayerButton
            // 
            addLayerButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            addLayerButton.Location = new Point(75, 186);
            addLayerButton.Name = "addLayerButton";
            addLayerButton.Size = new Size(150, 50);
            addLayerButton.TabIndex = 7;
            addLayerButton.Text = "Add";
            addLayerButton.UseVisualStyleBackColor = true;
            addLayerButton.Click += AddLayerButtonClick;
            // 
            // AppendLayerWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 261);
            Controls.Add(addLayerButton);
            Controls.Add(layerTypeComboBox);
            Controls.Add(label4);
            Controls.Add(actFctComboBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(neuronsNumericUpDown);
            Controls.Add(headerLabel);
            Name = "AppendLayerWindow";
            Text = "AppendLayerWindow";
            ((System.ComponentModel.ISupportInitialize)neuronsNumericUpDown).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label headerLabel;
        private NumericUpDown neuronsNumericUpDown;
        private Label label2;
        private Label label3;
        private ComboBox actFctComboBox;
        private ComboBox layerTypeComboBox;
        private Label label4;
        private Button addLayerButton;
    }
}