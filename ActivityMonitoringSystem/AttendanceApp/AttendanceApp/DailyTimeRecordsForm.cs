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

            this.comboBox1.SelectedValueChanged += ComboBox1_SelectedValueChanged;
        }

        

        public event GetFilesFromLocalEventHandler GetFilesFromLocalEvent;
        public event ParseFilesEventHandler ParseFilesEvent;
        public event SaveDtrInfoEventHandler SaveDtrInfoEvent;
        public event GetDtrDetailsEventHandler GetDtrDetailsEvent;

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
            ParseFilesEvent?.Invoke(null);
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
    }
}
