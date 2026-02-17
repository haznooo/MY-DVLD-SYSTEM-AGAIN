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

namespace MY_DVLD_SYSTEM_AGAIN.Applications.Release_licenses
{
    public partial class ReleaseDetainedLicense : Form
    {

        int _LicenseID = -1;
        public ReleaseDetainedLicense()
        {
            InitializeComponent();
        }
        public ReleaseDetainedLicense(int LicneseID)
        {
            InitializeComponent();

            _LicenseID = LicneseID;
        }

        private void ctrlDriverLicenseInfoWithSearch1_OnLicenseSelected(int obj)
        {
            _LicenseID = obj;

            if (_LicenseID < 0) return;

            if (!ctrlDriverLicenseInfoWithSearch1.LicenseInfo.IsDetained) 
            {
                MessageBox.Show("license is not detianed ", "not detained ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            
            }
            _LicenseID = ctrlDriverLicenseInfoWithSearch1.LicenseID;
            lbDetainID.Text = ctrlDriverLicenseInfoWithSearch1.LicenseInfo.DetainInfo.DetainID.ToString();
            lbDetainDate.Text = ctrlDriverLicenseInfoWithSearch1.LicenseInfo.DetainInfo.DetainDate.ToString();
            lbLicenseID.Text = _LicenseID.ToString();
            lbReleasedBy.Text = clsGlobal.CurrentUser.UserName;
            lbFindFees.Text = ctrlDriverLicenseInfoWithSearch1.LicenseInfo.DetainInfo.fineFees.ToString();
            lbApplicationFees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.ReleaseDetainedLicens).ApplicationTypeFee.ToString();
            lbTotalFees.Text = (Convert.ToDecimal(lbFindFees.Text) + Convert.ToDecimal(lbApplicationFees.Text)).ToString();

            btnRelease.Enabled = true;

        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            int ApplicationID = -1;
        bool isReleased = ctrlDriverLicenseInfoWithSearch1.LicenseInfo.Release(clsGlobal.CurrentUser.UserID,ref ApplicationID);

            lbApplicationID.Text = ApplicationID.ToString();

            if (isReleased)
            {
                MessageBox.Show("license released");

            }
            else 
            {
                MessageBox.Show("failed to relesae");
            }
            btnRelease.Enabled = false;

        }
    }
}
