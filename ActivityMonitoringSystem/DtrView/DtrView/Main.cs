using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DtrDelegates;

namespace DtrView
{
    public partial class Main : Form
    {
        public event GetFilesFromLocalEventHandler GetFilesFromLocalEvent;
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browser = new FolderBrowserDialog();
            if (browser.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = browser.SelectedPath;

                string[] files = Directory.GetFiles(this.textBox1.Text, "*.xlsx");

                if (files.Length > 0)
                {
                    GetFilesFromLocal(this.textBox1.Text);
                }
                else
                {
                    MessageBox.Show("No Excel files were detected.");
                }
            }
        }

        private void GetFilesFromLocal(string localPath)
        {
            if (GetFilesFromLocalEvent != null)
            {
                GetFilesFromLocalEvent(localPath);
            }
        }
    }
}
