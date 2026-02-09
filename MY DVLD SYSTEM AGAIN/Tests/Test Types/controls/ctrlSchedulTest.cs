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

namespace MY_DVLD_SYSTEM_AGAIN.Tests.Test_Types.controls
{
    public partial class ctrlSchedulTest : UserControl
    {
        public ctrlSchedulTest()
        {
            InitializeComponent();
        }

        enum enMode { add = 0, update = 1 }
        enum createionMode { FirstTimeTest = 0, retakeTest = 1 }
        enMode _mode;
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

        private bool _handleActiveTestAppointment()
        {
            // if we are adding a new appointment we check if there is an active appointment of the same type for this application, if there is we prevent the user from adding another one
            if (_mode == enMode.add && _localDrivingLicensApplication.isthereActiveScheduledTest((int)TestType))
            {
                MessageBox.Show("There is already an active scheduled test of this type for this application", "Active Test Appointment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnSave.Enabled = false;
                dtpDate.Enabled = false;
                return false;
            }
            return true;

        }
        private void _handleAppointmentLocked()
        {

            if (_testAppointmentt.isLocked)
            {
                lbErrorMesseges.Visible = true;
                lbErrorMesseges.Text = "This appointment is locked and cannot be edited.";
                btnSave.Enabled = false;
                dtpDate.Enabled = false;

            }


        }
        private bool _handlePreviousTestConstraint()
        {

            switch (_testType)
            {

                case clsTestTypes.enTestType.vissionTest:
                    lbErrorMesseges.Visible = false;
                    return true;

                case clsTestTypes.enTestType.writtenTest:
                    {
                        if (!_localDrivingLicensApplication.DoesPassTestType((int)clsTestTypes.enTestType.vissionTest))
                        {
                            lbErrorMesseges.Visible = true;
                            lbErrorMesseges.Text = "The applicant must pass the Vission Test before scheduling the Written Test.";
                            btnSave.Enabled = false;
                            dtpDate.Enabled = false;
                            return false;
                        }
                        else
                        {
                            lbErrorMesseges.Visible = false;
                            btnSave.Enabled = true;
                            dtpDate.Enabled = true;
                            return true;

                        }

                    }

                case clsTestTypes.enTestType.streetTest:
                    {
                        if (!_localDrivingLicensApplication.DoesPassTestType((int)clsTestTypes.enTestType.writtenTest))
                        {
                            lbErrorMesseges.Visible = true;
                            lbErrorMesseges.Text = "The applicant must pass the Written Test before scheduling the Street Test.";
                            btnSave.Enabled = false;
                            dtpDate.Enabled = false;
                            return false;
                        }
                        else
                        {
                            lbErrorMesseges.Visible = false;
                            btnSave.Enabled = true;
                            dtpDate.Enabled = true;
                            return true;
                        }
                    }

                default: return false;
            }




        }

        private bool _handleRetakeTest()
        {

            if (_mode == enMode.add && _creationMode == createionMode.retakeTest)
            {

                clsApplication application = new clsApplication();
                application.applicantID = _localDrivingLicensApplication.applicantID;
                application.applicationDate = DateTime.Now;
               application.applicationStatus = clsApplication.enApplicationStatus.New;
                application.applicationTypeID = (byte)clsApplication.enApplicationType.RetakeDrivingTest;
                application.createdByUserID = clsGlobal.CurrentUser.UserID;
                application.lastStatusDate = DateTime.Now;
                application.paidFee = Convert.ToDecimal(clsApplicationTypes.Find(Convert.ToInt32(clsApplication.enApplicationType.RetakeDrivingTest)));

                if (!application.SaveApplication(out int NewApplicationID))
                {
                   MessageBox.Show("Error saving retake test application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                _testAppointmentt.RetakeTestApplicationID = NewApplicationID;

            }
            return true;

        }
        private bool _loadTestAppointmentData()
        {
            _testAppointmentt = clsTestAppointment.Find(_testAppointmentID);
            if (_testAppointmentt == null)
            {
                MessageBox.Show("Error loading test appointment data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return false;
            }

         //   dtpDate.Value = _testAppointmentt.AppointmentDate;
         //   lbRetakeTestAppID.Text = _testAppointmentt.TestAppointmentID.ToString();
        //    lbFullName.Text = _localDrivingLicensApplication.applicantFullName;
            lbFees.Text = _testAppointmentt.paidFees.ToString();
          //  lbTotalTrails.Text = _localDrivingLicensApplication.TotalTrialsForTestType((int)TestType).ToString();

            // im not sure why this logic is like that but,
            // in case we were updating an appointment and its due date is in the past, we update it to now
            // if it was in the future we keep it as is but we prevent the user from setting it before the due date
            if (DateTime.Compare(_testAppointmentt.AppointmentDate, DateTime.Now) > 0)
            {
                dtpDate.MinDate = DateTime.Now;
            }
            else
            {
                dtpDate.MinDate = _testAppointmentt.AppointmentDate;

            }


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
        public void LoadInfo(int localDrivingLicnesApplicationID, int testAppointmentID = -1)
        {

            if (testAppointmentID == -1)
            {
                _mode = enMode.add;
            }
            else
            {
                _mode = enMode.update;
            }


            _localDrivingLicnesApplicationID = localDrivingLicnesApplicationID;
            _localDrivingLicensApplication = clsLocalDrivingLicensApplication.FindLocalDrivingLicensApplicationByID(localDrivingLicnesApplicationID);
            _testAppointmentID = testAppointmentID;

            if (_localDrivingLicensApplication == null)
            {
                MessageBox.Show("Error loading local driving license application data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            if (_localDrivingLicensApplication.DoesAttendTestType((int)TestType))
                _creationMode = createionMode.retakeTest;
            else _creationMode = createionMode.FirstTimeTest;



            if (_creationMode == createionMode.FirstTimeTest)
            {

                lbTestTitle.Text = "First Time Test";
                gbRetakeTest.Enabled = false;
                lbRetakeTestAppID.Text = "N/A";
                lbRetakeTestFees.Text = "0";


            }
            else
            {
                lbTestTitle.Text = "Retake Test";
                lbRetakeTestFees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.RetakeDrivingTest).ApplicationTypeFee.ToString();
                gbRetakeTest.Enabled = true;
                lbRetakeTestAppID.Text = "0";


            }

            DLAppID.Text = _localDrivingLicnesApplicationID.ToString();
            lbDrivingClass.Text = _localDrivingLicensApplication.LicensClassInfo.ClassName;
            lbFullName.Text = _localDrivingLicensApplication.applicantFullName;
            lbTotalTrails.Text = _localDrivingLicensApplication.TotalTrialsForTestType((int)TestType).ToString();


            if (_mode == enMode.add)
            {
                lbFees.Text = clsTestTypes.GetTestTypeByID(TestType).TestTypeFee.ToString();
                dtpDate.MinDate = DateTime.Now;
                lbRetakeTestAppID.Text = "N/A";

                _testAppointmentt = new clsTestAppointment();
            }
            else
            {
                if (!_loadTestAppointmentData())
                    return;
            }

            lbTotalFees.Text = Convert.ToString(Convert.ToInt32(lbFees.Text) + Convert.ToInt32(lbRetakeTestFees.Text));

            if (!_handleActiveTestAppointment())
                return;
            _handleAppointmentLocked();

            if (!_handlePreviousTestConstraint())
                return;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_handleRetakeTest()) return;

            _testAppointmentt.TestTypeID = (int)_testType;
            _testAppointmentt.localDrivingLicensesApplicantID = _localDrivingLicnesApplicationID;
            _testAppointmentt.AppointmentDate = dtpDate.Value;
            _testAppointmentt.paidFees = Convert.ToInt32(lbTotalFees.Text);
            _testAppointmentt.createdByUserID = clsGlobal.CurrentUser.UserID;

            if (_testAppointmentt.save())
            {

                _mode = enMode.update;
                MessageBox.Show("Test appointment saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            else
            {
                MessageBox.Show("Error saving test appointment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }
    }
}
