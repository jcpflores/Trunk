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
        { }

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
                    Initial = x.First().Initial,
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
            Excel.Application xlApp = new Excel.Application();
            Excel.Range formatRange;

            Workbook xlWorkBook = null;
            Worksheet xlWorkSheet = null;

            xlApp.Visible = false;
            xlApp.StandardFont = "Tahoma";
            xlApp.StandardFontSize = 10;
            xlWorkBook = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets[1];

            formatRange = xlWorkSheet.get_Range("A2", "L2");
            formatRange.EntireRow.Font.Bold = true;
            formatRange.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#BCD6EE");
            formatRange.Borders.Color = System.Drawing.Color.Black;

            xlWorkSheet.Columns[1].ColumnWidth = 26;
            xlWorkSheet.Columns[2].ColumnWidth = 12;
            xlWorkSheet.Columns[3].ColumnWidth = 14;
            xlWorkSheet.Columns[4].ColumnWidth = 14;
            xlWorkSheet.Columns[5].ColumnWidth = 14;
            xlWorkSheet.Columns[11].ColumnWidth = 10;
            xlWorkSheet.Range["A2:L2"].Cells.WrapText = true;
            xlWorkSheet.Range["A2:L2"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            xlWorkSheet.Range["A2:L2"].Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            xlWorkSheet.Rows[2].RowHeight = 28;

            xlWorkSheet.Cells[2, 1] = "Partners Name";
            xlWorkSheet.Cells[2, 2] = "Initial";
            xlWorkSheet.Cells[2, 3] = "Total Minutes of Late";
            xlWorkSheet.Cells[2, 4] = "Total Hours of Late";
            xlWorkSheet.Cells[2, 5] = "Frequency of Tardiness";
            xlWorkSheet.Cells[2, 6] = "Total Leave";
            xlWorkSheet.Cells[2, 7] = "Total SL";
            xlWorkSheet.Cells[2, 8] = "Total EL";
            xlWorkSheet.Cells[2, 9] = "Total VL";
            xlWorkSheet.Cells[2, 10] = "Total HD";
            xlWorkSheet.Cells[2, 11] = "Maternity Leave";
            xlWorkSheet.Cells[2, 12] = "Total SL/EL";

            int i = 3;

            var result = _reports
               .GroupBy(o => o.PartnerName)
               .Select(x => new
               {
                   PartnerName = x.First().PartnerName,
                   Initial = x.First().Initial,
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
                xlWorkSheet.Cells[i, 2] = data.Initial;
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

            xlApp.DisplayAlerts = false;
            xlWorkBook.Worksheets[1].Name = "Summary (Attendance)";
            string _path = @"C:\Temp\";
            string _filename = "AttendanceSummary_" + DateTime.Now.ToString("yyyy_MM_dd hh_mmss");
            xlWorkBook.SaveAs(_path + _filename + ".xlsx");
            xlWorkBook.Close();
            xlApp.Quit();

            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
        }
    }
}
