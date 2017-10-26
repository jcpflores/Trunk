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

namespace AttendanceApp
{
    public partial class DailyTimeRecordsForm : Form, DtrInterfaces.IView
    {
        ICollection<string> _discoveredFiles;
        ICollection<string> _errorList;
        DataGridViewImageColumn _editbutton;
        BindingSource _bs;
        Color EDITED_COLOR = Color.Pink;

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

        public void ShowDtrInfo(DtrInfo info)
        {
            InitDatagridView();

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
            this.lblTimeIn.Text = info.TimeInScheduleDefault.ToString("HH:mm tt");
            this.lblMonthYear.Text = info.MonthYear;
            this.lblContract.Text = info.ContractRef;
            this.lblProject.Text = info.Project;

            _bs = new BindingSource();
            _bs.DataSource = info.DtrInOut;
            this.dataGridView1.DataSource = _bs;
            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns["DtrInfoRefId"].Visible = false;
            this.dataGridView1.Columns["DtrInfo"].Visible = false;

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
        }

        private void InitDatagridView()
        {
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
            this.lblError.Visible = true;
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
            this.lblError.Visible = true;
            this.lblError.Text = "Error: " + errorFiles.Count.ToString();
            listBoxError.DataSource = errorFiles;
        }

        public void ShowProgress(int count, int totalCount)
        {
        }

        public void ShowProcessedResources(ICollection<ProcessedResource> processed)
        {
            this.comboBox1.Items.Clear();
            this.comboBox1.Text = string.Empty;
            foreach (ProcessedResource resource in processed)
            {
                this.comboBox1.Items.Add(resource.ResourceId + " - " + resource.MonthYear);
            }

            if (processed != null)
                MessageBox.Show("DTRs are now ready for reviewing!");

        }

        public void ShowMessage(string message)
        {
        }

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
                }
            }
        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            ParseFilesEvent?.Invoke(_discoveredFiles);
            GetErrorFileListEvent?.Invoke(_errorList);
        }

        private void btnSaveCurrToDb_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want save to the current DAR to the database?", "ATTENTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SaveDtrInfoEvent?.Invoke(this.lblId.Text);
            }
        }

        private void btnSaveAllToDb_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want save to all DAR to the database?", "ATTENTION", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SaveDtrInfoEvent?.Invoke(null);
            }
        }

        private void ComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            GetDtrDetailsEvent?.Invoke(this.comboBox1.SelectedItem.ToString());
        }

        private void lblError_MouseHover(object sender, EventArgs e)
        {
            this.listBoxError.Visible = true;
            this.listBoxError.Width = 300;
            this.listBoxError.Height = 300;
            this.listBoxError.Location = new Point(350, 25);
        }

        private void lblError_MouseLeave(object sender, EventArgs e)
        {
            this.listBoxError.Visible = false;
            this.listBoxError.Location = new Point(350, 25);

        }
    }
}
