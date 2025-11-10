namespace MY_DVLD_SYSTEM_AGAIN.Applications.Local_Driving_licens
{
    partial class ManageLocalDrivingLicenses
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
            this.label3 = new System.Windows.Forms.Label();
            this.cbSearchFilter = new System.Windows.Forms.ComboBox();
            this.lbTotalRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddUpdate = new System.Windows.Forms.Button();
            this.dgvApplications = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplications)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 266);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 25);
            this.label3.TabIndex = 40;
            this.label3.Text = "Filter:";
            // 
            // cbSearchFilter
            // 
            this.cbSearchFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSearchFilter.FormattingEnabled = true;
            this.cbSearchFilter.Items.AddRange(new object[] {
            "none"});
            this.cbSearchFilter.Location = new System.Drawing.Point(76, 263);
            this.cbSearchFilter.Name = "cbSearchFilter";
            this.cbSearchFilter.Size = new System.Drawing.Size(121, 28);
            this.cbSearchFilter.TabIndex = 38;
            // 
            // lbTotalRecords
            // 
            this.lbTotalRecords.AutoSize = true;
            this.lbTotalRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalRecords.Location = new System.Drawing.Point(108, 707);
            this.lbTotalRecords.Name = "lbTotalRecords";
            this.lbTotalRecords.Size = new System.Drawing.Size(49, 20);
            this.lbTotalRecords.TabIndex = 37;
            this.lbTotalRecords.Text = "????";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 707);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 36;
            this.label2.Text = "Record:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MY_DVLD_SYSTEM_AGAIN.Properties.Resources.LicenseView_400;
            this.pictureBox1.Location = new System.Drawing.Point(598, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(284, 197);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.UseWaitCursor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Constantia", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(425, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(631, 66);
            this.label1.TabIndex = 34;
            this.label1.Text = "Manage local applications";
            // 
            // btnAddUpdate
            // 
            this.btnAddUpdate.Image = global::MY_DVLD_SYSTEM_AGAIN.Properties.Resources.New_Application_64;
            this.btnAddUpdate.Location = new System.Drawing.Point(1290, 221);
            this.btnAddUpdate.Name = "btnAddUpdate";
            this.btnAddUpdate.Size = new System.Drawing.Size(87, 75);
            this.btnAddUpdate.TabIndex = 33;
            this.btnAddUpdate.UseVisualStyleBackColor = true;
            this.btnAddUpdate.Click += new System.EventHandler(this.btnAddUpdate_Click);
            // 
            // dgvApplications
            // 
            this.dgvApplications.AllowUserToAddRows = false;
            this.dgvApplications.AllowUserToDeleteRows = false;
            this.dgvApplications.AllowUserToOrderColumns = true;
            this.dgvApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplications.Location = new System.Drawing.Point(2, 299);
            this.dgvApplications.Name = "dgvApplications";
            this.dgvApplications.ReadOnly = true;
            this.dgvApplications.Size = new System.Drawing.Size(1375, 387);
            this.dgvApplications.TabIndex = 32;
            // 
            // ManageLocalDrivingLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 728);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbSearchFilter);
            this.Controls.Add(this.lbTotalRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddUpdate);
            this.Controls.Add(this.dgvApplications);
            this.Name = "ManageLocalDrivingLicenses";
            this.Text = "ManageLocalDrivingLicenses";
            this.Load += new System.EventHandler(this.ManagePeopleMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplications)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbSearchFilter;
        private System.Windows.Forms.Label lbTotalRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddUpdate;
        private System.Windows.Forms.DataGridView dgvApplications;
    }
}