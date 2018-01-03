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
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Excel;

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

        ICollection<DtrCommon.Reports> _reports = new List<DtrCommon.Reports>();
         

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
                    LatePerHour = x.Sum(y => y.LatePerHour).ToString(),
                    TardinessFrequency = x.Sum(y => y.TardinessFrequency),
                    TotalLeave = x.Sum(y => y.TotalLeave),
                    SickLeave = x.Sum(y => y.SickLeave),
                    VacationLeave = x.Sum(y => y.VacationLeave),
                    EmergencyLeave = x.Sum(y => y.EmergencyLeave),
                    Halfday = x.Sum(y => y.Halfday),
                    MaternityPaternity = x.Sum(y => y.ParentalLeave),
                }).ToList();


            _reports = reports;         


            if (result.Count > 0)
            {
                dgvReports.DataSource = result;
            }
            else
            {
                MessageBox.Show("No records found!", "Reports", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp = new Excel.Application(); // new Microsoft.Office.Interop.Excel.Application();

            Workbook xlWorkBook = null;
            Worksheet xlWorkSheet = null;

            xlApp.Visible = true;

            xlWorkBook = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);

            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets[1];


            xlWorkSheet.Cells[1, 1].Font.Size = 10;
            xlWorkSheet.Cells[1, 1].Font.FontStyle = System.Drawing.FontStyle.Bold;
            xlWorkSheet.Cells[1, 1].Font.Color = System.Drawing.Color.Black;            
            xlWorkSheet.Cells[1, 1] = "Partners Name";        
            xlWorkSheet.Cells.Borders.Color = System.Drawing.Color.Black;

            xlWorkSheet.Cells[1, 2] = "Initial";
            xlWorkSheet.Cells[1, 3] = "Total Minutes of Late";
            xlWorkSheet.Cells[1, 4] = "Total Hours of Late";
            xlWorkSheet.Cells[1, 5] = "Frequency of Tardiness";
            xlWorkSheet.Cells[1, 6] = "Total Leave";
            xlWorkSheet.Cells[1, 7] = "Total SL";
            xlWorkSheet.Cells[1, 8] = "Total EL";
            xlWorkSheet.Cells[1, 9] = "Total VL";
            xlWorkSheet.Cells[1, 10] = "Total HD";
            xlWorkSheet.Cells[1, 11] = "Maternity Leave";
            xlWorkSheet.Cells[1, 12] = "Total SL/EL";

            int i = 2;




            var result = _reports
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


            foreach (var data in result)
            {

                xlWorkSheet.Cells[i, 1] = data.PartnerName;
                xlWorkSheet.Cells[i, 2] = "";
                xlWorkSheet.Cells[i, 3] = data.LatePerMinute;
                xlWorkSheet.Cells[i, 4] = data.LatePerHour;
                xlWorkSheet.Cells[i, 5] = data.TardinessFrequency;
                xlWorkSheet.Cells[i, 6] = data.TotalLeave;
                xlWorkSheet.Cells[i, 7] = data.SickLeave;
                xlWorkSheet.Cells[i, 8] = data.EmergencyLeave;
                xlWorkSheet.Cells[i, 9] = data.VacationLeave;
                xlWorkSheet.Cells[i, 10] = data.Halfday;
                xlWorkSheet.Cells[i, 11] = data.MaternityPaternity;
                xlWorkSheet.Cells[i, 12] = data.SickLeave + data.EmergencyLeave;               

                i = i + 1;
            }


            xlWorkBook.Worksheets[1].Name = "MySheet";
            xlWorkBook.SaveAs(@"C:\Temp\Test101.xlsx");
            xlWorkBook.Close();
            xlApp.Quit();


            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);


        }
    }
}
