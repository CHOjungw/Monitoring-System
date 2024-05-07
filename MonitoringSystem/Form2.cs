using MonitoringSystem.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static OfficeOpenXml.ExcelErrorValue;

namespace MonitoringSystem
{
    public partial class Form2 : Form
    {
        private double xCount = 200;
        public int chartFlag = 1;
              
        public Form2()
        {
           
            InitializeComponent();
            
            ChartSetting();
            checkPoint();
        }

       
        private void ChartSetting()
        {
            if (chartFlag == 1)
            {
                chart1.ChartAreas.Clear();
                chart1.ChartAreas.Add("draw");
                chart1.ChartAreas["draw"].AxisX.Minimum = 0;
                chart1.ChartAreas["draw"].AxisX.Maximum = xCount;
                chart1.ChartAreas["draw"].AxisX.Interval = xCount / 4;
                chart1.ChartAreas["draw"].AxisX.MajorGrid.LineColor = Color.White;
                chart1.ChartAreas["draw"].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

                chart1.ChartAreas["draw"].AxisY.Minimum = 0;
                chart1.ChartAreas["draw"].AxisY.Maximum = 1024;
                chart1.ChartAreas["draw"].AxisY.Interval = 200;
                chart1.ChartAreas["draw"].AxisY.MajorGrid.LineColor = Color.White;
                chart1.ChartAreas["draw"].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

                chart1.ChartAreas["draw"].BackColor = Color.Blue;
                chart1.ChartAreas["draw"].CursorX.AutoScroll = true;

                chart1.ChartAreas["draw"].AxisX.ScaleView.Zoomable = true;
                chart1.ChartAreas["draw"].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
                chart1.ChartAreas["draw"].AxisX.ScrollBar.ButtonColor = Color.LightSteelBlue;
            }
            if (chartFlag == 2)
            {
                chart1.ChartAreas.Clear();
                chart1.ChartAreas.Add("draw");
                chart1.ChartAreas["draw"].AxisX.Minimum = 0;
                chart1.ChartAreas["draw"].AxisX.Maximum = xCount;
                chart1.ChartAreas["draw"].AxisX.Interval = xCount / 4;
                chart1.ChartAreas["draw"].AxisX.MajorGrid.LineColor = Color.White;
                chart1.ChartAreas["draw"].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

                chart1.ChartAreas["draw"].AxisY.Minimum = 0;
                chart1.ChartAreas["draw"].AxisY.Maximum = 100;
                chart1.ChartAreas["draw"].AxisY.Interval = 10;
                chart1.ChartAreas["draw"].AxisY.MajorGrid.LineColor = Color.White;
                chart1.ChartAreas["draw"].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

                chart1.ChartAreas["draw"].BackColor = Color.Blue;
                chart1.ChartAreas["draw"].CursorX.AutoScroll = true;

                chart1.ChartAreas["draw"].AxisX.ScaleView.Zoomable = true;
                chart1.ChartAreas["draw"].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
                chart1.ChartAreas["draw"].AxisX.ScrollBar.ButtonColor = Color.LightSteelBlue;
            }
            if (chartFlag == 3)
            {
                chart1.ChartAreas.Clear();
                chart1.ChartAreas.Add("draw");
                chart1.ChartAreas["draw"].AxisX.Minimum = 0;
                chart1.ChartAreas["draw"].AxisX.Maximum = xCount;
                chart1.ChartAreas["draw"].AxisX.Interval = xCount / 4;
                chart1.ChartAreas["draw"].AxisX.MajorGrid.LineColor = Color.White;
                chart1.ChartAreas["draw"].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

                chart1.ChartAreas["draw"].AxisY.Minimum = 700;
                chart1.ChartAreas["draw"].AxisY.Maximum = 800;
                chart1.ChartAreas["draw"].AxisY.Interval = 10;
                chart1.ChartAreas["draw"].AxisY.MajorGrid.LineColor = Color.White;
                chart1.ChartAreas["draw"].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

                chart1.ChartAreas["draw"].BackColor = Color.Blue;
                chart1.ChartAreas["draw"].CursorX.AutoScroll = true;

                chart1.ChartAreas["draw"].AxisX.ScaleView.Zoomable = true;
                chart1.ChartAreas["draw"].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
                chart1.ChartAreas["draw"].AxisX.ScrollBar.ButtonColor = Color.LightSteelBlue;
            }

            //차트 시리즈 설정
            chart1.Series.Clear();
            chart1.Series.Add("HeaterData");
            chart1.Series["HeaterData"].ChartType = SeriesChartType.Line;
            chart1.Series["HeaterData"].Color = Color.LightGreen;
            chart1.Series["HeaterData"].BorderWidth = 3;
            chart1.Series.Add("WaterData");
            chart1.Series["WaterData"].ChartType = SeriesChartType.Line;
            chart1.Series["WaterData"].Color = Color.LightGreen;
            chart1.Series["WaterData"].BorderWidth = 3;
            chart1.Series.Add("Air1Data");
            chart1.Series["Air1Data"].ChartType = SeriesChartType.Line;
            chart1.Series["Air1Data"].Color = Color.LightYellow;
            chart1.Series["Air1Data"].BorderWidth = 3;
            chart1.Series.Add("Air2Data");
            chart1.Series["Air2Data"].ChartType = SeriesChartType.Line;
            chart1.Series["Air2Data"].Color = Color.LightCoral;
            chart1.Series["Air2Data"].BorderWidth = 3;

            chart1.Series["WaterData"].Enabled = false;
            chart1.Series["Air1Data"].Enabled = false;
            chart1.Series["Air2Data"].Enabled = false;

            //범례 제거
            if (chart1.Legends.Count > 0)
                chart1.Legends.RemoveAt(0);
        }
        public void ChartAddPoint(int av1, int av2, int wv, int hv)
        {
            chart1.Series["HeaterData"].Points.Add(hv);
            chart1.Series["WaterData"].Points.Add(wv);
            chart1.Series["Air1Data"].Points.Add(av1);
            chart1.Series["Air2Data"].Points.Add(av2);
        }
        private void heaterDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chartFlag = 1;
            ChartSetting();
            chart1.Series["HeaterData"].Enabled = true;
            chart1.Series["WaterData"].Enabled = false;
            chart1.Series["Air1Data"].Enabled = false;
            chart1.Series["Air2Data"].Enabled = false;
            checkPoint();
        }
        private void waterDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chartFlag = 2;
            ChartSetting();
            chart1.Series["HeaterData"].Enabled = false;
            chart1.Series["WaterData"].Enabled = true;
            chart1.Series["Air1Data"].Enabled = false;
            chart1.Series["Air2Data"].Enabled = false;
            checkPoint();
        }

        private void airDataTrendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chartFlag = 3;
            ChartSetting();
            chart1.Series["HeaterData"].Enabled = false;
            chart1.Series["WaterData"].Enabled = false;
            chart1.Series["Air1Data"].Enabled = true;
            chart1.Series["Air2Data"].Enabled = true;
            checkPoint();
        }
        public void checkPoint()
        {
            if(chartFlag == 1)
                foreach(var item in DataManager.HDatas)
                {
                    chart1.Series["HeaterData"].Points.Add(item.value);
                }
            else if(chartFlag==2)
                foreach (var item in DataManager.WDatas)
                {
                    chart1.Series["WaterData"].Points.Add(item.value);
                }
            else
                foreach(var item in DataManager.ADatas)
                {
                    chart1.Series["Air1Data"].Points.Add(item.value);
                    chart1.Series["Air2Data"].Points.Add(item.value2);
                }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Dispose();
        }
    }
}
