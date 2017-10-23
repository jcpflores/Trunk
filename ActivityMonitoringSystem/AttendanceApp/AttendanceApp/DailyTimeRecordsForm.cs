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

        public void ShowDtrInfo(DtrInfo info)
        {
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

            BindingSource bs = new BindingSource();
            bs.DataSource = info.DtrInOut;
            this.dataGridView1.DataSource = bs;

            this.dataGridView1.Columns[0].Visible = false;
            SetWeekendsColor(Color.White, Color.Blue);
        }

        private void SetWeekendsColor(Color foreColor, Color backColor)
        {
            for (int i = 1; i < this.dataGridView1.Rows.Count; i++)
            {
                if (this.dataGridView1.Rows[i].Cells[1].Value == null)
                    continue;

                if ((DateTime.Parse(this.dataGridView1.Rows[i].Cells[1].Value.ToString()).DayOfWeek == DayOfWeek.Saturday) || (DateTime.Parse(this.dataGridView1.Rows[i].Cells[1].Value.ToString()).DayOfWeek == DayOfWeek.Sunday))
                {
                    this.dataGridView1.Rows[i].DefaultCellStyle.ForeColor = foreColor;
                    this.dataGridView1.Rows[i].DefaultCellStyle.BackColor = backColor;
                }
            }
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
            foreach (ProcessedResource resource in processed)
            {
                this.comboBox1.Items.Add(resource.ResourceId + " - " + resource.MonthYear);
            }

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveDtrInfoEvent?.Invoke("All");
        }

        private void btnSaveCurrent_Click(object sender, EventArgs e)
        {
            SaveDtrInfoEvent?.Invoke("Current");
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
