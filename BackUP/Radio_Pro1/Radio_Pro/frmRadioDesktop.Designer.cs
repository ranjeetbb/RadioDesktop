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
            this.createLoginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fetchRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageDoctorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageDoctorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.manageUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageResponsedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createLoginToolStripMenuItem,
            this.recordToolStripMenuItem,
            this.manageDoctorToolStripMenuItem,
            this.trackToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(11, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1370, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // createLoginToolStripMenuItem
            // 
            this.createLoginToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newAccountToolStripMenuItem});
            this.createLoginToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createLoginToolStripMenuItem.Name = "createLoginToolStripMenuItem";
            this.createLoginToolStripMenuItem.Size = new System.Drawing.Size(75, 23);
            this.createLoginToolStripMenuItem.Text = "Account";
            // 
            // newAccountToolStripMenuItem
            // 
            this.newAccountToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newAccountToolStripMenuItem.Name = "newAccountToolStripMenuItem";
            this.newAccountToolStripMenuItem.Size = new System.Drawing.Size(165, 24);
            this.newAccountToolStripMenuItem.Text = "New Account";
            // 
            // recordToolStripMenuItem
            // 
            this.recordToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fetchRecordsToolStripMenuItem});
            this.recordToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recordToolStripMenuItem.Name = "recordToolStripMenuItem";
            this.recordToolStripMenuItem.Size = new System.Drawing.Size(70, 23);
            this.recordToolStripMenuItem.Text = "Record";
            // 
            // fetchRecordsToolStripMenuItem
            // 
            this.fetchRecordsToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fetchRecordsToolStripMenuItem.Name = "fetchRecordsToolStripMenuItem";
            this.fetchRecordsToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.fetchRecordsToolStripMenuItem.Text = "Fetch Records";
            this.fetchRecordsToolStripMenuItem.Click += new System.EventHandler(this.fetchRecordsToolStripMenuItem_Click);
            // 
            // manageDoctorToolStripMenuItem
            // 
            this.manageDoctorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageDoctorToolStripMenuItem1,
            this.manageUsersToolStripMenuItem,
            this.manageResponsedToolStripMenuItem});
            this.manageDoctorToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageDoctorToolStripMenuItem.Name = "manageDoctorToolStripMenuItem";
            this.manageDoctorToolStripMenuItem.Size = new System.Drawing.Size(77, 23);
            this.manageDoctorToolStripMenuItem.Text = "Manage";
            // 
            // manageDoctorToolStripMenuItem1
            // 
            this.manageDoctorToolStripMenuItem1.Name = "manageDoctorToolStripMenuItem1";
            this.manageDoctorToolStripMenuItem1.Size = new System.Drawing.Size(211, 24);
            this.manageDoctorToolStripMenuItem1.Text = "Manage Doctor";
            this.manageDoctorToolStripMenuItem1.Click += new System.EventHandler(this.manageDoctorToolStripMenuItem1_Click);
            // 
            // manageUsersToolStripMenuItem
            // 
            this.manageUsersToolStripMenuItem.Name = "manageUsersToolStripMenuItem";
            this.manageUsersToolStripMenuItem.Size = new System.Drawing.Size(211, 24);
            this.manageUsersToolStripMenuItem.Text = "Manage Users";
            // 
            // trackToolStripMenuItem
            // 
            this.trackToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trackUsersToolStripMenuItem});
            this.trackToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trackToolStripMenuItem.Name = "trackToolStripMenuItem";
            this.trackToolStripMenuItem.Size = new System.Drawing.Size(60, 23);
            this.trackToolStripMenuItem.Text = "Track";
            // 
            // trackUsersToolStripMenuItem
            // 
            this.trackUsersToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trackUsersToolStripMenuItem.Name = "trackUsersToolStripMenuItem";
            this.trackUsersToolStripMenuItem.Size = new System.Drawing.Size(160, 24);
            this.trackUsersToolStripMenuItem.Text = "Track Users";
            // 
            // manageResponsedToolStripMenuItem
            // 
            this.manageResponsedToolStripMenuItem.Name = "manageResponsedToolStripMenuItem";
            this.manageResponsedToolStripMenuItem.Size = new System.Drawing.Size(211, 24);
            this.manageResponsedToolStripMenuItem.Text = "Manage Responses";
            // 
            // frmRadioDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 674);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmRadioDesktop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "RadioDesktop";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRadioDesktop_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem createLoginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fetchRecordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageDoctorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageDoctorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem manageUsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageResponsedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trackUsersToolStripMenuItem;
    }
}