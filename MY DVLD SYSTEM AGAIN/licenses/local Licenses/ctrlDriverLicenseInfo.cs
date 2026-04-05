using BusinessLayer;
using System.IO;
using System.Windows.Forms;

namespace MY_DVLD_SYSTEM_AGAIN.licenses.local_Licenses
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {
        public int _LicenseID;
        public clsLicense LicenseInfo;

        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();



        }


        public void LoadInfo(int LicenseID)
        {



            _LicenseID = LicenseID;

            if (this.DesignMode) return;

            LicenseInfo = clsLicense.FindbyID(_LicenseID);

            if (LicenseInfo == null)
            { MessageBox.Show("Failed to load license info", "error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }


            clsPerson person = clsPerson.GetPersonInfoByID(LicenseInfo.DriverInfo.PersonInfo.PersonID);

            lbFullName.Text = person.FullName;
            lbNationalNumber.Text = person.NationalNUmber.ToString();
            lbDateOfBirth.Text = person.DateOfBirth.ToString();
            lbGender.Text = person.GenderTxt;
            lbDriverID.Text = LicenseInfo.DriverInfo.DriverID.ToString();
            lbIssueReason.Text = LicenseInfo.IssueReasonText;
            lbIsActive.Text = LicenseInfo.isActive.ToString();

            lbLicenseID.Text = _LicenseID.ToString();
            lbLicenseClass.Text = LicenseInfo.LicenceClassesInfo.ClassName;
            lbIssueDate.Text = LicenseInfo.issueDate.ToString();
            LbExpirationDate.Text = LicenseInfo.ExpirationDate.ToString();
            lbNotes.Text = LicenseInfo.Notes.ToString();



            if (person.ImagePath != string.Empty && File.Exists(person.ImagePath))
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
