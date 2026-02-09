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
    public partial class listTestAppointments : Form
    {

        clsTestTypes.enTestType _TestType;
        int _localDrivingLicenseApplicationID;
        clsLocalDrivingLicensApplication _localDrivingLicensApplication;
        DataTable _DtAppointments;

        public listTestAppointments(int localDrivingLicenseApplicationID,clsTestTypes.enTestType testType)
        {
            InitializeComponent();

            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
            {
                // Stop here! We are in the Visual Studio Designer.
                return;
            }
            if (this.DesignMode) 
            {
                return;
            }
            _localDrivingLicenseApplicationID = localDrivingLicenseApplicationID;
            this._TestType = testType;

        }

        private void listTestAppointments_Load(object sender, EventArgs e)
        {
            if (ctrlLocalDrivingLicensInfo1.loadApplicationInfoByLocalDrivingLicenseAppID(_localDrivingLicenseApplicationID))
            {
                return;
            }
            _DtAppointments = clsLocalDrivingLicensApplication.GetAllApplications();

            dgvAppoinments.DataSource = _DtAppointments;

            if (dgvAppoinments.Rows.Count > 0) 
            {

                dgvAppoinments.Columns[0].HeaderText = "ID";
                dgvAppoinments.Columns[0].Width = 100;

                dgvAppoinments.Columns[1].HeaderText = "Appointment Date";
                dgvAppoinments.Columns[1].Width = 100;

                dgvAppoinments.Columns[2].HeaderText = "paied fees";
                dgvAppoinments.Columns[2].Width = 100;

                dgvAppoinments.Columns[3].HeaderText = "is locked";
                dgvAppoinments.Columns[3].Width = 100;


            }

        }

        private void btnSchedulTest_Click(object sender, EventArgs e)
        {
            scheduleTest frm = new scheduleTest(_localDrivingLicenseApplicationID, _TestType);
            frm.ShowDialog();
        }
    }
}
