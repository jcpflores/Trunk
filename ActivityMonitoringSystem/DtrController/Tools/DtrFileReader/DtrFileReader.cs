using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Excel= Microsoft.Office.Interop.Excel;   //microsoft Excel 14 object in references-> COM tab
using DtrController.Tools.DtrFileReader.Common;
using DtrModel.Entities;
using DtrCommon;



namespace DtrController.Tools.DtrFileReader 
{
    public class DtrFileReader
    {
        DtrFileModel _Dtr;
        
        

        #region **************** comment *********************
        //public DtrFileReader (IDtrFile dtrfile, IList dtrDataList)
        //{
        //    _dtrDataList = dtrDataList;
        //    dtrfile.SetController(this);
        //}

        //public IList _DtrDataList
        //{
        //    get { return ArrayList.ReadOnly(_dtrDataList); }

        //}



        //public List<IDtrFile> Dtrlist { get; } 
        //public DtrFileReader()
        //{
        //    Dtrlist = new List<IDtrFile>();
        //}


        #endregion*************************

        

        public List<DtrFileModel> ReadFile(string dtrFile)
        {
            var list = new List<DtrFileModel>();
            string _resourceId = "";
            Excel.Application xlsApp = new Excel.Application();
            Excel.Workbook xlsWorkBk = xlsApp.Workbooks.Open(dtrFile);
            xlsWorkBk.Date1904 = true;
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
                    //if (j == 1)
                    // Console.Write("\r\n");

                    //write the value to the console
                    //if (xlsRange.Cells[i, j] != null && xlsRange.Cells[i, j].Value2 != null)
                    //    Console.Write(xlsRange.Cells[i, j].Value2.ToString() + "\t");
                    //if (xlsRange.Cells[i, j] != null && xlsRange.Cells[i, j].Value2 != null)
                    //{

                    if (String.Equals(xlsRange.Cells[i, j].Value2, "1. RESOURCE ID:"))
                    {

                        _resourceId = xlsRange.Cells[i, j + 1].Value2.ToString();
                    }

                    //}

                    if (i >= 12 && i <= rowCount && j <= 18)

                    {
                        _Dtr = new DtrFileModel();
                        _Dtr.ClientName = xlsRange.Cells[i, 6].Value.ToString();
                        _Dtr.Project = xlsRange.Cells[i, 8].Value.ToString();
                        _Dtr.WorkLocation = xlsRange.Cells[i, 9].Value.ToString();
                        _Dtr.TimeInSchedule = xlsRange.Cells[i, 10].Value.ToString();
                     //   _Dtr.DateIn = DateTime.Parse(xlsRange.Cells[i, 11].Value.ToString());
                        var test = xlsRange.Cells[i, 15].Value.ToString();
                        _Dtr.TimeIn = xlsRange.Cells[i, 12].Value == null ? null : DateTime.Parse(xlsRange.Cells[i, 12].Value.ToString());
                       // _Dtr.DateOut = DateTime.Parse(xlsRange.Cells[i, 13].Value.ToString());
                        _Dtr.TimeOut = xlsRange.Cells[i, 14].Value == null ? null : DateTime.Parse(xlsRange.Cells[i, 14].Value.ToString());
                        _Dtr.WorkingHours = xlsRange.Cells[i, 15].Value == null || xlsRange.Cells[i, 15].Value == "" ? 0 : int.Parse(xlsRange.Cells[i, 15].Value.ToString());
                        _Dtr.TimeOffReason = xlsRange.Cells[i, 16].Value.ToString();
                        _Dtr.Notes = xlsRange.Cells[i, 18].Value.ToString();
                        _Dtr.ResourceId = _resourceId;
                        //this.updateViewDetailValues(_Dtr);
                        list.Add(_Dtr);

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

            return list;

        }


        #region////***************************************** D T R  L O G S *****************************************////
   
       
        #endregion

        
    }
}
