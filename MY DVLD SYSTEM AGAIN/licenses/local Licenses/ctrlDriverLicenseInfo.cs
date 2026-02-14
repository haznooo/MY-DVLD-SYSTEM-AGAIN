using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MY_DVLD_SYSTEM_AGAIN.licenses.local_Licenses
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {
        int _LicenseID;
        public ctrlDriverLicenseInfo(int licenseID)
        {
            InitializeComponent();
            if (this.DesignMode) { return; }

            _LicenseID = licenseID;
        }

        private void ctrlDriverLicenseInfo_Load(object sender, EventArgs e)
        {

            clsLicense license = clsLicense.FindbyID(_LicenseID);

            if (license == null) 
            { MessageBox.Show("Failed to load license info", "error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            clsPerson person = clsPerson.GetPersonInfoByID(license.DriverInfo.PersonInfo.PersonID);

            lbFullName.Text = person.FullName ;
            lbNationalNumber.Text = person.NationalNUmber;
            lbDateOfBirth.Text = person.DateOfBirth.ToString() ;
            lbGender.Text = person.GenderTxt;
            lbDriverID.Text = license.DriverInfo.DriverID.ToString();
            lbIssueReason.Text = license.IssueReasonText;
            lbIsActive.Text = license.isActive.ToString();

            lbLicenseID.Text = _LicenseID.ToString();
            lbLicenseClass.Text = license.LicenceClassesInfo.ClassName;
            lbIssueDate.Text = license.issueDate.ToString();
            LbExpirationDate.Text = license.ExpirationDate.ToString();
            lbNotes.Text = license.Notes.ToString();

            if (person.ImagePath != string.Empty)
            {
                pbPersonImage.ImageLocation = person.ImagePath;
            }
            else 
            {
                // 0 means it is a male
                if (person.Gender == 0) { pbPersonImage.Image = Properties.Resources.Male_512; }
                else pbPersonImage.Image = Properties.Resources.Female_512;
            }

          





        }
    }
}
