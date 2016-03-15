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
            this.grdManagesDoctor.Location = new System.Drawing.Point(41, 73);
            this.grdManagesDoctor.Name = "grdManagesDoctor";
            this.grdManagesDoctor.Size = new System.Drawing.Size(1046, 178);
            this.grdManagesDoctor.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Doctor Information";
            // 
            // btnUpdateClose
            // 
            this.btnUpdateClose.Location = new System.Drawing.Point(822, 273);
            this.btnUpdateClose.Name = "btnUpdateClose";
            this.btnUpdateClose.Size = new System.Drawing.Size(185, 42);
            this.btnUpdateClose.TabIndex = 6;
            this.btnUpdateClose.Text = "Close";
            this.btnUpdateClose.UseVisualStyleBackColor = true;
            this.btnUpdateClose.Click += new System.EventHandler(this.btnUpdateClose_Click);
            // 
            // btnUpdateContact
            // 
            this.btnUpdateContact.Location = new System.Drawing.Point(472, 273);
            this.btnUpdateContact.Name = "btnUpdateContact";
            this.btnUpdateContact.Size = new System.Drawing.Size(185, 42);
            this.btnUpdateContact.TabIndex = 7;
            this.btnUpdateContact.Text = "Update Contact";
            this.btnUpdateContact.UseVisualStyleBackColor = true;
            this.btnUpdateContact.Click += new System.EventHandler(this.btnUpdateContact_Click);
            // 
            // frmUpdatedDoctorscs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 342);
            this.Controls.Add(this.btnUpdateContact);
            this.Controls.Add(this.btnUpdateClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdManagesDoctor);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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