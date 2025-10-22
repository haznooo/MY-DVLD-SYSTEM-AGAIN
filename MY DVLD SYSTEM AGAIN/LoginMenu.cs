using BusinessLayer;
using MY_DVLD_SYSTEM.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MY_DVLD_SYSTEM_AGAIN
{
    public partial class LoginMenu : Form
    {
        public LoginMenu()
        {
            InitializeComponent();
        }
        private void _ResetForm()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            clsGlobal.CurrentUser = clsUser.GetUserByUserNameAndPassword(txtUsername.Text, txtPassword.Text);


            if ((clsGlobal.CurrentUser == null))
            {
                MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsGlobal.CurrentUser.isActive == false)
            {

                MessageBox.Show("This account is not active\n please contact your admin", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (cbRememberMe.Checked)
            {

                if (!clsGlobal.SaveLoginCredentials(txtUsername.Text, txtPassword.Text))
                {

                    MessageBox.Show("Faild to save Credentails", "internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            else
            {
                if (!clsGlobal.ClearSavedLoginCredentials())
                {

                    MessageBox.Show("Faild to save Credentails", "internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }

            MainMenu mainMenu = new MainMenu(this);
            this.Hide();
            mainMenu.ShowDialog();

        }

        private void LoginMenu_Load(object sender, EventArgs e)
        {

            _ResetForm();
            string UserName = "", Password = "";


            if (clsGlobal.GetSavedLoginCredentials(ref UserName, ref Password))
            {


                txtUsername.Text = UserName;
                txtPassword.Text = Password;
                cbRememberMe.Checked = true;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
