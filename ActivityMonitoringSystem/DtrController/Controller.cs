using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DtrInterfaces;
using DtrDelegates;
using DtrController.Tools.DtrFileReader;
using DtrCommon;
using DtrModel.Entities;


namespace DtrController
{
    public class Controller : IController
    {
        IView _view = null;
        DtrModel.AttendanceDbContext _context = null;
        Tools.DtrFileReader.DtrExcelFile _dtrfile = new DtrController.Tools.DtrFileReader.DtrExcelFile();


        public Controller()
        {
            _dtrfile.DoneParsingFilesEvent += _dtrfile_DoneParsingFilesEvent;
            _dtrfile.GetExcelErrorFileEvent += _dtrfile_GetExcelErrorFileEvent;
            _dtrfile.GetExcelFilesProgressEvent += _dtrfile_GetExcelFilesProgressEvent;
            InitializeModel();
        }

        private void _dtrfile_GetExcelFilesProgressEvent(int progressCount, int filesToProcess)
        {
            _view.ShowProgress(progressCount, filesToProcess);
        }

        private void _dtrfile_GetExcelErrorFileEvent()
        {
            ICollection<string> errorFiles = new List<string>();
            foreach (ExcelErrorFile err in _dtrfile.ErrorFile)
            {
                errorFiles.Add(err.Filename);
            }
            _view.ShowError(errorFiles);
        }

        private void _dtrfile_DoneParsingFilesEvent()
        {
            foreach (DtrCommon.DtrInfo dtr in _dtrfile.ProcessDtr)
            {
                if (dtr != null)
                {
                    _context.Set<DtrCommon.DtrInfo>().Add(dtr);
                    _context.SaveChanges();
                }
            }
            QueryTempTableDtr();
        }

        private void InitializeModel()
        {
            _context = DtrModel.Model.GetAttendanceDbContext;
            ClearAllTempTables();
            DtrModel.Model.ChangesSavedEvent += Model_ChangesSavedEvent;
        }

        private void GetHolidays()
        {

            ICollection<DtrCommon.Holiday> holidayList = new List<DtrCommon.Holiday>();

            holidayList = Tools.GoogleHolidayApi.GoogleHolidayApi.GetHolidays();

            var _holidayDb = _context.Set<DtrModel.Entities.Holiday>().Where(t => t.Id != 0).ToList();

            ICollection<DtrCommon.Holiday> _holidayList = new List<DtrCommon.Holiday>();

            foreach (var myHoliday in _holidayDb)
            {
                _holidayList.Add(new DtrCommon.Holiday()
                {
                    Id = myHoliday.Id.ToString(),
                    HolidayDate = myHoliday.HolidayDate,
                    HolidayName = myHoliday.HolidayName
                });
            }

            holidayList = holidayList.Concat(_holidayList).ToList();
            _view.ShowHolidayList(holidayList);

        }

        private void ClearAllTempTables()
        {
            _context.TempDtrInOut.RemoveRange(_context.TempDtrInOut);
            _context.TempDtr.RemoveRange(_context.TempDtr);
            _context.SaveChanges();
        }

        private void Model_ChangesSavedEvent()
        {
        }

        private void QueryTempTableDtr()
        {
            var query = _context.TempDtr;
            ICollection<ProcessedResource> resources = new List<ProcessedResource>();

            foreach (DtrInfo dtr in query)
            {
                resources.Add(new ProcessedResource()
                {
                    ResourceId = dtr.ResourceId,
                    MonthYear = dtr.MonthYear
                });
            }

            _view.ShowProcessedResources(resources);
        }

