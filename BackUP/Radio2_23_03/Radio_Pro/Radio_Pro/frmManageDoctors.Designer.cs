namespace Radio_Pro
{
    partial class frmManageDoctors
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageDoctors));
            this.grdManagesDoctor = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdateInfo = new System.Windows.Forms.Button();
            this.btnViewUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdManagesDoctor)).BeginInit();
            this.SuspendLayout();
            // 
            // grdManagesDoctor
            // 
            this.grdManagesDoctor.AllowUserToOrderColumns = true;
            this.grdManagesDoctor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grdManagesDoctor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdManagesDoctor.Location = new System.Drawing.Point(31, 96);
            this.grdManagesDoctor.Name = "grdManagesDoctor";
            this.grdManagesDoctor.Size = new System.Drawing.Size(966, 169);
            this.grdManagesDoctor.TabIndex = 0;
            this.grdManagesDoctor.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdManagesDoctor_CellContentClick);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(383, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Doctor Information";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnUpdateInfo
            // 
            this.btnUpdateInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUpdateInfo.Location = new System.Drawing.Point(812, 285);
            this.btnUpdateInfo.Name = "btnUpdateInfo";
            this.btnUpdateInfo.Size = new System.Drawing.Size(185, 40);
            this.btnUpdateInfo.TabIndex = 2;
            this.btnUpdateInfo.Text = "Update Info";
            this.btnUpdateInfo.UseVisualStyleBackColor = true;
            this.btnUpdateInfo.Click += new System.EventHandler(this.btnUpdateInfo_Click);
            // 
            // btnViewUpdate
            // 
            this.btnViewUpdate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnViewUpdate.Location = new System.Drawing.Point(499, 285);
            this.btnViewUpdate.Name = "btnViewUpdate";
            this.btnViewUpdate.Size = new System.Drawing.Size(185, 40);
            this.btnViewUpdate.TabIndex = 3;
            this.btnViewUpdate.Text = "View Update Info";
            this.btnViewUpdate.UseVisualStyleBackColor = true;
            this.btnViewUpdate.Click += new System.EventHandler(this.btnViewUpdate_Click);
            // 
            // frmManageDoctors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1033, 363);
            this.Controls.Add(this.btnViewUpdate);
            this.Controls.Add(this.btnUpdateInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdManagesDoctor);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmManageDoctors";
            this.Text = "ManageDoctors";
            this.Load += new System.EventHandler(this.frmManageDoctors_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdManagesDoctor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdManagesDoctor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpdateInfo;
        private System.Windows.Forms.Button btnViewUpdate;
    }
}