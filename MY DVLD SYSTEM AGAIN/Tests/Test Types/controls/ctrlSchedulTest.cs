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

namespace MY_DVLD_SYSTEM_AGAIN.Tests.Test_Types.controls
{
    public partial class ctrlSchedulTest : UserControl
    {
        public ctrlSchedulTest()
        {
            InitializeComponent();
        }

        enum enMode { add =0 , update =1 }
        enum createionMode { FirstTimeTest = 0,retakeTest = 1 }
        enMode _mode;
        createionMode _creationMode;

        clsTestTypes.enTestType _testType = clsTestTypes.enTestType.vissionTest;

       private int _localDrivingLicnesApplicationID = 0;
        private clsLocalDrivingLicensApplication _localDrivingLicensApplication;

        private clsTestAppointment _testAppointment;
        private int _testAppointmentID = -1;

        public clsTestTypes.enTestType TestType { 
            
            get => _testType;

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
                        pbTestType.Image = Properties.Resources.Driver_Main;
                        gbTestType.Text = "Street Test";
                        break;

                }

            }
        }

        public void LoadData(int localDrivingLicnesApplicationID, int testAppointmentID = -1)
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

            //  if(_localDrivingLicensApplication.)

            if (_creationMode == createionMode.FirstTimeTest)
            {

                lbTestTitle.Text = "First Time Test";
                gbRetakeTest.Enabled = false;



            }
            else {
                lbTestTitle.Text = "Retake Test";
                lbRetakeTestFees.Text = clsApplicationTypes.GetApplicationTypeByID((int)TestType).ApplicationTypeFee.ToString();
                gbRetakeTest.Enabled = true;
                lbRetakeTestAppID.Text = "0";


            }

        }



































































        
        }
}
