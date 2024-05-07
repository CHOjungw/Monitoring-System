using MonitoringSystem.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;

namespace MonitoringSystem
{
    class DataManager
    { 
        public static List<HeaterData> HDatas = new List<HeaterData>();
        public static List<WaterData> WDatas= new List<WaterData>();
        public static List<AirData> ADatas= new List<AirData>();

        XElement root;   


        public DataManager()
        {

            xmlDoc = new XmlDocument.Load("Data.xml");
            //Load();
        }
       

        //public void Load()
        //{
        //    xmlDoc.Load(@"./Data.xml");            
        //}
        public static void Save()
        {
            string hdataOutput = "";
            hdataOutput += "<datas>\n<data>\n";
            foreach(var item in HDatas)
            {
                hdataOutput += "<heaterdata>\n";
                hdataOutput += "<date>" + item.date+"</date>";
                hdataOutput += "<time>" + item.time + "</time>";
                hdataOutput += "<value>" + item.value + "</value>";
                hdataOutput += "</heaterdata>\n";
            }
            hdataOutput += "</data>\n</datas>\n";
            string wdataOutput = "";
            wdataOutput += "<datas>\n<data>\n";
            foreach (var item in WDatas)
            {
                wdataOutput += "<waterdata>\n";
                wdataOutput += "<date>" + item.date + "</date>";
                wdataOutput += "<time>" + item.time + "</time>";
                wdataOutput += "<value>" + item.value + "</value>";
                wdataOutput += "</waterdata>\n";
            }
            wdataOutput += "</data>\n</datas>\n";
            string adataOutput = "";
            adataOutput += "<datas>\n<data>\n";
            foreach (var item in ADatas)
            {
                adataOutput += "<airdata>\n";
                adataOutput += "<date>" + item.date + "</date>";
                adataOutput += "<time>" + item.time + "</time>";
                adataOutput += "<value>" + item.value + "</value>";
                adataOutput += "</airdata>\n";
            }
            adataOutput += "</data>\n</datas>\n";
            File.WriteAllText(@"./Data.xml", hdataOutput);
            File.WriteAllText(@"./Data.xml", wdataOutput);
            File.WriteAllText(@"./Data.xml", adataOutput);
            
        }
        public void XmlSave()
        {
            xmlDoc.Save(@"./Data.xml");
        }
    }
}
