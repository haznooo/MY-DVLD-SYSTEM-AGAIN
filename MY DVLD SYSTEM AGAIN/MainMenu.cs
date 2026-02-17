using MY_DVLD_SYSTEM.Global;
using MY_DVLD_SYSTEM_AGAIN.Applications.Application_types;
using MY_DVLD_SYSTEM_AGAIN.Applications.Local_Driving_licens;
using MY_DVLD_SYSTEM_AGAIN.Applications.Release_licenses;
using MY_DVLD_SYSTEM_AGAIN.Applications.Renew_Licenses;
using MY_DVLD_SYSTEM_AGAIN.Applications.replacement_damaged_lost;
using MY_DVLD_SYSTEM_AGAIN.Drivers;
using MY_DVLD_SYSTEM_AGAIN.licenses.InternationalLicenses;
using MY_DVLD_SYSTEM_AGAIN.licenses.local_Licenses.Detain;
using MY_DVLD_SYSTEM_AGAIN.Tests.Test_Types;
using MY_DVLD_SYSTEM_AGAIN.Users;
using System;
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

            UserDetails frm = new UserDetails(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();

        }
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswordMenu frm = new ChangePasswordMenu(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _loginMenu.Show();
            this.Close();
        }
        private void applicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ApplicationTypesMenu frm = new ApplicationTypesMenu();
            frm.ShowDialog();

        }
        private void testTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestTypesMenu frm = new TestTypesMenu();
            frm.ShowDialog();
        }
        private void localLicensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUpdateLocalDrivingLicensApplication frm = new AddUpdateLocalDrivingLicensApplication();
            frm.ShowDialog();
        }
        private void localLicenseAppllicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageLocalDrivingLicenses frm = new ManageLocalDrivingLicenses();
            frm.ShowDialog();
        }

        private void renewLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenewLicense frm = new RenewLicense();
            frm.ShowDialog();
        }

        private void replacmentForLostOfDamagedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReplacementDamageLostLicenses frm = new ReplacementDamageLostLicenses();
            frm.ShowDialog();
        }

        private void manageDriversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListDrivers frm = new ListDrivers();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetainLicense frm = new DetainLicense();
            frm.ShowDialog();
        }

        private void releaseLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReleaseDetainedLicense frm = new ReleaseDetainedLicense();
            frm.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageDetainedLicenses frm = new ManageDetainedLicenses();
            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueInternationalLicense frm = new IssueInternationalLicense();
            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ManageInterNationalLicenses frm = new ManageInterNationalLicenses();
            frm.ShowDialog();
        }
    }
}
