using MonitoringSystem.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.ComponentModel;
using System.Drawing;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using LicenseContext = OfficeOpenXml.LicenseContext;
//using Microsoft.Office.Interop.Excel;
//using Excel = Microsoft.Office.Interop.Excel;

namespace MonitoringSystem
{
    class DataManager
    { 
        public static List<HeaterData> HDatas = new List<HeaterData>();
        public static List<WaterData> WDatas= new List<WaterData>();
        public static List<AirData> ADatas= new List<AirData>();

        public static void SaveToXml()
        {

            XElement root = new XElement("datas");
            string xmlfilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Data.xml");            

            foreach (var item in HDatas)
            {
                
                XElement heaterDataElement = new XElement("heaterdata");

                heaterDataElement.Add(new XElement("date", item.date));
                heaterDataElement.Add(new XElement("time", item.time));
                heaterDataElement.Add(new XElement("value", item.value));
                
                root.Add(heaterDataElement);
            }
            foreach (var item in WDatas)
            {
                
                XElement waterDataElement = new XElement("waterdata");

                waterDataElement.Add(new XElement("date", item.date));
                waterDataElement.Add(new XElement("time", item.time));
                waterDataElement.Add(new XElement("value", item.value));
                
                root.Add(waterDataElement);
            }
            foreach (var item in ADatas)
            {

                XElement airDataElement = new XElement("airdata");

                airDataElement.Add(new XElement("date", item.date));
                airDataElement.Add(new XElement("time", item.time));
                airDataElement.Add(new XElement("value", item.value));
                airDataElement.Add(new XElement("value2", item.value2));

                root.Add(airDataElement);
            }


            XDocument doc = new XDocument(root);
            doc.Save(xmlfilePath);
            Console.WriteLine("XML파일이 생성되었습니다.");
            ConvertXmlToExcel(xmlfilePath);
        }
        public static void ConvertXmlToExcel(string xmlfilePath)
        {
            string excelFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Data.xlsx");

            XDocument doc = XDocument.Load(xmlfilePath);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage())
            {

                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Data");
                worksheet.Cells[1, 1].Value = "Type";
                worksheet.Cells[1, 5].Value = "Type";
                worksheet.Cells[1, 9].Value = "Type";
                worksheet.Cells[1, 2].Value = "Date";
                worksheet.Cells[1, 6].Value = "Date";
                worksheet.Cells[1, 10].Value = "Date";
                worksheet.Cells[1, 3].Value = "Time";
                worksheet.Cells[1, 7].Value = "Time";
                worksheet.Cells[1, 11].Value = "Time";
                worksheet.Cells[1, 4].Value = "Value";
                worksheet.Cells[1, 8].Value = "Value";
                worksheet.Cells[1, 12].Value = "Value";
                worksheet.Cells[1, 13].Value = "Value2";
                using (ExcelRange range = worksheet.Cells["A1:D1"])
                {
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.Orange);
                }
                using (ExcelRange range = worksheet.Cells["E1:H1"])
                {
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.SkyBlue);
                }
                using (ExcelRange range = worksheet.Cells["I1:M1"])
                {
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightSalmon);
                }
                int row = 2;
                int row2 = 2;
                int row3 = 2;

                foreach (XElement element in doc.Descendants("heaterdata"))
                {
                    worksheet.Cells[row, 1].Value = "Heater";
                    worksheet.Cells[row, 2].Value = element.Element("date").Value;
                    worksheet.Cells[row, 3].Value = element.Element("time").Value;
                    worksheet.Cells[row, 4].Value = element.Element("value").Value;
                    row ++;
                }

                foreach (XElement element in doc.Descendants("waterdata"))
                {
                    worksheet.Cells[row2, 5].Value = "Water";
                    worksheet.Cells[row2, 6].Value = element.Element("date").Value;
                    worksheet.Cells[row2, 7].Value = element.Element("time").Value;
                    worksheet.Cells[row2, 8].Value = element.Element("value").Value;
                    row2 ++;
                }
                foreach (XElement element in doc.Descendants("airdata"))
                {
                    worksheet.Cells[row3, 9].Value = "Air";
                    worksheet.Cells[row3, 10].Value = element.Element("date").Value;
                    worksheet.Cells[row3, 11].Value = element.Element("time").Value;
                    worksheet.Cells[row3, 12].Value = element.Element("value").Value;
                    worksheet.Cells[row3, 13].Value = element.Element("value2").Value;
                    row3++;
                }

                package.SaveAs(new FileInfo(excelFilePath));
                Console.WriteLine("Excel 파일이 생성되었습니다.");
            }
        }


    }
}
