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

namespace MY_DVLD_SYSTEM_AGAIN.Applications.Application_types
{
    public partial class UpdateApplicationTypeMenu : Form
    {

        int _appTypeID;

        clsApplicationTypes appType = null;
        public UpdateApplicationTypeMenu(int appType)
        {
            InitializeComponent();

            if(this.DesignMode)
            {
                return;
            }

            _appTypeID = appType;
        }

        private void UpdateApplicationTypeMenu_Load(object sender, EventArgs e)
        {

          appType =  clsApplicationTypes.GetApplicationTypeByID(_appTypeID);

            txtApplicationName.Text = appType.ApplicationTypeTitle;
            txtApplicationFee.Text = appType.ApplicationTypeFee.ToString();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtApplicationName.Text))
            {
                MessageBox.Show("Application type name is required", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!decimal.TryParse(txtApplicationFee.Text, out decimal fee) || fee < 0)
            {
                MessageBox.Show("Application fee must be a valid non-negative number", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            appType.ApplicationTypeTitle = txtApplicationName.Text;
            appType.ApplicationTypeFee = Convert.ToDecimal(txtApplicationFee.Text);

            if (clsApplicationTypes.UpdateApplicationType(_appTypeID, appType.ApplicationTypeTitle, appType.ApplicationTypeFee))
            {

                MessageBox.Show("Application type updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {

                MessageBox.Show("Failed to update application type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
