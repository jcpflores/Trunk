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
using DtrCommon;
using DtrInterfaces;


namespace AttendanceApp
{
    public partial class MaintenanceForm : Form, DtrInterfaces.IView
    {
        public MaintenanceForm()
        {
            InitializeComponent();
            EnableTextbox(false);
            EnabledButtons(true);
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
        public event GetClientListEventHandler GetClientListEvent;
        public event SaveClientEventHandler SaveClientEvent;

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

        public void ShowClientList(ICollection<DtrCommon.Client> client)
        { }

        public void ShowHolidayList(ICollection<DtrCommon.Holiday> holidayList)
        {

            //  holidayList = holidayList.OrderBy(x=>x.HolidayDate).ToList();            
            dgvHolidayList.DataSource = holidayList.OrderBy(x => x.HolidayDate).ToList();
            dgvHolidayList.Columns["HolidayName"].Width = 250;
            dgvHolidayList.Columns["HolidayDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
        }

        public void ShowEmployeeList(ICollection<DtrCommon.Employee> employee)
        { }

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want save to the database?", "ATTENTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DtrCommon.Holiday _holiday = new DtrCommon.Holiday();

                _holiday = new DtrCommon.Holiday()
                {
                    HolidayDate = dtpHoliday.Value,
                    HolidayName = txtHolidayName.Text
                };

                SaveHolidayEvent?.Invoke(_holiday);
                EnableTextbox(false);
                EnabledButtons(true);
            }
        }

        private void dgvHolidayList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EnableTextbox(false);
            DataGridViewRow row = this.dgvHolidayList.Rows[e.RowIndex];
            dtpHoliday.Value = Convert.ToDateTime(row.Cells[0].Value.ToString());
            txtHolidayName.Text = dgvHolidayList[1, e.RowIndex].Value.ToString();
        }

        public void EnableTextbox(bool val)
        {
            txtHolidayName.Enabled = val;
            dtpHoliday.Enabled = val;
        }

        public void EnabledButtons(bool val)
        {
            btnAdd.Enabled = val;
            btnEdit.Enabled = val;
            btnSave.Enabled = !val;
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            EnableTextbox(true);
            EnabledButtons(false);
            txtHolidayName.Text = string.Empty;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EnableTextbox(true);
            EnabledButtons(false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EnabledButtons(true);
            EnableTextbox(false);
        }
    }
}
