using BusinessLayer;
using MY_DVLD_SYSTEM_AGAIN.licenses.local_Licenses;
using MY_DVLD_SYSTEM_AGAIN.Tests;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace MY_DVLD_SYSTEM_AGAIN.Applications.Local_Driving_licens
{
    public partial class ManageLocalDrivingLicenses : Form
    {
        public ManageLocalDrivingLicenses()
        {
            InitializeComponent();
        }

        // this is used in some cases to save the selected row 
        int _CurrentRowIndex = 0;

        static DataTable _dtAllLocalDrivingLicensApplications = null;
        
        //load
        private void ManagePeopleMenu_Load(object sender, EventArgs e)
        {

            _refreshList();



            if (dgvApplications.Rows.Count > 0)
            {


                dgvApplications.Columns[0].HeaderText = "L.D License app ID";
                dgvApplications.Columns[0].Width = 130;


                dgvApplications.Columns[1].HeaderText = "driving class";
                dgvApplications.Columns[1].Width = 200;

                dgvApplications.Columns[2].HeaderText = "national number";
                dgvApplications.Columns[2].Width = 110;

                dgvApplications.Columns[3].HeaderText = "full name";
                dgvApplications.Columns[3].Width = 200;

                dgvApplications.Columns[4].HeaderText = "application date";
                dgvApplications.Columns[4].Width = 140;

                dgvApplications.Columns[5].HeaderText = "passed tests";
                dgvApplications.Columns[5].Width = 140;


                dgvApplications.Columns[6].HeaderText = "status";
                dgvApplications.Columns[6].Width = 150;

            }

        }
        private void _refreshList()
        {

            cbSearchFilter.SelectedIndex = 0;


            _dtAllLocalDrivingLicensApplications = clsLocalDrivingLicensApplication.GetAllLocalDrivingLicensApplications();


            dgvApplications.DataSource = _dtAllLocalDrivingLicensApplications;
            lbTotalRecords.Text = dgvApplications.Rows.Count.ToString();

        }


        //ui logic
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddUpdateLocalDrivingLicensApplication frm = new AddUpdateLocalDrivingLicensApplication();
            frm.ShowDialog();
            _refreshList();
        }


        //context menu
        private void cmsApplicationOpetions_Opening(object sender, CancelEventArgs e)
        {
            int passedTests = clsTest.GetPassedTestsCount(Convert.ToInt32(dgvApplications.CurrentRow.Cells[0].Value));

            bool isCompleted = clsLocalDrivingLicensApplication.isCompleted(Convert.ToInt32(dgvApplications.CurrentRow.Cells[0].Value));

            if (passedTests == 3)
            {
                issueDrivingLicensfristTimeToolStripMenuItem.Enabled = true;
                editToolStripMenuItem.Enabled = false;
                cancelToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
                sToolStripMenuItem.Enabled = false;
                showLicensToolStripMenuItem.Enabled = false;

                if (isCompleted)
                {
                    issueDrivingLicensfristTimeToolStripMenuItem.Enabled = false;
                    showLicensToolStripMenuItem.Enabled = true;
                }





            }
            else
            {
                editToolStripMenuItem.Enabled = true;
                cancelToolStripMenuItem.Enabled = true;
                deleteToolStripMenuItem.Enabled = true;
                sToolStripMenuItem.Enabled = true;

                showLicensToolStripMenuItem.Enabled = false;
                issueDrivingLicensfristTimeToolStripMenuItem.Enabled = false;

            }

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (clsApplication.DeleteApplicationByID(Convert.ToInt32(dgvApplications.CurrentRow.Cells[0].Value)))
            {
                MessageBox.Show("Application deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _refreshList();
            }
            else
            {
                MessageBox.Show("Failed to delete application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            localDrivingLicensInfo frm = new localDrivingLicensInfo(Convert.ToInt32(dgvApplications.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUpdateLocalDrivingLicensApplication frm = new AddUpdateLocalDrivingLicensApplication(Convert.ToInt32(dgvApplications.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
            _refreshList();
        }
        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsLocalDrivingLicensApplication.FindLocalDrivingLicensApplicationByID(Convert.ToInt32(dgvApplications.CurrentRow.Cells[0].Value)).Cancel())
            {
                MessageBox.Show("Application canceled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to cancel application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _refreshList();

        }
        private void issueDrivingLicensfristTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueDriverLicenseForFirstTime frm = new IssueDriverLicenseForFirstTime(Convert.ToInt32(dgvApplications.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
            _refreshList();
        }
        private void showLicensToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // kinda goofy ngl
            DriverLicenseInfo frm = new DriverLicenseInfo(clsLocalDrivingLicensApplication.GetLicneseID_IfIssued(Convert.ToInt32(dgvApplications.CurrentRow.Cells[0].Value)));
            frm.Show();
        }
        private void licensesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonNN = Convert.ToInt32(dgvApplications.CurrentRow.Cells[2].Value);

            PersonLicenseHistory frm = new PersonLicenseHistory(clsPerson.GetPersonInfoByNationalNumber(PersonNN).PersonID);
            frm.ShowDialog();

        }


        //context menu "scedule test"
        private void sToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            _CurrentRowIndex = Convert.ToInt32(dgvApplications.CurrentRow.Index);

            switch (Convert.ToInt32(dgvApplications.CurrentRow.Cells[5].Value))
            {
                //those number check how many test the person has passed to determine which test to take 
                case 0:
                    {
                        visionTestToolStripMenuItem.Enabled = true;
                        writtenTestToolStripMenuItem.Enabled = false;
                        streetTestToolStripMenuItem.Enabled = false;
                        break;
                    }
                case 1:
                    {
                        visionTestToolStripMenuItem.Enabled = false;
                        writtenTestToolStripMenuItem.Enabled = true;
                        streetTestToolStripMenuItem.Enabled = false;
                        break;
                    }
                case 2:
                    {
                        visionTestToolStripMenuItem.Enabled = false;
                        writtenTestToolStripMenuItem.Enabled = false;
                        streetTestToolStripMenuItem.Enabled = true;
                        break;
                    }

                default:
                    {
                        visionTestToolStripMenuItem.Enabled = false;
                        writtenTestToolStripMenuItem.Enabled = false;
                        streetTestToolStripMenuItem.Enabled = false;
                        break;

                    }

            }
        }
        private void sToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            _refreshList();
        }

        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // idk why but i tried the property 'CurrentRow' and it did not works well "Alway use the first row value"
            listTestAppointments frm = new listTestAppointments(Convert.ToInt32(dgvApplications.Rows[_CurrentRowIndex].Cells[0].Value), clsTestTypes.enTestType.vissionTest);
            frm.ShowDialog();
            _refreshList();
        }
        private void writtenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // idk why but i tried the property 'CurrentRow' and it did not works well "Alway use the first row value"
            listTestAppointments frm = new listTestAppointments(Convert.ToInt32(dgvApplications.Rows[_CurrentRowIndex].Cells[0].Value), clsTestTypes.enTestType.writtenTest);
            frm.ShowDialog();
            _refreshList();
        }
        private void streetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // idk why but i tried the property 'CurrentRow' and it did not works well "Alway use the first row value"
            listTestAppointments frm = new listTestAppointments(Convert.ToInt32(dgvApplications.Rows[_CurrentRowIndex].Cells[0].Value), clsTestTypes.enTestType.streetTest);
            frm.ShowDialog();
            _refreshList();
        }


    }
}
