namespace MY_DVLD_SYSTEM_AGAIN.Tests
{
    partial class listTestAppointments
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
            this.ctrlLocalDrivingLicensInfo1 = new MY_DVLD_SYSTEM_AGAIN.Applications.Local_Driving_licens.ctrlLocalDrivingLicensInfo();
            this.pbTestType = new System.Windows.Forms.PictureBox();
            this.lbTestType = new System.Windows.Forms.Label();
            this.dgvAppoinments = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbTotalRecords = new System.Windows.Forms.Label();
            this.btnSchedulTest = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppoinments)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlLocalDrivingLicensInfo1
            // 
            this.ctrlLocalDrivingLicensInfo1.Location = new System.Drawing.Point(3, 113);
            this.ctrlLocalDrivingLicensInfo1.Name = "ctrlLocalDrivingLicensInfo1";
            this.ctrlLocalDrivingLicensInfo1.Size = new System.Drawing.Size(742, 374);
            this.ctrlLocalDrivingLicensInfo1.TabIndex = 0;
            // 
            // pbTestType
            // 
            this.pbTestType.Image = global::MY_DVLD_SYSTEM_AGAIN.Properties.Resources.Vision_512;
            this.pbTestType.Location = new System.Drawing.Point(272, -9);
            this.pbTestType.Name = "pbTestType";
            this.pbTestType.Size = new System.Drawing.Size(131, 91);
            this.pbTestType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTestType.TabIndex = 1;
            this.pbTestType.TabStop = false;
            // 
            // lbTestType
            // 
            this.lbTestType.AutoSize = true;
            this.lbTestType.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTestType.ForeColor = System.Drawing.Color.Red;
            this.lbTestType.Location = new System.Drawing.Point(228, 85);
            this.lbTestType.Name = "lbTestType";
            this.lbTestType.Size = new System.Drawing.Size(209, 25);
            this.lbTestType.TabIndex = 2;
            this.lbTestType.Text = "schedul vision test";
            // 
            // dgvAppoinments
            // 
            this.dgvAppoinments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppoinments.Location = new System.Drawing.Point(12, 533);
            this.dgvAppoinments.Name = "dgvAppoinments";
            this.dgvAppoinments.Size = new System.Drawing.Size(722, 150);
            this.dgvAppoinments.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(632, 363);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 503);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Appoinments";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 686);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Records";
            // 
            // lbTotalRecords
            // 
            this.lbTotalRecords.AutoSize = true;
            this.lbTotalRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalRecords.Location = new System.Drawing.Point(101, 686);
            this.lbTotalRecords.Name = "lbTotalRecords";
            this.lbTotalRecords.Size = new System.Drawing.Size(26, 18);
            this.lbTotalRecords.TabIndex = 7;
            this.lbTotalRecords.Text = "??";
            // 
            // btnSchedulTest
            // 
            this.btnSchedulTest.Image = global::MY_DVLD_SYSTEM_AGAIN.Properties.Resources.AddAppointment_32;
            this.btnSchedulTest.Location = new System.Drawing.Point(683, 484);
            this.btnSchedulTest.Name = "btnSchedulTest";
            this.btnSchedulTest.Size = new System.Drawing.Size(51, 43);
            this.btnSchedulTest.TabIndex = 8;
            this.btnSchedulTest.UseVisualStyleBackColor = true;
            this.btnSchedulTest.Click += new System.EventHandler(this.btnSchedulTest_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(631, 503);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "Add :";
            // 
            // listTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 727);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSchedulTest);
            this.Controls.Add(this.lbTotalRecords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvAppoinments);
            this.Controls.Add(this.lbTestType);
            this.Controls.Add(this.pbTestType);
            this.Controls.Add(this.ctrlLocalDrivingLicensInfo1);
            this.Name = "listTestAppointments";
            this.Text = "listTestAppointments";
            this.Load += new System.EventHandler(this.listTestAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppoinments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Applications.Local_Driving_licens.ctrlLocalDrivingLicensInfo ctrlLocalDrivingLicensInfo1;
        private System.Windows.Forms.PictureBox pbTestType;
        private System.Windows.Forms.Label lbTestType;
        private System.Windows.Forms.DataGridView dgvAppoinments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbTotalRecords;
        private System.Windows.Forms.Button btnSchedulTest;
        private System.Windows.Forms.Label label4;
    }
}