        private void GetReportsPerPartner(string category, string perPartnerName, string Month, string Year)
        {
            ICollection<DtrCommon.Reports> report = new List<DtrCommon.Reports>();

            var _DailyTimeRecordDb = _context.Set<DtrModel.Entities.DailyTimeRecord>().Where(t => t.Id != 0).ToList();
            var _TimeInOutDb = _context.Set<DtrModel.Entities.TimeInOut>().Where(t => t.Id != 0).ToList();

            if (category == "Per Month")
            {
                try
                {
                    var dtr = _DailyTimeRecordDb.Where(t => t.ResourceId == perPartnerName && t.MonthYear == Month + "," + Year).Single();

                    var timeInOut = _context.Set<DtrModel.Entities.TimeInOut>().Where(t => t.DailyTimeRecordRefId == dtr.Id).ToList();


                    var aggregate = timeInOut
                       .GroupBy(o => o.DailyTimeRecordRefId)
                       .Select(x => new
                       {
                           LatePerMinute = x.Sum(y => y.LatePerMinute),
                           VacationLeave = (from y in timeInOut where y.TimeOffReason == "Vacation Leave" select y).Count(),
                           EmergencyLeave = (from y in timeInOut where y.TimeOffReason == "Emergency Leave" select y).Count(),
                           SickLeave = (from y in timeInOut where y.TimeOffReason == "Sick Leave" select y).Count(),
                           ParentalLeave = (from y in timeInOut where y.TimeOffReason == "Maternity/Paternity Leave" select y).Count()

                       }).Single();
                              

                    TimeSpan spWorkMin = TimeSpan.FromMinutes(aggregate.LatePerMinute);
                    string LatePerHours = spWorkMin.ToString(@"hh\.mm");

                    report.Add(new DtrCommon.Reports()
                    {
                        PartnerName = perPartnerName,
                        MonthYear = dtr.MonthYear,
                        LatePerMinute = aggregate.LatePerMinute,
                        LatePerHour = double.Parse(LatePerHours),
                        TardinessFrequency = 0,
                        TotalLeave = 0,
                        SickLeave = aggregate.SickLeave,
                        VacationLeave = aggregate.VacationLeave,
                        EmergencyLeave = aggregate.EmergencyLeave,
                        Halfday = 0,
                        ParentalLeave = aggregate.ParentalLeave
                    });

                    _view.ShowReportList(report);

                }

                catch { }
            }

            else if (category == "Per Year")
            {


                var dtrYear = _context.Set<DtrModel.Entities.DailyTimeRecord>().Where(t => t.ResourceId == perPartnerName &&
                                     t.MonthYear.Substring(t.MonthYear.Length - 4) == Year).ToList();

                foreach (var dtr in dtrYear)
                {
                    var timeInOut = _context.Set<DtrModel.Entities.TimeInOut>().Where(t => t.DailyTimeRecordRefId == dtr.Id).ToList();

                    var aggregate = timeInOut
                       .GroupBy(o => o.DailyTimeRecordRefId)
                      .Select(x => new
                      {
                          LatePerMinute = x.Sum(y => y.LatePerMinute),
                          VacationLeave = (from y in timeInOut where y.TimeOffReason == "Vacation Leave" select y).Count(),
                          EmergencyLeave = (from y in timeInOut where y.TimeOffReason == "Emergency Leave" select y).Count(),
                          SickLeave = (from y in timeInOut where y.TimeOffReason == "Sick Leave" select y).Count(),
                          ParentalLeave = (from y in timeInOut where y.TimeOffReason == "Maternity/Paternity Leave" select y).Count()
                      }).Single();


                


                    TimeSpan spWorkMin = TimeSpan.FromMinutes(aggregate.LatePerMinute);
                    string LatePerHours = spWorkMin.ToString(@"hh\.mm");

                    report.Add(new DtrCommon.Reports()
                    {
                        PartnerName = perPartnerName,
                        MonthYear = dtr.MonthYear.Substring(dtr.MonthYear.Length - 4),
                        LatePerMinute = aggregate.LatePerMinute,
                        LatePerHour = double.Parse(LatePerHours),
                        TardinessFrequency = 0,
                        TotalLeave = 0,
                        SickLeave = aggregate.SickLeave,
                        VacationLeave = aggregate.VacationLeave,
                        EmergencyLeave = aggregate.EmergencyLeave,
                        Halfday = 0,
                        ParentalLeave = aggregate.ParentalLeave
                    });

                }

                _view.ShowReportList(report);
            }

        }

