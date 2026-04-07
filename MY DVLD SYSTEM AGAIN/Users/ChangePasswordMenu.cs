using BusinessLayer;
using System;
using System.Windows.Forms;

namespace MY_DVLD_SYSTEM_AGAIN.Users
{
    public partial class ChangePasswordMenu : Form
    {
        int UserID = -1;
        clsUser User = null;
        public ChangePasswordMenu(int UserID)
        {
            InitializeComponent();

            if (this.DesignMode) { return; }

            this.UserID = UserID;
        }

        //load
        private void ChangePasswordMenu_Load(object sender, EventArgs e)
        {

            if (this.DesignMode) { return; }

            User = clsUser.GetUserByID(UserID);


            if (User == null)
            {

                MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;

            }

            ctrlLoginInfos1.LoadUserInfos(User.UserID);


        }

        //save
        private void btnChange_Click(object sender, EventArgs e)
        {

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("New Password and Confirm Password do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtCurrentPassword.Text != User.Password)
            {

                MessageBox.Show("Current Password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


            if (User.ChangePassword(txtNewPassword.Text))
            {

                MessageBox.Show("Password changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            else
            {

                MessageBox.Show("Failed to change password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

            }




        }

        //ui logic
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
