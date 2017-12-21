﻿using System;
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

namespace AttendanceApp
{
    public partial class DailyTimeRecordsForm : Form, DtrInterfaces.IView
    {
        ICollection<string> _discoveredFiles;
        ICollection<string> _errorList;
        ICollection<DtrCommon.Holiday> _holidayList = new List<DtrCommon.Holiday>();
        ICollection<ProcessedResource> _processedResource;
        DataGridViewImageColumn _editbutton;
        BindingSource _bs;
        Color EDITED_COLOR = Color.Pink;
        ErrorForm _errorForm = new ErrorForm();


        public DailyTimeRecordsForm()
        {
            InitializeComponent();

            this.comboBox1.SelectedValueChanged += ComboBox1_SelectedValueChanged;
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
        public event SaveEmployeeRecordsEventHandler SaveEmployeeRecordsEvent;
        public event GetEmployeeListEventHandler GetEmployeeListEvent;
        public event SaveHolidayEventHandler SaveHolidayEvent;
        public event GetClientListEventHandler GetClientListEvent;
        public event SaveClientEventHandler SaveClientEvent;
        public event GetExistingHolidayEventHandler GetExistingHolidayEvent;
        public event GetReportsEventHandler GetReportsEvent;
        public void ShowDtrInfo(DtrInfo info)
        {
            InitInfoView();

            if (info == null)
                return;

            ShowHeaders();
            this.lblId.Text = info.ResourceId;
            this.lblProcRole.Text = info.ProcessRole;
            this.lblTechRole.Text = info.TechnicalRole;
            this.lblTech.Text = info.Technology;
            this.lblSkill.Text = info.SkillLevel;
            this.lblClient.Text = info.ClientName;
            this.lblLocation.Text = info.WorkLocationDefault;
            this.lblTimeIn.Text = DateTime.Parse(info.TimeInScheduleDefault).ToString("HH:mm tt");// info.TimeInScheduleDefault.ToString("HH:mm tt");
            this.lblMonthYear.Text = info.MonthYear;
            this.lblContract.Text = info.ContractRef;
            this.lblProject.Text = info.Project;

            _bs = new BindingSource();
            _bs.DataSource = info.DtrInOut;
            this.dataGridView1.DataSource = _bs;
            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns["DtrInfoRefId"].Visible = false;
            this.dataGridView1.Columns["DtrInfo"].Visible = false;
        //    this.dataGridView1.Columns["LatePerMinute"].Visible = false;
            

            _editbutton = new DataGridViewImageColumn();
            _editbutton.Image = AttendanceApp.Properties.Resources.saveicon;
            _editbutton.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            _editbutton.Width = 50;
            _editbutton.Name = "Save";
            _editbutton.ReadOnly = true;
            dataGridView1.Columns.Add(_editbutton);

            SetWeekendsColumnProperty(Color.White, Color.Blue);

            this.dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            this.dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.dataGridView1.Columns["Save"].Index && this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor == EDITED_COLOR)
            {
                EditDtrInOutEvent?.Invoke((DtrInOut)this.dataGridView1.Rows[e.RowIndex].DataBoundItem);

                if (IsWeekendDate(this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()))
                {
                    this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                    this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Blue;

                    return;
                }
                this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = EDITED_COLOR;
            this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;

            string TimeInSchedule = Convert.ToDateTime(this.dataGridView1[1, e.RowIndex].Value).ToString("MM/dd/yyyy ") + this.dataGridView1[8, e.RowIndex].Value.ToString();
            this.dataGridView1.Rows[e.RowIndex].Cells[10].Value = LatePerMinuteComputation(Convert.ToDateTime(TimeInSchedule), Convert.ToDateTime(this.dataGridView1[1, e.RowIndex].Value));
        }

        private int LatePerMinuteComputation(DateTime TimeInSchedule, DateTime TimeIn)
        {
        
            TimeSpan Late = new TimeSpan(0, 0, 0, 0, 0);
                        
                int result = DateTime.Compare(TimeInSchedule, TimeIn);

                if (result < 0)
                {
                    Late = TimeInSchedule.Subtract(TimeIn);                   
                }
            

            return Math.Abs(Convert.ToInt32(Late.TotalMinutes));
        }

        private void InitInfoView()
        {
            this.lblId.Text = string.Empty;
            this.lblProcRole.Text = string.Empty;
            this.lblTechRole.Text = string.Empty;
            this.lblTech.Text = string.Empty;
            this.lblSkill.Text = string.Empty;
            this.lblClient.Text = string.Empty;
            this.lblLocation.Text = string.Empty;
            this.lblTimeIn.Text = string.Empty;
            this.lblMonthYear.Text = string.Empty;
            this.lblContract.Text = string.Empty;
            this.lblProject.Text = string.Empty;

            this.dataGridView1.CellValueChanged -= DataGridView1_CellValueChanged;
            this.dataGridView1.CellClick -= DataGridView1_CellClick;
            _bs = null;
            this.dataGridView1.DataSource = null;
            _editbutton = null;
            this.dataGridView1.Columns.Clear();

            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = false;
        }

        private void SetWeekendsColumnProperty(Color foreColor, Color backColor)
        {
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                if (this.dataGridView1.Rows[i].Cells[1].Value == null)
                    continue;

                if (IsWeekendDate(this.dataGridView1.Rows[i].Cells[1].Value.ToString()))
                {
                    this.dataGridView1.Rows[i].DefaultCellStyle.ForeColor = foreColor;
                    this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = backColor;
                }

                if (IsHolidayDate(this.dataGridView1.Rows[i].Cells[1].Value.ToString()))
                {
                    this.dataGridView1.Rows[i].DefaultCellStyle.ForeColor = foreColor;
                    this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.ForestGreen;
                }
            }
        }

