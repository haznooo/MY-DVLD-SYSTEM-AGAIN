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

namespace MY_DVLD_SYSTEM_AGAIN.Tests
{
    public partial class TakeTest : Form
    {

        int _appointmentID;
        clsTestTypes _testTypes;
        clsTest _test;
        public TakeTest(int appointmentID,clsTestTypes testType)
        {
            InitializeComponent();

            if (this.DesignMode) 
            {
                return; 
            }

            _appointmentID = appointmentID;
            _testTypes = testType;
        }

        private void TakeTest_Load(object sender, EventArgs e)
        {
            ctrlScheduledTest2.LoadInfo(_appointmentID);


            int testID = -1;

            if (testID != -1)
            {

                _test = clsTest.Find(testID);
                if (_test.TestResults)
                {
                    rdPass.Checked = true;
                }
                else
                {
                    rdFaild.Checked = true;
                }
                rdFaild.Enabled = false;
                rdPass.Enabled = false;
                lbUserMessage.Enabled = false;

            }
            _test = new clsTest();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("are you sure you want to take this tetst", "take test",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Cancel) 
            {
                return;
            }

            _test.TestAppointmentID = _appointmentID;
            _test.TestResults = rdPass.Checked;
            _test.Notes = txtNotes.Text;
            _test.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_test.Save())
            {

                MessageBox.Show("test taken successfully", "take test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else { 
            MessageBox.Show("an error occurred while taking the test", "take test", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }
    }
}
