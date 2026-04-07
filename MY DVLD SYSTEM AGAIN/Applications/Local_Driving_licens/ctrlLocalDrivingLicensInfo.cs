using BusinessLayer;
using MY_DVLD_SYSTEM_AGAIN.People;
using System.Windows.Forms;
namespace MY_DVLD_SYSTEM_AGAIN.Applications.Local_Driving_licens
{
    public partial class ctrlLocalDrivingLicensInfo : UserControl
    {

        private clsLocalDrivingLicensApplication _localDrivingLicensApp;
        private int _localDrivingLicensAppID = 0;
        public int LocalDrivingLicensAppID
        {
            get { return _localDrivingLicensAppID; }
        }
        private int LicenseID = -1;
        public int passedTests = 0;

        public ctrlLocalDrivingLicensInfo()
        {
            InitializeComponent();
        }

 
        //load
        public bool loadApplicationInfoByLocalDrivingLicenseAppID(int localDrivingAppID)
        {

            _localDrivingLicensApp = clsLocalDrivingLicensApplication.FindLocalDrivingLicensApplicationByID(localDrivingAppID);

            if (_localDrivingLicensApp == null)
            {
                _resetControl();
                MessageBox.Show("Local Driving License Application not found.");
                return false;
            }

            _FillLocalDrivingLicensInfo();
            return true;
        }
        public void LoaddApplicationInfoByApplicationAppID(int applicationID)
        {
            _localDrivingLicensApp = clsLocalDrivingLicensApplication.FindLocalDrivingLicensApplicationByApplicationID(applicationID);

            if (_localDrivingLicensApp == null)
            {
                _resetControl();
                MessageBox.Show("Local Driving License Application not found.");
                return;
            }

            _FillLocalDrivingLicensInfo();


        }
        private void _FillLocalDrivingLicensInfo()
        {
            lbDLappID.Text = _localDrivingLicensApp.LocalDrivingLicensApplicationID.ToString();
            lbLicensClass.Text = clsLicenceClasses.Find(_localDrivingLicensApp.LicensClassId).ClassName;
            lbPassedTests.Text = clsTest.GetPassedTestsCount(_localDrivingLicensApp.LocalDrivingLicensApplicationID).ToString();

            if (LicenseID == -1)
                llLicenseInfo.Visible = false;
            else llLicenseInfo.Visible = true;

            lbAppID.Text = _localDrivingLicensApp.applicantID.ToString();
            lbApplicantName.Text = _localDrivingLicensApp.applicantFullName;
            lbCreatedBy.Text = _localDrivingLicensApp.CreatedByUser.UserName;
            lbDate.Text = _localDrivingLicensApp.applicationDate.ToShortDateString();
            lbStatusDate.Text = _localDrivingLicensApp.lastStatusDate.ToShortDateString();
            lbFees.Text = _localDrivingLicensApp.paidFee.ToString();
            lbStatus.Text = _localDrivingLicensApp.ApplicationStatusText.ToString();
            lbType.Text = _localDrivingLicensApp.ApplicationTypeInfo.ApplicationTypeTitle;

        }


        // utility
        private void _resetControl()
        {

            lbDLappID.Text = "????";
            lbLicensClass.Text = "??????????";
            lbPassedTests.Text = "??????????";

            lbAppID.Text = "????";
            lbApplicantName.Text = "??????????";
            lbCreatedBy.Text = "??????????";
            lbFees.Text = "????";
            lbDate.Text = "??????????";
            lbStatus.Text = "??????????";
            lbStatusDate.Text = "??????????";
            lbType.Text = "??????????";

        }

        // ui logic
        private void llPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PersonDetails frm = new PersonDetails(_localDrivingLicensApp.applicantID);
            frm.ShowDialog();
        }
        private void llLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Viewing License Class details is not implemented yet");
        }
    }

}

