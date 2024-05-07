using MonitoringSystem.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace MonitoringSystem
{
    public partial class Form1 : Form
    {
        
        Timer timer = new Timer();
        Random random = new Random();
        private DataManager dataManager = new DataManager();

        private HeaterData heaterData; /*= new HeaterData(DateTime.Now.ToShortDateString(), DateTime.Now.ToString("HH:mm:ss"), 0);*/
        private WaterData waterData;  /*new WaterData(DateTime.Now.ToShortDateString(), DateTime.Now.ToString("HH:mm:ss"),0);*/
        private AirData airData;/* new AirData(DateTime.Now.ToShortDateString(), DateTime.Now.ToString("HH:mm:ss"), 0,0);*/

        int lampFlag = 0;
        private Form2 form2;
        int av1 = 0;
        int av2 = 0;
        int hv =  0;
        int wv = 0;
        bool compdrain = true;
        int WaterLeakCount = 0;


        public Form1()
        {
            form2 = new Form2();
            InitializeComponent();            

            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
            airData = new AirData(DateTime.Now.ToShortDateString(), DateTime.Now.ToString("HH:mm:ss"), 0, 0);
            waterData = new WaterData(DateTime.Now.ToShortDateString(), DateTime.Now.ToString("HH:mm:ss"), 0);
            heaterData = new HeaterData(DateTime.Now.ToShortDateString(), DateTime.Now.ToString("HH:mm:ss"), 0);

        }
        public void simulation()
        {
            av1 = random.Next(750, 770);
            av2 = random.Next(750, 770);            
            if(hv<=700)
            {
                hv += 30;
            }
            else
            {
                hv += random.Next(-10, 10);
            }
            if(wv <=80&& compdrain ==true)
            {
                wv += 10;
                drain(false);
            }
            else
            {
                compdrain = false;
                drain(true);   

            }
            waterLeak(wv);
            ShowValue(av1, av2, wv, hv);
            
        }
        private void drain(bool value)
        {
            
            checkedListBox1.SetItemChecked(0, value);
            if (value) 
            {
                wv -= 10;
                if (wv <= 30) compdrain = true;
            }
        }
        private void waterLeak(int wv)
        {
            
            if (DataManager.WDatas.Count >= 1)
            {
                int lastvalue = DataManager.WDatas[DataManager.WDatas.Count - 1].value;

                if (compdrain == true && lastvalue > wv)
                {
                    WaterLeakCount++;
                }
                else WaterLeakCount = 0;
                if (WaterLeakCount >= 2) checkedListBox1.SetItemChecked(1, true);
                else checkedListBox1.SetItemChecked(1, false);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {                          
            simulation();          
            
            Lamp_Contol();
            Error_Log();
            
            DataManager.SaveToXml();
        }
        public void ShowValue(int av1,int av2,int wv,int hv)
        {
            airData = new AirData(DateTime.Now.ToShortDateString(), DateTime.Now.ToString("HH:mm:ss"), av1, av2);
            waterData = new WaterData(DateTime.Now.ToShortDateString(), DateTime.Now.ToString("HH:mm:ss"), wv);
            heaterData = new HeaterData(DateTime.Now.ToShortDateString(), DateTime.Now.ToString("HH:mm:ss"), hv);
            Console.WriteLine(waterData.date);
            Console.ReadLine();
            DataManager.HDatas.Add(heaterData);
            DataManager.WDatas.Add(waterData);
            DataManager.ADatas.Add(airData);
            
            //debug
            Console.WriteLine(DataManager.HDatas.Count);
            if(form2 != null && form2.Visible)
            form2.ChartAddPoint(av1, av2, wv, hv);

            tbair1.Text = airData.value.ToString();
            tbair2.Text=airData.value2.ToString();
            lbhtemp.Text = heaterData.value.ToString();
            lbwlevel.Text = waterData.value.ToString();
            panel1.Invalidate();
            panel2.Invalidate();            
        }
     
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (heaterData.value != null)
            {
                int maxRectHeight = panel1.Height;
                int rectHeight = (heaterData.value * maxRectHeight) / 1000;
                int rectY = maxRectHeight - rectHeight;
                Rectangle rect = new Rectangle(0, rectY, 60, rectHeight);
                e.Graphics.FillRectangle(Brushes.Orange, rect);
                Panel1_DrawImage(sender, e);
            }
            else
                MessageBox.Show("Null값입니다");
        }       

        public void Panel1_DrawImage(object sender, PaintEventArgs p)
        {
            Rectangle rect = new Rectangle(0,0,60,300);
            p.Graphics.DrawImage(Properties.Resources.Pb_fire11, rect);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            if (waterData.value != null)
            {
                int maxRectHeight = panel1.Height;
                int rectHeight = (waterData.value * maxRectHeight) / 100;
                int rectY = maxRectHeight - rectHeight;
                Rectangle rect = new Rectangle(0, rectY, 60, rectHeight);
                e.Graphics.FillRectangle(Brushes.Aqua, rect);
                Panel2_DrawImage(sender, e);
            }
            else
                MessageBox.Show("Null값입니다");
        }

        private void ruler1_Paint1(object sender, PaintEventArgs p)
        {
            Graphics g = p.Graphics;
            int Height = 300;
            int Tick = 15;
            int TickLength=5;
            int TotalTick = 20;
            g.DrawLine(Pens.Black, 0, 0, 0, Height);
            for (int i = 0; i <= TotalTick; i++)
            {
                int x = i * Tick;
                if (i%2 ==0)                
                    g.DrawLine(Pens.Black, 0, i * Tick, TickLength * 2, i * Tick);
                else
                    g.DrawLine(Pens.Black, 0, i * Tick, TickLength, i * Tick);
                g.DrawString((i*100).ToString(), SystemFonts.DefaultFont, Brushes.Black, new Point(10,(10-i)*30 ));
            }
        }

        private void ruler2_Paint(object sender, PaintEventArgs p)
        {
            Graphics g = p.Graphics;
            int Height = 300;
            int Tick = 15;
            int TickLength = 5;
            int TotalTick = 20;
            g.DrawLine(Pens.Black, 0, 0, 0, Height);
            for (int i = 0; i <= TotalTick; i++)
            {
                int x = i * Tick;
                if (i % 2 == 0)
                    g.DrawLine(Pens.Black, 0, i * Tick, TickLength * 2, i * Tick);
                else
                    g.DrawLine(Pens.Black, 0, i * Tick, TickLength, i * Tick);
                g.DrawString((i * 10).ToString(), SystemFonts.DefaultFont, Brushes.Black, new Point(10, (10 - i) * 30));
            }
        }

        public void Panel2_DrawImage(object sender, PaintEventArgs p)
        {
            Rectangle rect = new Rectangle(0, 0, 60, 300);
            p.Graphics.DrawImage(Properties.Resources.Pb_water, rect);
        }
        public void Lamp_Contol()
        {
           switch(lampFlag)
                {
                case 0:
                    btnGreen.BackColor = Color.LightGreen;
                    btnRed.BackColor = Color.White;
                    btnYellow.BackColor = Color.White;
                    break;
                case 1:
                    btnGreen.BackColor = Color.White;
                    btnRed.BackColor = Color.White;
                    btnYellow.BackColor = Color.Yellow;
                    break;
                case 2:
                    btnGreen.BackColor = Color.White;
                    btnRed.BackColor = Color.Red;
                    btnYellow.BackColor = Color.White;
                    break;
                 default : 
                    break;
                }            
        }
        private void Error_Log()
        {
            string heatLowTemp = "Heater Low Temp" + "\t" + heaterData.value.ToString();
            string heatHighTemp = "Heater High Temp"+"\t" + heaterData.value.ToString();

            string waterOverFlow = "Water Over Flow" + "\t" + waterData.value.ToString();
            string waterLowFlow = "Water Low Flow" + "\t" + waterData.value.ToString();
                        
            string errorString = "\t" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToString("HH:mm:ss");
            string ErrorLog = "";

            if (heaterData.value<=600)
            {
                ErrorLog = heatLowTemp + errorString;
                lbLog.Items.Insert(0,ErrorLog);
                lampFlag = 1;
            }
            else if(heaterData.value>=850)
            {
                ErrorLog = heatHighTemp + errorString;
                lbLog.Items.Insert(0,ErrorLog);
                lampFlag = 2;
            }            
            
            if(waterData.value >= 100)
            {
                ErrorLog = waterOverFlow + errorString;
                lbLog.Items.Insert(0, ErrorLog);
                lampFlag = 2;
            }
            else if (waterData.value <= 10)
            {
                ErrorLog = waterLowFlow + errorString;
                lbLog.Items.Insert(0, ErrorLog);
                lampFlag = 1;
            }

        }        

        private void btnxmlsave_Click(object sender, EventArgs e)
        {
            if (form2 == null || form2.IsDisposed)
            form2 = new Form2();
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void btnlogreset_Click(object sender, EventArgs e)
        {
            lbLog.Items.Clear();
            lampFlag = 0;
        }
    }
}
