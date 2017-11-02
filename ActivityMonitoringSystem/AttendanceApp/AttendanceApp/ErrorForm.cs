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

        public event GetFilesFromRemoteEventHandler GetFilesFromRemoteEvent;
        public event GetFilesFromLocalEventHandler GetFilesFromLocalEvent;
        public event ParseFilesEventHandler ParseFilesEvent;
        public event SaveDtrInfoEventHandler SaveDtrInfoEvent;
        public event GetDtrDetailsEventHandler GetDtrDetailsEvent;
        public event GetErrorFileListEventHandler GetErrorFileListEvent;
        public event EditDtrInOutEventHandler EditDtrInOutEvent;
        public event StartProgressBarEventHandler StartProgressBarEvent;
        public event GetHolidayListEventHandler GetHolidayListEvent;

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

        public void ShowError(ICollection<string> errorFiles)
        {
            listBoxError.DataSource = errorFiles;
        }

        public void ShowHolidayList(ICollection<DtrCommon.Holiday> holidayList)
        { }

        }
}
