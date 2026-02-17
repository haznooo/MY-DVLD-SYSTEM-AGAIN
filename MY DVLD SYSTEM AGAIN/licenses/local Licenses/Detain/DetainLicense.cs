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

namespace MY_DVLD_SYSTEM_AGAIN.licenses.local_Licenses.Detain
{
    public partial class DetainLicense : Form
    {
        public DetainLicense()
        {
            InitializeComponent();
        }
        int _DetainID = -1;
        int _LicensesID = -1;
        private void ctrlDriverLicenseInfoWithSearch1_OnLicenseSelected(int obj)
        {
            _LicensesID = obj;
            lbLicenseID.Text = _LicensesID.ToString();

            if (_LicensesID == -1) return;

            if (ctrlDriverLicenseInfoWithSearch1.LicenseInfo.IsDetained) 
            {
                MessageBox.Show("licnese is already detained", "detained license", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnDetain.Enabled = true;
            txtFineFees.Focus();
        }

        private void DetainLicense_Load(object sender, EventArgs e)
        {
            lbDetainDate.Text = DateTime.Now.ToString();
            lbCreatedBy.Text =  clsGlobal.CurrentUser.UserName;
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {

            _DetainID = ctrlDriverLicenseInfoWithSearch1.LicenseInfo.Detain(Convert.ToDecimal(txtFineFees.Text), clsGlobal.CurrentUser.UserID);
            if (_DetainID != -1)
            {
                MessageBox.Show("license detained succesfully", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else 
            {
                MessageBox.Show("failed to detain", "fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnDetain.Enabled = false;
        }
        private void emptyTxtBox_Validating(object sender, CancelEventArgs e)
        {

            TextBox currentTextBox = (TextBox)sender;

            if (string.IsNullOrEmpty(currentTextBox.Text.Trim()))
            {

                e.Cancel = true;
                currentTextBox.Focus();
                errorProvider1.SetError(currentTextBox, "This info is required");

            }
            else
            {

                e.Cancel = false;
                errorProvider1.SetError(currentTextBox, "");
            }
        }

        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        
        }
    }
}
