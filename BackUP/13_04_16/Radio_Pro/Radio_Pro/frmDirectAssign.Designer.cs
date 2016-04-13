namespace Radio_Pro
{
    partial class frmDirectAssign
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
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAssignData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstUsers
            // 
            this.lstUsers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.ItemHeight = 18;
            this.lstUsers.Location = new System.Drawing.Point(34, 53);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(120, 76);
            this.lstUsers.TabIndex = 75;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 18);
            this.label3.TabIndex = 77;
            this.label3.Text = "Select Users";
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
            this.btnAssignData.Location = new System.Drawing.Point(177, 65);
            this.btnAssignData.Name = "btnAssignData";
            this.btnAssignData.Size = new System.Drawing.Size(82, 31);
            this.btnAssignData.TabIndex = 76;
            this.btnAssignData.Text = "Assign";
            this.btnAssignData.UseVisualStyleBackColor = false;
            this.btnAssignData.Click += new System.EventHandler(this.btnAssignData_Click);
            // 
            // frmDirectAssign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(290, 165);
            this.Controls.Add(this.lstUsers);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAssignData);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmDirectAssign";
            this.Text = "DirectAssign";
            this.Load += new System.EventHandler(this.frmDirectAssign_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAssignData;
    }
}