namespace MY_DVLD_SYSTEM_AGAIN.licenses.InternationalLicenses
{
    partial class IssueInternationalLicense
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
            this.ctrlDriverLicenseInfoWithSearch1 = new MY_DVLD_SYSTEM_AGAIN.licenses.local_Licenses.ctrlDriverLicenseInfoWithSearch();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbApplicationDate = new System.Windows.Forms.Label();
            this.lbIssueDate = new System.Windows.Forms.Label();
            this.InternationalLicenseID = new System.Windows.Forms.Label();
            this.InternationalLicenseApplicationID = new System.Windows.Forms.Label();
            this.lbCreatedBy = new System.Windows.Forms.Label();
            this.lbLocalLicenseID = new System.Windows.Forms.Label();
            this.lbExpirationDate = new System.Windows.Forms.Label();
            this.lbFees = new System.Windows.Forms.Label();
            this.btnIssue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlDriverLicenseInfoWithSearch1
            // 
            this.ctrlDriverLicenseInfoWithSearch1.Enable_serach = true;
            this.ctrlDriverLicenseInfoWithSearch1.Location = new System.Drawing.Point(12, 12);
            this.ctrlDriverLicenseInfoWithSearch1.Name = "ctrlDriverLicenseInfoWithSearch1";
            this.ctrlDriverLicenseInfoWithSearch1.Size = new System.Drawing.Size(872, 388);
            this.ctrlDriverLicenseInfoWithSearch1.TabIndex = 0;
            this.ctrlDriverLicenseInfoWithSearch1.OnLicenseSelected += new System.Action<int>(this.ctrlDriverLicenseInfoWithSearch1_OnLicenseSelected);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 520);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Application Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(454, 479);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = " fees";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(454, 432);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Issue Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(454, 562);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Local License ID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 562);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Created By";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(454, 520);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "Expiration Date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 432);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "I.L Application ID ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 479);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "I.L License ID";
            // 
            // lbApplicationDate
            // 
            this.lbApplicationDate.AutoSize = true;
            this.lbApplicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApplicationDate.Location = new System.Drawing.Point(164, 520);
            this.lbApplicationDate.Name = "lbApplicationDate";
            this.lbApplicationDate.Size = new System.Drawing.Size(45, 20);
            this.lbApplicationDate.TabIndex = 10;
            this.lbApplicationDate.Text = "????";
            // 
            // lbIssueDate
            // 
            this.lbIssueDate.AutoSize = true;
            this.lbIssueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIssueDate.Location = new System.Drawing.Point(590, 432);
            this.lbIssueDate.Name = "lbIssueDate";
            this.lbIssueDate.Size = new System.Drawing.Size(45, 20);
            this.lbIssueDate.TabIndex = 11;
            this.lbIssueDate.Text = "????";
            // 
            // InternationalLicenseID
            // 
            this.InternationalLicenseID.AutoSize = true;
            this.InternationalLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InternationalLicenseID.Location = new System.Drawing.Point(164, 479);
            this.InternationalLicenseID.Name = "InternationalLicenseID";
            this.InternationalLicenseID.Size = new System.Drawing.Size(45, 20);
            this.InternationalLicenseID.TabIndex = 12;
            this.InternationalLicenseID.Text = "????";
            // 
            // InternationalLicenseApplicationID
            // 
            this.InternationalLicenseApplicationID.AutoSize = true;
            this.InternationalLicenseApplicationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InternationalLicenseApplicationID.Location = new System.Drawing.Point(164, 432);
            this.InternationalLicenseApplicationID.Name = "InternationalLicenseApplicationID";
            this.InternationalLicenseApplicationID.Size = new System.Drawing.Size(45, 20);
            this.InternationalLicenseApplicationID.TabIndex = 13;
            this.InternationalLicenseApplicationID.Text = "????";
            // 
            // lbCreatedBy
            // 
            this.lbCreatedBy.AutoSize = true;
            this.lbCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCreatedBy.Location = new System.Drawing.Point(164, 562);
            this.lbCreatedBy.Name = "lbCreatedBy";
            this.lbCreatedBy.Size = new System.Drawing.Size(45, 20);
            this.lbCreatedBy.TabIndex = 14;
            this.lbCreatedBy.Text = "????";
            // 
            // lbLocalLicenseID
            // 
            this.lbLocalLicenseID.AutoSize = true;
            this.lbLocalLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLocalLicenseID.Location = new System.Drawing.Point(603, 562);
            this.lbLocalLicenseID.Name = "lbLocalLicenseID";
            this.lbLocalLicenseID.Size = new System.Drawing.Size(45, 20);
            this.lbLocalLicenseID.TabIndex = 16;
            this.lbLocalLicenseID.Text = "????";
            // 
            // lbExpirationDate
            // 
            this.lbExpirationDate.AutoSize = true;
            this.lbExpirationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExpirationDate.Location = new System.Drawing.Point(590, 520);
            this.lbExpirationDate.Name = "lbExpirationDate";
            this.lbExpirationDate.Size = new System.Drawing.Size(45, 20);
            this.lbExpirationDate.TabIndex = 17;
            this.lbExpirationDate.Text = "????";
            // 
            // lbFees
            // 
            this.lbFees.AutoSize = true;
            this.lbFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFees.Location = new System.Drawing.Point(590, 479);
            this.lbFees.Name = "lbFees";
            this.lbFees.Size = new System.Drawing.Size(45, 20);
            this.lbFees.TabIndex = 18;
            this.lbFees.Text = "????";
            // 
            // btnIssue
            // 
            this.btnIssue.Enabled = false;
            this.btnIssue.Location = new System.Drawing.Point(767, 675);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(75, 23);
            this.btnIssue.TabIndex = 19;
            this.btnIssue.Text = "issue";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // IssueInternationalLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 723);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.lbFees);
            this.Controls.Add(this.lbExpirationDate);
            this.Controls.Add(this.lbLocalLicenseID);
            this.Controls.Add(this.lbCreatedBy);
            this.Controls.Add(this.InternationalLicenseApplicationID);
            this.Controls.Add(this.InternationalLicenseID);
            this.Controls.Add(this.lbIssueDate);
            this.Controls.Add(this.lbApplicationDate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlDriverLicenseInfoWithSearch1);
            this.Name = "IssueInternationalLicense";
            this.Text = "IssueInternationalLicense";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private local_Licenses.ctrlDriverLicenseInfoWithSearch ctrlDriverLicenseInfoWithSearch1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbApplicationDate;
        private System.Windows.Forms.Label lbIssueDate;
        private System.Windows.Forms.Label InternationalLicenseID;
        private System.Windows.Forms.Label InternationalLicenseApplicationID;
        private System.Windows.Forms.Label lbCreatedBy;
        private System.Windows.Forms.Label lbLocalLicenseID;
        private System.Windows.Forms.Label lbExpirationDate;
        private System.Windows.Forms.Label lbFees;
        private System.Windows.Forms.Button btnIssue;
    }
}