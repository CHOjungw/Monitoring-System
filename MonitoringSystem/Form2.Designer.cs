namespace MonitoringSystem
{
    partial class Form2
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.heaterDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.waterDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.airDataTrendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.heaterDataToolStripMenuItem,
            this.waterDataToolStripMenuItem,
            this.airDataTrendToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(770, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // heaterDataToolStripMenuItem
            // 
            this.heaterDataToolStripMenuItem.Name = "heaterDataToolStripMenuItem";
            this.heaterDataToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.heaterDataToolStripMenuItem.Text = "HeaterData Trend";
            this.heaterDataToolStripMenuItem.Click += new System.EventHandler(this.heaterDataToolStripMenuItem_Click);
            // 
            // waterDataToolStripMenuItem
            // 
            this.waterDataToolStripMenuItem.Name = "waterDataToolStripMenuItem";
            this.waterDataToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.waterDataToolStripMenuItem.Text = "WaterData Trend";
            this.waterDataToolStripMenuItem.Click += new System.EventHandler(this.waterDataToolStripMenuItem_Click);
            // 
            // airDataTrendToolStripMenuItem
            // 
            this.airDataTrendToolStripMenuItem.Name = "airDataTrendToolStripMenuItem";
            this.airDataTrendToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.airDataTrendToolStripMenuItem.Text = "AirData Trend";
            this.airDataTrendToolStripMenuItem.Click += new System.EventHandler(this.airDataTrendToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // chart1
            // 
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart1.Legends.Add(legend4);
            this.chart1.Location = new System.Drawing.Point(12, 47);
            this.chart1.Name = "chart1";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(738, 300);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 362);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem heaterDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem waterDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem airDataTrendToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}