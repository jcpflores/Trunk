namespace AttendanceApp
{
    partial class EmployeeRecords
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtSearchbox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvEmployeeList = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMaternity = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lblPaternity = new System.Windows.Forms.Label();
            this.txtEmployeeNo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblVL = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtResourceId = new System.Windows.Forms.TextBox();
            this.lblSL = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbProcessRole = new System.Windows.Forms.ComboBox();
            this.cmbTechnicalRole = new System.Windows.Forms.ComboBox();
            this.cmbTechnology = new System.Windows.Forms.ComboBox();
            this.cmbWorkLocation = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSkillLevel = new System.Windows.Forms.TextBox();
            this.txtProject = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtClient = new System.Windows.Forms.TextBox();
            this.txtContract = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeList)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(703, 476);
            this.tabControl1.TabIndex = 36;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtSearchbox);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.btnSearch);
            this.tabPage1.Controls.Add(this.dgvEmployeeList);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(695, 450);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Employee List";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtSearchbox
            // 
            this.txtSearchbox.Location = new System.Drawing.Point(89, 40);
            this.txtSearchbox.Name = "txtSearchbox";
            this.txtSearchbox.Size = new System.Drawing.Size(250, 20);
            this.txtSearchbox.TabIndex = 3;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(42, 43);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 13);
            this.label18.TabIndex = 2;
            this.label18.Text = "Search";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(366, 40);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvEmployeeList
            // 
            this.dgvEmployeeList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmployeeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployeeList.Location = new System.Drawing.Point(33, 69);
            this.dgvEmployeeList.Name = "dgvEmployeeList";
            this.dgvEmployeeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployeeList.Size = new System.Drawing.Size(383, 189);
            this.dgvEmployeeList.TabIndex = 0;
            this.dgvEmployeeList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployeeList_CellContentClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.cmbGender);
            this.tabPage2.Controls.Add(this.txtEmail);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.lblMaternity);
            this.tabPage2.Controls.Add(this.btnSave);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.btnEdit);
            this.tabPage2.Controls.Add(this.lblPaternity);
            this.tabPage2.Controls.Add(this.txtEmployeeNo);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.btnAdd);
            this.tabPage2.Controls.Add(this.lblVL);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.txtResourceId);
            this.tabPage2.Controls.Add(this.lblSL);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.txtName);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.cmbProcessRole);
            this.tabPage2.Controls.Add(this.cmbTechnicalRole);
            this.tabPage2.Controls.Add(this.cmbTechnology);
            this.tabPage2.Controls.Add(this.cmbWorkLocation);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.txtSkillLevel);
            this.tabPage2.Controls.Add(this.txtProject);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.txtClient);
            this.tabPage2.Controls.Add(this.txtContract);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(954, 450);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Employee Details";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(345, 62);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(45, 13);
            this.label16.TabIndex = 71;
            this.label16.Text = "Gender:";
            // 
            // cmbGender
            // 
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cmbGender.Location = new System.Drawing.Point(403, 59);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(199, 21);
            this.cmbGender.TabIndex = 72;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(403, 23);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(199, 20);
            this.txtEmail.TabIndex = 70;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(345, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 69;
            this.label13.Text = "Email:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Employee No.:";
            // 
            // lblMaternity
            // 
            this.lblMaternity.AutoSize = true;
            this.lblMaternity.Location = new System.Drawing.Point(452, 188);
            this.lblMaternity.Name = "lblMaternity";
            this.lblMaternity.Size = new System.Drawing.Size(13, 13);
            this.lblMaternity.TabIndex = 65;
            this.lblMaternity.Text = "0";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(565, 382);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 68;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(345, 188);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(106, 13);
            this.label17.TabIndex = 64;
            this.label17.Text = "Remaining Maternity:";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(484, 382);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 67;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // lblPaternity
            // 
            this.lblPaternity.AutoSize = true;
            this.lblPaternity.Location = new System.Drawing.Point(452, 158);
            this.lblPaternity.Name = "lblPaternity";
            this.lblPaternity.Size = new System.Drawing.Size(13, 13);
            this.lblPaternity.TabIndex = 63;
            this.lblPaternity.Text = "0";
            // 
            // txtEmployeeNo
            // 
            this.txtEmployeeNo.Location = new System.Drawing.Point(125, 23);
            this.txtEmployeeNo.Name = "txtEmployeeNo";
            this.txtEmployeeNo.Size = new System.Drawing.Size(199, 20);
            this.txtEmployeeNo.TabIndex = 37;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(345, 158);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(104, 13);
            this.label15.TabIndex = 62;
            this.label15.Text = "Remaining Paternity:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(403, 382);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 66;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // lblVL
            // 
            this.lblVL.AutoSize = true;
            this.lblVL.Location = new System.Drawing.Point(424, 129);
            this.lblVL.Name = "lblVL";
            this.lblVL.Size = new System.Drawing.Size(13, 13);
            this.lblVL.TabIndex = 61;
            this.lblVL.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Resource Id.:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(345, 129);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 13);
            this.label14.TabIndex = 60;
            this.label14.Text = "Remaining VL:";
            // 
            // txtResourceId
            // 
            this.txtResourceId.Location = new System.Drawing.Point(125, 62);
            this.txtResourceId.Name = "txtResourceId";
            this.txtResourceId.Size = new System.Drawing.Size(199, 20);
            this.txtResourceId.TabIndex = 39;
            // 
            // lblSL
            // 
            this.lblSL.AutoSize = true;
            this.lblSL.Location = new System.Drawing.Point(424, 101);
            this.lblSL.Name = "lblSL";
            this.lblSL.Size = new System.Drawing.Size(13, 13);
            this.lblSL.TabIndex = 59;
            this.lblSL.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Name:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(345, 101);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 13);
            this.label12.TabIndex = 58;
            this.label12.Text = "Remaining SL:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(125, 94);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(199, 20);
            this.txtName.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 42;
            this.label4.Text = "Process Role:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "Technical Role:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "Technology:";
            // 
            // cmbProcessRole
            // 
            this.cmbProcessRole.FormattingEnabled = true;
            this.cmbProcessRole.Items.AddRange(new object[] {
            "TM (Team Member)",
            "PC (Productivity Champion)",
            "TL (Team Lead)",
            "SqL (Squadron Leader)"});
            this.cmbProcessRole.Location = new System.Drawing.Point(125, 126);
            this.cmbProcessRole.Name = "cmbProcessRole";
            this.cmbProcessRole.Size = new System.Drawing.Size(199, 21);
            this.cmbProcessRole.TabIndex = 45;
            // 
            // cmbTechnicalRole
            // 
            this.cmbTechnicalRole.FormattingEnabled = true;
            this.cmbTechnicalRole.Items.AddRange(new object[] {
            "Project Manager",
            "Solution Architect",
            "Functional Analyst",
            "Quality Analyst",
            "Developer",
            "Support Analyst",
            "Tester",
            "Techno-Functional"});
            this.cmbTechnicalRole.Location = new System.Drawing.Point(126, 164);
            this.cmbTechnicalRole.Name = "cmbTechnicalRole";
            this.cmbTechnicalRole.Size = new System.Drawing.Size(199, 21);
            this.cmbTechnicalRole.TabIndex = 46;
            // 
            // cmbTechnology
            // 
            this.cmbTechnology.FormattingEnabled = true;
            this.cmbTechnology.Items.AddRange(new object[] {
            ".Net",
            "AX",
            "BI",
            "BOBJ",
            "E2E",
            "SharePoint",
            "SQL",
            "SAP ABAP",
            "SAP APO",
            "SAP BASIS",
            "SAP FI",
            "SAP FI/CO",
            "SAP HCM",
            "SAP MDM",
            "SAP MM",
            "SAP PI",
            "SAP PM",
            "SAP PP",
            "SAP SD",
            "SAP TRM"});
            this.cmbTechnology.Location = new System.Drawing.Point(126, 201);
            this.cmbTechnology.Name = "cmbTechnology";
            this.cmbTechnology.Size = new System.Drawing.Size(199, 21);
            this.cmbTechnology.TabIndex = 47;
            // 
            // cmbWorkLocation
            // 
            this.cmbWorkLocation.FormattingEnabled = true;
            this.cmbWorkLocation.Items.AddRange(new object[] {
            "Home",
            "(Official Business)",
            "24/7 Office",
            "Client Site"});
            this.cmbWorkLocation.Location = new System.Drawing.Point(125, 389);
            this.cmbWorkLocation.Name = "cmbWorkLocation";
            this.cmbWorkLocation.Size = new System.Drawing.Size(199, 21);
            this.cmbWorkLocation.TabIndex = 57;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 240);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 48;
            this.label7.Text = "Skill Level:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(42, 392);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 13);
            this.label11.TabIndex = 56;
            this.label11.Text = "Work Location:";
            // 
            // txtSkillLevel
            // 
            this.txtSkillLevel.Location = new System.Drawing.Point(125, 233);
            this.txtSkillLevel.Name = "txtSkillLevel";
            this.txtSkillLevel.Size = new System.Drawing.Size(199, 20);
            this.txtSkillLevel.TabIndex = 49;
            // 
            // txtProject
            // 
            this.txtProject.Location = new System.Drawing.Point(125, 336);
            this.txtProject.Multiline = true;
            this.txtProject.Name = "txtProject";
            this.txtProject.Size = new System.Drawing.Size(199, 47);
            this.txtProject.TabIndex = 55;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(42, 275);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 50;
            this.label8.Text = "Client:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(41, 343);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 54;
            this.label10.Text = "Project:";
            // 
            // txtClient
            // 
            this.txtClient.Location = new System.Drawing.Point(126, 268);
            this.txtClient.Name = "txtClient";
            this.txtClient.Size = new System.Drawing.Size(199, 20);
            this.txtClient.TabIndex = 51;
            // 
            // txtContract
            // 
            this.txtContract.Location = new System.Drawing.Point(125, 297);
            this.txtContract.Name = "txtContract";
            this.txtContract.Size = new System.Drawing.Size(199, 20);
            this.txtContract.TabIndex = 53;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(41, 304);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 52;
            this.label9.Text = "Contract:";
            // 
            // EmployeeRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 477);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EmployeeRecords";
            this.Text = "Employee Record";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeList)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMaternity;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label lblPaternity;
        private System.Windows.Forms.TextBox txtEmployeeNo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblVL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtResourceId;
        private System.Windows.Forms.Label lblSL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbProcessRole;
        private System.Windows.Forms.ComboBox cmbTechnicalRole;
        private System.Windows.Forms.ComboBox cmbTechnology;
        private System.Windows.Forms.ComboBox cmbWorkLocation;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSkillLevel;
        private System.Windows.Forms.TextBox txtProject;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtClient;
        private System.Windows.Forms.TextBox txtContract;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.DataGridView dgvEmployeeList;
        private System.Windows.Forms.TextBox txtSearchbox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnSearch;
    }
}