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
namespace MY_DVLD_SYSTEM_AGAIN.Applications.Local_Driving_licens
{
    public partial class ctrlLocalDrivingLicensInfo : UserControl
    {
        public ctrlLocalDrivingLicensInfo()
        {
            InitializeComponent();
        }

        private clsLocalDrivingLicensApplication _localDrivingLicensApp;

        private int _localDrivingLicensAppID;
        public int LocalDrivingLicensAppID
        {
            get { return _localDrivingLicensAppID; }
        }
        public void loadApplicationInfoByLocalDrivingAppID(int localDrivingAppID)
        {

            throw new NotImplementedException("control not ready yet");

            _localDrivingLicensApp = clsLocalDrivingLicensApplication.FindLocalDrivingLicensApplicationByID(localDrivingAppID);

            if (_localDrivingLicensApp == null)
            {
                _resetControl();
                MessageBox.Show("Local Driving License Application not found.");
                return;

            }
            _FillLocalDrivingLicensInfoToControl();


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

        private void _FillLocalDrivingLicensInfoToControl()
        {
            lbDLappID.Text = _localDrivingLicensApp.LocalDrivingLicensApplicationID.ToString();
            lbLicensClass.Text = "not implemented yet";
            lbPassedTests.Text = "not implemented yet";

            lbAppID.Text = _localDrivingLicensApp.applicantID.ToString();
            lbApplicantName.Text = _localDrivingLicensApp.applicantFullName;
            lbCreatedBy.Text = _localDrivingLicensApp.CreatedByUser.UserName;
            lbDate.Text = _localDrivingLicensApp.applicationDate.ToShortDateString();
            lbStatusDate.Text = _localDrivingLicensApp.lastStatusDate.ToShortDateString();
            lbFees.Text = _localDrivingLicensApp.paidFee.ToString();
            lbStatus.Text = _localDrivingLicensApp.ApplicationStatusText.ToString();
            lbType.Text = _localDrivingLicensApp.ApplicationType.ToString();

        }

      
    }

}

