namespace asharma_BI_A1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button5 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.PieRadioButton = new System.Windows.Forms.RadioButton();
            this.LineRadioButton = new System.Windows.Forms.RadioButton();
            this.ControlRadioButton = new System.Windows.Forms.RadioButton();
            this.ParetoRadioButton = new System.Windows.Forms.RadioButton();
            this.titleLabel = new System.Windows.Forms.Label();
            this.desiredLimitEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(7, 134);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(437, 339);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(7, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "Type Of Chart:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(499, 226);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(545, 106);
            this.dataGridView1.TabIndex = 6;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button5.Location = new System.Drawing.Point(709, 373);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(130, 38);
            this.button5.TabIndex = 7;
            this.button5.Text = "UPDATE";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Update_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(535, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 58);
            this.label2.TabIndex = 8;
            this.label2.Text = "A01 - Data Visualization using MS Chart";
            // 
            // PieRadioButton
            // 
            this.PieRadioButton.AutoSize = true;
            this.PieRadioButton.Location = new System.Drawing.Point(13, 78);
            this.PieRadioButton.Name = "PieRadioButton";
            this.PieRadioButton.Size = new System.Drawing.Size(68, 17);
            this.PieRadioButton.TabIndex = 9;
            this.PieRadioButton.TabStop = true;
            this.PieRadioButton.Text = "Pie Chart";
            this.PieRadioButton.UseVisualStyleBackColor = true;
            this.PieRadioButton.Click += new System.EventHandler(this.PieRadioButton_CheckedChanged);
            // 
            // LineRadioButton
            // 
            this.LineRadioButton.AutoSize = true;
            this.LineRadioButton.Location = new System.Drawing.Point(113, 78);
            this.LineRadioButton.Name = "LineRadioButton";
            this.LineRadioButton.Size = new System.Drawing.Size(73, 17);
            this.LineRadioButton.TabIndex = 10;
            this.LineRadioButton.TabStop = true;
            this.LineRadioButton.Text = "Line Chart";
            this.LineRadioButton.UseVisualStyleBackColor = true;
            this.LineRadioButton.Click += new System.EventHandler(this.LineRadioButton_CheckedChanged);
            // 
            // ControlRadioButton
            // 
            this.ControlRadioButton.AutoSize = true;
            this.ControlRadioButton.Location = new System.Drawing.Point(224, 78);
            this.ControlRadioButton.Name = "ControlRadioButton";
            this.ControlRadioButton.Size = new System.Drawing.Size(86, 17);
            this.ControlRadioButton.TabIndex = 11;
            this.ControlRadioButton.TabStop = true;
            this.ControlRadioButton.Text = "Control Chart";
            this.ControlRadioButton.UseVisualStyleBackColor = true;
            this.ControlRadioButton.Click += new System.EventHandler(this.ControlRadioButton_CheckedChanged);
            // 
            // ParetoRadioButton
            // 
            this.ParetoRadioButton.AutoSize = true;
            this.ParetoRadioButton.Location = new System.Drawing.Point(336, 78);
            this.ParetoRadioButton.Name = "ParetoRadioButton";
            this.ParetoRadioButton.Size = new System.Drawing.Size(98, 17);
            this.ParetoRadioButton.TabIndex = 12;
            this.ParetoRadioButton.TabStop = true;
            this.ParetoRadioButton.Text = "Pareto Diagram";
            this.ParetoRadioButton.UseVisualStyleBackColor = true;
            this.ParetoRadioButton.Click += new System.EventHandler(this.ParetoRadioButton_CheckedChanged);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.Blue;
            this.titleLabel.Location = new System.Drawing.Point(206, 20);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(16, 24);
            this.titleLabel.TabIndex = 13;
            this.titleLabel.Text = " ";
            // 
            // desiredLimitEdit
            // 
            this.desiredLimitEdit.Location = new System.Drawing.Point(941, 434);
            this.desiredLimitEdit.Name = "desiredLimitEdit";
            this.desiredLimitEdit.Size = new System.Drawing.Size(103, 39);
            this.desiredLimitEdit.TabIndex = 14;
            this.desiredLimitEdit.Text = "Edit Desired Limits";
            this.desiredLimitEdit.UseVisualStyleBackColor = true;
            this.desiredLimitEdit.Click += new System.EventHandler(this.desiredLimitEdit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1070, 492);
            this.Controls.Add(this.desiredLimitEdit);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.ParetoRadioButton);
            this.Controls.Add(this.ControlRadioButton);
            this.Controls.Add(this.LineRadioButton);
            this.Controls.Add(this.PieRadioButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chart1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton PieRadioButton;
        private System.Windows.Forms.RadioButton LineRadioButton;
        private System.Windows.Forms.RadioButton ControlRadioButton;
        private System.Windows.Forms.RadioButton ParetoRadioButton;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button desiredLimitEdit;
    }
}

