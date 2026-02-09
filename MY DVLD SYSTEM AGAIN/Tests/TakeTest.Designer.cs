namespace MY_DVLD_SYSTEM_AGAIN.Tests
{
    partial class TakeTest
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
            this.label1 = new System.Windows.Forms.Label();
            this.rdFaild = new System.Windows.Forms.RadioButton();
            this.rdPass = new System.Windows.Forms.RadioButton();
            this.lbUserMessage = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.ctrlScheduledTest2 = new MY_DVLD_SYSTEM_AGAIN.Tests.Test_Types.controls.ctrlScheduledTest();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 644);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Results";
            // 
            // rdFaild
            // 
            this.rdFaild.AutoSize = true;
            this.rdFaild.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdFaild.Location = new System.Drawing.Point(230, 641);
            this.rdFaild.Name = "rdFaild";
            this.rdFaild.Size = new System.Drawing.Size(52, 24);
            this.rdFaild.TabIndex = 2;
            this.rdFaild.TabStop = true;
            this.rdFaild.Text = "Fail";
            this.rdFaild.UseVisualStyleBackColor = true;
            // 
            // rdPass
            // 
            this.rdPass.AutoSize = true;
            this.rdPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdPass.Location = new System.Drawing.Point(153, 639);
            this.rdPass.Name = "rdPass";
            this.rdPass.Size = new System.Drawing.Size(61, 24);
            this.rdPass.TabIndex = 3;
            this.rdPass.TabStop = true;
            this.rdPass.Text = "pass";
            this.rdPass.UseVisualStyleBackColor = true;
            // 
            // lbUserMessage
            // 
            this.lbUserMessage.AutoSize = true;
            this.lbUserMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserMessage.ForeColor = System.Drawing.Color.Red;
            this.lbUserMessage.Location = new System.Drawing.Point(336, 641);
            this.lbUserMessage.Name = "lbUserMessage";
            this.lbUserMessage.Size = new System.Drawing.Size(224, 20);
            this.lbUserMessage.TabIndex = 4;
            this.lbUserMessage.Text = "You can\'t change this later";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 674);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "notes";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(92, 671);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(468, 94);
            this.txtNotes.TabIndex = 6;
            // 
            // ctrlScheduledTest2
            // 
            this.ctrlScheduledTest2.Location = new System.Drawing.Point(2, 0);
            this.ctrlScheduledTest2.Name = "ctrlScheduledTest2";
            this.ctrlScheduledTest2.Size = new System.Drawing.Size(565, 642);
            this.ctrlScheduledTest2.TabIndex = 9;
            this.ctrlScheduledTest2.TestType = BusinessLayer.clsTestTypes.enTestType.vissionTest;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::MY_DVLD_SYSTEM_AGAIN.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(388, 773);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(83, 44);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::MY_DVLD_SYSTEM_AGAIN.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(477, 773);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 44);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MY_DVLD_SYSTEM_AGAIN.Properties.Resources.Number_32;
            this.pictureBox1.Location = new System.Drawing.Point(92, 633);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // TakeTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 819);
            this.Controls.Add(this.ctrlScheduledTest2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbUserMessage);
            this.Controls.Add(this.rdPass);
            this.Controls.Add(this.rdFaild);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "TakeTest";
            this.Text = "TakeTest";
            this.Load += new System.EventHandler(this.TakeTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton rdFaild;
        private System.Windows.Forms.RadioButton rdPass;
        private System.Windows.Forms.Label lbUserMessage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private Test_Types.controls.ctrlScheduledTest ctrlScheduledTest1;
        private Test_Types.controls.ctrlScheduledTest ctrlScheduledTest2;
    }
}