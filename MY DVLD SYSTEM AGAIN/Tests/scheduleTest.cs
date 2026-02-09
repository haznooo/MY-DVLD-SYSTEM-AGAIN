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

namespace MY_DVLD_SYSTEM_AGAIN.Tests
{
    public partial class scheduleTest : Form
    {

        int _LocalDrivingLicenseApplicationID;
        clsTestTypes.enTestType _testType = clsTestTypes.enTestType.vissionTest;
        int _appointmentID;

        public scheduleTest(int LocalDrivingLicenseApplicationID,clsTestTypes.enTestType testType,int appointmentID =-1)
        {
            InitializeComponent();

            this._LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this._testType = testType;
            this._appointmentID = appointmentID;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlSchedulTest1_Load(object sender, EventArgs e)
        {
            ctrlSchedulTest1.TestType = this._testType;
            ctrlSchedulTest1.LoadInfo(_LocalDrivingLicenseApplicationID);
        }
    }
}
