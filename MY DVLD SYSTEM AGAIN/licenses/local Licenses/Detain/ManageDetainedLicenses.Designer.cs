namespace MY_DVLD_SYSTEM_AGAIN.licenses.local_Licenses.Detain
{
    partial class ManageDetainedLicenses
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSearchFilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDetainLicense = new System.Windows.Forms.Button();
            this.dgvDetainedLicenses = new System.Windows.Forms.DataGridView();
            this.btnReleaseLicense = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lbTotalRecords = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainedLicenses)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::MY_DVLD_SYSTEM_AGAIN.Properties.Resources.SearchPerson;
            this.btnSearch.Location = new System.Drawing.Point(3, 226);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(43, 43);
            this.btnSearch.TabIndex = 43;
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-188, 223);
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
            "None",
            "Person ID",
            "National Number",
            "Phone",
            "First Name",
            "Second Name",
            "Third Name",
            "Last Name",
            "Gender",
            "Address",
            "Email"});
            this.cbSearchFilter.Location = new System.Drawing.Point(-122, 220);
            this.cbSearchFilter.Name = "cbSearchFilter";
            this.cbSearchFilter.Size = new System.Drawing.Size(121, 28);
            this.cbSearchFilter.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-168, 664);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 36;
            this.label2.Text = "Record:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MY_DVLD_SYSTEM_AGAIN.Properties.Resources.Detain_512;
            this.pictureBox1.Location = new System.Drawing.Point(408, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(274, 188);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.UseWaitCursor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Constantia", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(407, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 59);
            this.label1.TabIndex = 34;
            this.label1.Text = "Detained list";
            // 
            // btnDetainLicense
            // 
            this.btnDetainLicense.Image = global::MY_DVLD_SYSTEM_AGAIN.Properties.Resources.Detain_64;
            this.btnDetainLicense.Location = new System.Drawing.Point(1288, 190);
            this.btnDetainLicense.Name = "btnDetainLicense";
            this.btnDetainLicense.Size = new System.Drawing.Size(87, 75);
            this.btnDetainLicense.TabIndex = 33;
            this.btnDetainLicense.UseVisualStyleBackColor = true;
            this.btnDetainLicense.Click += new System.EventHandler(this.btnDetainLicense_Click);
            // 
            // dgvDetainedLicenses
            // 
            this.dgvDetainedLicenses.AllowUserToAddRows = false;
            this.dgvDetainedLicenses.AllowUserToDeleteRows = false;
            this.dgvDetainedLicenses.AllowUserToOrderColumns = true;
            this.dgvDetainedLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetainedLicenses.Location = new System.Drawing.Point(3, 271);
            this.dgvDetainedLicenses.Name = "dgvDetainedLicenses";
            this.dgvDetainedLicenses.ReadOnly = true;
            this.dgvDetainedLicenses.Size = new System.Drawing.Size(1375, 387);
            this.dgvDetainedLicenses.TabIndex = 32;
            // 
            // btnReleaseLicense
            // 
            this.btnReleaseLicense.Image = global::MY_DVLD_SYSTEM_AGAIN.Properties.Resources.Release_Detained_License_64;
            this.btnReleaseLicense.Location = new System.Drawing.Point(1195, 190);
            this.btnReleaseLicense.Name = "btnReleaseLicense";
            this.btnReleaseLicense.Size = new System.Drawing.Size(87, 75);
            this.btnReleaseLicense.TabIndex = 44;
            this.btnReleaseLicense.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(12, 671);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 23);
            this.label4.TabIndex = 45;
            this.label4.Text = "Records :";
            // 
            // lbTotalRecords
            // 
            this.lbTotalRecords.AutoSize = true;
            this.lbTotalRecords.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalRecords.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbTotalRecords.Location = new System.Drawing.Point(110, 671);
            this.lbTotalRecords.Name = "lbTotalRecords";
            this.lbTotalRecords.Size = new System.Drawing.Size(46, 23);
            this.lbTotalRecords.TabIndex = 46;
            this.lbTotalRecords.Text = "????";
            // 
            // ManageDetainedLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1381, 730);
            this.Controls.Add(this.lbTotalRecords);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnReleaseLicense);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbSearchFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDetainLicense);
            this.Controls.Add(this.dgvDetainedLicenses);
            this.Name = "ManageDetainedLicenses";
            this.Text = "ManageDetainedLicenses";
            this.Load += new System.EventHandler(this.ManageDetainedLicenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetainedLicenses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbSearchFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDetainLicense;
        private System.Windows.Forms.DataGridView dgvDetainedLicenses;
        private System.Windows.Forms.Button btnReleaseLicense;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbTotalRecords;
    }
}