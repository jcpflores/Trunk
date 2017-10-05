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

        public void ShowFiles(string[] discoveredFiles)
        { }

        public void ShowProcessedResources(List<ProcessedResource> processed)
        { }

        public void ShowDtrInfo(DtrInfo info)
        { }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
        #endregion

        private void btnDtr_Click(object sender, EventArgs e)
        {
            DailyTimeRecordsForm dtrForm = new DailyTimeRecordsForm();
            dtrForm.MdiParent = this;
            this.panelProcessArea.Controls.Clear();
            dtrForm.Size = this.panel1.Size;
            this.panelProcessArea.Controls.Add(dtrForm);
            dtrForm.Show();
            dtrForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));

            //string source = string.Empty;
            //using (OpenFileDialog openFile = new OpenFileDialog())
            //{
            //    openFile.Multiselect = false;
            //    openFile.CheckPathExists = true;
            //    openFile.Filter = "Excel | *.xlsx";
            //    if (openFile.ShowDialog() == DialogResult.OK)
            //    {
            //        source = openFile.FileName;
            //    }
            //}

            //GetFilesFromLocalEvent?.Invoke(source);
        }
    }
}
