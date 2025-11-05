using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MY_DVLD_SYSTEM_AGAIN.Tests.Test_Types
{
    public partial class EditTestTypeMenu : Form
    {

        int _TestTypeID;

        clsTestTypes _TestType = null;
        public EditTestTypeMenu(int TestTypeID)
        {
            InitializeComponent();

            if (this.DesignMode)
            {
                return;
            }

            _TestTypeID = TestTypeID;
        }


        private void UpdateTestTypeMenu_Load(object sender, EventArgs e)
        {

            _TestType = clsTestTypes.GetTestTypeByID((clsTestTypes.enTestType)_TestTypeID);

            txtTestTypeTitle.Text = _TestType.TestTypeTitle;
            txtTestTypeFee.Text = _TestType.TestTypeFee.ToString();
            txtTestTypeDescription.Text = _TestType.TestTypeDescription;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtTestTypeTitle.Text))
            {
                MessageBox.Show("Application type name is required", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txtTestTypeFee.Text, out decimal fee) || fee < 0)
            {
                MessageBox.Show("Application fee must be a valid non-negative number", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            _TestType.TestTypeTitle = txtTestTypeTitle.Text;
            _TestType.TestTypeFee = Convert.ToDecimal(txtTestTypeFee.Text);
            _TestType.TestTypeDescription = txtTestTypeDescription.Text;

            if (clsTestTypes.UpdateApplicationType(_TestTypeID, _TestType.TestTypeDescription,_TestType.TestTypeTitle,_TestType.TestTypeFee))
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
