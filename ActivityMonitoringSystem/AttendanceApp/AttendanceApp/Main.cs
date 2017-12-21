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
using DtrController;

namespace AttendanceApp
{
    public partial class Main : Form, DtrInterfaces.IView
    {
        DtrController.Controller _controller = null;
        DailyTimeRecordsForm _dtrForm = new DailyTimeRecordsForm();
        Calendar _dtrCalendar = new Calendar();
        EmployeeRecords _dtrEmployee = new EmployeeRecords();
        HolidayForm _dtrHolidayForm = new HolidayForm();
        ClientForm _dtrClientForm = new ClientForm();
        ReportsForm _dtrReportFOrm = new ReportsForm();
        LogsForm _dtrLogForm = new LogsForm();


        public Main()
        {
            InitializeComponent();
            this.labelToday.Text = System.DateTime.Now.ToString("dddd, MMMM dd yyyy");
            _controller = new Controller();
            _controller.SetView(this);
        }

        #region IView
        public event GetFilesFromLocalEventHandler GetFilesFromLocalEvent;
        public event GetFilesFromRemoteEventHandler GetFilesFromRemoteEvent;
        public event ParseFilesEventHandler ParseFilesEvent;
        public event GetDtrDetailsEventHandler GetDtrDetailsEvent;
        public event SaveDtrInfoEventHandler SaveDtrInfoEvent;
        public event EditDtrInOutEventHandler EditDtrInOutEvent;
        public event GetHolidayListEventHandler GetHolidayListEvent;
        public event SaveEmployeeRecordsEventHandler SaveEmployeeRecordsEvent;
        public event GetEmployeeListEventHandler GetEmployeeListEvent;
        public event SaveHolidayEventHandler SaveHolidayEvent;
        public event SaveClientEventHandler SaveClientEvent;
        public event GetClientListEventHandler GetClientListEvent;
        public event GetExistingHolidayEventHandler GetExistingHolidayEvent;
        public event GetReportsEventHandler GetReportsEvent;

        public void ShowFiles(ICollection<string> discoveredFiles)
        {
            //_discoveredFiles = discoveredFiles;
            _dtrForm.ShowFiles(discoveredFiles);
        }

        public void ShowError(ICollection<string> errorFiles)
        {
            _dtrForm.ShowError(errorFiles);
        }

        public void ShowProgress(int processedFiles, int totalFiles)
        {
            this.toolStripProgressBar1.Minimum = 0;
            this.toolStripProgressBar1.Maximum = totalFiles;
            this.toolStripProgressBar1.Value = processedFiles;
        }

        public void ShowProcessedResources(ICollection<ProcessedResource> processed)
        {
            _dtrForm.ShowProcessedResources(processed);
            this.toolStripProgressBar1.Visible = false;
        }

        public void ShowReportList(ICollection<DtrCommon.Reports> reports)
        {
            _dtrReportFOrm.ShowReportList(reports);
        }

        public void ShowDtrInfo(DtrInfo info)
        {
            _dtrForm.ShowDtrInfo(info);
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void ShowHolidayList(ICollection<DtrCommon.Holiday> holiday)
        {
            _dtrHolidayForm.ShowHolidayList(holiday);
            _dtrForm.ShowHolidayList(holiday);
        }

        public void ShowEmployeeList(ICollection<DtrCommon.Employee> employee)
        {
            //GetEmployeeListEvent?.Invoke(employee);
            _dtrEmployee.ShowEmployeeList(employee);
            _dtrClientForm.ShowEmployeeList(employee);
        }

        public void ShowClientList(ICollection<DtrCommon.Client> client)
        {
            _dtrClientForm.ShowClientList(client);
            _dtrEmployee.ShowClientList(client);
        }

        public void GetExistingRecord(bool existRecord, string holidayDate)
        {
            _dtrHolidayForm.GetExistingRecord(existRecord, holidayDate);
        }
        #endregion

        private void btnDtr_Click(object sender, EventArgs e)
        {
          //  if (!_dtrForm.Visible)
          //  {
                _dtrForm = new DailyTimeRecordsForm();
                _dtrForm.MdiParent = this;
                this.panelProcessArea.Controls.Clear();
                _dtrForm.Size = this.panel1.Size;
                this.panelProcessArea.Controls.Add(_dtrForm);
                _dtrForm.Show();
                _dtrForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));

                _dtrForm.GetFilesFromLocalEvent += DtrForm_GetFilesFromLocalEvent;
                _dtrForm.ParseFilesEvent += _dtrForm_ParseFilesEvent;
                _dtrForm.SaveDtrInfoEvent += _dtrForm_SaveDtrInfoEvent;
                _dtrForm.GetDtrDetailsEvent += _dtrForm_GetDtrDetailsEvent;
                _dtrForm.EditDtrInOutEvent += _dtrForm_EditDtrInOutEvent;
                _dtrForm.StartProgressBarEvent += _dtrForm_StartProgressBarEvent;
                _dtrForm.GetHolidayListEvent += _dtrForm_GetHolidayListEvent;

                GetHolidayListEvent?.Invoke();
           // }
        }



        private void _dtrForm_GetHolidayListEvent()
        {
            GetHolidayListEvent?.Invoke();
        }

        private void _dtrForm_StartProgressBarEvent(bool startProgressBar)
        {
            this.toolStripProgressBar1.Visible = startProgressBar;
        }

