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
        public event GetExistingHolidayEventHandler GetExistingHolidayEvent;
        public event GetReportsEventHandler GetReportsEvent;

        ICollection<DtrCommon.Employee> _employeeList = new List<DtrCommon.Employee>();
        ICollection<DtrCommon.Client> _clientList = new List<DtrCommon.Client>();
 
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
        { }

        public void ShowHolidayList(ICollection<DtrCommon.Holiday> holidayList)
        { }

        public void ShowEmployeeList(ICollection<DtrCommon.Employee> employee)
        {
            _employeeList = employee;
        }

        public void ShowClientList(ICollection<DtrCommon.Client> client)
        {
            //dgvClientList.DataSource = client.Select(x => new
            //{
            //    x.ClientName,
            //    x.Contract,
            //    x.TimeIn,
            //    x.TimeOut,
            //    x.Flexi
            //}).ToList();

          _clientList = client;
        }

        public void GetExistingRecord(bool existRecord, string holidayDate)
        { }

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

        //private void dgvClientList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    //tabControl1.SelectedIndex = 1;

        //   // var _clientName = dgvClientList[0, e.RowIndex].Value.ToString();

        //    //dgvClientList.DataSource = _clientList.Where(c => c.ClientName == _clientName).First();

        //    dgvEmployee.DataSource =  _employeeList.Where(x => x.Client == _clientName).ToList();

        //    DataGridViewRow row = this.dgvClientList.Rows[e.RowIndex];
           
        //    txtClientName.Text = dgvClientList[0, e.RowIndex].Value.ToString();
        //    txtContract.Text = dgvClientList[1, e.RowIndex].Value.ToString();
        //    dtpTimeIn.Value = Convert.ToDateTime(dgvClientList[2, e.RowIndex].Value.ToString());
        //    dtpTimeOut.Value = Convert.ToDateTime(dgvClientList[3, e.RowIndex].Value.ToString());
        //    chkFlexi.Checked = Convert.ToBoolean(dgvClientList[4, e.RowIndex].Value);
        //}

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //var myEmployee = _employeeList.Where(x => x.Initial.ToLower() == (txtSearchbox.Text.ToLower())).Single();

                var myClient = _clientList.Where(x => x.ClientName.ToLower() == (txtSearchbox.Text.ToLower())).Single();

                txtClientName.Text = myClient.ClientName;
                txtContract.Text = myClient.Contract;
                dtpTimeIn.Value = Convert.ToDateTime(myClient.TimeIn);
                dtpTimeOut.Value = Convert.ToDateTime(myClient.TimeOut);
                chkFlexi.Checked = Convert.ToBoolean(myClient.Flexi);

                dgvEmployee.DataSource = _employeeList.Where(x => x.Client == txtSearchbox.Text).Select(x => new
                {
                    x.EmpNo,
                    x.Initial                  
                }).ToList();

        }

            catch { }          
        }


    }
}
