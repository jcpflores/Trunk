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

        private void btnUploadDtr_Click(object sender, EventArgs e)
        {
            string source = string.Empty;
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Multiselect = false;
                openFile.CheckPathExists = true;
                openFile.Filter = "Excel | *.xlsx";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    source = openFile.FileName;
                }
            }

            GetFilesFromLocalEvent?.Invoke(source);
        }
    }
}
