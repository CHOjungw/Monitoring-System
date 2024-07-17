using MonitoringSystem.Properties;
using MQTTnet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static OfficeOpenXml.ExcelErrorValue;


namespace MonitoringSystem
{
    public partial class Form1 : Form
    {
        public string _deviceName;
        private Mqtt _mqttClient;
        Timer timer = new Timer();
        Random random = new Random();
        private DataManager dataManager = new DataManager();
        private SetValue setValue;
        private TempController tempController;

        private HeaterData heaterData; 
        private WaterData waterData;  
        private AirData airData;

        int lampFlag = 0;
        private Form2 form2;
        int av1 = 0;
        int av2 = 0;
        int hv =  0;
        int wv = 0;
        bool compdrain = true;
        int WaterLeakCount = 0;

        PIDController pIDController;
        public struct equipData
        {
            public int av1;
            public int av2;
            public int hv;
            public int wv;
        }
        public equipData _equipData;


        public Form1(string deviceName)
        {
            _equipData = new equipData();
            _deviceName= deviceName;
            setValue = new SetValue();
            form2 = new Form2();
            InitializeComponent();

            _mqttClient = new Mqtt(_deviceName);
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;            
            airData = new AirData(DateTime.Now.ToShortDateString(), DateTime.Now.ToString("HH:mm:ss"), 0, 0);
            waterData = new WaterData(DateTime.Now.ToShortDateString(), DateTime.Now.ToString("HH:mm:ss"), 0);
            heaterData = new HeaterData(DateTime.Now.ToShortDateString(), DateTime.Now.ToString("HH:mm:ss"), 0);
            
            _mqttClient.ConnectionStatusChanged += Mqttmanager_ConnectionStatusChanged;
            _mqttClient.MessageReceived += Mqttmanager_MessegeReceive;

            tempController = new TempController(this, 0.005, 0.0005, 0.01);
        }
        
