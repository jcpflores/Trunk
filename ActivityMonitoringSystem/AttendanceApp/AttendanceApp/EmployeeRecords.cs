using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DtrCommon;
using DtrDelegates;



namespace AttendanceApp
{
    public partial class EmployeeRecords : Form, DtrInterfaces.IView
    {
        ICollection<DtrCommon.Employee> _employeeList = new List<DtrCommon.Employee>();


        public EmployeeRecords()
        {
            InitializeComponent();
            GetEmployeeListEvent?.Invoke(null);
            EnableTextbox(false);
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
        public event GetExistingHolidayEventHandler GetExistingHolidayEvent;

        public void ShowEmployeeList(ICollection<DtrCommon.Employee> employee)
        {
            //var emp = _context.Set<DtrModel.Entities.Employee>()
            //    .Select(x => new { x.EmpNo, x.Initial, x.Name });
            _employeeList = employee;
            dgvEmployeeList.DataSource = employee.Select(x => new
            {
                x.EmpNo,
                x.Initial,
                x.Name,
                x.Email,
                x.Technology,
                x.ProcessRole,
                x.TecnicalRole
            }).ToList();

            dgvEmployeeList.Columns["Name"].Width = 250;
            dgvEmployeeList.Columns["ProcessRole"].Width = 120;
            dgvEmployeeList.Columns["Email"].Width = 200;


        }

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

        public void ShowClientList(ICollection<DtrCommon.Client> client)
        {
            cmbClient.DataSource = client.Select(x => x.ClientName).ToList();
        }

        public void GetExistingRecord(bool existRecord, string holidayDate)
        { }
        #endregion



        public void InitInfoDetails()
        {
            this.txtEmployeeNo.Text =
            this.cmbClient.Text =
            this.txtContract.Text =
            this.txtName.Text =
            this.txtProject.Text =
            this.txtResourceId.Text =
            this.txtSkillLevel.Text =
            this.cmbProcessRole.Text =
            this.cmbTechnicalRole.Text =
            this.cmbTechnology.Text =
            this.cmbWorkLocation.Text =
            this.txtMaternity.Text =
            this.txtPaternity.Text =
            this.txtSL.Text =
            this.txtVL.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            DtrCommon.Employee _employeeRecord = new DtrCommon.Employee();

            _employeeRecord = new DtrCommon.Employee()
            {
                EmpNo = txtEmployeeNo.Text,
                Initial = txtResourceId.Text,
                Name = txtName.Text,
                ProcessRole = cmbProcessRole.Text,
                TecnicalRole = cmbTechnicalRole.Text,
                Technology = cmbTechnology.Text,
                SkillLevel = txtSkillLevel.Text,
                Client = cmbClient.Text,
                Contract = txtContract.Text,
                Project = txtProject.Text,
                WorkLocation = cmbWorkLocation.Text,
                Email = txtEmail.Text,
                Gender = rbMale.Checked
            };

            SaveEmployeeRecordsEvent?.Invoke(_employeeRecord);

            GetEmployeeListEvent?.Invoke(null);
            EnableTextbox(false);
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                var myEmployee = _employeeList.Where(x => x.Initial.Contains(txtSearchbox.Text)).First();

                txtEmployeeNo.Text = myEmployee.EmpNo;
                txtName.Text = myEmployee.Name;
                txtResourceId.Text = myEmployee.Initial;
                cmbProcessRole.Text = myEmployee.ProcessRole;
                cmbTechnicalRole.Text = myEmployee.TecnicalRole;
                cmbTechnology.Text = myEmployee.Technology;
                txtSkillLevel.Text = myEmployee.SkillLevel;
                cmbClient.Text = myEmployee.Client;
                txtContract.Text = myEmployee.Contract;
                txtProject.Text = myEmployee.Project;
                cmbWorkLocation.Text = myEmployee.WorkLocation;
                txtEmail.Text = myEmployee.Email;
                if (myEmployee.Gender)
                { rbMale.Checked = myEmployee.Gender; }
                else
                { rbFemale.Checked = true; }
            }
            
            catch
            {

            }

        }


        private void dgvEmployeeList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tabControl1.SelectedIndex = 1;

            var _empNo = dgvEmployeeList[0, e.RowIndex].Value.ToString();

            var _empList = _employeeList.Where(x => x.EmpNo == _empNo).First();

            txtEmployeeNo.Text = _empList.EmpNo;
            txtName.Text = _empList.Name;
            txtResourceId.Text = _empList.Initial;
            cmbProcessRole.Text = _empList.ProcessRole;
            cmbTechnicalRole.Text = _empList.TecnicalRole;
            cmbTechnology.Text = _empList.Technology;
            txtSkillLevel.Text = _empList.SkillLevel;
            cmbClient.Text = _empList.Client;
            txtContract.Text = _empList.Contract;
            txtProject.Text = _empList.Project;
            cmbWorkLocation.Text = _empList.WorkLocation;
            txtEmail.Text = _empList.Email;
            if (_empList.Gender)
            { rbMale.Checked = _empList.Gender; }
            else
            { rbFemale.Checked = true; }
        }



        public void EnableTextbox(bool val)
        {
            txtEmployeeNo.Enabled =
            txtName.Enabled =
            txtResourceId.Enabled =
            cmbProcessRole.Enabled =
            cmbTechnicalRole.Enabled =
            cmbTechnology.Enabled =
            txtSkillLevel.Enabled =
            cmbClient.Enabled =
            txtContract.Enabled =
            txtProject.Enabled =
            cmbWorkLocation.Enabled =
            txtEmail.Enabled =
            rbMale.Enabled =
            rbFemale.Enabled = val;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EnableTextbox(true);
            InitInfoDetails();
        }

        private void btnSearch_TextChanged(object sender, EventArgs e)
        {
            dgvEmployeeList.DataSource = _employeeList.Where(x => x.Name.Contains(txtSearchbox.Text))
              .Select(x => new
              {
                  x.EmpNo,
                  x.Initial,
                  x.Name,
                  x.Email,
                  x.Technology,
                  x.ProcessRole,
                  x.TecnicalRole
              }).ToList();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EnableTextbox(true);
        }
    }
}
