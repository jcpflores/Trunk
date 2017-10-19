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

        public void ShowFiles(ICollection<string> discoveredFiles)
        {
            //_discoveredFiles = discoveredFiles;
            _dtrForm.ShowFiles(discoveredFiles);
        }

        public void ShowProcessedResources(ICollection<ProcessedResource> processed)
        {
            _dtrForm.ShowProcessedResources(processed);
        }

        public void ShowDtrInfo(DtrInfo info)
        {
            _dtrForm.ShowDtrInfo(info);
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
        #endregion

        private void btnDtr_Click(object sender, EventArgs e)
        {
            if(!_dtrForm.Visible)
            { 
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
            }
        }

        private void _dtrForm_GetDtrDetailsEvent(string resourceId)
        {
            GetDtrDetailsEvent?.Invoke(resourceId);
        }

        private void _dtrForm_SaveDtrInfoEvent(string empId)
        {
            SaveDtrInfoEvent?.Invoke(empId);
        }

        private void _dtrForm_ParseFilesEvent(ICollection<string> filesToProcess)
        {
            if(filesToProcess.Count > 0)
                ParseFilesEvent?.Invoke(filesToProcess);
        }

        private void DtrForm_GetFilesFromLocalEvent(string localPath)
        {
            GetFilesFromLocalEvent?.Invoke(localPath);
            //_dtrfile.ReadDtrFileFromFolder(localPath);
        }
    }
}
