using BusinessLayer;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MY_DVLD_SYSTEM_AGAIN.licenses.local_Licenses
{
    public partial class ctrlDriverLicenseInfoWithSearch : UserControl
    {
        public ctrlDriverLicenseInfoWithSearch()
        {
            InitializeComponent();
        }

        public event Action<int> OnLicenseSelected;
        protected virtual void PersonSelected(int LicenseID)
        {

            Action<int> handler = OnLicenseSelected;
            if (handler != null)
            {
                handler(LicenseID);
            }


        }

        bool _Enable_serach = true;

        public bool Enable_serach
        {
            get { return _Enable_serach; }

            set
            {
                _Enable_serach = value;
                gbSearch.Enabled = _Enable_serach;
            }

        }
        public int LicenseID = -1;
        public clsLicense LicenseInfo { get { return ctrlDriverLicenseInfo1.LicenseInfo; } }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not ready", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            int licenseID = int.Parse(txtSearch.Text);
            LoadInfo(licenseID);

        }

        public void LoadInfo(int licenseID)
        {

            ctrlDriverLicenseInfo1.LoadInfo(licenseID);


            txtSearch.Text = licenseID.ToString();

            LicenseID = licenseID;

            if (OnLicenseSelected != null && _Enable_serach)
                OnLicenseSelected(LicenseID);
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            // if enter is pressed
            if (e.KeyChar == (char)13)
            {
                btnSearch.PerformClick();
            }
        }

        private void emptyTxtBox_Validating(object sender, CancelEventArgs e)
        {

        }
    }
}
