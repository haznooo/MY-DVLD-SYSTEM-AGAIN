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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSearchFilter = new System.Windows.Forms.ComboBox();
            this.lbTotalRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddUpdate = new System.Windows.Forms.Button();
            this.dgvApplications = new System.Windows.Forms.DataGridView();
            this.cmsApplicationOpetions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writtenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.streetTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueDrivingLicensfristTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licensesHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplications)).BeginInit();
            this.cmsApplicationOpetions.SuspendLayout();
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
            this.pictureBox1.Image = global::MY_DVLD_SYSTEM_AGAIN.Properties.Resources.Applications;
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
            this.dgvApplications.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvApplications.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvApplications.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplications.ContextMenuStrip = this.cmsApplicationOpetions;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvApplications.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvApplications.Location = new System.Drawing.Point(2, 299);
            this.dgvApplications.Name = "dgvApplications";
            this.dgvApplications.ReadOnly = true;
            this.dgvApplications.Size = new System.Drawing.Size(1375, 387);
            this.dgvApplications.TabIndex = 32;
            // 
            // cmsApplicationOpetions
            // 
            this.cmsApplicationOpetions.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.cmsApplicationOpetions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detailsToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.cancelToolStripMenuItem,
            this.sToolStripMenuItem,
            this.issueDrivingLicensfristTimeToolStripMenuItem,
            this.showLicensToolStripMenuItem,
            this.licensesHistoryToolStripMenuItem});
            this.cmsApplicationOpetions.Name = "cmsPeopleOpetions";
            this.cmsApplicationOpetions.Size = new System.Drawing.Size(246, 314);
            this.cmsApplicationOpetions.Opening += new System.ComponentModel.CancelEventHandler(this.cmsApplicationOpetions_Opening);
            // 
            // detailsToolStripMenuItem
            // 
            this.detailsToolStripMenuItem.Image = global::MY_DVLD_SYSTEM_AGAIN.Properties.Resources.PersonDetails_32;
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            this.detailsToolStripMenuItem.Size = new System.Drawing.Size(245, 36);
            this.detailsToolStripMenuItem.Text = "Details";
            this.detailsToolStripMenuItem.Click += new System.EventHandler(this.detailsToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::MY_DVLD_SYSTEM_AGAIN.Properties.Resources.edit_32;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(245, 36);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::MY_DVLD_SYSTEM_AGAIN.Properties.Resources.Delete_32_2;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(245, 36);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Image = global::MY_DVLD_SYSTEM_AGAIN.Properties.Resources.Delete_32;
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(245, 36);
            this.cancelToolStripMenuItem.Text = "Cancel";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // sToolStripMenuItem
            // 
            this.sToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visionTestToolStripMenuItem,
            this.writtenTestToolStripMenuItem,
            this.streetTestToolStripMenuItem});
            this.sToolStripMenuItem.Image = global::MY_DVLD_SYSTEM_AGAIN.Properties.Resources.Schedule_Test_32;
            this.sToolStripMenuItem.Name = "sToolStripMenuItem";
            this.sToolStripMenuItem.Size = new System.Drawing.Size(245, 36);
            this.sToolStripMenuItem.Text = "schedul test";
            this.sToolStripMenuItem.DropDownOpening += new System.EventHandler(this.sToolStripMenuItem_DropDownOpening);
            // 
            // visionTestToolStripMenuItem
            // 
            this.visionTestToolStripMenuItem.Image = global::MY_DVLD_SYSTEM_AGAIN.Properties.Resources.Vision_Test_Schdule;
            this.visionTestToolStripMenuItem.Name = "visionTestToolStripMenuItem";
            this.visionTestToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.visionTestToolStripMenuItem.Text = "vision test";
            this.visionTestToolStripMenuItem.Click += new System.EventHandler(this.visionTestToolStripMenuItem_Click);
            // 
            // writtenTestToolStripMenuItem
            // 
            this.writtenTestToolStripMenuItem.Enabled = false;
            this.writtenTestToolStripMenuItem.Image = global::MY_DVLD_SYSTEM_AGAIN.Properties.Resources.Written_Test_32_Sechdule;
            this.writtenTestToolStripMenuItem.Name = "writtenTestToolStripMenuItem";
            this.writtenTestToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.writtenTestToolStripMenuItem.Text = "written test";
            this.writtenTestToolStripMenuItem.Click += new System.EventHandler(this.writtenTestToolStripMenuItem_Click);
            // 
            // streetTestToolStripMenuItem
            // 
            this.streetTestToolStripMenuItem.Enabled = false;
            this.streetTestToolStripMenuItem.Image = global::MY_DVLD_SYSTEM_AGAIN.Properties.Resources.Street_Test_32;
            this.streetTestToolStripMenuItem.Name = "streetTestToolStripMenuItem";
            this.streetTestToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.streetTestToolStripMenuItem.Text = "street test";
            this.streetTestToolStripMenuItem.Click += new System.EventHandler(this.streetTestToolStripMenuItem_Click);
            // 
            // issueDrivingLicensfristTimeToolStripMenuItem
            // 
            this.issueDrivingLicensfristTimeToolStripMenuItem.Enabled = false;
            this.issueDrivingLicensfristTimeToolStripMenuItem.Image = global::MY_DVLD_SYSTEM_AGAIN.Properties.Resources.IssueDrivingLicense_32;
            this.issueDrivingLicensfristTimeToolStripMenuItem.Name = "issueDrivingLicensfristTimeToolStripMenuItem";
            this.issueDrivingLicensfristTimeToolStripMenuItem.Size = new System.Drawing.Size(245, 36);
            this.issueDrivingLicensfristTimeToolStripMenuItem.Text = "issue driving licens (frist time)";
            this.issueDrivingLicensfristTimeToolStripMenuItem.Click += new System.EventHandler(this.issueDrivingLicensfristTimeToolStripMenuItem_Click);
            // 
            // showLicensToolStripMenuItem
            // 
            this.showLicensToolStripMenuItem.Enabled = false;
            this.showLicensToolStripMenuItem.Image = global::MY_DVLD_SYSTEM_AGAIN.Properties.Resources.Driver_License_48;
            this.showLicensToolStripMenuItem.Name = "showLicensToolStripMenuItem";
            this.showLicensToolStripMenuItem.Size = new System.Drawing.Size(245, 36);
            this.showLicensToolStripMenuItem.Text = "show licens";
            // 
            // licensesHistoryToolStripMenuItem
            // 
            this.licensesHistoryToolStripMenuItem.Image = global::MY_DVLD_SYSTEM_AGAIN.Properties.Resources.PersonLicenseHistory_32;
            this.licensesHistoryToolStripMenuItem.Name = "licensesHistoryToolStripMenuItem";
            this.licensesHistoryToolStripMenuItem.Size = new System.Drawing.Size(245, 36);
            this.licensesHistoryToolStripMenuItem.Text = "licenses history";
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
            this.cmsApplicationOpetions.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip cmsApplicationOpetions;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issueDrivingLicensfristTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicensToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem licensesHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writtenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem streetTestToolStripMenuItem;
    }
}