        public void simulation()
        {
            if(setValue.AIRV1 == 0)
            {
                _equipData.av1 = random.Next(750, 770);
            }
            else if(setValue.AIRV1 != null) 
            {
                _equipData.av1 = (int)setValue.AIRV1;
                if(_equipData.av1 < setValue.AIRV1) 
                {
                    _equipData.av1 += random.Next(0, 2);
                }
                else if (_equipData.av1 > setValue.AIRV1) 
                {
                    _equipData.av1 -= random.Next(0,2);
                }
                else
                {
                    _equipData.av1 += random.Next(-2, 2);
                }
            }
            if (setValue.AIRV2 == 0)
            {
                _equipData.av2 = random.Next(750, 770);
            }
            else if (setValue.AIRV2 != null)
            {
                _equipData.av2 = (int)setValue.AIRV2;
                if (_equipData.av2 < setValue.AIRV2)
                {
                    _equipData.av2 += random.Next(0, 2);
                }
                else if (_equipData.av2 > setValue.AIRV1)
                {
                    _equipData.av2 -= random.Next(0, 2);
                }
            }

            if (setValue.HVValue == 0)
            {
                if (_equipData.hv <= 700)
                {
                    _equipData.hv += tempController.TimerElapsed(setValue.HVValue);
                }
                else
                {
                    _equipData.hv += tempController.TimerElapsed(setValue.HVValue);
                }
            }
            else if(setValue.HVValue != 0)
            {
                if(_equipData.hv <= setValue.HVValue)
                {
                    _equipData.hv += tempController.TimerElapsed(setValue.HVValue); ;
                }
                else if (_equipData.hv >= setValue.HVValue)
                {
                    _equipData.hv += tempController.TimerElapsed(setValue.HVValue);
                }
            }

            if (setValue.WVValue == 0)
            {
                if (_equipData.wv <= 80 && compdrain == true)
                {
                    _equipData.wv += 10;
                    drain(false);
                }
                else
                {
                    compdrain = false;
                    drain(true);

                }
            }
            else if (setValue.WVValue != null)
            {
                if (_equipData.wv <= setValue.WVValue)
                {
                    _equipData.wv += 10;
                    drain(false);
                }
                else if (_equipData.wv >= setValue.WVValue)
                {
                    if (_equipData.wv > setValue.WVValue)
                    {
                        compdrain = false;
                        drain(true);
                    }
                }
            }
            waterLeak(_equipData.wv);
            ShowValue(_equipData.av1, _equipData.av2, _equipData.wv, _equipData.hv);
            
        }
        private void drain(bool value)
        {
            
            checkedListBox1.SetItemChecked(0, value);
            if (value) 
            {
                _equipData.wv -= 10;
                if (_equipData.wv <= 30) compdrain = true;
            }
        }
        private void waterLeak(int wv)
        {
            
            if (DataManager.WDatas.Count >= 1)
            {
                double lastvalue = DataManager.WDatas[DataManager.WDatas.Count - 1].value;

                if (compdrain == true && lastvalue > wv)
                {
                    WaterLeakCount++;
                }
                else WaterLeakCount = 0;
                if (WaterLeakCount >= 2) checkedListBox1.SetItemChecked(1, true);
                else checkedListBox1.SetItemChecked(1, false);
            }
        }
        public string ToFormatString()
        {
            return $"{_equipData.av1},{_equipData.av2},{_equipData.hv},{_equipData.wv}";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {                          
            simulation();
            _mqttClient.PublishMessage("status",ToFormatString());


            Lamp_Contol();
            Error_Log();
            
            DataManager.SaveToXml();
        }
        public void ShowValue(int av1,int av2,int wv,int hv)
        {
            airData = new AirData(DateTime.Now.ToShortDateString(), DateTime.Now.ToString("HH:mm:ss"), _equipData.av1, _equipData.av2);
            waterData = new WaterData(DateTime.Now.ToShortDateString(), DateTime.Now.ToString("HH:mm:ss"), _equipData.wv);
            heaterData = new HeaterData(DateTime.Now.ToShortDateString(), DateTime.Now.ToString("HH:mm:ss"), _equipData.hv);
            Console.WriteLine(waterData.date);
            Console.ReadLine();
            DataManager.HDatas.Add(heaterData);
            DataManager.WDatas.Add(waterData);
            DataManager.ADatas.Add(airData);
            
            //debug
            Console.WriteLine(DataManager.HDatas.Count);
            if(form2 != null && form2.Visible)
            form2.ChartAddPoint(_equipData.av1, _equipData.av2, _equipData.wv, _equipData.hv);

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
                SendError(ErrorLog);
            }
            else if(heaterData.value>=850)
            {
                ErrorLog = heatHighTemp + errorString;
                lbLog.Items.Insert(0,ErrorLog);
                lampFlag = 2;
                SendError(ErrorLog);
            }            
            
            if(waterData.value >= 100)
            {
                ErrorLog = waterOverFlow + errorString;
                lbLog.Items.Insert(0, ErrorLog);
                lampFlag = 2;
                SendError(ErrorLog);
            }
            else if (waterData.value <= 10)
            {
                ErrorLog = waterLowFlow + errorString;
                lbLog.Items.Insert(0, ErrorLog);
                lampFlag = 1;
                SendError(ErrorLog);
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
        public void Mqttmanager_ConnectionStatusChanged(object sender, string status)
        {
            Invoke((Action)(() =>
            {
                textBox1.Text = status;
            }));
        }
        public void Mqttmanager_MessegeReceive(object sender, MqttApplicationMessageReceivedEventArgs e)
        {

            var payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
            var parts = payload.Split('/');

            switch (parts[0])
            {
                case "Heater Temp":
                    setValue.HVValue = double.Parse(parts[1]);
                    break;
                case "Water Level":
                    setValue.WVValue = double.Parse(parts[1]);
                    break;
                case "Air Pressure1":
                    setValue.AIRV1 = double.Parse(parts[1]);
                    break;
                case "Air Pressure2":
                    setValue.AIRV2 = double.Parse(parts[1]);
                    break;
                case "Turn Off":
                    Invoke((Action)(() =>
                    {
                        timer.Stop();
                        Console.WriteLine("Timer stopped.");
                    }));
                    break;
                case "Turn On":
                    Invoke((Action)(() =>
                    {
                        timer.Dispose();
                        timer = new Timer();
                        timer.Interval = 1000;
                        timer.Tick += Timer_Tick;
                        timer.Start();
                        Console.WriteLine("Timer started.");
                    }));
                    break;
            }          
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                await _mqttClient.StartAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Faild to start Mqtt client : {ex.Message}");
            }
            timer.Start();
        }
        private void SendError(string message)
        {
            _mqttClient.PublishMessage("error",message);
        }
    }
}