        private void GetReportsAllPartner(string category, string perPartnerName, string Month, string Year)
        {
            ICollection<DtrCommon.Reports> report = new List<DtrCommon.Reports>();

            var _DailyTimeRecordDb = _context.Set<DtrModel.Entities.DailyTimeRecord>().Where(t => t.Id != 0).ToList();
            var _TimeInOutDb = _context.Set<DtrModel.Entities.TimeInOut>().Where(t => t.Id != 0).ToList();

            if (category == "Per Month")
            {
                var dtrMonth = _DailyTimeRecordDb.Where(t => t.MonthYear == Month + "," + Year).ToList();

                foreach (var dtr in dtrMonth)
                {
                    var timeInOut = _context.Set<DtrModel.Entities.TimeInOut>().Where(t => t.DailyTimeRecordRefId == dtr.Id).ToList();


                    var aggregate = timeInOut
                       .GroupBy(o => o.DailyTimeRecordRefId)
                       .Select(x => new
                       {
                           LatePerMinute = x.Sum(y => y.LatePerMinute),
                           VacationLeave = (from y in timeInOut where y.TimeOffReason == "Vacation Leave" select y).Count(),
                           EmergencyLeave = (from y in timeInOut where y.TimeOffReason == "Emergency Leave" select y).Count(),
                           SickLeave = (from y in timeInOut where y.TimeOffReason == "Sick Leave" select y).Count(),
                           ParentalLeave = (from y in timeInOut where y.TimeOffReason == "Maternity/Paternity Leave" select y).Count()

                       }).Single();

                    TimeSpan spWorkMin = TimeSpan.FromMinutes(aggregate.LatePerMinute);
                    string LatePerHours = spWorkMin.ToString(@"hh\.mm");

                    report.Add(new DtrCommon.Reports()
                    {
                        PartnerName = dtr.ResourceId,
                        MonthYear = dtr.MonthYear,
                        LatePerMinute = aggregate.LatePerMinute,
                        LatePerHour = double.Parse(LatePerHours),
                        TardinessFrequency = 0,
                        TotalLeave = 0,
                        SickLeave = aggregate.SickLeave,
                        VacationLeave = aggregate.VacationLeave,
                        EmergencyLeave = aggregate.EmergencyLeave,
                        Halfday = 0,
                        ParentalLeave = aggregate.ParentalLeave
                    });


                }
                _view.ShowReportList(report);
            }

            else if (category == "Per Year")
            {

                var dtrYear = _context.Set<DtrModel.Entities.DailyTimeRecord>().Where(t =>
                             t.MonthYear.Substring(t.MonthYear.Length - 4) == Year).ToList();

                foreach (var dtr in dtrYear)
                {

                    var timeInOut = _context.Set<DtrModel.Entities.TimeInOut>().Where(t => t.DailyTimeRecordRefId == dtr.Id).ToList();

               
                        var aggregate = timeInOut
                           .GroupBy(o => o.DailyTimeRecordRefId)
                           .Select(x => new
                           {
                               LatePerMinute = x.Sum(y => y.LatePerMinute),
                               VacationLeave = (from y in timeInOut where y.TimeOffReason == "Vacation Leave" select y).Count(),
                               EmergencyLeave = (from y in timeInOut where y.TimeOffReason == "Emergency Leave" select y).Count(),
                               SickLeave = (from y in timeInOut where y.TimeOffReason == "Sick Leave" select y).Count(),
                               ParentalLeave = (from y in timeInOut where y.TimeOffReason == "Maternity/Paternity Leave" select y).Count()

                           }).Single();

                        TimeSpan spWorkMin = TimeSpan.FromMinutes(aggregate.LatePerMinute);
                        string LatePerHours = spWorkMin.ToString(@"hh\.mm");

                        report.Add(new DtrCommon.Reports()
                        {
                            PartnerName = dtr.ResourceId,
                            MonthYear = dtr.MonthYear.Substring(dtr.MonthYear.Length - 4),
                            LatePerMinute = aggregate.LatePerMinute,
                            LatePerHour = double.Parse(LatePerHours),
                            TardinessFrequency = 0,
                            TotalLeave = 0,
                            SickLeave = aggregate.SickLeave,
                            VacationLeave = aggregate.VacationLeave,
                            EmergencyLeave = aggregate.EmergencyLeave,
                            Halfday = 0,
                            ParentalLeave = aggregate.ParentalLeave
                        });

            
                }
                _view.ShowReportList(report);

            }


        }

        #region IController
        public void SetView(IView view)
        {
            _view = view;
            _view.GetFilesFromLocalEvent += _view_GetFilesFromLocalEvent;
            _view.GetDtrDetailsEvent += _view_GetDtrDetailsEvent;
            _view.SaveDtrInfoEvent += _view_SaveDtrInfoEvent;
            _view.ParseFilesEvent += _view_ParseFilesEvent;
            _view.EditDtrInOutEvent += _view_EditDtrInOutEvent;
            _view.GetHolidayListEvent += _view_GetHolidayListEvent;
            _view.SaveEmployeeRecordsEvent += _view_SaveEmployeeRecordsEvent;
            _view.GetEmployeeListEvent += _view_GetEmployeeListEvent;
            _view.SaveHolidayEvent += _view_SaveHolidayEvent;
            _view.SaveClientEvent += _view_SaveClientEvent;
            _view.GetClientListEvent += _view_GetClientListEvent;
            _view.GetExistingHolidayEvent += _view_GetExistingHolidayEvent;
            _view.GetReportsEvent += _view_GetReportsEvent;

        }

        private void _view_GetReportsEvent(string category, string perPartnerName, string Month, string Year)
        {
            if (perPartnerName != "")
            {
                GetReportsPerPartner(category, perPartnerName, Month, Year);
            }
            else
            {
                GetReportsAllPartner(category, perPartnerName, Month, Year);
            }
        }

