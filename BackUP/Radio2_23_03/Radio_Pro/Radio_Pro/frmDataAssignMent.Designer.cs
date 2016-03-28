namespace Radio_Pro
{
    partial class frmDataAssignMent
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
            this.grdAssignStatus = new System.Windows.Forms.DataGridView();
            this.grdCVSFile = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblMessages = new System.Windows.Forms.Label();
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.cmbDateEnd = new System.Windows.Forms.ComboBox();
            this.cmbMonthEnd = new System.Windows.Forms.ComboBox();
            this.cmbYearEnd = new System.Windows.Forms.ComboBox();
            this.cmdDate = new System.Windows.Forms.ComboBox();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.btnFetchData = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grdShowData = new System.Windows.Forms.DataGridView();
            this.btnAssignData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdAssignStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCVSFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdShowData)).BeginInit();
            this.SuspendLayout();
            // 
            // grdAssignStatus
            // 
            this.grdAssignStatus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grdAssignStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAssignStatus.Location = new System.Drawing.Point(18, 121);
            this.grdAssignStatus.Name = "grdAssignStatus";
            this.grdAssignStatus.Size = new System.Drawing.Size(1000, 374);
            this.grdAssignStatus.TabIndex = 71;
            // 
            // grdCVSFile
            // 
            this.grdCVSFile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grdCVSFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCVSFile.Location = new System.Drawing.Point(18, 121);
            this.grdCVSFile.Name = "grdCVSFile";
            this.grdCVSFile.Size = new System.Drawing.Size(1000, 374);
            this.grdCVSFile.TabIndex = 70;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(122, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 18);
            this.label7.TabIndex = 69;
            this.label7.Text = "Day";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(167, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 18);
            this.label8.TabIndex = 68;
            this.label8.Text = "Month";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(214, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 18);
            this.label9.TabIndex = 67;
            this.label9.Text = "Year";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(114, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 18);
            this.label5.TabIndex = 66;
            this.label5.Text = "Day";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(167, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 18);
            this.label4.TabIndex = 65;
            this.label4.Text = "Month";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(214, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 18);
            this.label6.TabIndex = 64;
            this.label6.Text = "Year";
            // 
            // lblMessages
            // 
            this.lblMessages.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMessages.AutoSize = true;
            this.lblMessages.Location = new System.Drawing.Point(312, 11);
            this.lblMessages.Name = "lblMessages";
            this.lblMessages.Size = new System.Drawing.Size(81, 18);
            this.lblMessages.TabIndex = 63;
            this.lblMessages.Text = "Messages";
            // 
            // lstUsers
            // 
            this.lstUsers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.ItemHeight = 18;
            this.lstUsers.Location = new System.Drawing.Point(770, 27);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(120, 76);
            this.lstUsers.TabIndex = 62;
            // 
            // cmbDateEnd
            // 
            this.cmbDateEnd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbDateEnd.FormattingEnabled = true;
            this.cmbDateEnd.Location = new System.Drawing.Point(117, 80);
            this.cmbDateEnd.Name = "cmbDateEnd";
            this.cmbDateEnd.Size = new System.Drawing.Size(41, 26);
            this.cmbDateEnd.TabIndex = 61;
            // 
            // cmbMonthEnd
            // 
            this.cmbMonthEnd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbMonthEnd.FormattingEnabled = true;
            this.cmbMonthEnd.Location = new System.Drawing.Point(170, 81);
            this.cmbMonthEnd.Name = "cmbMonthEnd";
            this.cmbMonthEnd.Size = new System.Drawing.Size(41, 26);
            this.cmbMonthEnd.TabIndex = 60;
            // 
            // cmbYearEnd
            // 
            this.cmbYearEnd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbYearEnd.FormattingEnabled = true;
            this.cmbYearEnd.Location = new System.Drawing.Point(217, 80);
            this.cmbYearEnd.Name = "cmbYearEnd";
            this.cmbYearEnd.Size = new System.Drawing.Size(65, 26);
            this.cmbYearEnd.TabIndex = 59;
            // 
            // cmdDate
            // 
            this.cmdDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdDate.FormattingEnabled = true;
            this.cmdDate.Location = new System.Drawing.Point(117, 30);
            this.cmdDate.Name = "cmdDate";
            this.cmdDate.Size = new System.Drawing.Size(41, 26);
            this.cmdDate.TabIndex = 58;
            // 
            // cmbMonth
            // 
            this.cmbMonth.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new System.Drawing.Point(170, 30);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(41, 26);
            this.cmbMonth.TabIndex = 57;
            // 
            // cmbYear
            // 
            this.cmbYear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(217, 30);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(65, 26);
            this.cmbYear.TabIndex = 56;
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
            this.btnFetchData.Location = new System.Drawing.Point(302, 45);
            this.btnFetchData.Name = "btnFetchData";
            this.btnFetchData.Size = new System.Drawing.Size(117, 38);
            this.btnFetchData.TabIndex = 55;
            this.btnFetchData.Text = "Receive Data";
            this.btnFetchData.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(638, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 18);
            this.label3.TabIndex = 54;
            this.label3.Text = "Select Users";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 18);
            this.label2.TabIndex = 53;
            this.label2.Text = "End Data";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 18);
            this.label1.TabIndex = 52;
            this.label1.Text = "Start Date";
            // 
            // grdShowData
            // 
            this.grdShowData.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grdShowData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdShowData.Location = new System.Drawing.Point(18, 121);
            this.grdShowData.Name = "grdShowData";
            this.grdShowData.Size = new System.Drawing.Size(1000, 374);
            this.grdShowData.TabIndex = 51;
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
            this.btnAssignData.Location = new System.Drawing.Point(920, 45);
            this.btnAssignData.Name = "btnAssignData";
            this.btnAssignData.Size = new System.Drawing.Size(98, 31);
            this.btnAssignData.TabIndex = 50;
            this.btnAssignData.Text = "Assign";
            this.btnAssignData.UseVisualStyleBackColor = false;
            // 
            // frmDataAssignMent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1033, 504);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmDataAssignMent";
            this.Text = "frmDataAssignMent";
            this.Load += new System.EventHandler(this.frmDataAssignMent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdAssignStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCVSFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdShowData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdAssignStatus;
        private System.Windows.Forms.DataGridView grdCVSFile;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblMessages;
        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.ComboBox cmbDateEnd;
        private System.Windows.Forms.ComboBox cmbMonthEnd;
        private System.Windows.Forms.ComboBox cmbYearEnd;
        private System.Windows.Forms.ComboBox cmdDate;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Button btnFetchData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grdShowData;
        private System.Windows.Forms.Button btnAssignData;
    }
}