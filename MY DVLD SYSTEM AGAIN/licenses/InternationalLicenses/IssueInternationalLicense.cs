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

namespace MY_DVLD_SYSTEM_AGAIN.licenses.InternationalLicenses
{
    public partial class IssueInternationalLicense : Form
    {
        public IssueInternationalLicense()
        {
            InitializeComponent();
        }

        int _LicenseID = -1;
        private void ctrlDriverLicenseInfoWithSearch1_OnLicenseSelected(int obj)
        {
            _LicenseID = obj;

            if (_LicenseID == -1) return;

            

            if (clsLicense.FindbyID(_LicenseID).LicenseClassID != 3)
            {
                MessageBox.Show("You can only use normal License to make international License", "fail");
                btnIssue.Enabled = false;
                return;
            }

            int activeInternationalLicense = clsInternationalLicense.GetActiveInternationalLicenseIDByDriverID(ctrlDriverLicenseInfoWithSearch1.LicenseInfo.DriverID);

            if (activeInternationalLicense > 0)
            {
                MessageBox.Show("You already have an active license ", "fail");
                btnIssue.Enabled = false;
                return;
            }

            btnIssue.Enabled = true;
            lbIssueDate.Text =  DateTime.Now.ToString();
            lbFees.Text = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationType.NewInternationalLicens).ApplicationTypeFee.ToString();
            lbCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            lbLocalLicenseID.Text = _LicenseID.ToString();
            lbExpirationDate.Text = ctrlDriverLicenseInfoWithSearch1.LicenseInfo.ExpirationDate.ToString();
            lbApplicationDate.Text = DateTime.Now.ToString();


  


        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            clsInternationalLicense NewInternationalLicense = new clsInternationalLicense();


            NewInternationalLicense.driverID = ctrlDriverLicenseInfoWithSearch1.LicenseInfo.DriverID;
            NewInternationalLicense.localLicenseID = _LicenseID;
            NewInternationalLicense.IssueDate = DateTime.Now;
            NewInternationalLicense.ExpirationDate = ctrlDriverLicenseInfoWithSearch1.LicenseInfo.ExpirationDate;
            NewInternationalLicense.isActive = true;
            NewInternationalLicense.createdByUserID = clsGlobal.CurrentUser.UserID;

            NewInternationalLicense.applicantID = ctrlDriverLicenseInfoWithSearch1.LicenseInfo.DriverInfo.PersonID;
            NewInternationalLicense.applicationDate = DateTime.Now;
            NewInternationalLicense.applicationStatus = clsApplication.enApplicationStatus.complete;
            NewInternationalLicense.lastStatusDate = DateTime.Now;
            NewInternationalLicense.paidFee = clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationType.NewInternationalLicens).ApplicationTypeFee;
            NewInternationalLicense.applicationTypeID = (byte)clsApplicationTypes.Find((int)clsApplicationTypes.enApplicationType.NewInternationalLicens).ApplicationTypeID;

            if (NewInternationalLicense.save())
            {
                MessageBox.Show("Added new international licenses");
            }
            else
            {
                MessageBox.Show("failed to add");
            }
        }
    }
}
