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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeRecords));
            this.txtSearchbox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.txtMaternity = new System.Windows.Forms.TextBox();
            this.txtPaternity = new System.Windows.Forms.TextBox();
            this.txtVL = new System.Windows.Forms.TextBox();
            this.txtSL = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.txtEmployeeNo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtResourceId = new System.Windows.Forms.TextBox();
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
            this.txtContract = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtInitial = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtSearchbox
            // 
            this.txtSearchbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchbox.Location = new System.Drawing.Point(61, 75);
            this.txtSearchbox.Multiline = true;
            this.txtSearchbox.Name = "txtSearchbox";
            this.txtSearchbox.Size = new System.Drawing.Size(244, 27);
            this.txtSearchbox.TabIndex = 3;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(15, 78);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(43, 18);
            this.label18.TabIndex = 2;
            this.label18.Text = "Initial";
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(311, 75);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(27, 27);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbClient
            // 
            this.cmbClient.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClient.FormattingEnabled = true;
            this.cmbClient.Location = new System.Drawing.Point(126, 397);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Size = new System.Drawing.Size(199, 26);
            this.cmbClient.TabIndex = 80;
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFemale.Location = new System.Drawing.Point(472, 219);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(72, 22);
            this.rbFemale.TabIndex = 79;
            this.rbFemale.TabStop = true;
            this.rbFemale.Tag = "gender";
            this.rbFemale.Text = "Female";
            this.rbFemale.UseVisualStyleBackColor = true;
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Checked = true;
            this.rbMale.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMale.Location = new System.Drawing.Point(404, 221);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(57, 22);
            this.rbMale.TabIndex = 78;
            this.rbMale.TabStop = true;
            this.rbMale.Tag = "gender";
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            // 
            // txtMaternity
            // 
            this.txtMaternity.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaternity.Location = new System.Drawing.Point(492, 346);
            this.txtMaternity.Name = "txtMaternity";
            this.txtMaternity.Size = new System.Drawing.Size(108, 26);
            this.txtMaternity.TabIndex = 76;
            // 
            // txtPaternity
            // 
            this.txtPaternity.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaternity.Location = new System.Drawing.Point(492, 313);
            this.txtPaternity.Name = "txtPaternity";
            this.txtPaternity.Size = new System.Drawing.Size(108, 26);
            this.txtPaternity.TabIndex = 75;
            // 
            // txtVL
            // 
            this.txtVL.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVL.Location = new System.Drawing.Point(492, 287);
            this.txtVL.Name = "txtVL";
            this.txtVL.Size = new System.Drawing.Size(108, 26);
            this.txtVL.TabIndex = 74;
            // 
            // txtSL
            // 
            this.txtSL.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSL.Location = new System.Drawing.Point(492, 262);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(108, 26);
            this.txtSL.TabIndex = 73;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(346, 223);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 18);
            this.label16.TabIndex = 71;
            this.label16.Text = "Gender:";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(424, 122);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(285, 26);
            this.txtEmail.TabIndex = 70;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(372, 125);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 18);
            this.label13.TabIndex = 69;
            this.label13.Text = "Email:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 18);
            this.label1.TabIndex = 36;
            this.label1.Text = "Employee No.:";
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(407, 76);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(27, 27);
            this.btnSave.TabIndex = 68;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(346, 349);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(142, 18);
            this.label17.TabIndex = 64;
            this.label17.Text = "Remaining Maternity:";
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(375, 75);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(27, 27);
            this.btnEdit.TabIndex = 67;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // txtEmployeeNo
            // 
            this.txtEmployeeNo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeNo.Location = new System.Drawing.Point(126, 117);
            this.txtEmployeeNo.Name = "txtEmployeeNo";
            this.txtEmployeeNo.Size = new System.Drawing.Size(199, 26);
            this.txtEmployeeNo.TabIndex = 37;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(346, 319);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(138, 18);
            this.label15.TabIndex = 62;
            this.label15.Text = "Remaining Paternity:";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(344, 75);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(27, 27);
            this.btnAdd.TabIndex = 66;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 18);
            this.label2.TabIndex = 38;
            this.label2.Text = "Resource Id.:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(346, 290);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 18);
            this.label14.TabIndex = 60;
            this.label14.Text = "Remaining VL:";
            // 
            // txtResourceId
            // 
            this.txtResourceId.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResourceId.Location = new System.Drawing.Point(126, 187);
            this.txtResourceId.Name = "txtResourceId";
            this.txtResourceId.Size = new System.Drawing.Size(199, 26);
            this.txtResourceId.TabIndex = 39;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 18);
            this.label3.TabIndex = 40;
            this.label3.Text = "Name:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(346, 262);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 18);
            this.label12.TabIndex = 58;
            this.label12.Text = "Remaining SL:";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(126, 154);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(199, 26);
            this.txtName.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 18);
            this.label4.TabIndex = 42;
            this.label4.Text = "Process Role:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 300);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 18);
            this.label5.TabIndex = 43;
            this.label5.Text = "Technical Role:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 337);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 18);
            this.label6.TabIndex = 44;
            this.label6.Text = "Technology:";
            // 
            // cmbProcessRole
            // 
            this.cmbProcessRole.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProcessRole.FormattingEnabled = true;
            this.cmbProcessRole.Items.AddRange(new object[] {
            "",
            "TM (Team Member)",
            "PC (Productivity Champion)",
            "TL (Team Lead)",
            "SqL (Squadron Leader)"});
            this.cmbProcessRole.Location = new System.Drawing.Point(126, 259);
            this.cmbProcessRole.Name = "cmbProcessRole";
            this.cmbProcessRole.Size = new System.Drawing.Size(199, 26);
            this.cmbProcessRole.TabIndex = 45;
            // 
            // cmbTechnicalRole
            // 
            this.cmbTechnicalRole.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTechnicalRole.FormattingEnabled = true;
            this.cmbTechnicalRole.Items.AddRange(new object[] {
            "",
            "Project Manager",
            "Solution Architect",
            "Functional Analyst",
            "Quality Analyst",
            "Developer",
            "Support Analyst",
            "Tester",
            "Techno-Functional"});
            this.cmbTechnicalRole.Location = new System.Drawing.Point(127, 297);
            this.cmbTechnicalRole.Name = "cmbTechnicalRole";
            this.cmbTechnicalRole.Size = new System.Drawing.Size(199, 26);
            this.cmbTechnicalRole.TabIndex = 46;
            // 
            // cmbTechnology
            // 
            this.cmbTechnology.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTechnology.FormattingEnabled = true;
            this.cmbTechnology.Items.AddRange(new object[] {
            "",
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
            this.cmbTechnology.Location = new System.Drawing.Point(127, 334);
            this.cmbTechnology.Name = "cmbTechnology";
            this.cmbTechnology.Size = new System.Drawing.Size(199, 26);
            this.cmbTechnology.TabIndex = 47;
            // 
            // cmbWorkLocation
            // 
            this.cmbWorkLocation.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWorkLocation.FormattingEnabled = true;
            this.cmbWorkLocation.Items.AddRange(new object[] {
            "Home",
            "(Official Business)",
            "24/7 Office",
            "Client Site"});
            this.cmbWorkLocation.Location = new System.Drawing.Point(126, 437);
            this.cmbWorkLocation.Name = "cmbWorkLocation";
            this.cmbWorkLocation.Size = new System.Drawing.Size(199, 26);
            this.cmbWorkLocation.TabIndex = 57;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 373);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 18);
            this.label7.TabIndex = 48;
            this.label7.Text = "Skill Level:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 440);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 18);
            this.label11.TabIndex = 56;
            this.label11.Text = "Work Location:";
            // 
            // txtSkillLevel
            // 
            this.txtSkillLevel.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSkillLevel.Location = new System.Drawing.Point(126, 366);
            this.txtSkillLevel.Name = "txtSkillLevel";
            this.txtSkillLevel.Size = new System.Drawing.Size(199, 26);
            this.txtSkillLevel.TabIndex = 49;
            // 
            // txtProject
            // 
            this.txtProject.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProject.Location = new System.Drawing.Point(126, 475);
            this.txtProject.Multiline = true;
            this.txtProject.Name = "txtProject";
            this.txtProject.Size = new System.Drawing.Size(199, 47);
            this.txtProject.TabIndex = 55;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 408);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 18);
            this.label8.TabIndex = 50;
            this.label8.Text = "Client:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 476);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 18);
            this.label10.TabIndex = 54;
            this.label10.Text = "Project:";
            // 
            // txtContract
            // 
            this.txtContract.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContract.Location = new System.Drawing.Point(425, 157);
            this.txtContract.Name = "txtContract";
            this.txtContract.Size = new System.Drawing.Size(199, 26);
            this.txtContract.TabIndex = 53;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(358, 164);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 18);
            this.label9.TabIndex = 52;
            this.label9.Text = "Contract:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(12, 5);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(141, 23);
            this.label19.TabIndex = 81;
            this.label19.Text = "Emplyee Records";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(12, 224);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(47, 18);
            this.label20.TabIndex = 82;
            this.label20.Text = "Initial:";
            // 
            // txtInitial
            // 
            this.txtInitial.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInitial.Location = new System.Drawing.Point(126, 224);
            this.txtInitial.Name = "txtInitial";
            this.txtInitial.Size = new System.Drawing.Size(199, 26);
            this.txtInitial.TabIndex = 83;
            // 
            // EmployeeRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 537);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtInitial);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchbox);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.cmbClient);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.rbFemale);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbMale);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtContract);
            this.Controls.Add(this.txtMaternity);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtPaternity);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtVL);
            this.Controls.Add(this.txtProject);
            this.Controls.Add(this.txtSL);
            this.Controls.Add(this.txtSkillLevel);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbWorkLocation);
            this.Controls.Add(this.cmbTechnology);
            this.Controls.Add(this.cmbTechnicalRole);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cmbProcessRole);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEmployeeNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtResourceId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EmployeeRecords";
            this.Text = "Employee Record";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox txtEmployeeNo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtResourceId;
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
        private System.Windows.Forms.TextBox txtContract;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtSearchbox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtMaternity;
        private System.Windows.Forms.TextBox txtPaternity;
        private System.Windows.Forms.TextBox txtVL;
        private System.Windows.Forms.TextBox txtSL;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.ComboBox cmbClient;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtInitial;
    }
}