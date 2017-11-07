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
        public event GetExistEmployeeRecordEventHandler GetExistEmployeeRecordEvent;

        ICollection<DtrCommon.Employee> _employeeList = new List<DtrCommon.Employee>();
        bool _existEmployeeRecord;

        public EmployeeRecords()
        {
            InitializeComponent();
            GetEmployeeListEvent?.Invoke(null);
        }



        public void InitInfoDetails()
        {
            this.txtEmployeeNo.Text =
            this.txtClient.Text =
            this.txtContract.Text =
            this.txtName.Text =
            this.txtProject.Text =
            this.txtResourceId.Text =
            this.txtSkillLevel.Text =
            this.lblMaternity.Text =
            this.lblPaternity.Text =
            this.lblSL.Text =
            this.lblVL.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            GetExistEmployeeRecordEvent?.Invoke(txtEmployeeNo.Text);

            if (_existEmployeeRecord == true)
            {
              
            }
            else
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
                    Client = txtClient.Text,
                    Contract = txtContract.Text,
                    Project = txtProject.Text,
                    WorkLocation = cmbWorkLocation.Text,
                    Email = txtEmail.Text,
                    Gender = true
                };

                SaveEmployeeRecordsEvent?.Invoke(_employeeRecord);
            }

            GetEmployeeListEvent?.Invoke(null);
        }

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

        public void ExistEmployeeRecord(bool employeeExist)
        {
            _existEmployeeRecord = employeeExist;
        }

        private void btnSearch_Click(object sender, EventArgs e)
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
            txtClient.Text = _empList.Client;
            txtContract.Text = _empList.Contract;
            txtProject.Text = _empList.Project;
            cmbWorkLocation.Text = _empList.WorkLocation;
            txtEmail.Text = _empList.Email;
            //cmbGender.Text = 
        }
    }
}
