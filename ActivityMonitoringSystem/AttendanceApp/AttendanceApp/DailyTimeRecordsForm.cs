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
