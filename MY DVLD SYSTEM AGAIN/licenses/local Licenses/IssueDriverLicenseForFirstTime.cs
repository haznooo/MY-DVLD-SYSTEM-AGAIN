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

namespace MY_DVLD_SYSTEM_AGAIN.licenses.local_Licenses
{
    public partial class IssueDriverLicenseForFirstTime : Form
    {
        int _LocalDrivingLicensesApplicationID;
        clsLocalDrivingLicensApplication _LocalDrivingLicensApplication;
        public IssueDriverLicenseForFirstTime(int localDrivingLicenseApplicationId)
        {
            InitializeComponent();

            if (this.DesignMode) {
                return;
            }
            this._LocalDrivingLicensesApplicationID = localDrivingLicenseApplicationId;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {

            _LocalDrivingLicensApplication = clsLocalDrivingLicensApplication.FindLocalDrivingLicensApplicationByID(_LocalDrivingLicensesApplicationID);

            if (_LocalDrivingLicensApplication == null) 
            {
                MessageBox.Show("application with the id " + _LocalDrivingLicensesApplicationID + " not found", "faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }



            if (!clsLocalDrivingLicensApplication.DoesPassAllTests(_LocalDrivingLicensesApplicationID)) 
            {
                MessageBox.Show("person did not pass all the test yet", "faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

       //soon i will addd a method that checks if the person already have a licnese of this class
  

            if (_LocalDrivingLicensApplication.IssueLicenseFirstTime(txtNotes.Text, clsGlobal.CurrentUser.UserID) > 0)
            {
                MessageBox.Show("new license added", "succese", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("failed to add the new licnese", "faild", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void IssueDriverLicenseForFirstTime_Load(object sender, EventArgs e)
        {
            ctrlLocalDrivingLicensInfo1.loadApplicationInfoByLocalDrivingLicenseAppID(this._LocalDrivingLicensesApplicationID);



           

            }
        }
    }

