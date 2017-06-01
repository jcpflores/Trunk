using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Excel= Microsoft.Office.Interop.Excel;   //microsoft Excel 14 object in references-> COM tab
using DtrController.Tools.DtrFileReader.Common;


namespace DtrController.Tools.DtrFileReader 
{
    public class DtrFileReader
    {
        //IDtrFile _dtrFile;
        //String _dtrFolderPath;
       


        public List<IDtrFile> Dtrlist { get; } 
        public DtrFileReader()
        {
            Dtrlist = new List<IDtrFile>();
        }

        public void ReadDtrFileFromFolder(String folderPath)
        {
            String[] dtrFiles= Directory.GetFiles(folderPath);
            if (folderPath.Equals(String.Empty))
            {
                throw new Exception("Empty path....");

            }

            foreach (String dtrFile in dtrFiles)
            {

                Dtrlist.Add( this.ReadFile(dtrFile)); 
                //Dtrlist.Add(dtrFile);
            }


        }
        private IDtrFile ReadFile(string dtrFile)
        {
            
            Excel.Application xlsApp = new Excel.Application();
            Excel.Workbook xlsWorkBk = xlsApp.Workbooks.Open(dtrFile);
            Excel.Worksheet xlsWorkSht = xlsWorkBk.Sheets["DTR"];
            Excel.Range xlsRange = xlsWorkSht.UsedRange;


            int rowCount = xlsRange.Rows.Count;
            int colCount = xlsRange.Columns.Count;

            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!
            for (int i = 1; i <= rowCount; i++)
            {
                for (int j = 1; j <= colCount; j++)
                {
                    //new line
                    if (j == 1)
                        Console.Write("\r\n");

                    //write the value to the console
                    //if (xlsRange.Cells[i, j] != null && xlsRange.Cells[i, j].Value2 != null)
                    //    Console.Write(xlsRange.Cells[i, j].Value2.ToString() + "\t");
                    if (xlsRange.Cells[i, j] != null && xlsRange.Cells[i, j].Value2 != null)
                    {

                        if (String.Equals(xlsRange.Cells[i, j].Value2, "1. RESOURCE ID:"))
                        {
                            
                            var ID = xlsRange.Cells[i, j + 1].Value2.ToString();
                        }
                           
                    }
                            
                        
                }
            }


            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlsRange);
            Marshal.ReleaseComObject(xlsWorkSht);

            //close and release
            xlsWorkBk.Close();
            Marshal.ReleaseComObject(xlsWorkBk);

            //quit and release
            xlsApp.Quit();
            Marshal.ReleaseComObject(xlsApp);

            return null;

        }

    }
}
