using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DtrInterfaces;
using DtrDelegates;
using DtrController.Tools.DtrFileReader;
using DtrController.Tools.DtrFileReader.Common;
using DtrCommon;
using DtrModel.Entities;


namespace DtrController
{
    public class Controller : IController
    {
        public Controller()
        {
        }

        IView _view = null;
        DtrModel.AttendanceDbContext context = DtrModel.Model.GetAttendanceDbContext;

        #region IController
        public void SetView(IView view)
        {
            _view = view;
            _view.GetFilesFromLocalEvent += _view_GetFilesFromLocalEvent;
            _view.GetDtrDetailsEvent += _view_GetDtrDetailsEvent;
            _view.SaveDtrInfoEvent += _view_SaveDtrInfoEvent;
        }

        public void ReadDtrInformation(string path)
        { }

        public void GetResourceInformation(List<UnprocessedResource> unprocessed)
        { }

        public void GetResourceInformation(UnprocessedResource unprocessed)
        { }

        public void UpdateResource(DtrInfo info)
        { }

        private void _view_SaveDtrInfoEvent(string _empID)
        {
            //SaveDtrData(_empID);
            _view.ShowMessage("DTR is successfully save!..");
        }
        private void _view_GetDtrDetailsEvent(string resourceId)
        {
            //_view.ShowDtrInfo(GetDtrInfo(resourceId));
        }
        private void _view_GetFilesFromLocalEvent(string localPath)
        {
            //this.ReadDtrFiles(localPath);
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
