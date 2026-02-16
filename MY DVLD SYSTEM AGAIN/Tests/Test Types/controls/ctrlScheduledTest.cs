using BusinessLayer;
using System.Windows.Forms;

namespace MY_DVLD_SYSTEM_AGAIN.Tests.Test_Types.controls
{
    public partial class ctrlScheduledTest : UserControl
    {
        public ctrlScheduledTest()
        {
            InitializeComponent();
        }

        enum createionMode { FirstTimeTest = 0, retakeTest = 1 }
        createionMode _creationMode;
        private clsTestTypes.enTestType _testType = clsTestTypes.enTestType.vissionTest;
        private int _localDrivingLicnesApplicationID = 0;
        private clsLocalDrivingLicensApplication _localDrivingLicensApplication;
        private clsTestAppointment _testAppointmentt;
        private int _testAppointmentID = -1;
        public clsTestTypes.enTestType TestType
        {

            get { return _testType; }

            set
            {
                _testType = value;

                switch (value)
                {

                    case clsTestTypes.enTestType.vissionTest:
                        pbTestType.Image = Properties.Resources.Vision_512;
                        gbTestType.Text = "Vission Test";
                        break;
                    case clsTestTypes.enTestType.writtenTest:
                        pbTestType.Image = Properties.Resources.Written_Test_512;
                        gbTestType.Text = "Written Test";
                        break;
                    case clsTestTypes.enTestType.streetTest:
                        pbTestType.Image = Properties.Resources.street_test;
                        gbTestType.Text = "Street Test";
                        break;

                }

            }
        }



        private bool _loadTestAppointmentData()
        {
            _testAppointmentt = clsTestAppointment.Find(_testAppointmentID);
            if (_testAppointmentt == null)
            {
                MessageBox.Show("Error loading test appointment data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //   dtpDate.Value = _testAppointmentt.AppointmentDate;
            //   lbRetakeTestAppID.Text = _testAppointmentt.TestAppointmentID.ToString();
            //    lbFullName.Text = _localDrivingLicensApplication.applicantFullName;
            lbFees.Text = _testAppointmentt.paidFees.ToString();
            //  lbTotalTrails.Text = _localDrivingLicensApplication.TotalTrialsForTestType((int)TestType).ToString();

            if (_testAppointmentt.RetakeTestApplicationID == -1)
            {

                lbRetakeTestAppID.Text = "N/A";
                lbRetakeTestFees.Text = "0";
                gbRetakeTest.Enabled = false;
            }
            else
            {

                lbRetakeTestAppID.Text = _testAppointmentt.RetakeTestApplicationID.ToString();
                lbRetakeTestFees.Text = clsApplicationTypes.Find((int)TestType).ApplicationTypeFee.ToString();
                gbRetakeTest.Enabled = true;

            }


            return true;
        }
        public bool LoadInfo(int localDrivingLicnesApplicationID, int testAppointmentID = -1)
        {
            gbRetakeTest.Enabled = false;



            _localDrivingLicnesApplicationID = localDrivingLicnesApplicationID;
            _localDrivingLicensApplication = clsLocalDrivingLicensApplication.FindLocalDrivingLicensApplicationByID(localDrivingLicnesApplicationID);
            _testAppointmentID = testAppointmentID;



            if (_localDrivingLicensApplication == null)
            {
                MessageBox.Show("Error loading local driving license application data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_localDrivingLicensApplication.DoesAttendTestType((int)TestType))
                _creationMode = createionMode.retakeTest;
            else _creationMode = createionMode.FirstTimeTest;


            if (_creationMode == createionMode.FirstTimeTest)
            {

                lbTestTitle.Text = "First Time Test";
                lbRetakeTestAppID.Text = "N/A";
                lbRetakeTestFees.Text = "0";


            }
            //else
            //{
            //    lbTestTitle.Text = "Retake Test";
            //    lbRetakeTestFees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.RetakeDrivingTest).ApplicationTypeFee.ToString();
            //    lbRetakeTestAppID.Text = "0";


            //}

            DLAppID.Text = _localDrivingLicnesApplicationID.ToString();
            lbDrivingClass.Text = _localDrivingLicensApplication.LicensClassInfo.ClassName;
            lbFullName.Text = _localDrivingLicensApplication.applicantFullName;
            lbTotalTrails.Text = _localDrivingLicensApplication.TotalTrialsForTestType((int)TestType).ToString();
            return true;
        }


    }
}
