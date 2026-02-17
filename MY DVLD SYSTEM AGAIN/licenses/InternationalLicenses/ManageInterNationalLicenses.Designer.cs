namespace MY_DVLD_SYSTEM_AGAIN.licenses.InternationalLicenses
{
    partial class ManageInterNationalLicenses
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
            this.dgvAllInternationalLicenses = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTotalRecords = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllInternationalLicenses)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAllInternationalLicenses
            // 
            this.dgvAllInternationalLicenses.AllowUserToAddRows = false;
            this.dgvAllInternationalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllInternationalLicenses.Location = new System.Drawing.Point(12, 91);
            this.dgvAllInternationalLicenses.Name = "dgvAllInternationalLicenses";
            this.dgvAllInternationalLicenses.Size = new System.Drawing.Size(896, 427);
            this.dgvAllInternationalLicenses.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 544);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Records :";
            // 
            // lbTotalRecords
            // 
            this.lbTotalRecords.AutoSize = true;
            this.lbTotalRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalRecords.Location = new System.Drawing.Point(104, 544);
            this.lbTotalRecords.Name = "lbTotalRecords";
            this.lbTotalRecords.Size = new System.Drawing.Size(39, 20);
            this.lbTotalRecords.TabIndex = 2;
            this.lbTotalRecords.Text = "???";
            // 
            // ManageInterNationalLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 611);
            this.Controls.Add(this.lbTotalRecords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvAllInternationalLicenses);
            this.Name = "ManageInterNationalLicenses";
            this.Text = "ManageInterNationalLicenses";
            this.Load += new System.EventHandler(this.ManageInterNationalLicenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllInternationalLicenses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAllInternationalLicenses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTotalRecords;
    }
}