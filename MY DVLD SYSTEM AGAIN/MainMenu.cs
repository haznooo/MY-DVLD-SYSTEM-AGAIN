using MY_DVLD_SYSTEM.Global;
using MY_DVLD_SYSTEM_AGAIN.Users;
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
    public partial class MainMenu : Form
    {
  

       LoginMenu _loginMenu;
        public MainMenu(LoginMenu loginMenu)
        {
            InitializeComponent();

           _loginMenu = loginMenu;
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void managePeopleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ManagePeopleMenu frm = new ManagePeopleMenu();
            frm.ShowDialog();
        }


        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {


           ManageUsersMenu frm = new ManageUsersMenu();
            frm.ShowDialog();
        }

        private void applicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void currentInfosToolStripMenuItem_Click(object sender, EventArgs e)
        {
        //    UserDetails frm = new UserDetails(clsGlobal.CurrentUser.UserID);
        //    frm.ShowDialog();

        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
        //    ChangePasswordMenu frm = new ChangePasswordMenu(clsGlobal.CurrentUser.UserID);
       //     frm.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _loginMenu.Show();
           this.Close();
        }

        private void manageApplicationsTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {

         //   ApplicationTypesMenu frm = new ApplicationTypesMenu();
         //   frm.ShowDialog();
        }
    }
}
