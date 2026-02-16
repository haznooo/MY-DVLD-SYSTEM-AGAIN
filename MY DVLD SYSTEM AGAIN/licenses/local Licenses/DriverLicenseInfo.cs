using System;
using System.Windows.Forms;

namespace MY_DVLD_SYSTEM_AGAIN.licenses.local_Licenses
{
    public partial class DriverLicenseInfo : Form
    {
        int _linceseID = 0;
        public DriverLicenseInfo(int licenseID)
        {
            InitializeComponent();
            if (this.DesignMode) return;

            _linceseID = licenseID;
        }

        private void ctrlDriverLicenseInfo1_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;

            ctrlDriverLicenseInfo1.LoadInfo(_linceseID);

        }
    }
}