        private void _dtrForm_EditDtrInOutEvent(DtrInOut inOut)
        {
            EditDtrInOutEvent?.Invoke(inOut);
        }

        private void _dtrForm_GetDtrDetailsEvent(string resourceId)
        {
            GetDtrDetailsEvent?.Invoke(resourceId);
        }

        private void _dtrForm_SaveDtrInfoEvent(string resourceId)
        {
            SaveDtrInfoEvent?.Invoke(resourceId);
        }

        private void _dtrForm_ParseFilesEvent(ICollection<string> filesToProcess)
        {
            if (filesToProcess.Count > 0)
                ParseFilesEvent?.Invoke(filesToProcess);
        }

        private void DtrForm_GetFilesFromLocalEvent(string localPath)
        {
            GetFilesFromLocalEvent?.Invoke(localPath);
            //_dtrfile.ReadDtrFileFromFolder(localPath);
        }

        private void labelToday_Click(Object sender, EventArgs e)
        {
            _dtrCalendar = new Calendar();
            _dtrCalendar.Show();
        }



        private void btnEmployee_Click(object sender, EventArgs e)
        {

        }

        private void _dtrEmployee_SaveHolidayEvent(Holiday holiday)
        {
            SaveHolidayEvent?.Invoke(holiday);
        }

        private void _dtrEmployee_GetEmployeeListEvent(Employee employeeRecord)
        {
            GetEmployeeListEvent?.Invoke(employeeRecord);
        }

        private void _dtrEmployee_SaveEmployeeRecordsEvent(Employee employeeRecord)
        {
            SaveEmployeeRecordsEvent?.Invoke(employeeRecord);
        }

        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(btnMaintenance, 0, btnMaintenance.Height);
        }

        private void _dtrMaintenanceForm_GetExistingHolidayEvent(bool existRecord, string holidayDate)
        {
            GetExistingHolidayEvent?.Invoke(false, holidayDate);

        }



        private void _dtrClientForm_GetClientListEvent(Client clientList)
        {
            GetClientListEvent?.Invoke(clientList);
        }

        private void _dtrClientForm_SaveClientEvent(Client clientRecord)
        {
            SaveClientEvent?.Invoke(clientRecord);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            _dtrReportFOrm = new ReportsForm();
            _dtrReportFOrm.MdiParent = this;
            this.panelProcessArea.Controls.Clear();
            _dtrReportFOrm.Size = this.panel1.Size;
            this.panelProcessArea.Controls.Add(_dtrReportFOrm);
            _dtrReportFOrm.Show();
            _dtrReportFOrm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            _dtrReportFOrm.GetReportsEvent += _dtrReportFOrm_GetReportsEvent;

           // GetReportsEvent?.Invoke(null, null, null, null);
        }

        private void _dtrReportFOrm_GetReportsEvent(string category , string perPartnerName, string month, string year )
        {
            GetReportsEvent?.Invoke(category, perPartnerName, month, year);
        }

        private void employeeRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _dtrEmployee = new EmployeeRecords();
            _dtrEmployee.MdiParent = this;
            this.panelProcessArea.Controls.Clear();
            _dtrEmployee.Size = this.panel1.Size;
            this.panelProcessArea.Controls.Add(_dtrEmployee);
            _dtrEmployee.Show();
            _dtrEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            _dtrEmployee.SaveEmployeeRecordsEvent += _dtrEmployee_SaveEmployeeRecordsEvent;
            _dtrEmployee.GetEmployeeListEvent += _dtrEmployee_GetEmployeeListEvent;

            GetClientListEvent?.Invoke(null);
            GetEmployeeListEvent?.Invoke(null);
        }

        private void holidayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _dtrHolidayForm = new HolidayForm();
            _dtrHolidayForm.MdiParent = this;
            this.panelProcessArea.Controls.Clear();
            _dtrHolidayForm.Size = this.panel1.Size;
            this.panelProcessArea.Controls.Add(_dtrHolidayForm);
            _dtrHolidayForm.Show();
            _dtrHolidayForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            _dtrHolidayForm.SaveHolidayEvent += _dtrEmployee_SaveHolidayEvent;
            _dtrHolidayForm.GetExistingHolidayEvent += _dtrMaintenanceForm_GetExistingHolidayEvent;

            GetHolidayListEvent?.Invoke();
        }

        private void clientRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _dtrClientForm = new ClientForm();
            _dtrClientForm.MdiParent = this;
            this.panelProcessArea.Controls.Clear();
            _dtrClientForm.Size = this.panel1.Size;
            this.panelProcessArea.Controls.Add(_dtrClientForm);
            _dtrClientForm.Show();
            _dtrClientForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            _dtrClientForm.SaveClientEvent += _dtrClientForm_SaveClientEvent;
            _dtrClientForm.GetClientListEvent += _dtrClientForm_GetClientListEvent;

            GetClientListEvent?.Invoke(null);
            GetEmployeeListEvent?.Invoke(null);
        }


        private void logsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _dtrLogForm = new LogsForm();
            _dtrLogForm.MdiParent = this;
            this.panelProcessArea.Controls.Clear();
            _dtrLogForm.Size = this.panel1.Size;
            this.panelProcessArea.Controls.Add(_dtrLogForm);
            _dtrLogForm.Show();
            _dtrLogForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
        }
    }
}