        private void _view_GetExistingHolidayEvent(bool existRecord, string holidayDate)
        {
            DateTime _holiday = DateTime.Parse(holidayDate);

            bool holidayExists = _context.Set<DtrModel.Entities.Holiday>().Count(t => t.HolidayDate == _holiday) > 0;


            _view.GetExistingRecord(holidayExists, null);
        }

        public void GetClientList()
        {
            ICollection<DtrCommon.Client> _clientList = new List<DtrCommon.Client>();

            var _clientDb = _context.Set<DtrModel.Entities.Client>().Where(t => t.Id != 0).ToList();

            foreach (var myClient in _clientDb)
            {
                _clientList.Add(new DtrCommon.Client()
                {
                    ClientName = myClient.ClientName,
                    Contract = myClient.Contract,
                    TimeIn = myClient.TimeIn,
                    TimeOut = myClient.TimeOut,
                    Flexi = myClient.Flexi
                });
            }

            _view.ShowClientList(_clientList);
        }


        private void _view_GetClientListEvent(DtrCommon.Client clientList)
        {
            GetClientList();
        }

        private void _view_SaveClientEvent(DtrCommon.Client clientRecord)
        {
            _context.Set<DtrModel.Entities.Client>().Add(new DtrModel.Entities.Client
            {
                ClientName = clientRecord.ClientName,
                Contract = clientRecord.Contract,
                TimeIn = clientRecord.TimeIn,
                TimeOut = clientRecord.TimeOut,
                Flexi = clientRecord.Flexi
            });

            _context.SaveChanges();
            //    _view.ShowClientList();
        }



        private void _view_SaveHolidayEvent(DtrCommon.Holiday holiday)
        {
            _context.Set<DtrModel.Entities.Holiday>().Add(new DtrModel.Entities.Holiday
            {
                HolidayName = holiday.HolidayName,
                HolidayDate = holiday.HolidayDate
            });

            _context.SaveChanges();

            ICollection<DtrCommon.Holiday> _holidayList = new List<DtrCommon.Holiday>();

            var _holidayDb = _context.Set<DtrModel.Entities.Holiday>().Where(t => t.Id != 0).ToList();

            foreach (var myHoliday in _holidayDb)
            {
                _holidayList.Add(new DtrCommon.Holiday()
                {
                    HolidayDate = myHoliday.HolidayDate,
                    HolidayName = myHoliday.HolidayName
                });
            }

            GetHolidays();
            //var myHol = Tools.GoogleHolidayApi.GoogleHolidayApi.GetHolidays();
            //myHol = myHol.Concat(_holidayList).ToList();
            //_view.ShowHolidayList(myHol);
        }

        private void _view_GetEmployeeListEvent(DtrCommon.Employee employeeRecord)
        {

            ICollection<DtrCommon.Employee> employeeList = new List<DtrCommon.Employee>();

            var emp = _context.Set<DtrModel.Entities.Employee>().Where(t => t.Id != 0).ToList();

            foreach (var myEmployee in emp)
            {
                employeeList.Add(new DtrCommon.Employee()
                {
                    EmpNo = myEmployee.EmpNo,
                    Initial = myEmployee.Initial,
                    Name = myEmployee.Name,
                    Email = myEmployee.Email,
                    SickLeave = myEmployee.SickLeave,
                    ProcessRole = myEmployee.ProcessRole,
                    TecnicalRole = myEmployee.TechnicalRole,
                    Technology = myEmployee.Technology,
                    SkillLevel = myEmployee.SkillLevel,
                    Client = myEmployee.Client,
                    Contract = myEmployee.Contract,
                    Project = myEmployee.Project,
                    WorkLocation = myEmployee.WorkLocation,
                    VacationLeave = myEmployee.VacationLeave,
                    MaternityLeave = myEmployee.MaternityLeave,
                    PaternityLeave = myEmployee.PaternityLeave,
                    Gender = myEmployee.Gender
                });
            }

            _view.ShowEmployeeList(employeeList);
        }



        private void UpdateEmployeeRecord(DtrCommon.Employee emp)
        {
            //_context.Set<DtrModel.Entities.Employee>()
            //    .Where(u => u.EmpNo == emp.EmpNo).First()
            //    .Name = emp.Name;
            //DtrCommon.Employee e;

            var e = _context.Set<DtrModel.Entities.Employee>().Where(u => u.EmpNo == emp.EmpNo).FirstOrDefault<DtrModel.Entities.Employee>();

            e.Name = emp.Name;
            e.Initial = emp.Initial;
            e.Name = emp.Name;
            e.Email = emp.Email;
            e.ProcessRole = emp.ProcessRole;
            e.TechnicalRole = emp.TecnicalRole;
            e.Technology = emp.Technology;
            e.SkillLevel = emp.SkillLevel;
            e.Client = emp.Client;
            e.Contract = emp.Contract;
            e.Project = emp.Project;
            e.WorkLocation = emp.WorkLocation;
            e.SickLeave = emp.SickLeave;
            e.VacationLeave = emp.VacationLeave;
            e.MaternityLeave = emp.MaternityLeave;
            e.PaternityLeave = emp.PaternityLeave;
            e.Gender = emp.Gender;

            _context.Entry(e).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }


