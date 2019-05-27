﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using DtrDelegates;
using DtrModel.Entities;
using System.Diagnostics;

namespace DtrController.Tools.DtrFileReader
{
    public class DtrExcelFile
    {
        ICollection<DtrCommon.DtrInfo> _dtrList;
        ICollection<ExcelErrorFile> _errorFileList = new List<ExcelErrorFile>();
        string _workingHours;

        public event DoneParsingFilesEventHandler DoneParsingFilesEvent;
        public event GetExcelFilesProgressEventHandler GetExcelFilesProgressEvent;
        public event GetExcelErrorFileEventHandler GetExcelErrorFileEvent;


        public void ReadDtrFileFromFolder(ICollection<string> filesToProcess)
        {
            _dtrList = new List<DtrCommon.DtrInfo>();

            int _progressCount = 0;
            foreach (String dtrFile in filesToProcess)
            {
                _dtrList.Add(ReadExcelFileEmployeeDetail(dtrFile));
                _progressCount += 1;
                GetExcelFilesProgressEvent?.Invoke(_progressCount, filesToProcess.Count());
            }
            GetExcelErrorFileEvent?.Invoke();
            DoneParsingFilesEvent?.Invoke();
        }

        public ICollection<ExcelErrorFile> ErrorFile
        {
            get { return _errorFileList; }
        }


        public ICollection<DtrCommon.DtrInfo> ProcessDtr
        {
            get { return _dtrList; }
        }


        private string Flexi(string timeInDefault)
        {
            if (timeInDefault == "Flexi")
            {
                return "Flexi";
            }

            else if (timeInDefault == "")
            {
                return "";
            }

            else
            {
                return DateTime.FromOADate(double.Parse(timeInDefault)).ToString();
            }
        }


