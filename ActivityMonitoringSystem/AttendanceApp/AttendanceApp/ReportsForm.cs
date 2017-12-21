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
    public partial class ReportsForm : Form, DtrInterfaces.IView
    {
        public ReportsForm()
        {
            InitializeComponent();
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
        }

        public void GetExistingRecord(bool existRecord, string holidayDate)
        { }

        public void ShowReportList(ICollection<DtrCommon.Reports> reports)
        {
            dgvReports.DataSource = null;

            var result = reports
                .GroupBy(o => o.PartnerName)
                .Select(x => new
                {
                    PartnerName = x.First().PartnerName,
                    MonthYear = x.First().MonthYear,
                    LatePerMinute = x.Sum(y => y.LatePerMinute),
                    LatePerHour = x.Sum(y => y.LatePerHour),
                    TardinessFrequency = x.Sum(y => y.TardinessFrequency),
                    TotalLeave = x.Sum(y => y.TotalLeave),
                    SickLeave = x.Sum(y => y.SickLeave),
                    VacationLeave = x.Sum(y => y.VacationLeave),
                    EmergencyLeave = x.Sum(y => y.EmergencyLeave),
                    Halfday = x.Sum(y => y.Halfday),
                    MaternityPaternity = x.Sum(y => y.ParentalLeave),
                }).ToList();

            if (result.Count > 0)
            {
                dgvReports.DataSource = result;
            }
            else
            {
                MessageBox.Show("No records found!","Reports",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetReportsEvent?.Invoke(cmbCategory.Text, txtPartnerName.Text, cmbMonth.Text, cmbYear.Text);
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbCategory.Text == "Per Month")
            {
                cmbMonth.Enabled = true;
                cmbYear.Enabled = true;
            }
            else if (cmbCategory.Text == "Per Year")
            {
                cmbMonth.Enabled = false;
                cmbYear.Enabled = true;
            }
        }
    }
}
