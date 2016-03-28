namespace Radio_Pro
{
    partial class frmUpdatedDoctorscs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdatedDoctorscs));
            this.grdManagesDoctor = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdateClose = new System.Windows.Forms.Button();
            this.btnUpdateContact = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdManagesDoctor)).BeginInit();
            this.SuspendLayout();
            // 
            // grdManagesDoctor
            // 
            this.grdManagesDoctor.AllowUserToOrderColumns = true;
            this.grdManagesDoctor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdManagesDoctor.Location = new System.Drawing.Point(12, 29);
            this.grdManagesDoctor.Name = "grdManagesDoctor";
            this.grdManagesDoctor.Size = new System.Drawing.Size(920, 345);
            this.grdManagesDoctor.TabIndex = 4;
            this.grdManagesDoctor.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdManagesDoctor_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(376, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Doctor Information";
            // 
            // btnUpdateClose
            // 
            this.btnUpdateClose.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdateClose.FlatAppearance.BorderColor = System.Drawing.SystemColors.InfoText;
            this.btnUpdateClose.FlatAppearance.BorderSize = 0;
            this.btnUpdateClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnUpdateClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnUpdateClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdateClose.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUpdateClose.Location = new System.Drawing.Point(724, 383);
            this.btnUpdateClose.Name = "btnUpdateClose";
            this.btnUpdateClose.Size = new System.Drawing.Size(124, 32);
            this.btnUpdateClose.TabIndex = 6;
            this.btnUpdateClose.Text = "Close";
            this.btnUpdateClose.UseVisualStyleBackColor = false;
            this.btnUpdateClose.Click += new System.EventHandler(this.btnUpdateClose_Click);
            // 
            // btnUpdateContact
            // 
            this.btnUpdateContact.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdateContact.FlatAppearance.BorderColor = System.Drawing.SystemColors.InfoText;
            this.btnUpdateContact.FlatAppearance.BorderSize = 0;
            this.btnUpdateContact.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnUpdateContact.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnUpdateContact.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdateContact.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUpdateContact.Location = new System.Drawing.Point(359, 383);
            this.btnUpdateContact.Name = "btnUpdateContact";
            this.btnUpdateContact.Size = new System.Drawing.Size(152, 30);
            this.btnUpdateContact.TabIndex = 7;
            this.btnUpdateContact.Text = "Update Contact";
            this.btnUpdateContact.UseVisualStyleBackColor = false;
            this.btnUpdateContact.Click += new System.EventHandler(this.btnUpdateContact_Click);
            // 
            // frmUpdatedDoctorscs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(942, 422);
            this.Controls.Add(this.btnUpdateContact);
            this.Controls.Add(this.btnUpdateClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdManagesDoctor);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmUpdatedDoctorscs";
            this.Text = "UpdatedDoctors";
            this.Load += new System.EventHandler(this.frmUpdatedDoctorscs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdManagesDoctor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdManagesDoctor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpdateClose;
        private System.Windows.Forms.Button btnUpdateContact;

    }
}