        private void _view_SaveEmployeeRecordsEvent(DtrCommon.Employee employeeRecord)
        {
            bool employeeExists = _context.Set<DtrModel.Entities.Employee>().Count(t => t.EmpNo == employeeRecord.EmpNo) > 0;

            if (employeeExists == true)
            {
                UpdateEmployeeRecord(employeeRecord);
            }
            else
            {
                ICollection<DtrModel.Entities.Employee> emp = new List<DtrModel.Entities.Employee>();

                _context.Set<DtrModel.Entities.Employee>().Add(new DtrModel.Entities.Employee
                {
                    EmpNo = employeeRecord.EmpNo,
                    Initial = employeeRecord.Initial,
                    Name = employeeRecord.Name,
                    Email = employeeRecord.Email,
                    ProcessRole = employeeRecord.ProcessRole,
                    TechnicalRole = employeeRecord.TecnicalRole,
                    Technology = employeeRecord.Technology,
                    SkillLevel = employeeRecord.SkillLevel,
                    Client = employeeRecord.Client,
                    Contract = employeeRecord.Contract,
                    Project = employeeRecord.Project,
                    WorkLocation = employeeRecord.WorkLocation,
                    SickLeave = employeeRecord.SickLeave,
                    VacationLeave = employeeRecord.VacationLeave,
                    MaternityLeave = employeeRecord.MaternityLeave,
                    PaternityLeave = employeeRecord.PaternityLeave,
                    Gender = employeeRecord.Gender
                });
                _context.SaveChanges();
            }
        }



        private void _view_GetHolidayListEvent()
        {
            GetHolidays();
        }

