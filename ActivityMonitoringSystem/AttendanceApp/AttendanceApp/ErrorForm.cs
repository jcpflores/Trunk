using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DtrInterfaces;
using DtrDelegates;
using DtrCommon;


namespace AttendanceApp
{
    public partial class ErrorForm : Form, DtrInterfaces.IView
    {
        public ErrorForm()
        {
            InitializeComponent();
        }

        #region IView

        public event GetFilesFromRemoteEventHandler GetFilesFromRemoteEvent;
        public event GetFilesFromLocalEventHandler GetFilesFromLocalEvent;
        public event ParseFilesEventHandler ParseFilesEvent;
        public event SaveDtrInfoEventHandler SaveDtrInfoEvent;
        public event GetDtrDetailsEventHandler GetDtrDetailsEvent;
        public event GetErrorFileListEventHandler GetErrorFileListEvent;
        public event EditDtrInOutEventHandler EditDtrInOutEvent;
        public event StartProgressBarEventHandler StartProgressBarEvent;
        public event GetHolidayListEventHandler GetHolidayListEvent;
        public event SaveEmployeeRecordsEventHandler SaveEmployeeRecordsEvent;
        public event GetEmployeeListEventHandler GetEmployeeListEvent;
        public event SaveHolidayEventHandler SaveHolidayEvent;
        public event GetClientListEventHandler GetClientListEvent;
        public event SaveClientEventHandler SaveClientEvent;
        public event GetExistingHolidayEventHandler GetExistingHolidayEvent;
        public event GetReportsEventHandler GetReportsEvent;

        public void ShowDtrInfo(DtrInfo info)
        { }
        public void ShowFiles(ICollection<string> discoveredFiles)
        { }

        public void ShowProgress(int count, int totalCount)
        { }

        public void ShowProcessedResources(ICollection<ProcessedResource> processed)
        { }
        public void ShowMessage(string message)
        { }
        public void ShowReportList(ICollection<DtrCommon.Reports> reports)
        { }
        public void ShowError(ICollection<string> errorFiles)
        {
            listBoxError.DataSource = errorFiles;
        }

        public void ShowHolidayList(ICollection<DtrCommon.Holiday> holidayList)
        { }

        public void ShowEmployeeList(ICollection<DtrCommon.Employee> employee)
        { }

        public void ShowClientList(ICollection<DtrCommon.Client> client)
        { }

        public void GetExistingRecord(bool existRecord, string holidayDate)
        { }        
        

        #endregion

    }
}
