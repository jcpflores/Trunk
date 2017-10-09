using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace DtrController.Tools.DtrFileReader
{
    public class DtrExcelFile
    {


        DtrController.Tools.DtrFileReader.Common.DtrFileModel DtrFileModel = new DtrController.Tools.DtrFileReader.Common.DtrFileModel();

        public void ReadDtrFileFromFolder(string FolderPath)
        {
            string[] TimeIn, TimeOut;
            DtrFileReader dfr = new DtrFileReader();
            string path = Path.GetDirectoryName(FolderPath);
            string[] dtrFiles = Directory.GetFiles(path);

            foreach (String dtrFile in dtrFiles)
            {
                ReadExcelFileEmployeeDetail(dtrFile);
                TimeIn = ReadExcelFileTimeIn(dtrFile);
                TimeOut = ReadExcelFileTimeOut(dtrFile);

                List<string> ArrayListTimeIn = new List<string>(TimeIn);
                List<string> ArrayListTimeOn = new List<string>(TimeOut);
            }
        }


        public void ReadExcelFileEmployeeDetail(string FolderPath)
        {
            Excel.Application xlsApp = new Excel.Application();
            Excel.Workbook xlsWorkBk = xlsApp.Workbooks.Open(FolderPath);
            xlsWorkBk.Date1904 = true;
            Excel.Worksheet xlsWorkSht = xlsWorkBk.Sheets["DTR"];
            Excel.Range xlsRange = xlsWorkSht.UsedRange;

            DtrFileModel.ResourceId = xlsRange.Cells[5, 3].Value.ToString();
            DtrFileModel.ProcessRole = xlsRange.Cells[6, 3].Value.ToString();
            DtrFileModel.TechnicalRole = xlsRange.Cells[7, 3].Value.ToString();
            DtrFileModel.Technology = xlsRange.Cells[8, 3].Value.ToString();
            DtrFileModel.SkillLevel = xlsRange.Cells[5, 6].Value.ToString();
            DtrFileModel.ClientName = xlsRange.Cells[6, 6].Value.ToString();
            DtrFileModel.ContractRef = xlsRange.Cells[7, 6].Value.ToString();
            DtrFileModel.Project = xlsRange.Cells[8, 6].Value.ToString();
            DtrFileModel.WorkLocation = xlsRange.Cells[5, 9].Value.ToString();
            double _TimeIn = xlsRange.Cells[6, 9].Value == null ? 0 : double.Parse(xlsRange.Cells[6, 9].Value.ToString());
            DateTime _ConvTimeIn = DateTime.FromOADate(_TimeIn);
            DtrFileModel.TimeInSchedule = _ConvTimeIn.ToString("t");

            xlsWorkBk.Close(false);
            xlsApp.Quit();
        }

        public string[] ReadExcelFileTimeIn(string FolderPath)
        {

            Excel.Application xlsApp = new Excel.Application();
            Excel.Workbook xlsWorkBk = xlsApp.Workbooks.Open(FolderPath);
            xlsWorkBk.Date1904 = true;
            Excel.Worksheet xlsWorkSht = xlsWorkBk.Sheets["DTR"];
            Excel.Range xlsRange = xlsWorkSht.UsedRange;

            string[] ExcelFile = new string[31];

            for (int i = 1; i <= 1; i++)
            {
                int ctr = 0;
                for (int j = 12; j <= 42; j++)
                {
                    double day1 = xlsRange.Cells[j, 3].Value == null ? 0 : double.Parse(xlsRange.Cells[j, 3].Value.ToString());
                    DateTime conv = DateTime.FromOADate(day1);

                    ExcelFile[ctr] += conv.ToString("H:mm");
                    ctr += 1;
                }

                xlsWorkBk.Close(false);
                xlsApp.Quit();
            }

            return ExcelFile;

        }

        

        public string[] ReadExcelFileTimeOut(string FolderPath)
        {

            Excel.Application xlsApp = new Excel.Application();
            Excel.Workbook xlsWorkBk = xlsApp.Workbooks.Open(FolderPath);
            xlsWorkBk.Date1904 = true;
            Excel.Worksheet xlsWorkSht = xlsWorkBk.Sheets["DTR"];
            Excel.Range xlsRange = xlsWorkSht.UsedRange;
            
            string[] ExcelFile = new string[31];

            for (int i = 1; i <= 1; i++)
            {

                int ctr = 0;
                for (int j = 12; j <= 42; j++)
                {
                    double day1 = xlsRange.Cells[j, 5].Value == null ? 0 : double.Parse(xlsRange.Cells[j, 5].Value.ToString());
                    DateTime conv = DateTime.FromOADate(day1);

                    ExcelFile[ctr] += conv.ToString("H:mm");
                    ctr += 1;
                }


                xlsWorkBk.Close(false);
                xlsApp.Quit();
            }

            return ExcelFile;
        }



    }
}
