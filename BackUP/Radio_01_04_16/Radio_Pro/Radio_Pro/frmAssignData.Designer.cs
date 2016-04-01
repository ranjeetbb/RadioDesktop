namespace Radio_Pro
{
    partial class frmAssignData
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grdShowData = new System.Windows.Forms.DataGridView();
            this.btnAssignData = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFetchData = new System.Windows.Forms.Button();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.cmdDate = new System.Windows.Forms.ComboBox();
            this.cmbDateEnd = new System.Windows.Forms.ComboBox();
            this.cmbMonthEnd = new System.Windows.Forms.ComboBox();
            this.cmbYearEnd = new System.Windows.Forms.ComboBox();
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.lblMessages = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.grdCVSFile = new System.Windows.Forms.DataGridView();
            this.grdAssignStatus = new System.Windows.Forms.DataGridView();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.cmbDoctors = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbSelectType = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdShowData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCVSFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAssignStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 18);
            this.label2.TabIndex = 12;
            this.label2.Text = "End Data";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "Start Date";
            // 
            // grdShowData
            // 
            this.grdShowData.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grdShowData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdShowData.Location = new System.Drawing.Point(16, 117);
            this.grdShowData.Name = "grdShowData";
            this.grdShowData.Size = new System.Drawing.Size(1000, 374);
            this.grdShowData.TabIndex = 10;
            // 
            // btnAssignData
            // 
            this.btnAssignData.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAssignData.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAssignData.FlatAppearance.BorderColor = System.Drawing.SystemColors.InfoText;
            this.btnAssignData.FlatAppearance.BorderSize = 0;
            this.btnAssignData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAssignData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAssignData.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAssignData.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAssignData.Location = new System.Drawing.Point(919, 75);
            this.btnAssignData.Name = "btnAssignData";
            this.btnAssignData.Size = new System.Drawing.Size(82, 31);
            this.btnAssignData.TabIndex = 9;
            this.btnAssignData.Text = "Assign";
            this.btnAssignData.UseVisualStyleBackColor = false;
            this.btnAssignData.Click += new System.EventHandler(this.btnFetchData_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(776, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 18);
            this.label3.TabIndex = 15;
            this.label3.Text = "Select Users";
            // 
            // btnFetchData
            // 
            this.btnFetchData.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFetchData.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnFetchData.FlatAppearance.BorderColor = System.Drawing.SystemColors.InfoText;
            this.btnFetchData.FlatAppearance.BorderSize = 0;
            this.btnFetchData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnFetchData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnFetchData.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFetchData.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnFetchData.Location = new System.Drawing.Point(292, 77);
            this.btnFetchData.Name = "btnFetchData";
            this.btnFetchData.Size = new System.Drawing.Size(121, 31);
            this.btnFetchData.TabIndex = 21;
            this.btnFetchData.Text = "Receive Data";
            this.btnFetchData.UseVisualStyleBackColor = false;
            this.btnFetchData.Click += new System.EventHandler(this.btnFetchData_Click_1);
            // 
            // cmbYear
            // 
            this.cmbYear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(215, 26);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(65, 26);
            this.cmbYear.TabIndex = 22;
            // 
            // cmbMonth
            // 
            this.cmbMonth.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new System.Drawing.Point(168, 26);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(41, 26);
            this.cmbMonth.TabIndex = 23;
            // 
            // cmdDate
            // 
            this.cmdDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdDate.FormattingEnabled = true;
            this.cmdDate.Location = new System.Drawing.Point(115, 26);
            this.cmdDate.Name = "cmdDate";
            this.cmdDate.Size = new System.Drawing.Size(41, 26);
            this.cmdDate.TabIndex = 24;
            // 
            // cmbDateEnd
            // 
            this.cmbDateEnd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbDateEnd.FormattingEnabled = true;
            this.cmbDateEnd.Location = new System.Drawing.Point(115, 76);
            this.cmbDateEnd.Name = "cmbDateEnd";
            this.cmbDateEnd.Size = new System.Drawing.Size(41, 26);
            this.cmbDateEnd.TabIndex = 27;
            // 
            // cmbMonthEnd
            // 
            this.cmbMonthEnd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbMonthEnd.FormattingEnabled = true;
            this.cmbMonthEnd.Location = new System.Drawing.Point(168, 77);
            this.cmbMonthEnd.Name = "cmbMonthEnd";
            this.cmbMonthEnd.Size = new System.Drawing.Size(41, 26);
            this.cmbMonthEnd.TabIndex = 26;
            // 
            // cmbYearEnd
            // 
            this.cmbYearEnd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbYearEnd.FormattingEnabled = true;
            this.cmbYearEnd.Location = new System.Drawing.Point(215, 76);
            this.cmbYearEnd.Name = "cmbYearEnd";
            this.cmbYearEnd.Size = new System.Drawing.Size(65, 26);
            this.cmbYearEnd.TabIndex = 25;
            // 
            // lstUsers
            // 
            this.lstUsers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.ItemHeight = 18;
            this.lstUsers.Location = new System.Drawing.Point(779, 35);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(120, 76);
            this.lstUsers.TabIndex = 28;
            this.lstUsers.SelectedIndexChanged += new System.EventHandler(this.lstUsers_SelectedIndexChanged);
            // 
            // lblMessages
            // 
            this.lblMessages.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMessages.AutoSize = true;
            this.lblMessages.Location = new System.Drawing.Point(310, 7);
            this.lblMessages.Name = "lblMessages";
            this.lblMessages.Size = new System.Drawing.Size(81, 18);
            this.lblMessages.TabIndex = 29;
            this.lblMessages.Text = "Messages";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(112, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 18);
            this.label5.TabIndex = 44;
            this.label5.Text = "Day";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(165, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 18);
            this.label4.TabIndex = 43;
            this.label4.Text = "Month";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(212, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 18);
            this.label6.TabIndex = 42;
            this.label6.Text = "Year";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(120, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 18);
            this.label7.TabIndex = 47;
            this.label7.Text = "Day";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(165, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 18);
            this.label8.TabIndex = 46;
            this.label8.Text = "Month";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(212, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 18);
            this.label9.TabIndex = 45;
            this.label9.Text = "Year";
            // 
            // grdCVSFile
            // 
            this.grdCVSFile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grdCVSFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCVSFile.Location = new System.Drawing.Point(16, 117);
            this.grdCVSFile.Name = "grdCVSFile";
            this.grdCVSFile.Size = new System.Drawing.Size(1000, 374);
            this.grdCVSFile.TabIndex = 48;
            // 
            // grdAssignStatus
            // 
            this.grdAssignStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grdAssignStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAssignStatus.Location = new System.Drawing.Point(16, 117);
            this.grdAssignStatus.Name = "grdAssignStatus";
            this.grdAssignStatus.Size = new System.Drawing.Size(1000, 374);
            this.grdAssignStatus.TabIndex = 49;
            // 
            // cmbArea
            // 
            this.cmbArea.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(528, 55);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(127, 26);
            this.cmbArea.TabIndex = 50;
            this.cmbArea.SelectedIndexChanged += new System.EventHandler(this.cmbArea_SelectedIndexChanged);
            // 
            // cmbDoctors
            // 
            this.cmbDoctors.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbDoctors.FormattingEnabled = true;
            this.cmbDoctors.Location = new System.Drawing.Point(528, 82);
            this.cmbDoctors.Name = "cmbDoctors";
            this.cmbDoctors.Size = new System.Drawing.Size(189, 26);
            this.cmbDoctors.TabIndex = 51;
            this.cmbDoctors.SelectedIndexChanged += new System.EventHandler(this.cmbDoctors_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(419, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 18);
            this.label10.TabIndex = 52;
            this.label10.Text = "Select Area";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(419, 88);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 18);
            this.label11.TabIndex = 53;
            this.label11.Text = "Select Doctor";
            // 
            // cmbSelectType
            // 
            this.cmbSelectType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbSelectType.FormattingEnabled = true;
            this.cmbSelectType.Location = new System.Drawing.Point(528, 29);
            this.cmbSelectType.Name = "cmbSelectType";
            this.cmbSelectType.Size = new System.Drawing.Size(189, 26);
            this.cmbSelectType.TabIndex = 54;
            this.cmbSelectType.SelectedIndexChanged += new System.EventHandler(this.cmbSelectType_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(419, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 18);
            this.label12.TabIndex = 55;
            this.label12.Text = "Selection Type";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(95, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 18);
            this.label13.TabIndex = 56;
            this.label13.Text = "*";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(95, 79);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 18);
            this.label14.TabIndex = 57;
            this.label14.Text = "*";
            // 
            // frmAssignData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1033, 504);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbSelectType);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbDoctors);
            this.Controls.Add(this.cmbArea);
            this.Controls.Add(this.grdAssignStatus);
            this.Controls.Add(this.grdCVSFile);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblMessages);
            this.Controls.Add(this.lstUsers);
            this.Controls.Add(this.cmbDateEnd);
            this.Controls.Add(this.cmbMonthEnd);
            this.Controls.Add(this.cmbYearEnd);
            this.Controls.Add(this.cmdDate);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.btnFetchData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdShowData);
            this.Controls.Add(this.btnAssignData);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAssignData";
            this.Text = "AssignData";
            this.Load += new System.EventHandler(this.frmAssignData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdShowData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCVSFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAssignStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grdShowData;
        private System.Windows.Forms.Button btnAssignData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFetchData;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.ComboBox cmdDate;
        private System.Windows.Forms.ComboBox cmbDateEnd;
        private System.Windows.Forms.ComboBox cmbMonthEnd;
        private System.Windows.Forms.ComboBox cmbYearEnd;
        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.Label lblMessages;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView grdCVSFile;
        private System.Windows.Forms.DataGridView grdAssignStatus;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.ComboBox cmbDoctors;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbSelectType;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
    }
}