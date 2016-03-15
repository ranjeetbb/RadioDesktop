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
            this.grdManagesDoctor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdManagesDoctor.Location = new System.Drawing.Point(31, 101);
            this.grdManagesDoctor.Name = "grdManagesDoctor";
            this.grdManagesDoctor.Size = new System.Drawing.Size(966, 178);
            this.grdManagesDoctor.TabIndex = 0;
            this.grdManagesDoctor.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdManagesDoctor_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Doctor Information";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnUpdateInfo
            // 
            this.btnUpdateInfo.Location = new System.Drawing.Point(812, 301);
            this.btnUpdateInfo.Name = "btnUpdateInfo";
            this.btnUpdateInfo.Size = new System.Drawing.Size(185, 42);
            this.btnUpdateInfo.TabIndex = 2;
            this.btnUpdateInfo.Text = "Update Info";
            this.btnUpdateInfo.UseVisualStyleBackColor = true;
            this.btnUpdateInfo.Click += new System.EventHandler(this.btnUpdateInfo_Click);
            // 
            // btnViewUpdate
            // 
            this.btnViewUpdate.Location = new System.Drawing.Point(499, 301);
            this.btnViewUpdate.Name = "btnViewUpdate";
            this.btnViewUpdate.Size = new System.Drawing.Size(185, 42);
            this.btnViewUpdate.TabIndex = 3;
            this.btnViewUpdate.Text = "View Update Info";
            this.btnViewUpdate.UseVisualStyleBackColor = true;
            this.btnViewUpdate.Click += new System.EventHandler(this.btnViewUpdate_Click);
            // 
            // frmManageDoctors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 383);
            this.Controls.Add(this.btnViewUpdate);
            this.Controls.Add(this.btnUpdateInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdManagesDoctor);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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