        public DtrCommon.DtrInfo ReadExcelFileEmployeeDetail(string FolderPath)
        {
            Excel.Application xlsApp = new Excel.Application();
            Excel.Workbook xlsWorkBk = xlsApp.Workbooks.Open(FolderPath);
            //xlsWorkBk.Date1904 = true;
            bool is1904 = xlsWorkBk.Date1904;
            Excel.Worksheet xlsWorkSht = xlsWorkBk.Sheets["DTR"];
            Excel.Range xlsRange = xlsWorkSht.UsedRange;
          

            DtrCommon.DtrInfo dtrModel = null;

            try
            {
                dtrModel = new DtrCommon.DtrInfo()
                {
                    ResourceId = xlsRange.Cells[5, 3].Value == null ? "" : xlsRange.Cells[5, 3].Value.ToString(),
                    ProcessRole = xlsRange.Cells[6, 3].Value == null ? "" : xlsRange.Cells[6, 3].Value.ToString(),
                    TechnicalRole = xlsRange.Cells[7, 3].Value == null ? "" : xlsRange.Cells[7, 3].Value.ToString(),
                    Technology = xlsRange.Cells[8, 3].Value == null ? "" : xlsRange.Cells[8, 3].Value.ToString(),
                    SkillLevel = xlsRange.Cells[5, 6].Value == null ? "" : xlsRange.Cells[5, 6].Value.ToString(),
                    ClientName = xlsRange.Cells[6, 6].Value == null ? "" : xlsRange.Cells[6, 6].Value.ToString(),
                    ContractRef = xlsRange.Cells[7, 6].Value == null ? "" : xlsRange.Cells[7, 6].Value.ToString(),
                    Project = xlsRange.Cells[8, 6].Value == null ? "" : xlsRange.Cells[8, 6].Value.ToString(),
                    WorkLocationDefault = xlsRange.Cells[5, 9].Value == null ? "" : xlsRange.Cells[5, 9].Value.ToString(),
                    MonthYear = ((string)xlsRange.Cells[12, 2].Value.ToString("y")).Replace(" ", ""),
                    // TimeInScheduleDefault = DateTime.FromOADate(xlsRange.Cells[6, 9].Value == null ? 0 : double.Parse(xlsRange.Cells[6, 9].Value.ToString())),
                    TimeInScheduleDefault = Flexi(xlsRange.Cells[6, 9].Value == null ? "" : xlsRange.Cells[6, 9].Value.ToString()),
                    
                    DtrInOut = new List<DtrCommon.DtrInOut> { }
                };

                DtrCommon.DtrInOut tempInOut;

                //get the last day of the Month
                var lastDayOfMonth = DateTime.DaysInMonth(Convert.ToDateTime(xlsRange.Cells[12, 2].Value).Year, Convert.ToDateTime(xlsRange.Cells[12, 2].Value).Month);

                int count = 1;
                for (int i = 12; count <= lastDayOfMonth; i++)
                {

                    tempInOut = new DtrCommon.DtrInOut();

                    // Date In/Out and Time In/Out

                    DateTime TimeIn = DateTime.FromOADate(xlsRange.Cells[i, 3].Value == null ? 0 : double.Parse(xlsRange.Cells[i, 3].Value.ToString()));
                    DateTime TimeOut = DateTime.FromOADate(xlsRange.Cells[i, 5].Value == null ? 0 : double.Parse(xlsRange.Cells[i, 5].Value.ToString()));

                    tempInOut.DateTimeIn = xlsRange.Cells[i, 2].Value.ToString("d") + " " + String.Format("{0:T}", TimeIn);
                    tempInOut.DateTimeOut = xlsRange.Cells[i, 4].Value.ToString("d") + " " + String.Format("{0:T}", TimeOut);

                    tempInOut.WorkHours = xlsRange.Cells[i, 6].Value == null ? "" : String.Format("{0:0.00}", xlsRange.Cells[i, 6].Value);
                    _workingHours = tempInOut.WorkHours;

                    tempInOut.TimeOffReason = xlsRange.Cells[i, 7].Value == null ? "" : xlsRange.Cells[i, 7].Value.ToString();
                    tempInOut.BillableWorkHours = xlsRange.Cells[i, 8].Value == null ? "" : String.Format("{0:0.00}", xlsRange.Cells[i, 8].Value);
                    tempInOut.Notes = xlsRange.Cells[i, 9].Value == null ? "" : xlsRange.Cells[i, 9].Value.ToString();
                    tempInOut.WorkLocation = xlsRange.Cells[i, 10].Value == null ? "" : xlsRange.Cells[i, 10].Value.ToString();
                    tempInOut.Client = xlsRange.Cells[i, 16].Value == null ? "" : xlsRange.Cells[i, 16].Value.ToString();

                    //  DateTime TimeInSchedule = DateTime.FromOADate(xlsRange.Cells[i, 11].Value == null ? 0 : double.Parse(xlsRange.Cells[i, 11].Value.ToString()));

                    tempInOut.TimeInSchedule = Flexi(xlsRange.Cells[i, 11].Value == null ? "" : xlsRange.Cells[i, 11].Value.ToString());

                    if (tempInOut.TimeInSchedule == "Flexi")
                    {
                        tempInOut.LatePerMinute = 0;
                    }

                    else
                    {
                        tempInOut.LatePerMinute = ComputationLate(DateTime.Parse(tempInOut.TimeInSchedule), TimeIn);
                        tempInOut.TimeInSchedule = DateTime.Parse(tempInOut.TimeInSchedule).ToString("HH:mm tt");
                    }

                   tempInOut.Halfday =  Halfday(DateTime.Parse(tempInOut.DateTimeIn), DateTime.Parse(tempInOut.TimeInSchedule));

                    //Add to Collection
                    dtrModel.DtrInOut.Add(tempInOut);

                    count += 1;
                }
            }

            catch
            {
                //Console.WriteLine(ex.ToString());                                
                _errorFileList.Add(ErrorExcelFilename(FolderPath.Split('\\').Last()));
            }


            finally
            {
                xlsWorkBk.Close(false);
                xlsApp.Application.Quit();
                xlsApp.Quit();
                xlsApp = null;
                xlsWorkBk = null;
                xlsRange = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsWorkSht);

                //xlsApp.Quit();
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsWorkSht);
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsWorkBk);
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsApp);

                foreach (Process procs in Process.GetProcessesByName("Excel"))
                {
                    procs.Kill();
                }

            }
            return dtrModel;

        }

        private int ComputationLate(DateTime TimeInSchedule, DateTime TimeIn)
        {
            //default to 0 minutes late
            TimeSpan Late = new TimeSpan(0, 0, 0, 0, 0);

            if (TimeIn.ToString() != "12/30/1899 12:00:00 AM")
            {
                int result = DateTime.Compare(TimeInSchedule, TimeIn);

                if (result < 0)
                {
                    Late = TimeInSchedule.Subtract(TimeIn);
                }
            }

            return Math.Abs(Convert.ToInt32(Late.TotalMinutes));
        }

        public int Halfday(DateTime TimeIn , DateTime TimeInSchedule)
        {
            //var T1 = String.Format("{0:t}", TimeInSchedule);
            //var T2 = String.Format("{0:t}", TimeIn);
            //var timeDiff = (DateTime.Parse(T1) - DateTime.Parse(T2)).TotalHours;
            //var dasda = (int)(timeDiff);

            if (TimeIn.Hour >= 12)
            {
                return 1;
            }                   
            //below 12PM time in
            else
            {
               if (_workingHours == "")
                {
                    return 0;
                }

               else if (double.Parse(_workingHours) <= 4)
                {
                    return 1;
                }
               else
                { return 0; }
            }
        }


        public ExcelErrorFile ErrorExcelFilename(string name)
        {
            ExcelErrorFile excelErrorList = null;

            excelErrorList = new ExcelErrorFile()
            {
                Filename = name
            };
            return excelErrorList;
        }





    }
}
