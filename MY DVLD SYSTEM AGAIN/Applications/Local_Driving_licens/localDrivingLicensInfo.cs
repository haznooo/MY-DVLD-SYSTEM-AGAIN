using System;
using System.Windows.Forms;


namespace MY_DVLD_SYSTEM_AGAIN.Applications.Local_Driving_licens
{
    public partial class localDrivingLicensInfo : Form
    {

        int _applicationID = -1;
        int _localDrivingLicenseAppID = -1;
        bool _isLocalDrivingLicenseAppInfoLoaded = false;
        public localDrivingLicensInfo(int applicationID, bool loadByLocalDrivingLicenseApplicationID = true)
        {
            InitializeComponent();
            this._localDrivingLicenseAppID = applicationID;
            _isLocalDrivingLicenseAppInfoLoaded = loadByLocalDrivingLicenseApplicationID;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void localDrivingLicensInfo_Load(object sender, EventArgs e)
        {
            if (_isLocalDrivingLicenseAppInfoLoaded)
            {
                ctrlLocalDrivingLicensInfo1.loadApplicationInfoByLocalDrivingLicenseAppID(_localDrivingLicenseAppID);
            }
            else
            {
                ctrlLocalDrivingLicensInfo1.LoaddApplicationInfoByApplicationAppID(_applicationID);
            }
        }

    }
}
