using BusinessLayer;
using MY_DVLD_SYSTEM.Global;
using MY_DVLD_SYSTEM_AGAIN.licenses.local_Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MY_DVLD_SYSTEM_AGAIN.Applications.replacement_damaged_lost
{
    public partial class ReplacementDamageLostLicenses : Form
    {
        clsApplication.enApplicationType _ApplicationType;
        public ReplacementDamageLostLicenses()
        {
            InitializeComponent();
        }

    

        private void ReplacementDamageLostLicenses_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfoWithSearch1.Focus();
            btnIssueReplacementLicense.Enabled = false;
            lbApplicationDate.Text = DateTime.Now.ToString();
            lbCreatedBy.Text = clsGlobal.CurrentUser.UserName;
          
        }

        private void ctrlDriverLicenseInfoWithSearch1_OnLicenseSelected(int obj)
        {
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
            btnIssueReplacementLicense.Enabled = true;
            int oldLicenseID = obj;
            lbOldLicenseID.Text = oldLicenseID.ToString();

            if (oldLicenseID <= 0) return;


        }

        private void rdDamaged_CheckedChanged(object sender, EventArgs e)
        {
            _ApplicationType = clsApplication.enApplicationType.ReplaceDamagedLicens;
            lbApplicationFees.Text = clsApplicationTypes.Find((int)_ApplicationType).ApplicationTypeFee.ToString();
        }

        private void rdLost_CheckedChanged(object sender, EventArgs e)
        {
            _ApplicationType = clsApplication.enApplicationType.ReplaceLostLicens;
            lbApplicationFees.Text = clsApplicationTypes.Find((int)_ApplicationType).ApplicationTypeFee.ToString();

        }

        private void btnIssueReplacementLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure you want to replace this license ?", "renew licesne", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                return;
            }
            clsLicense NewLicense = ctrlDriverLicenseInfoWithSearch1.LicenseInfo.Replace(clsGlobal.CurrentUser.UserID,(byte)_ApplicationType);

            if (NewLicense == null)
            {
                MessageBox.Show("Failed to replace license", "fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("License replaced seccusfully", "succes", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }
    }
}
