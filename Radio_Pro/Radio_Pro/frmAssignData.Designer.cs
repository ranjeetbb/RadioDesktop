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
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grdShowData = new System.Windows.Forms.DataGridView();
            this.btnAssignData = new System.Windows.Forms.Button();
            this.cmbDeviceId = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSelectArea = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSelectDoctors = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFetchData = new System.Windows.Forms.Button();
            this.ccb = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdShowData)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEndDate
            // 
            this.txtEndDate.Location = new System.Drawing.Point(612, 31);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(232, 26);
            this.txtEndDate.TabIndex = 14;
            // 
            // txtStartDate
            // 
            this.txtStartDate.Location = new System.Drawing.Point(233, 30);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(232, 26);
            this.txtStartDate.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(509, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 19);
            this.label2.TabIndex = 12;
            this.label2.Text = "End Data";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 19);
            this.label1.TabIndex = 11;
            this.label1.Text = "Start Date";
            // 
            // grdShowData
            // 
            this.grdShowData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdShowData.Location = new System.Drawing.Point(29, 221);
            this.grdShowData.Name = "grdShowData";
            this.grdShowData.Size = new System.Drawing.Size(969, 132);
            this.grdShowData.TabIndex = 10;
            // 
            // btnAssignData
            // 
            this.btnAssignData.Location = new System.Drawing.Point(608, 370);
            this.btnAssignData.Name = "btnAssignData";
            this.btnAssignData.Size = new System.Drawing.Size(198, 57);
            this.btnAssignData.TabIndex = 9;
            this.btnAssignData.Text = "Assign To";
            this.btnAssignData.UseVisualStyleBackColor = true;
            this.btnAssignData.Click += new System.EventHandler(this.btnFetchData_Click);
            // 
            // cmbDeviceId
            // 
            this.cmbDeviceId.FormattingEnabled = true;
            this.cmbDeviceId.Location = new System.Drawing.Point(233, 386);
            this.cmbDeviceId.Name = "cmbDeviceId";
            this.cmbDeviceId.Size = new System.Drawing.Size(232, 27);
            this.cmbDeviceId.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 394);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 19);
            this.label3.TabIndex = 15;
            this.label3.Text = "Select Users";
            // 
            // cmbSelectArea
            // 
            this.cmbSelectArea.FormattingEnabled = true;
            this.cmbSelectArea.Location = new System.Drawing.Point(233, 108);
            this.cmbSelectArea.Name = "cmbSelectArea";
            this.cmbSelectArea.Size = new System.Drawing.Size(232, 27);
            this.cmbSelectArea.TabIndex = 18;
            this.cmbSelectArea.SelectedIndexChanged += new System.EventHandler(this.cmbSelectArea_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(118, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 19);
            this.label4.TabIndex = 17;
            this.label4.Text = "Select Area";
            // 
            // cmbSelectDoctors
            // 
            this.cmbSelectDoctors.FormattingEnabled = true;
            this.cmbSelectDoctors.Location = new System.Drawing.Point(612, 108);
            this.cmbSelectDoctors.Name = "cmbSelectDoctors";
            this.cmbSelectDoctors.Size = new System.Drawing.Size(232, 27);
            this.cmbSelectDoctors.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(497, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 19);
            this.label5.TabIndex = 19;
            this.label5.Text = "Select Doctors";
            // 
            // btnFetchData
            // 
            this.btnFetchData.Location = new System.Drawing.Point(426, 158);
            this.btnFetchData.Name = "btnFetchData";
            this.btnFetchData.Size = new System.Drawing.Size(198, 44);
            this.btnFetchData.TabIndex = 21;
            this.btnFetchData.Text = "Fetch Data";
            this.btnFetchData.UseVisualStyleBackColor = true;
            this.btnFetchData.Click += new System.EventHandler(this.btnFetchData_Click_1);
            // 
            // ccb
            // 
            this.ccb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ccb.DropDownHeight = 1;
            this.ccb.FormattingEnabled = true;
            this.ccb.IntegralHeight = false;
            this.ccb.Location = new System.Drawing.Point(135, 168);
            this.ccb.Name = "ccb";
            this.ccb.Size = new System.Drawing.Size(233, 27);
            this.ccb.TabIndex = 22;
            // 
            // frmAssignData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 441);
            this.Controls.Add(this.ccb);
            this.Controls.Add(this.btnFetchData);
            this.Controls.Add(this.cmbSelectDoctors);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbSelectArea);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbDeviceId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.txtStartDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdShowData);
            this.Controls.Add(this.btnAssignData);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAssignData";
            this.Text = "AssignData";
            this.Load += new System.EventHandler(this.frmAssignData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdShowData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grdShowData;
        private System.Windows.Forms.Button btnAssignData;
        private System.Windows.Forms.ComboBox cmbDeviceId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSelectArea;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSelectDoctors;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFetchData;
        private System.Windows.Forms.ComboBox ccb;
    }
}