namespace ConsignmentShopMainUI
{
    partial class CashGraphicWindowMonthly
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.CashChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.CloseButton = new System.Windows.Forms.Button();
            this.YearlySalesVolumeBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CashChart)).BeginInit();
            this.SuspendLayout();
            // 
            // CashChart
            // 
            chartArea2.Name = "ChartArea1";
            this.CashChart.ChartAreas.Add(chartArea2);
            legend2.DockedToChartArea = "ChartArea1";
            legend2.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend2.Name = "Legend1";
            this.CashChart.Legends.Add(legend2);
            this.CashChart.Location = new System.Drawing.Point(12, 12);
            this.CashChart.Name = "CashChart";
            this.CashChart.Size = new System.Drawing.Size(815, 419);
            this.CashChart.TabIndex = 0;
            this.CashChart.Text = "Umsatz";
            title2.Name = "Umsätze";
            this.CashChart.Titles.Add(title2);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(752, 437);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "schliessen";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // YearlySalesVolumeBtn
            // 
            this.YearlySalesVolumeBtn.Location = new System.Drawing.Point(12, 437);
            this.YearlySalesVolumeBtn.Name = "YearlySalesVolumeBtn";
            this.YearlySalesVolumeBtn.Size = new System.Drawing.Size(102, 23);
            this.YearlySalesVolumeBtn.TabIndex = 2;
            this.YearlySalesVolumeBtn.Text = "Jahresumsätze";
            this.YearlySalesVolumeBtn.UseVisualStyleBackColor = true;
            this.YearlySalesVolumeBtn.Click += new System.EventHandler(this.YearlySalesVolumeBtn_Click);
            // 
            // CashGraphicWindowMonthly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 462);
            this.Controls.Add(this.YearlySalesVolumeBtn);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.CashChart);
            this.Name = "CashGraphicWindowMonthly";
            this.Text = "Monatsumsätze";
            this.Shown += new System.EventHandler(this.CashGraphicWindow_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.CashChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart CashChart;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button YearlySalesVolumeBtn;
    }
}