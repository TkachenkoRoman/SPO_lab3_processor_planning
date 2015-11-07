namespace lab3_ProcessPlanning
{
    partial class Test1
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
            this.maskedTextBoxArisingTimeIntervalMax = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxArisingTimeIntervalMin = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxStep = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // maskedTextBoxArisingTimeIntervalMax
            // 
            this.maskedTextBoxArisingTimeIntervalMax.Location = new System.Drawing.Point(162, 45);
            this.maskedTextBoxArisingTimeIntervalMax.Mask = "99999";
            this.maskedTextBoxArisingTimeIntervalMax.Name = "maskedTextBoxArisingTimeIntervalMax";
            this.maskedTextBoxArisingTimeIntervalMax.Size = new System.Drawing.Size(35, 20);
            this.maskedTextBoxArisingTimeIntervalMax.TabIndex = 15;
            this.maskedTextBoxArisingTimeIntervalMax.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.maskedTextBoxArisingTimeIntervalMax.TextChanged += new System.EventHandler(this.maskedTextBoxArisingTimeIntervalMax_TextChanged);
            // 
            // maskedTextBoxArisingTimeIntervalMin
            // 
            this.maskedTextBoxArisingTimeIntervalMin.Location = new System.Drawing.Point(162, 12);
            this.maskedTextBoxArisingTimeIntervalMin.Mask = "99999";
            this.maskedTextBoxArisingTimeIntervalMin.Name = "maskedTextBoxArisingTimeIntervalMin";
            this.maskedTextBoxArisingTimeIntervalMin.Size = new System.Drawing.Size(35, 20);
            this.maskedTextBoxArisingTimeIntervalMin.TabIndex = 14;
            this.maskedTextBoxArisingTimeIntervalMin.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.maskedTextBoxArisingTimeIntervalMin.TextChanged += new System.EventHandler(this.maskedTextBoxArisingTimeIntervalMin_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Arising time interval minimum";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Arising time interval maximum";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Step";
            // 
            // textBoxStep
            // 
            this.textBoxStep.Location = new System.Drawing.Point(47, 77);
            this.textBoxStep.Name = "textBoxStep";
            this.textBoxStep.Size = new System.Drawing.Size(41, 20);
            this.textBoxStep.TabIndex = 18;
            this.textBoxStep.TextChanged += new System.EventHandler(this.textBoxStep_TextChanged);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(101, 115);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 19;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // Test1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 156);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.textBoxStep);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maskedTextBoxArisingTimeIntervalMax);
            this.Controls.Add(this.maskedTextBoxArisingTimeIntervalMin);
            this.Controls.Add(this.label2);
            this.Name = "Test1";
            this.Text = "Test1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedTextBoxArisingTimeIntervalMax;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxArisingTimeIntervalMin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxStep;
        private System.Windows.Forms.Button buttonStart;
    }
}