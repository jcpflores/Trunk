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
                _dtrForm.EditDtrInOutEvent += _dtrForm_EditDtrInOutEvent;
                _dtrForm.StartProgressBarEvent += _dtrForm_StartProgressBarEvent;
            }
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
            if(filesToProcess.Count > 0)
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
            _dtrCalendar.MdiParent = this;
            this.panelProcessArea.Controls.Clear();
            _dtrCalendar.Size = this.panel1.Size;
            this.panelProcessArea.Controls.Add(_dtrCalendar);
            _dtrCalendar.Show();
            _dtrCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
        }
    }
}