        private void _view_EditDtrInOutEvent(DtrInOut inOut)
        {
            _context.Entry(inOut).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void ReadDtrInformation(string path)
        { }

        public void GetResourceInformation(List<UnprocessedResource> unprocessed)
        { }

        public void GetResourceInformation(UnprocessedResource unprocessed)
        { }

        public void UpdateResource(DtrInfo info)
        { }

        private void _view_SaveDtrInfoEvent(string resourceId)
        {
            if (resourceId.Equals("ALL"))
            { }
            else
            {
                DtrInfo dtrinfo = _context.Set<DtrInfo>()
                    .Where(t => t.ResourceId.Equals(resourceId)).FirstOrDefault<DtrInfo>();

                ICollection<TimeInOut> timeInOutList = new List<TimeInOut>();

                foreach (DtrInOut inOut in dtrinfo.DtrInOut)
                {
                    timeInOutList.Add(new TimeInOut()
                    {
                        DateTimeIn = inOut.DateTimeIn,
                        DateTimeOut = inOut.DateTimeOut,
                        WorkHours = inOut.WorkHours,
                        WorkLocation = inOut.WorkLocation,
                        Client = inOut.Client,
                        TimeOffReason = inOut.TimeOffReason,
                        BillableWorkHours = inOut.BillableWorkHours,
                        Notes = inOut.Notes
                    });
                }

                _context.Set<DailyTimeRecord>().Add(new DailyTimeRecord()
                {
                    ResourceId = dtrinfo.ResourceId,
                    ProcessRole = dtrinfo.ProcessRole,
                    ClientName = dtrinfo.ClientName,
                    ContractRef = dtrinfo.ContractRef,
                    Project = dtrinfo.Project,
                    WorkLocationDefault = dtrinfo.WorkLocationDefault,
                    TimeInScheduleDefault = dtrinfo.TimeInScheduleDefault,
                    TechnicalRole = dtrinfo.TechnicalRole,
                    Technology = dtrinfo.Technology,
                    SkillLevel = dtrinfo.SkillLevel,
                    MonthYear = dtrinfo.MonthYear,
                    TimeInOut = timeInOutList
                });

                _context.Set<DtrInfo>().Remove(dtrinfo);
                _context.SaveChanges();

                _view.ShowDtrInfo(null);
                this.QueryTempTableDtr();
            }
        }

        private void _view_GetDtrDetailsEvent(string resourceId)
        {
            string[] filter = resourceId.Replace(" ", "").Split(new char[] { '-' });
            string resId = filter[0];
            string monthYear = filter[1];


            DtrInfo queryTempTableDtr = _context.TempDtr
                .Where(t => t.ResourceId == resId && t.MonthYear == monthYear).FirstOrDefault<DtrInfo>();

            _view.ShowDtrInfo(queryTempTableDtr);
        }
        private void _view_GetFilesFromLocalEvent(string localPath)
        {
            ICollection<string> xlsxFiles = new List<string>();
            foreach (string dtrFile in Directory.GetFiles(localPath))
            {
                if (dtrFile.EndsWith("xlsx"))
                {
                    xlsxFiles.Add(dtrFile);
                }
            }
            _view.ShowFiles(xlsxFiles);
        }

        private void _view_ParseFilesEvent(ICollection<string> filesToProcess)
        {
            _dtrfile.ReadDtrFileFromFolder(filesToProcess);
        }
        #endregion

        #region Old Code
        /*
        #region***************************  D T R   P R O C E S S  ***************************


        #region ***************************  V I E W   P R O C E S S  ***************************




        private void _view_SaveDtrInfoEvent(string _empID)
        {
            SaveDtrData(_empID);
            _view.ShowMessage("DTR is successfully save!..");
        }
         private void _view_GetDtrDetailsEvent(string resourceId)
        {
            _view.ShowDtrInfo(GetDtrInfo(resourceId));
        }
        private void _view_GetFilesFromLocalEvent(string localPath)
        {
            this.ReadDtrFiles(localPath);
        }  
        public List<DtrLogs> DtrProcessFile(DateTime dateProcess)
        {
            DtrFileReader dfr = new DtrFileReader();
            return getDtrProcessList(dateProcess);
        }
        #endregion

        // ********* get Dtr Info ********** //
        private List<DtrInfo> GetDtrInfo(string _empID)
        {
            var List = new List<DtrInfo>();
            DtrInfo _dtrInfo = new DtrInfo();
            foreach (DailyTimeRecord Dtr in getResourceDtrData(_empID))
            {
                List.Add(updateDtrValues(_dtrInfo, Dtr));

            }
            return List;
        }
        private List<DtrInfo> GetTempDtr(string _empID)
        {
            var List = new List<DtrInfo>();
            DtrInfo _dtrInfo = new DtrInfo();
            foreach (TempTableDtr Dtr in getResourceTempDtrData(_empID))
            {
                List.Add(updateTempDtrValues(_dtrInfo, Dtr));
            }
            return List;
        }
        private List<DailyTimeRecord> _GetTempDtr(string _empID)
        {
            var List = new List<DailyTimeRecord>();
            DailyTimeRecord _dtrInfo = new DailyTimeRecord();
            foreach (TempTableDtr Dtr in getResourceTempDtrData(_empID))
            {
                List.Add(_updateTempDtrValues(_dtrInfo, Dtr));
            }
            return List;
        }
        private DtrInfo updateDtrValues(DtrInfo _commnDtrInfo, DailyTimeRecord _efDtrInfo)
        {

            _commnDtrInfo.EmpId = _efDtrInfo.EmpId;
            _commnDtrInfo.DateIn = _efDtrInfo.DateIn;
            _commnDtrInfo.DateOut = _efDtrInfo.DateOut;
            _commnDtrInfo.TimeIn = _efDtrInfo.TimeIn;
            _commnDtrInfo.TimeOut = _efDtrInfo.TimeOut;
            _commnDtrInfo.Contact = _efDtrInfo.Contact;
            _commnDtrInfo.ProjectId = _efDtrInfo.ProjectId;
            _commnDtrInfo.WorkLocation = _efDtrInfo.WorkLocation;
            _commnDtrInfo.TimeInSchedule = _efDtrInfo.TimeInSchedule;
            _commnDtrInfo.Notes = _efDtrInfo.Notes;
            _commnDtrInfo.Late = _efDtrInfo.Late;
            _commnDtrInfo.Overtime = _efDtrInfo.Overtime;
            _commnDtrInfo.ClientId = _efDtrInfo.ClientId;
            _commnDtrInfo.TimeOffReasonId = _efDtrInfo.TimeOffReasonId;
            _commnDtrInfo.DateProcess = _efDtrInfo.DateProcess;
            return _commnDtrInfo;
        }
        private DtrInfo updateTempDtrValues(DtrInfo _commnDtrInfo, TempTableDtr _efDtrInfo)
        {

            _commnDtrInfo.EmpId = _efDtrInfo.EmpId;
            _commnDtrInfo.DateIn = _efDtrInfo.DateIn;
            _commnDtrInfo.DateOut = _efDtrInfo.DateOut;
            _commnDtrInfo.TimeIn = _efDtrInfo.TimeIn;
            _commnDtrInfo.TimeOut = _efDtrInfo.TimeOut;
            _commnDtrInfo.Contact = _efDtrInfo.Contact;
            _commnDtrInfo.ProjectId = _efDtrInfo.ProjectId;
            _commnDtrInfo.WorkLocation = _efDtrInfo.WorkLocation;
            _commnDtrInfo.TimeInSchedule = _efDtrInfo.TimeInSchedule;
            _commnDtrInfo.Notes = _efDtrInfo.Notes;
            _commnDtrInfo.Late = _efDtrInfo.Late;
            _commnDtrInfo.Overtime = _efDtrInfo.Overtime;
            _commnDtrInfo.ClientId = _efDtrInfo.ClientId;
            _commnDtrInfo.TimeOffReasonId = _efDtrInfo.TimeOffReasonId;
            _commnDtrInfo.DateProcess = _efDtrInfo.DateProcess;
            return _commnDtrInfo;
        }
        private DailyTimeRecord _updateTempDtrValues(DailyTimeRecord _commnDtrInfo, TempTableDtr _efDtrInfo)
        {

            _commnDtrInfo.EmpId = _efDtrInfo.EmpId;
            _commnDtrInfo.DateIn = _efDtrInfo.DateIn;
            _commnDtrInfo.DateOut = _efDtrInfo.DateOut;
            _commnDtrInfo.TimeIn = _efDtrInfo.TimeIn;
            _commnDtrInfo.TimeOut = _efDtrInfo.TimeOut;
            _commnDtrInfo.Contact = _efDtrInfo.Contact;
            _commnDtrInfo.ProjectId = _efDtrInfo.ProjectId;
            _commnDtrInfo.WorkLocation = _efDtrInfo.WorkLocation;
            _commnDtrInfo.TimeInSchedule = _efDtrInfo.TimeInSchedule;
            _commnDtrInfo.Notes = _efDtrInfo.Notes;
            _commnDtrInfo.Late = _efDtrInfo.Late;
            _commnDtrInfo.Overtime = _efDtrInfo.Overtime;
            _commnDtrInfo.ClientId = _efDtrInfo.ClientId;
            _commnDtrInfo.TimeOffReasonId = _efDtrInfo.TimeOffReasonId;
            _commnDtrInfo.DateProcess = _efDtrInfo.DateProcess;
            return _commnDtrInfo;
        }
        // ********* get Dtr Info ********** //

        // ********* get Dtr Logs ********** //
        private List<DtrLogs> getDtrProcessList(DateTime dateProcess)
        {
            var list = new List<DtrLogs>();
            DtrLogs _CommnDtrLgs = new DtrLogs();
            foreach (DtrProcessLog _Dtrlgs in getDtrProcessFileList(dateProcess))
            {
                list.Add(updateDtrLogs(_CommnDtrLgs, _Dtrlgs));
            }
            return list;
        }
        private List<DtrLogs> getDtrProcessList()
        {
            var list = new List<DtrLogs>();
            DtrLogs _CommnDtrLgs = new DtrLogs();
            foreach (DtrProcessLog _Dtrlgs in getDtrProcessFileList())
            {
                list.Add(updateDtrLogs(_CommnDtrLgs, _Dtrlgs));
            }
            return list;
        }
        private DtrLogs updateDtrLogs(DtrLogs _commnDtr, DtrProcessLog _efDtr)
        {
            _commnDtr.ResourceId = _efDtr.ResourceId;
            _commnDtr.EmpName = _efDtr.EmpName;
            _commnDtr.Filename = _efDtr.Filename;
            _commnDtr.DateProcess = _efDtr.DateProcess;
            _commnDtr.Status = _efDtr.Status;
            _commnDtr.Remarks = _efDtr.Remarks;
            _commnDtr.Approve = _efDtr.Approve;
            return _commnDtr;
        }
        // ********* get Dtr Logs ********** //


        // *********reading Files to local path********** //
        public void _ReadDtrFile(string path)
        { ReadDtrFiles(path); }
        private void ReadDtrFiles(string path)
        {
            ReadDtrFileFromFolder(path); 
            _view.ShowProcessedResources(getDtrProcessList());
        }
        private void ReadDtrFileFromFolder(String folderPath)
        {
            DtrFileReader dfr = new DtrFileReader();
            String[] dtrFiles = Directory.GetFiles(folderPath);
            if (folderPath.Equals(String.Empty))
            {
                throw new Exception("Empty path....");

            }

            foreach (String dtrFile in dtrFiles)
            {

                //Dtrlist.Add(this.ReadFile(dtrFile));
                int position = dtrFile.LastIndexOf("\\");
                string path = dtrFile;
                string filname = path.Substring(position + 1);
                SaveDtrLog(dfr.ReadFile(dtrFile), filname, SaveTempDtrData(dfr.ReadFile(dtrFile)));
            }


        }
        // *********reading Files to local path********** //

        #region***************************  L I N Q  D T R  F U N C T I O N  ***************************  
        private bool SaveTempDtrData(List<DtrFileModel> DtrData)
        {
            try
            {
                foreach (DtrFileModel _dtrModel in DtrData)
                {

                    string empId = _EmpId(_dtrModel.ResourceId);
                    int clientId = _clientID(_dtrModel.ClientName);
                    int timeOffReasonId = _timeOffReasonId(_dtrModel.TimeOffReason);
                    int projectId = _projectId(_dtrModel.Project, clientId);

                    context.TempTableDtr.Add(
                      new TempTableDtr
                      {

                          EmpId = empId,
                          DateIn = _dtrModel.DateIn,
                          DateOut = _dtrModel.DateOut,
                          TimeIn = _dtrModel.TimeIn,
                          TimeOut = _dtrModel.TimeOut,
                          Contact = _dtrModel.Contact,
                          ProjectId = projectId,
                          WorkLocation = _dtrModel.WorkLocation,
                          TimeInSchedule = _dtrModel.TimeInSchedule,
                          Notes = _dtrModel.Notes,
                          Late = _dtrModel.Late,
                          Overtime = _dtrModel.Overtime,
                          ClientId = clientId,
                          TimeOffReasonId = timeOffReasonId,
                          DateProcess = DateTime.Today
                      }
                    );
                    context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        private bool SaveDtrData(string _empId)
        {
            try
            {
                using (context)
                {
                    var data = _GetTempDtr(_empId);
                    context.DailyTimeRecord.AddRange(data);
                    context.SaveChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        private void SaveDtrLog(List<DtrFileModel> DtrData,string Filename,bool status)

        {
            foreach (DtrFileModel _dtrModel in DtrData)
            {

                string _resourceId = _EmpId(_dtrModel.ResourceId);
                string _empName = _Empname(_dtrModel.ResourceId);


                context.DtrProcessLog.Add(
                  new DtrProcessLog
                  {

                      ResourceId = _resourceId,
                      Filename = Filename,
                      EmpName = _empName,
                      DateProcess = DateTime.Today,
                      Status = status
                  }
                );
                context.SaveChanges();
                break;
            }

        }
        private int _clientID(string _clientName)
        {

            return context.Client
                    .Where(t => t.ClientName == _clientName)
                    .First()
                    .Id;
        }
        private string _EmpId(string _email)
        {
            return context.Employee
               .Where(t => t.Email.Substring(0, t.Email.IndexOf("@")).ToString() == _email)
               .First()
               .EmpId;
        }
        private string _Empname(string _email)
        {
            return context.Employee
               .Where(t => t.Email.Substring(0, t.Email.IndexOf("@")).ToString() == _email)
               .First()
               .Name;
        }
        private int _timeOffReasonId(string _description)
        {
            return context.TimeOffReason
                .Where(t => t.Description == _description)
                .First()
                .Id;
        }
        private int _projectId(string _description, int _clientRefId)
        {
            return context.Project
                .Where(t => t.ProjectName == _description && t.ClientContractRefId == _clientRefId)
                .First()
                .Id;
        }
        private List<DtrProcessLog> getDtrProcessFileList(DateTime processDate)
        {
            return context.DtrProcessLog
                .Where(t => t.DateProcess == processDate).ToList();
        }
        private List<DtrProcessLog> getDtrProcessFileList()
        {
            return context.DtrProcessLog.ToList();
        }
        private List<DailyTimeRecord> getResourceDtrData(string _empId)
        {
            return context.DailyTimeRecord
                .Where(t => t.EmpId == _empId).ToList();
        }
        private List<TempTableDtr> getResourceTempDtrData(string _empId)
        {
            return context.TempTableDtr
                .Where(t => t.EmpId == _empId).ToList();
        }
        private void UpdateDtrProcessLog(List<DtrProcessLog> dtrLog, DateTime processDate)
        {

            foreach (DtrProcessLog _dtrlog in dtrLog)
            {
                context.DtrProcessLog
               .Where(t => t.ResourceId == _dtrlog.ResourceId && t.DateProcess == processDate)
               .First()
               .Approve = _dtrlog.Approve;

            }

        }

        void IController.ReadDtrFiles(string path)
        {
            throw new NotImplementedException();
        }

        public void UpdateDtrLog(DtrLogs info)
        {
            throw new NotImplementedException();
        }

        #endregion
        #endregion
        */
        #endregion
    }
}
