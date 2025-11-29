namespace MY_DVLD_SYSTEM_AGAIN.Applications.Local_Driving_licens
{
    partial class AddUpdateLocalLicensApplication
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
            this.tcAddUpdateLocalLicensApplication = new System.Windows.Forms.TabControl();
            this.tpLinkPerson = new System.Windows.Forms.TabPage();
            this.ctrlPersonCardWithFilter1 = new MY_DVLD_SYSTEM.People.Controls.ctrlPersonCardWithFilter();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lbLinkPersonMessage = new System.Windows.Forms.Label();
            this.tpAddLocalLicensApplication = new System.Windows.Forms.TabPage();
            this.cbLicensClass = new System.Windows.Forms.ComboBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbCreatedBy = new System.Windows.Forms.Label();
            this.lbApplicationFee = new System.Windows.Forms.Label();
            this.lbApplicationDate = new System.Windows.Forms.Label();
            this.lbApplicationID = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbAddUserMessage = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tcAddUpdateLocalLicensApplication.SuspendLayout();
            this.tpLinkPerson.SuspendLayout();
            this.tpAddLocalLicensApplication.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tcAddUpdateLocalLicensApplication
            // 
            this.tcAddUpdateLocalLicensApplication.Controls.Add(this.tpLinkPerson);
            this.tcAddUpdateLocalLicensApplication.Controls.Add(this.tpAddLocalLicensApplication);
            this.tcAddUpdateLocalLicensApplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcAddUpdateLocalLicensApplication.Location = new System.Drawing.Point(-4, 2);
            this.tcAddUpdateLocalLicensApplication.Name = "tcAddUpdateLocalLicensApplication";
            this.tcAddUpdateLocalLicensApplication.SelectedIndex = 0;
            this.tcAddUpdateLocalLicensApplication.Size = new System.Drawing.Size(1025, 561);
            this.tcAddUpdateLocalLicensApplication.TabIndex = 2;
            // 
            // tpLinkPerson
            // 
            this.tpLinkPerson.Controls.Add(this.ctrlPersonCardWithFilter1);
            this.tpLinkPerson.Controls.Add(this.label3);
            this.tpLinkPerson.Controls.Add(this.label2);
            this.tpLinkPerson.Controls.Add(this.btnClose);
            this.tpLinkPerson.Controls.Add(this.btnNext);
            this.tpLinkPerson.Controls.Add(this.lbLinkPersonMessage);
            this.tpLinkPerson.Location = new System.Drawing.Point(4, 22);
            this.tpLinkPerson.Name = "tpLinkPerson";
            this.tpLinkPerson.Padding = new System.Windows.Forms.Padding(3);
            this.tpLinkPerson.Size = new System.Drawing.Size(1017, 535);
            this.tpLinkPerson.TabIndex = 0;
            this.tpLinkPerson.Text = "Link a Person";
            this.tpLinkPerson.UseVisualStyleBackColor = true;
            // 
            // ctrlPersonCardWithFilter1
            // 
            this.ctrlPersonCardWithFilter1.EnableAddButton = true;
            this.ctrlPersonCardWithFilter1.FilterEnabled = true;
            this.ctrlPersonCardWithFilter1.Location = new System.Drawing.Point(15, 51);
            this.ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            this.ctrlPersonCardWithFilter1.Size = new System.Drawing.Size(850, 431);
            this.ctrlPersonCardWithFilter1.TabIndex = 14;
            this.ctrlPersonCardWithFilter1.OnPersonSelected += new System.Action<int>(this.ctrlPersonCardWithFilter1_OnPersonSelected);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(724, 504);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 24);
            this.label3.TabIndex = 13;
            this.label3.Text = "Close";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(871, 504);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "Next";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Image = global::MY_DVLD_SYSTEM_AGAIN.Properties.Resources.cross_32;
            this.btnClose.Location = new System.Drawing.Point(793, 488);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 40);
            this.btnClose.TabIndex = 11;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnNext
            // 
            this.btnNext.Image = global::MY_DVLD_SYSTEM_AGAIN.Properties.Resources.Next_32;
            this.btnNext.Location = new System.Drawing.Point(930, 488);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(72, 40);
            this.btnNext.TabIndex = 10;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lbLinkPersonMessage
            // 
            this.lbLinkPersonMessage.AutoSize = true;
            this.lbLinkPersonMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLinkPersonMessage.ForeColor = System.Drawing.Color.Red;
            this.lbLinkPersonMessage.Location = new System.Drawing.Point(189, 16);
            this.lbLinkPersonMessage.Name = "lbLinkPersonMessage";
            this.lbLinkPersonMessage.Size = new System.Drawing.Size(487, 33);
            this.lbLinkPersonMessage.TabIndex = 1;
            this.lbLinkPersonMessage.Text = "Link A Person With The New User";
            // 
            // tpAddLocalLicensApplication
            // 
            this.tpAddLocalLicensApplication.Controls.Add(this.cbLicensClass);
            this.tpAddLocalLicensApplication.Controls.Add(this.pictureBox5);
            this.tpAddLocalLicensApplication.Controls.Add(this.pictureBox4);
            this.tpAddLocalLicensApplication.Controls.Add(this.pictureBox3);
            this.tpAddLocalLicensApplication.Controls.Add(this.pictureBox2);
            this.tpAddLocalLicensApplication.Controls.Add(this.pictureBox1);
            this.tpAddLocalLicensApplication.Controls.Add(this.lbCreatedBy);
            this.tpAddLocalLicensApplication.Controls.Add(this.lbApplicationFee);
            this.tpAddLocalLicensApplication.Controls.Add(this.lbApplicationDate);
            this.tpAddLocalLicensApplication.Controls.Add(this.lbApplicationID);
            this.tpAddLocalLicensApplication.Controls.Add(this.label9);
            this.tpAddLocalLicensApplication.Controls.Add(this.label8);
            this.tpAddLocalLicensApplication.Controls.Add(this.label4);
            this.tpAddLocalLicensApplication.Controls.Add(this.label7);
            this.tpAddLocalLicensApplication.Controls.Add(this.btnBack);
            this.tpAddLocalLicensApplication.Controls.Add(this.btnSave);
            this.tpAddLocalLicensApplication.Controls.Add(this.lbAddUserMessage);
            this.tpAddLocalLicensApplication.Controls.Add(this.label6);
            this.tpAddLocalLicensApplication.Controls.Add(this.label5);
            this.tpAddLocalLicensApplication.Controls.Add(this.label1);
            this.tpAddLocalLicensApplication.Location = new System.Drawing.Point(4, 22);
            this.tpAddLocalLicensApplication.Name = "tpAddLocalLicensApplication";
            this.tpAddLocalLicensApplication.Padding = new System.Windows.Forms.Padding(3);
            this.tpAddLocalLicensApplication.Size = new System.Drawing.Size(1017, 535);
            this.tpAddLocalLicensApplication.TabIndex = 1;
            this.tpAddLocalLicensApplication.Text = "Local drving licens Application";
            this.tpAddLocalLicensApplication.UseVisualStyleBackColor = true;
            // 
            // cbLicensClass
            // 
            this.cbLicensClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLicensClass.FormattingEnabled = true;
            this.cbLicensClass.Location = new System.Drawing.Point(316, 239);
            this.cbLicensClass.Name = "cbLicensClass";
            this.cbLicensClass.Size = new System.Drawing.Size(206, 28);
            this.cbLicensClass.TabIndex = 32;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::MY_DVLD_SYSTEM_AGAIN.Properties.Resources.LocalDriving_License;
            this.pictureBox5.Location = new System.Drawing.Point(241, 228);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(32, 32);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 31;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::MY_DVLD_SYSTEM_AGAIN.Properties.Resources.User_32__2;
            this.pictureBox4.Location = new System.Drawing.Point(241, 327);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(32, 32);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 30;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::MY_DVLD_SYSTEM_AGAIN.Properties.Resources.money_32;
            this.pictureBox3.Location = new System.Drawing.Point(241, 278);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 29;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::MY_DVLD_SYSTEM_AGAIN.Properties.Resources.Number_32;
            this.pictureBox2.Location = new System.Drawing.Point(241, 125);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 28;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MY_DVLD_SYSTEM_AGAIN.Properties.Resources.Calendar_32;
            this.pictureBox1.Location = new System.Drawing.Point(241, 166);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // lbCreatedBy
            // 
            this.lbCreatedBy.AutoSize = true;
            this.lbCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCreatedBy.Location = new System.Drawing.Point(312, 335);
            this.lbCreatedBy.Name = "lbCreatedBy";
            this.lbCreatedBy.Size = new System.Drawing.Size(50, 24);
            this.lbCreatedBy.TabIndex = 26;
            this.lbCreatedBy.Text = "????";
            // 
            // lbApplicationFee
            // 
            this.lbApplicationFee.AutoSize = true;
            this.lbApplicationFee.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApplicationFee.Location = new System.Drawing.Point(312, 293);
            this.lbApplicationFee.Name = "lbApplicationFee";
            this.lbApplicationFee.Size = new System.Drawing.Size(50, 24);
            this.lbApplicationFee.TabIndex = 25;
            this.lbApplicationFee.Text = "????";
            // 
            // lbApplicationDate
            // 
            this.lbApplicationDate.AutoSize = true;
            this.lbApplicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApplicationDate.Location = new System.Drawing.Point(312, 174);
            this.lbApplicationDate.Name = "lbApplicationDate";
            this.lbApplicationDate.Size = new System.Drawing.Size(50, 24);
            this.lbApplicationDate.TabIndex = 24;
            this.lbApplicationDate.Text = "????";
            // 
            // lbApplicationID
            // 
            this.lbApplicationID.AutoSize = true;
            this.lbApplicationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApplicationID.Location = new System.Drawing.Point(312, 125);
            this.lbApplicationID.Name = "lbApplicationID";
            this.lbApplicationID.Size = new System.Drawing.Size(50, 24);
            this.lbApplicationID.TabIndex = 20;
            this.lbApplicationID.Text = "????";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(64, 174);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(151, 24);
            this.label9.TabIndex = 19;
            this.label9.Text = "Application Date:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(64, 228);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 24);
            this.label8.TabIndex = 18;
            this.label8.Text = "Licens class:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(709, 489);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 24);
            this.label4.TabIndex = 17;
            this.label4.Text = "Back";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(827, 489);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 24);
            this.label7.TabIndex = 16;
            this.label7.Text = "Save";
            // 
            // btnBack
            // 
            this.btnBack.Image = global::MY_DVLD_SYSTEM_AGAIN.Properties.Resources.Back_32;
            this.btnBack.Location = new System.Drawing.Point(770, 479);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(51, 40);
            this.btnBack.TabIndex = 15;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::MY_DVLD_SYSTEM_AGAIN.Properties.Resources.Save_32;
            this.btnSave.Location = new System.Drawing.Point(899, 479);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(54, 43);
            this.btnSave.TabIndex = 14;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbAddUserMessage
            // 
            this.lbAddUserMessage.AutoSize = true;
            this.lbAddUserMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAddUserMessage.ForeColor = System.Drawing.Color.Red;
            this.lbAddUserMessage.Location = new System.Drawing.Point(148, 21);
            this.lbAddUserMessage.Name = "lbAddUserMessage";
            this.lbAddUserMessage.Size = new System.Drawing.Size(544, 33);
            this.lbAddUserMessage.TabIndex = 10;
            this.lbAddUserMessage.Text = "Link A Person For The New User First";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(70, 323);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 24);
            this.label6.TabIndex = 6;
            this.label6.Text = "Created by:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(64, 278);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 24);
            this.label5.TabIndex = 5;
            this.label5.Text = "Application fee:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "D.L application ID:";
            // 
            // AddUpdateLocalLicensApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 566);
            this.Controls.Add(this.tcAddUpdateLocalLicensApplication);
            this.Name = "AddUpdateLocalLicensApplication";
            this.Text = "AddUpdateLicens";
            this.Load += new System.EventHandler(this._AddUpdateLocalLicensApplication_Load);
            this.tcAddUpdateLocalLicensApplication.ResumeLayout(false);
            this.tpLinkPerson.ResumeLayout(false);
            this.tpLinkPerson.PerformLayout();
            this.tpAddLocalLicensApplication.ResumeLayout(false);
            this.tpAddLocalLicensApplication.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcAddUpdateLocalLicensApplication;
        private System.Windows.Forms.TabPage tpLinkPerson;
        private MY_DVLD_SYSTEM.People.Controls.ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lbLinkPersonMessage;
        private System.Windows.Forms.TabPage tpAddLocalLicensApplication;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbAddUserMessage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbCreatedBy;
        private System.Windows.Forms.Label lbApplicationFee;
        private System.Windows.Forms.Label lbApplicationDate;
        private System.Windows.Forms.Label lbApplicationID;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbLicensClass;
    }
}