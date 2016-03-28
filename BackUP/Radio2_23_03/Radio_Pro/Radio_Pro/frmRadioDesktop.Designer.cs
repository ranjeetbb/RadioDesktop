namespace Radio_Pro
{
    partial class frmRadioDesktop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRadioDesktop));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.recordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fetchRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageDoctorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageDoctorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.manageUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFetchData = new System.Windows.Forms.Button();
            this.btnTrackUsers = new System.Windows.Forms.Button();
            this.btnAssignData = new System.Windows.Forms.Button();
            this.btnManageDoctors = new System.Windows.Forms.Button();
            this.tbcLayout = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grdDisplayAll = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grdDisplayPending = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.grdDisplayAccepted = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnRefress = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tbcLayout.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDisplayAll)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDisplayPending)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDisplayAccepted)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recordToolStripMenuItem,
            this.manageDoctorToolStripMenuItem,
            this.trackToolStripMenuItem,
            this.toolStripMenuItem3});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1135, 26);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // recordToolStripMenuItem
            // 
            this.recordToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fetchRecordsToolStripMenuItem});
            this.recordToolStripMenuItem.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recordToolStripMenuItem.Name = "recordToolStripMenuItem";
            this.recordToolStripMenuItem.Size = new System.Drawing.Size(71, 22);
            this.recordToolStripMenuItem.Text = "Record";
            // 
            // fetchRecordsToolStripMenuItem
            // 
            this.fetchRecordsToolStripMenuItem.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fetchRecordsToolStripMenuItem.Name = "fetchRecordsToolStripMenuItem";
            this.fetchRecordsToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.fetchRecordsToolStripMenuItem.Text = "Fetch Records";
            this.fetchRecordsToolStripMenuItem.Click += new System.EventHandler(this.fetchRecordsToolStripMenuItem_Click);
            // 
            // manageDoctorToolStripMenuItem
            // 
            this.manageDoctorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageDoctorToolStripMenuItem1,
            this.manageUsersToolStripMenuItem});
            this.manageDoctorToolStripMenuItem.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageDoctorToolStripMenuItem.Name = "manageDoctorToolStripMenuItem";
            this.manageDoctorToolStripMenuItem.Size = new System.Drawing.Size(77, 22);
            this.manageDoctorToolStripMenuItem.Text = "Manage";
            // 
            // manageDoctorToolStripMenuItem1
            // 
            this.manageDoctorToolStripMenuItem1.Name = "manageDoctorToolStripMenuItem1";
            this.manageDoctorToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
            this.manageDoctorToolStripMenuItem1.Text = "Manage Doctor";
            this.manageDoctorToolStripMenuItem1.Click += new System.EventHandler(this.manageDoctorToolStripMenuItem1_Click);
            // 
            // manageUsersToolStripMenuItem
            // 
            this.manageUsersToolStripMenuItem.Name = "manageUsersToolStripMenuItem";
            this.manageUsersToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.manageUsersToolStripMenuItem.Text = "Manage Users";
            this.manageUsersToolStripMenuItem.Click += new System.EventHandler(this.manageUsersToolStripMenuItem_Click);
            // 
            // trackToolStripMenuItem
            // 
            this.trackToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trackUsersToolStripMenuItem});
            this.trackToolStripMenuItem.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trackToolStripMenuItem.Name = "trackToolStripMenuItem";
            this.trackToolStripMenuItem.Size = new System.Drawing.Size(58, 22);
            this.trackToolStripMenuItem.Text = "Track";
            this.trackToolStripMenuItem.Click += new System.EventHandler(this.trackToolStripMenuItem_Click);
            // 
            // trackUsersToolStripMenuItem
            // 
            this.trackUsersToolStripMenuItem.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trackUsersToolStripMenuItem.Name = "trackUsersToolStripMenuItem";
            this.trackUsersToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.trackUsersToolStripMenuItem.Text = "Track Users";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4});
            this.toolStripMenuItem3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(54, 22);
            this.toolStripMenuItem3.Text = "Data";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(195, 22);
            this.toolStripMenuItem4.Text = "Data Assignment";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // btnFetchData
            // 
            this.btnFetchData.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnFetchData.FlatAppearance.BorderColor = System.Drawing.SystemColors.InfoText;
            this.btnFetchData.FlatAppearance.BorderSize = 0;
            this.btnFetchData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnFetchData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnFetchData.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFetchData.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnFetchData.Location = new System.Drawing.Point(22, 44);
            this.btnFetchData.Margin = new System.Windows.Forms.Padding(2);
            this.btnFetchData.Name = "btnFetchData";
            this.btnFetchData.Size = new System.Drawing.Size(91, 28);
            this.btnFetchData.TabIndex = 1;
            this.btnFetchData.Text = "New Data";
            this.btnFetchData.UseVisualStyleBackColor = false;
            this.btnFetchData.Click += new System.EventHandler(this.btnFetchData_Click);
            // 
            // btnTrackUsers
            // 
            this.btnTrackUsers.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnTrackUsers.FlatAppearance.BorderColor = System.Drawing.SystemColors.InfoText;
            this.btnTrackUsers.FlatAppearance.BorderSize = 0;
            this.btnTrackUsers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnTrackUsers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnTrackUsers.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTrackUsers.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnTrackUsers.Location = new System.Drawing.Point(253, 44);
            this.btnTrackUsers.Margin = new System.Windows.Forms.Padding(2);
            this.btnTrackUsers.Name = "btnTrackUsers";
            this.btnTrackUsers.Size = new System.Drawing.Size(103, 28);
            this.btnTrackUsers.TabIndex = 2;
            this.btnTrackUsers.Text = "Track Users";
            this.btnTrackUsers.UseVisualStyleBackColor = false;
            this.btnTrackUsers.Click += new System.EventHandler(this.btnTrackUsers_Click);
            // 
            // btnAssignData
            // 
            this.btnAssignData.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAssignData.FlatAppearance.BorderColor = System.Drawing.SystemColors.InfoText;
            this.btnAssignData.FlatAppearance.BorderSize = 0;
            this.btnAssignData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAssignData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAssignData.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAssignData.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAssignData.Location = new System.Drawing.Point(130, 44);
            this.btnAssignData.Margin = new System.Windows.Forms.Padding(2);
            this.btnAssignData.Name = "btnAssignData";
            this.btnAssignData.Size = new System.Drawing.Size(108, 28);
            this.btnAssignData.TabIndex = 3;
            this.btnAssignData.Text = "Assign Data";
            this.btnAssignData.UseVisualStyleBackColor = false;
            this.btnAssignData.Click += new System.EventHandler(this.btnAssignData_Click);
            // 
            // btnManageDoctors
            // 
            this.btnManageDoctors.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnManageDoctors.FlatAppearance.BorderColor = System.Drawing.SystemColors.InfoText;
            this.btnManageDoctors.FlatAppearance.BorderSize = 0;
            this.btnManageDoctors.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnManageDoctors.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnManageDoctors.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnManageDoctors.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnManageDoctors.Location = new System.Drawing.Point(369, 44);
            this.btnManageDoctors.Margin = new System.Windows.Forms.Padding(2);
            this.btnManageDoctors.Name = "btnManageDoctors";
            this.btnManageDoctors.Size = new System.Drawing.Size(133, 28);
            this.btnManageDoctors.TabIndex = 4;
            this.btnManageDoctors.Text = "Manage Doctors";
            this.btnManageDoctors.UseVisualStyleBackColor = false;
            this.btnManageDoctors.Click += new System.EventHandler(this.btnManageDoctors_Click);
            // 
            // tbcLayout
            // 
            this.tbcLayout.Controls.Add(this.tabPage1);
            this.tbcLayout.Controls.Add(this.tabPage2);
            this.tbcLayout.Controls.Add(this.tabPage3);
            this.tbcLayout.Controls.Add(this.tabPage4);
            this.tbcLayout.Location = new System.Drawing.Point(22, 91);
            this.tbcLayout.Name = "tbcLayout";
            this.tbcLayout.SelectedIndex = 0;
            this.tbcLayout.Size = new System.Drawing.Size(998, 451);
            this.tbcLayout.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grdDisplayAll);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(990, 420);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "All";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grdDisplayAll
            // 
            this.grdDisplayAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDisplayAll.Location = new System.Drawing.Point(0, 0);
            this.grdDisplayAll.Name = "grdDisplayAll";
            this.grdDisplayAll.Size = new System.Drawing.Size(990, 420);
            this.grdDisplayAll.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grdDisplayPending);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(990, 420);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Pending";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grdDisplayPending
            // 
            this.grdDisplayPending.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDisplayPending.Location = new System.Drawing.Point(1, 0);
            this.grdDisplayPending.Name = "grdDisplayPending";
            this.grdDisplayPending.Size = new System.Drawing.Size(989, 424);
            this.grdDisplayPending.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.grdDisplayAccepted);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(990, 420);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Accepted";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // grdDisplayAccepted
            // 
            this.grdDisplayAccepted.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDisplayAccepted.Location = new System.Drawing.Point(1, 0);
            this.grdDisplayAccepted.Name = "grdDisplayAccepted";
            this.grdDisplayAccepted.Size = new System.Drawing.Size(989, 424);
            this.grdDisplayAccepted.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dataGridView1);
            this.tabPage4.Location = new System.Drawing.Point(4, 27);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(990, 420);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Rejected";
            this.tabPage4.UseVisualStyleBackColor = true;
            this.tabPage4.Click += new System.EventHandler(this.tabPage4_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(993, 421);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnRefress
            // 
            this.btnRefress.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnRefress.FlatAppearance.BorderColor = System.Drawing.SystemColors.InfoText;
            this.btnRefress.FlatAppearance.BorderSize = 0;
            this.btnRefress.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRefress.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRefress.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefress.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRefress.Location = new System.Drawing.Point(515, 44);
            this.btnRefress.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefress.Name = "btnRefress";
            this.btnRefress.Size = new System.Drawing.Size(91, 28);
            this.btnRefress.TabIndex = 6;
            this.btnRefress.Text = "Refresh";
            this.btnRefress.UseVisualStyleBackColor = false;
            this.btnRefress.Click += new System.EventHandler(this.btnRefress_Click);
            // 
            // frmRadioDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1135, 578);
            this.Controls.Add(this.btnRefress);
            this.Controls.Add(this.tbcLayout);
            this.Controls.Add(this.btnManageDoctors);
            this.Controls.Add(this.btnAssignData);
            this.Controls.Add(this.btnTrackUsers);
            this.Controls.Add(this.btnFetchData);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmRadioDesktop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "ManageApp";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRadioDesktop_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tbcLayout.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDisplayAll)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDisplayPending)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDisplayAccepted)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem recordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fetchRecordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageDoctorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageDoctorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem manageUsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trackUsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.Button btnFetchData;
        private System.Windows.Forms.Button btnTrackUsers;
        private System.Windows.Forms.Button btnAssignData;
        private System.Windows.Forms.Button btnManageDoctors;
        private System.Windows.Forms.TabControl tbcLayout;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView grdDisplayAll;
        private System.Windows.Forms.DataGridView grdDisplayPending;
        private System.Windows.Forms.DataGridView grdDisplayAccepted;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnRefress;
    }
}