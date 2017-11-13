using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DtrDelegates;
using DtrInterfaces;
using DtrCommon;

namespace AttendanceApp
{
    public partial class ClientForm : Form, DtrInterfaces.IView
    {
        public ClientForm()
        {
            InitializeComponent();
        
        }

        public void InitInfoDetails()
        {
            txtClientName.Text =
            txtContract.Text = 
            txtSearchbox.Text = string.Empty;
        }

        #region IView
        public event GetFilesFromLocalEventHandler GetFilesFromLocalEvent;
        public event ParseFilesEventHandler ParseFilesEvent;
        public event SaveDtrInfoEventHandler SaveDtrInfoEvent;
        public event GetDtrDetailsEventHandler GetDtrDetailsEvent;
        public event GetErrorFileListEventHandler GetErrorFileListEvent;
        public event EditDtrInOutEventHandler EditDtrInOutEvent;
        public event StartProgressBarEventHandler StartProgressBarEvent;
        public event GetHolidayListEventHandler GetHolidayListEvent;
        public event GetFilesFromRemoteEventHandler GetFilesFromRemoteEvent;
        public event SaveEmployeeRecordsEventHandler SaveEmployeeRecordsEvent;
        public event GetEmployeeListEventHandler GetEmployeeListEvent;
        public event SaveHolidayEventHandler SaveHolidayEvent;
        public event SaveClientEventHandler SaveClientEvent;
        public event GetClientListEventHandler GetClientListEvent;


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
        { }

        public void ShowHolidayList(ICollection<DtrCommon.Holiday> holidayList)
        { }

        public void ShowEmployeeList(ICollection<DtrCommon.Employee> employee)
        { }

        public void ShowClientList(ICollection<DtrCommon.Client> client)
        {
            dgvClientList.DataSource = client.Select(x => new
            {
                x.ClientName,
                x.Contract,
                x.TimeIn,
                x.TimeOut,
                x.Flexi
            }).ToList();
        }

        #endregion


        private void btnSave_Click(object sender, EventArgs e)
        {
            DtrCommon.Client _clientRecord = new DtrCommon.Client();

            _clientRecord = new DtrCommon.Client()
            {
                ClientName = txtClientName.Text,
                Contract = txtContract.Text,
                TimeIn = dtpTimeIn.Value.ToString("hh:mm tt"),
                TimeOut = dtpTimeOut.Value.ToString("hh:mm tt"),
                Flexi = chkFlexi.Checked
            };
            SaveClientEvent?.Invoke(_clientRecord);
            GetClientListEvent?.Invoke(null);
        }

    

    }
}
