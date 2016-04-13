namespace Radio_Pro
{
    partial class frmDoctorHistory
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
            this.grdDisplayDoctorsHistory = new System.Windows.Forms.DataGridView();
            this.btnTrackUsers = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDoctorName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdDisplayDoctorsHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDisplayDoctorsHistory
            // 
            this.grdDisplayDoctorsHistory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grdDisplayDoctorsHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDisplayDoctorsHistory.Location = new System.Drawing.Point(12, 129);
            this.grdDisplayDoctorsHistory.Name = "grdDisplayDoctorsHistory";
            this.grdDisplayDoctorsHistory.Size = new System.Drawing.Size(564, 154);
            this.grdDisplayDoctorsHistory.TabIndex = 73;
            // 
            // btnTrackUsers
            // 
            this.btnTrackUsers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTrackUsers.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnTrackUsers.FlatAppearance.BorderColor = System.Drawing.SystemColors.InfoText;
            this.btnTrackUsers.FlatAppearance.BorderSize = 0;
            this.btnTrackUsers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnTrackUsers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnTrackUsers.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTrackUsers.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnTrackUsers.Location = new System.Drawing.Point(269, 79);
            this.btnTrackUsers.Name = "btnTrackUsers";
            this.btnTrackUsers.Size = new System.Drawing.Size(113, 35);
            this.btnTrackUsers.TabIndex = 72;
            this.btnTrackUsers.Text = "Track";
            this.btnTrackUsers.UseVisualStyleBackColor = false;
            this.btnTrackUsers.Click += new System.EventHandler(this.btnTrackUsers_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 18);
            this.label2.TabIndex = 71;
            this.label2.Text = "Select Doctors";
            // 
            // cmbDoctorName
            // 
            this.cmbDoctorName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbDoctorName.FormattingEnabled = true;
            this.cmbDoctorName.Location = new System.Drawing.Point(183, 36);
            this.cmbDoctorName.Margin = new System.Windows.Forms.Padding(4);
            this.cmbDoctorName.Name = "cmbDoctorName";
            this.cmbDoctorName.Size = new System.Drawing.Size(272, 26);
            this.cmbDoctorName.TabIndex = 70;
            this.cmbDoctorName.SelectedIndexChanged += new System.EventHandler(this.cmbDoctorName_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(151, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 18);
            this.label1.TabIndex = 74;
            this.label1.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 290);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 18);
            this.label3.TabIndex = 75;
            this.label3.Text = "Msg";
            // 
            // frmDoctorHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(588, 317);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdDisplayDoctorsHistory);
            this.Controls.Add(this.btnTrackUsers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbDoctorName);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmDoctorHistory";
            this.Text = "Doctor History";
            this.Load += new System.EventHandler(this.frmDoctorHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDisplayDoctorsHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdDisplayDoctorsHistory;
        private System.Windows.Forms.Button btnTrackUsers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDoctorName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;

    }
}