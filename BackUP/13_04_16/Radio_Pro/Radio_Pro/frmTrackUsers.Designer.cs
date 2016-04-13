namespace Radio_Pro
{
    partial class frmTrackUsers
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
            this.btnTrackUsers = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbUserName = new System.Windows.Forms.ComboBox();
            this.grdDisplayLocation = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdDisplayLocation)).BeginInit();
            this.SuspendLayout();
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
            this.btnTrackUsers.Location = new System.Drawing.Point(149, 85);
            this.btnTrackUsers.Name = "btnTrackUsers";
            this.btnTrackUsers.Size = new System.Drawing.Size(113, 35);
            this.btnTrackUsers.TabIndex = 66;
            this.btnTrackUsers.Text = "Track";
            this.btnTrackUsers.UseVisualStyleBackColor = false;
            this.btnTrackUsers.Click += new System.EventHandler(this.btnTrackUsers_Click_1);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 18);
            this.label2.TabIndex = 65;
            this.label2.Text = "Select User";
            // 
            // cmbUserName
            // 
            this.cmbUserName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbUserName.FormattingEnabled = true;
            this.cmbUserName.Location = new System.Drawing.Point(126, 43);
            this.cmbUserName.Margin = new System.Windows.Forms.Padding(4);
            this.cmbUserName.Name = "cmbUserName";
            this.cmbUserName.Size = new System.Drawing.Size(180, 26);
            this.cmbUserName.TabIndex = 57;
            this.cmbUserName.SelectedIndexChanged += new System.EventHandler(this.cmbUserName_SelectedIndexChanged_1);
            // 
            // grdDisplayLocation
            // 
            this.grdDisplayLocation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grdDisplayLocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDisplayLocation.Location = new System.Drawing.Point(34, 151);
            this.grdDisplayLocation.Name = "grdDisplayLocation";
            this.grdDisplayLocation.Size = new System.Drawing.Size(338, 154);
            this.grdDisplayLocation.TabIndex = 69;
            this.grdDisplayLocation.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDisplayLocation_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 18);
            this.label1.TabIndex = 70;
            this.label1.Text = "*";
            // 
            // frmTrackUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(406, 317);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdDisplayLocation);
            this.Controls.Add(this.btnTrackUsers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbUserName);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTrackUsers";
            this.Text = "TrackUsers";
            this.Load += new System.EventHandler(this.frmTrackUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDisplayLocation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTrackUsers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbUserName;
        private System.Windows.Forms.DataGridView grdDisplayLocation;
        private System.Windows.Forms.Label label1;

    }
}