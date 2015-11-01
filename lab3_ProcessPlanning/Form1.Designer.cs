﻿namespace ProcessesPlanning
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.dataGridViewProcesses = new System.Windows.Forms.DataGridView();
            this.bindingSourceProcesses = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonStart = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewResults = new System.Windows.Forms.DataGridView();
            this.bindingSourceResults = new System.Windows.Forms.BindingSource(this.components);
            this.buttonStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.maskedTextBoxExecutionTimeIntervalMin = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxExecutionTimeIntervalMax = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxArisingTimeIntervalMax = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxArisingTimeIntervalMin = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.maskedTextBoxPriorityMax = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxPriorityMin = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelAveragePauseTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProcesses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceProcesses)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceResults)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewProcesses
            // 
            this.dataGridViewProcesses.AllowUserToAddRows = false;
            this.dataGridViewProcesses.AutoGenerateColumns = false;
            this.dataGridViewProcesses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProcesses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProcesses.DataSource = this.bindingSourceProcesses;
            this.dataGridViewProcesses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewProcesses.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewProcesses.Name = "dataGridViewProcesses";
            this.dataGridViewProcesses.Size = new System.Drawing.Size(467, 204);
            this.dataGridViewProcesses.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(10, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 229);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Processes";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewProcesses, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(473, 210);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(511, 412);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(116, 23);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewResults);
            this.groupBox2.Location = new System.Drawing.Point(12, 254);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(477, 224);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Results";
            // 
            // dataGridViewResults
            // 
            this.dataGridViewResults.AllowUserToAddRows = false;
            this.dataGridViewResults.AllowUserToDeleteRows = false;
            this.dataGridViewResults.AllowUserToOrderColumns = true;
            this.dataGridViewResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewResults.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewResults.Name = "dataGridViewResults";
            this.dataGridViewResults.Size = new System.Drawing.Size(471, 205);
            this.dataGridViewResults.TabIndex = 0;
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(511, 452);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(116, 23);
            this.buttonStop.TabIndex = 6;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(496, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Execution time interval";
            // 
            // maskedTextBoxExecutionTimeIntervalMin
            // 
            this.maskedTextBoxExecutionTimeIntervalMin.Location = new System.Drawing.Point(615, 40);
            this.maskedTextBoxExecutionTimeIntervalMin.Mask = "99";
            this.maskedTextBoxExecutionTimeIntervalMin.Name = "maskedTextBoxExecutionTimeIntervalMin";
            this.maskedTextBoxExecutionTimeIntervalMin.Size = new System.Drawing.Size(20, 20);
            this.maskedTextBoxExecutionTimeIntervalMin.TabIndex = 8;
            this.maskedTextBoxExecutionTimeIntervalMin.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.maskedTextBoxExecutionTimeIntervalMin.TextChanged += new System.EventHandler(this.maskedTextBoxExecutionTimeIntervalMin_TextChanged);
            // 
            // maskedTextBoxExecutionTimeIntervalMax
            // 
            this.maskedTextBoxExecutionTimeIntervalMax.Location = new System.Drawing.Point(641, 40);
            this.maskedTextBoxExecutionTimeIntervalMax.Mask = "99";
            this.maskedTextBoxExecutionTimeIntervalMax.Name = "maskedTextBoxExecutionTimeIntervalMax";
            this.maskedTextBoxExecutionTimeIntervalMax.Size = new System.Drawing.Size(20, 20);
            this.maskedTextBoxExecutionTimeIntervalMax.TabIndex = 9;
            this.maskedTextBoxExecutionTimeIntervalMax.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.maskedTextBoxExecutionTimeIntervalMax.TextChanged += new System.EventHandler(this.maskedTextBoxExecutionTimeIntervalMax_TextChanged);
            // 
            // maskedTextBoxArisingTimeIntervalMax
            // 
            this.maskedTextBoxArisingTimeIntervalMax.Location = new System.Drawing.Point(641, 68);
            this.maskedTextBoxArisingTimeIntervalMax.Mask = "99";
            this.maskedTextBoxArisingTimeIntervalMax.Name = "maskedTextBoxArisingTimeIntervalMax";
            this.maskedTextBoxArisingTimeIntervalMax.Size = new System.Drawing.Size(20, 20);
            this.maskedTextBoxArisingTimeIntervalMax.TabIndex = 12;
            this.maskedTextBoxArisingTimeIntervalMax.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.maskedTextBoxArisingTimeIntervalMax.TextChanged += new System.EventHandler(this.maskedTextBoxArisingTimeIntervalMax_TextChanged);
            // 
            // maskedTextBoxArisingTimeIntervalMin
            // 
            this.maskedTextBoxArisingTimeIntervalMin.Location = new System.Drawing.Point(615, 68);
            this.maskedTextBoxArisingTimeIntervalMin.Mask = "99";
            this.maskedTextBoxArisingTimeIntervalMin.Name = "maskedTextBoxArisingTimeIntervalMin";
            this.maskedTextBoxArisingTimeIntervalMin.Size = new System.Drawing.Size(20, 20);
            this.maskedTextBoxArisingTimeIntervalMin.TabIndex = 11;
            this.maskedTextBoxArisingTimeIntervalMin.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.maskedTextBoxArisingTimeIntervalMin.TextChanged += new System.EventHandler(this.maskedTextBoxArisingTimeIntervalMin_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(496, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Arising time interval";
            // 
            // maskedTextBoxPriorityMax
            // 
            this.maskedTextBoxPriorityMax.Location = new System.Drawing.Point(641, 97);
            this.maskedTextBoxPriorityMax.Mask = "99";
            this.maskedTextBoxPriorityMax.Name = "maskedTextBoxPriorityMax";
            this.maskedTextBoxPriorityMax.Size = new System.Drawing.Size(20, 20);
            this.maskedTextBoxPriorityMax.TabIndex = 15;
            this.maskedTextBoxPriorityMax.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.maskedTextBoxPriorityMax.TextChanged += new System.EventHandler(this.maskedTextBoxPriorityMax_TextChanged);
            // 
            // maskedTextBoxPriorityMin
            // 
            this.maskedTextBoxPriorityMin.Location = new System.Drawing.Point(615, 97);
            this.maskedTextBoxPriorityMin.Mask = "99";
            this.maskedTextBoxPriorityMin.Name = "maskedTextBoxPriorityMin";
            this.maskedTextBoxPriorityMin.Size = new System.Drawing.Size(20, 20);
            this.maskedTextBoxPriorityMin.TabIndex = 14;
            this.maskedTextBoxPriorityMin.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.maskedTextBoxPriorityMin.TextChanged += new System.EventHandler(this.maskedTextBoxPriorityMin_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(496, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Priority interval";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(499, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Average pause time: ";
            // 
            // labelAveragePauseTime
            // 
            this.labelAveragePauseTime.AutoSize = true;
            this.labelAveragePauseTime.Location = new System.Drawing.Point(600, 141);
            this.labelAveragePauseTime.Name = "labelAveragePauseTime";
            this.labelAveragePauseTime.Size = new System.Drawing.Size(16, 13);
            this.labelAveragePauseTime.TabIndex = 17;
            this.labelAveragePauseTime.Text = "...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 505);
            this.Controls.Add(this.labelAveragePauseTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.maskedTextBoxPriorityMax);
            this.Controls.Add(this.maskedTextBoxPriorityMin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maskedTextBoxArisingTimeIntervalMax);
            this.Controls.Add(this.maskedTextBoxArisingTimeIntervalMin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maskedTextBoxExecutionTimeIntervalMax);
            this.Controls.Add(this.maskedTextBoxExecutionTimeIntervalMin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProcesses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceProcesses)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewProcesses;
        private System.Windows.Forms.BindingSource bindingSourceProcesses;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridViewResults;
        private System.Windows.Forms.BindingSource bindingSourceResults;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxExecutionTimeIntervalMin;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxExecutionTimeIntervalMax;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxArisingTimeIntervalMax;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxArisingTimeIntervalMin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPriorityMax;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPriorityMin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelAveragePauseTime;
    }
}

