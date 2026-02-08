using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using MY_DVLD_SYSTEM_AGAIN.Applications.Local_Driving_licens;
using MY_DVLD_SYSTEM_AGAIN.People;
namespace MY_DVLD_SYSTEM_AGAIN.Applications.Local_Driving_licens
{
    public partial class ctrlLocalDrivingLicensInfo : UserControl
    {
        public ctrlLocalDrivingLicensInfo()
        {
            InitializeComponent();
        }

        private clsLocalDrivingLicensApplication _localDrivingLicensApp;

        private int _localDrivingLicensAppID = 0;
        public int LocalDrivingLicensAppID
        {
            get { return _localDrivingLicensAppID; }
        }
        private int  LicenseID = -1;
        public void loadApplicationInfoByLocalDrivingLicenseAppID(int localDrivingAppID)
        {

            _localDrivingLicensApp = clsLocalDrivingLicensApplication.FindLocalDrivingLicensApplicationByID(localDrivingAppID);

            if (_localDrivingLicensApp == null)
            {
                _resetControl();
                MessageBox.Show("Local Driving License Application not found.");
                return;
            }

                  _FillLocalDrivingLicensInfo();
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

        private void _FillLocalDrivingLicensInfo()
        {
            lbDLappID.Text = _localDrivingLicensApp.LocalDrivingLicensApplicationID.ToString();
            lbLicensClass.Text = clsLicenceClasses.Find(_localDrivingLicensApp.LicensClassId).ClassName;
            lbPassedTests.Text = "not implemented yet";

            if (LicenseID == -1)
            llLicensClass.Enabled = false;

            lbAppID.Text = _localDrivingLicensApp.applicantID.ToString();
            lbApplicantName.Text = _localDrivingLicensApp.applicantFullName;
            lbCreatedBy.Text = _localDrivingLicensApp.CreatedByUser.UserName;
            lbDate.Text = _localDrivingLicensApp.applicationDate.ToShortDateString();
            lbStatusDate.Text = _localDrivingLicensApp.lastStatusDate.ToShortDateString();
            lbFees.Text = _localDrivingLicensApp.paidFee.ToString();
            lbStatus.Text = _localDrivingLicensApp.ApplicationStatusText.ToString();
            lbType.Text = _localDrivingLicensApp.ApplicationTypeInfo.ToString();

        }

        private void llPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PersonDetails frm = new PersonDetails(_localDrivingLicensApp.applicantID);
            frm.ShowDialog();
        }

        private void llLicensClass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Viewing License Class details is not implemented yet");
        }

       
    }

}

