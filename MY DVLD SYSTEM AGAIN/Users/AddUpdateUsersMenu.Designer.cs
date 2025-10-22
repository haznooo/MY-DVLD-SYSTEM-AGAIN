namespace MY_DVLD_SYSTEM_AGAIN.Users
{
    partial class AddUpdateUsersMenu
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
            this.tcAddUpdateUsers = new System.Windows.Forms.TabControl();
            this.tpLinkPerson = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbLinkPersonMessage = new System.Windows.Forms.Label();
            this.tpAddUser = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbAddUserMessage = new System.Windows.Forms.Label();
            this.cbIsActvie = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.ctrlPersonCardWithFilter1 = new MY_DVLD_SYSTEM.People.Controls.ctrlPersonCardWithFilter();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tcAddUpdateUsers.SuspendLayout();
            this.tpLinkPerson.SuspendLayout();
            this.tpAddUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tcAddUpdateUsers
            // 
            this.tcAddUpdateUsers.Controls.Add(this.tpLinkPerson);
            this.tcAddUpdateUsers.Controls.Add(this.tpAddUser);
            this.tcAddUpdateUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcAddUpdateUsers.Location = new System.Drawing.Point(12, 12);
            this.tcAddUpdateUsers.Name = "tcAddUpdateUsers";
            this.tcAddUpdateUsers.SelectedIndex = 0;
            this.tcAddUpdateUsers.Size = new System.Drawing.Size(1025, 564);
            this.tcAddUpdateUsers.TabIndex = 1;
            this.tcAddUpdateUsers.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tcAddUpdateUsers_Selecting);
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
            this.tpLinkPerson.Size = new System.Drawing.Size(1017, 538);
            this.tpLinkPerson.TabIndex = 0;
            this.tpLinkPerson.Text = "Link a Person";
            this.tpLinkPerson.UseVisualStyleBackColor = true;
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
            // tpAddUser
            // 
            this.tpAddUser.Controls.Add(this.label4);
            this.tpAddUser.Controls.Add(this.label7);
            this.tpAddUser.Controls.Add(this.btnBack);
            this.tpAddUser.Controls.Add(this.btnSave);
            this.tpAddUser.Controls.Add(this.lbAddUserMessage);
            this.tpAddUser.Controls.Add(this.cbIsActvie);
            this.tpAddUser.Controls.Add(this.txtPassword);
            this.tpAddUser.Controls.Add(this.txtUserName);
            this.tpAddUser.Controls.Add(this.label6);
            this.tpAddUser.Controls.Add(this.label5);
            this.tpAddUser.Controls.Add(this.label1);
            this.tpAddUser.Controls.Add(this.txtConfirmPassword);
            this.tpAddUser.Location = new System.Drawing.Point(4, 22);
            this.tpAddUser.Name = "tpAddUser";
            this.tpAddUser.Padding = new System.Windows.Forms.Padding(3);
            this.tpAddUser.Size = new System.Drawing.Size(1017, 538);
            this.tpAddUser.TabIndex = 1;
            this.tpAddUser.Text = "Add New User";
            this.tpAddUser.UseVisualStyleBackColor = true;
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
            // cbIsActvie
            // 
            this.cbIsActvie.AutoSize = true;
            this.cbIsActvie.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbIsActvie.Checked = true;
            this.cbIsActvie.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIsActvie.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIsActvie.Location = new System.Drawing.Point(68, 268);
            this.cbIsActvie.Name = "cbIsActvie";
            this.cbIsActvie.Size = new System.Drawing.Size(98, 28);
            this.cbIsActvie.TabIndex = 9;
            this.cbIsActvie.Text = "Is Active";
            this.cbIsActvie.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(232, 171);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(227, 29);
            this.txtPassword.TabIndex = 8;
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.emptyTxtBox_Validating);
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(232, 120);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(227, 29);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.Validating += new System.ComponentModel.CancelEventHandler(this.emptyTxtBox_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(64, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 24);
            this.label6.TabIndex = 6;
            this.label6.Text = "Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(64, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 24);
            this.label5.TabIndex = 5;
            this.label5.Text = "Confirm Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPassword.Location = new System.Drawing.Point(232, 219);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(227, 29);
            this.txtConfirmPassword.TabIndex = 7;
            this.txtConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirmPassword_Validating);
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
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddUpdateUsersMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 586);
            this.Controls.Add(this.tcAddUpdateUsers);
            this.Name = "AddUpdateUsersMenu";
            this.Text = "AddUpdateUsersMenu";
            this.Load += new System.EventHandler(this._AddUpdateUsersMenu_Load);
            this.tcAddUpdateUsers.ResumeLayout(false);
            this.tpLinkPerson.ResumeLayout(false);
            this.tpLinkPerson.PerformLayout();
            this.tpAddUser.ResumeLayout(false);
            this.tpAddUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcAddUpdateUsers;
        private System.Windows.Forms.TabPage tpLinkPerson;
        private MY_DVLD_SYSTEM.People.Controls.ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lbLinkPersonMessage;
        private System.Windows.Forms.TabPage tpAddUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbAddUserMessage;
        private System.Windows.Forms.CheckBox cbIsActvie;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}