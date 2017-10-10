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

namespace AttendanceApp
{
    public partial class DailyTimeRecordsForm : Form
    {
        public DailyTimeRecordsForm()
        {
            InitializeComponent();
        }

        public event GetFilesFromLocalEventHandler GetFilesFromLocalEvent;

        private void btnSetSource_Click(object sender, EventArgs e)
        {
            string source = string.Empty;
            using (FolderBrowserDialog openFolder = new FolderBrowserDialog())
            {
                if (openFolder.ShowDialog() == DialogResult.OK)
                {
                    source = openFolder.SelectedPath;
                }
            }

            GetFilesFromLocalEvent?.Invoke(source);
        }
    }
}
