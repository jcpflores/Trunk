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
            this.btnUploadDtr = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUploadDtr
            // 
            this.btnUploadDtr.Location = new System.Drawing.Point(12, 82);
            this.btnUploadDtr.Name = "btnUploadDtr";
            this.btnUploadDtr.Size = new System.Drawing.Size(125, 23);
            this.btnUploadDtr.TabIndex = 0;
            this.btnUploadDtr.Text = "Upload DTR";
            this.btnUploadDtr.UseVisualStyleBackColor = true;
            this.btnUploadDtr.Click += new System.EventHandler(this.btnUploadDtr_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 463);
            this.Controls.Add(this.btnUploadDtr);
            this.Name = "Main";
            this.Text = "Attendance Monitoring";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUploadDtr;
    }
}