        private bool IsWeekendDate(string date)
        {
            if ((DateTime.Parse(date).DayOfWeek == DayOfWeek.Saturday) || (DateTime.Parse(date).DayOfWeek == DayOfWeek.Sunday))
            {
                return true;
            }
            return false;
        }

        private bool IsHolidayDate(string date)
        {
            var holidayExist = _holidayList.Where(x => x.HolidayDate == DateTime.Parse(date)).ToList();

            if (holidayExist.Count() > 0)
            {
                return true;
            }
            return false;
        }

        private void ShowHeaders()
        {
            this.lblId.Visible = true;
            this.lblProcRole.Visible = true;
            this.lblTechRole.Visible = true;
            this.lblTech.Visible = true;
            this.lblSkill.Visible = true;
            this.lblClient.Visible = true;
            this.lblLocation.Visible = true;
            this.lblTimeIn.Visible = true;
            this.lblMonthYear.Visible = true;
            this.lblContract.Visible = true;
            this.lblProject.Visible = true;
        }

        public void ShowFiles(ICollection<string> discoveredFiles)
        {
            _discoveredFiles = discoveredFiles;
            this.lblDiscovered.Visible = true;
            this.lblDiscovered.Text = "Discovered: " + discoveredFiles.Count.ToString();
        }

        public void ShowError(ICollection<string> errorFiles)
        {
            _errorList = errorFiles;

            if (errorFiles.Count > 0)
            {
                this.lblError.Visible = true;
            }
            this.lblError.Text = "Error: " + errorFiles.Count.ToString();
        }

        public void ShowProgress(int count, int totalCount)
        {
        }
        public void ShowReportList(ICollection<DtrCommon.Reports> reports)
        { }
        public void ShowProcessedResources(ICollection<ProcessedResource> processed)
        {
            _processedResource = processed;
            this.comboBox1.Items.Clear();
            this.comboBox1.Text = string.Empty;
            foreach (ProcessedResource resource in processed)
            {
                this.comboBox1.Items.Add(resource.ResourceId + " - " + resource.MonthYear);
            }
        }

        public void ShowMessage(string message)
        { }
   
        public void GetExistingRecord(bool existRecord, string holidayDate)
        { }


        private void btnSetSource_Click(object sender, EventArgs e)
        {
            string source = string.Empty;
            using (FolderBrowserDialog openFolder = new FolderBrowserDialog())
            {
                if (openFolder.ShowDialog() == DialogResult.OK)
                {
                    source = openFolder.SelectedPath;
                    this.textBox1.Text = source;
                    GetFilesFromLocalEvent?.Invoke(source);
                    btnReview.Enabled = true;
                }
            }
        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            StartProgressBarEvent?.Invoke(true);
            ParseFilesEvent?.Invoke(_discoveredFiles);
            GetErrorFileListEvent?.Invoke(_errorList);
            StartProgressBarEvent?.Invoke(false);

            if (_discoveredFiles.Count > 0)
            { comboBox1.Enabled = true; btnSaveAllToDb.Enabled = true; }
        }

        private void btnSaveCurrToDb_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want save to the current DTR to the database?", "ATTENTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SaveDtrInfoEvent?.Invoke(this.lblId.Text);
            }
        }

        private void btnSaveAllToDb_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want save to all DTR to the database?", "ATTENTION", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                foreach (var Resource in _processedResource)
                {
                    SaveDtrInfoEvent?.Invoke(Resource.ResourceId);
                }
               
            }
        }

        private void ComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            GetDtrDetailsEvent?.Invoke(this.comboBox1.SelectedItem.ToString());
            btnSaveAllToDb.Enabled = true;
            btnSaveCurrToDb.Enabled = true;
        }

        private void lblError_Click(object sender, EventArgs e)
        {
            _errorForm = new ErrorForm();
            _errorForm.Show();
            _errorForm.ShowError(_errorList);

        }

        public void ShowHolidayList(ICollection<DtrCommon.Holiday> holiday)
        {
            _holidayList = holiday;
        }

        public void ShowEmployeeList(ICollection<DtrCommon.Employee> employee)
        { }

        public void ShowClientList(ICollection<DtrCommon.Client> client)
        { }

    }
}
