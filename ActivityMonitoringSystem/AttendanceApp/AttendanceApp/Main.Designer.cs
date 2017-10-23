namespace AttendanceApp
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDtr = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelToday = new System.Windows.Forms.Label();
            this.panelBar = new System.Windows.Forms.Panel();
            this.panelControls = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.panelProcessArea = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelControls.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDtr
            // 
            this.btnDtr.Location = new System.Drawing.Point(3, 3);
            this.btnDtr.Name = "btnDtr";
            this.btnDtr.Size = new System.Drawing.Size(146, 23);
            this.btnDtr.TabIndex = 0;
            this.btnDtr.Text = "Daily Time Records";
            this.btnDtr.UseVisualStyleBackColor = true;
            this.btnDtr.Click += new System.EventHandler(this.btnDtr_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(76, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Attendance Monitoring";
            // 
            // labelToday
            // 
            this.labelToday.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelToday.AutoSize = true;
            this.labelToday.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelToday.ForeColor = System.Drawing.Color.Maroon;
            this.labelToday.Location = new System.Drawing.Point(653, 63);
            this.labelToday.Name = "labelToday";
            this.labelToday.Size = new System.Drawing.Size(111, 13);
            this.labelToday.TabIndex = 3;
            this.labelToday.Text = "dddd, MMMM dd yyyy";
            this.labelToday.Click += new System.EventHandler(this.labelToday_Click);
            // 
            // panelBar
            // 
            this.panelBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBar.BackColor = System.Drawing.Color.Maroon;
            this.panelBar.Location = new System.Drawing.Point(12, 79);
            this.panelBar.Name = "panelBar";
            this.panelBar.Size = new System.Drawing.Size(785, 5);
            this.panelBar.TabIndex = 4;
            // 
            // panelControls
            // 
            this.panelControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelControls.BackColor = System.Drawing.Color.Maroon;
            this.panelControls.Controls.Add(this.btnDtr);
            this.panelControls.Location = new System.Drawing.Point(12, 90);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(153, 345);
            this.panelControls.TabIndex = 5;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 441);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(809, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(700, 16);
            this.toolStripProgressBar1.Visible = false;
            // 
            // panelProcessArea
            // 
            this.panelProcessArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelProcessArea.BackColor = System.Drawing.Color.Silver;
            this.panelProcessArea.Location = new System.Drawing.Point(171, 90);
            this.panelProcessArea.Name = "panelProcessArea";
            this.panelProcessArea.Size = new System.Drawing.Size(626, 345);
            this.panelProcessArea.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::AttendanceApp.Properties.Resources._247Logo;
            this.pictureBox1.Location = new System.Drawing.Point(15, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(782, 48);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(809, 437);
            this.panel1.TabIndex = 9;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(809, 463);
            this.Controls.Add(this.panelProcessArea);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.panelBar);
            this.Controls.Add(this.labelToday);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(825, 500);
            this.Name = "Main";
            this.Text = "Attendance Monitoring";
            this.panelControls.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDtr;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelToday;
        private System.Windows.Forms.Panel panelBar;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panelProcessArea;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
    }
}

