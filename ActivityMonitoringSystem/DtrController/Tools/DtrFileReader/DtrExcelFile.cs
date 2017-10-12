﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using DtrDelegates;
using DtrModel.Entities;

namespace DtrController.Tools.DtrFileReader
{
    public class DtrExcelFile
    {
        ICollection<TempTableDtr> _dtrList;

        public event DoneParsingFilesEventHandler DoneParsingFilesEvent;

        public void ReadDtrFileFromFolder(ICollection<string> filesToProcess)
        {
            _dtrList = new List<TempTableDtr>();

            foreach (String dtrFile in filesToProcess)
            {
                _dtrList.Add(ReadExcelFileEmployeeDetail(dtrFile));
            }

            DoneParsingFilesEvent?.Invoke();
        }

        public ICollection<TempTableDtr> ProcessDtr
        {
            get { return _dtrList; }
        }

        public TempTableDtr ReadExcelFileEmployeeDetail(string FolderPath)
        {
            Excel.Application xlsApp = new Excel.Application();
            Excel.Workbook xlsWorkBk = xlsApp.Workbooks.Open(FolderPath);
            xlsWorkBk.Date1904 = false;
            Excel.Worksheet xlsWorkSht = xlsWorkBk.Sheets["DTR"];
            Excel.Range xlsRange = xlsWorkSht.UsedRange;

            TempTableDtr dtrModel = null;

            try
            {

                dtrModel = new TempTableDtr()
                {
                    ResourceId = xlsRange.Cells[5, 3].Value.ToString(),
                    ProcessRole = xlsRange.Cells[6, 3].Value.ToString(),
                    TechnicalRole = xlsRange.Cells[7, 3].Value.ToString(),
                    Technology = xlsRange.Cells[8, 3].Value.ToString(),
                    SkillLevel = xlsRange.Cells[5, 6].Value.ToString(),
                    ClientName = xlsRange.Cells[6, 6].Value.ToString(),
                    ContractRef = xlsRange.Cells[7, 6].Value.ToString(),
                    Project = xlsRange.Cells[8, 6].Value.ToString(),
                    WorkLocationDefault = xlsRange.Cells[5, 9].Value.ToString(),
                    MonthYear = xlsRange.Cells[12, 2].Value.ToString("y"),
                    TimeInScheduleDefault = DateTime.FromOADate(xlsRange.Cells[6, 9].Value == null ? 0 : double.Parse(xlsRange.Cells[6, 9].Value.ToString())),

                    TempTableTimeInOut = new List<TempTableTimeInOut> { }

                };

                TempTableTimeInOut tempInOut;

                //get the last day of the Month
                var lastDayOfMonth = DateTime.DaysInMonth(Convert.ToDateTime(xlsRange.Cells[12, 2].Value).Year, Convert.ToDateTime(xlsRange.Cells[12, 2].Value).Month);

                int count = 1;
                for (int i = 12; count <= lastDayOfMonth; i++)
                {                 
                   
                        tempInOut = new TempTableTimeInOut();

                        // Date In/Out and Time In/Out

                        DateTime TimeIn = DateTime.FromOADate(xlsRange.Cells[i, 3].Value == null ? 0 : double.Parse(xlsRange.Cells[i, 3].Value.ToString()));
                        DateTime TimeOut = DateTime.FromOADate(xlsRange.Cells[i, 5].Value == null ? 0 : double.Parse(xlsRange.Cells[i, 5].Value.ToString()));

                        tempInOut.DateTimeIn = xlsRange.Cells[i, 2].Value.ToString("d") + " " + String.Format("{0:T}", TimeIn);
                        tempInOut.DateTimeOut = xlsRange.Cells[i, 4].Value.ToString("d") + " " + String.Format("{0:T}", TimeOut);


                        tempInOut.WorkHours = xlsRange.Cells[i, 6].Value == null ? 0 : xlsRange.Cells[i, 6].Value.ToString();
                        tempInOut.TimeOffReason = xlsRange.Cells[i, 7].Value == null ? "" : xlsRange.Cells[i, 7].Value.ToString();
                        tempInOut.BillableWorkHours = xlsRange.Cells[i, 8].Value == null ? 0 : xlsRange.Cells[i, 8].Value.ToString();
                        tempInOut.Notes = xlsRange.Cells[i, 9].Value == null ? "" : xlsRange.Cells[i, 9].Value.ToString();
                        tempInOut.WorkLocation = xlsRange.Cells[i, 10].Value == null ? "" : xlsRange.Cells[i, 10].Value.ToString();

                        //Add to Collection
                        dtrModel.TempTableTimeInOut.Add(tempInOut);

                    count += 1;
                }


            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            finally
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsWorkSht);                
                xlsWorkBk.Close(false);
                xlsApp.Quit();
                xlsWorkBk = null;
                xlsApp = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            return dtrModel;

        }


    }
}
