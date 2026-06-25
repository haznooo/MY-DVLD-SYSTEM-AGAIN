using BusinessLayer;
using MY_DVLD_SYSTEM.Global;
using System;
using System.Windows.Forms;

namespace MY_DVLD_SYSTEM_AGAIN.Applications.Renew_Licenses
{
    public partial class RenewLicense : Form
    {
        public RenewLicense()
        {
            InitializeComponent();
        }

        private void ctrlDriverLicenseInfoWithSearch1_OnLicenseSelected(int obj)
        {
            if (ctrlDriverLicenseInfoWithSearch1.LicenseInfo == null)
            {
                btnIssueReNewLicense.Enabled = false;
                return;
            }

            if (!ctrlDriverLicenseInfoWithSearch1.LicenseInfo.isActive)
            {
                MessageBox.Show("This license is not active\nyou can not renew an unactive licnese", "unactive licnese", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ctrlDriverLicenseInfoWithSearch1.LicenseInfo.ExpirationDate < DateTime.Now)
            {
                MessageBox.Show("This license is expired\nyou can not replace an expired licnese", "expired licnese", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            btnIssueReNewLicense.Enabled = true;
            int oldLicenseID = obj;
            lbOldLicenseID.Text = oldLicenseID.ToString();

            if (oldLicenseID <= 0) return;
         

        }

        private void RenewLicense_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithSearch1.Focus();
            btnIssueReNewLicense.Enabled = false;
            lbApplicationDate.Text = DateTime.Now.ToString();
            lbIssueDate.Text = DateTime.Now.ToString();
            lbCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            lbApplicationFees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.RenewDrivingLicens).ApplicationTypeFee.ToString();
        }

        private void btnIssueReNewLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure you want to renew this license ?", "renew licesne", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                return;
            }
            clsLicense NewLicense = ctrlDriverLicenseInfoWithSearch1.LicenseInfo.RenewLicense(txtNotes.Text, clsGlobal.CurrentUser.UserID);


            if (NewLicense == null)
            {
                MessageBox.Show("Failed to renew license", "fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("License renewed seccusfully", "succes", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

        }


    }
}

