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

namespace MY_DVLD_SYSTEM_AGAIN.Applications.Local_Driving_licens
{
    public partial class ManageLocalDrivingLicenses : Form
    {
        public ManageLocalDrivingLicenses()
        {
            InitializeComponent();
        }

        static DataTable _dtAllLocalDrivingLicensApplications = null;

        private void _refreshList()
        {

            cbSearchFilter.SelectedIndex = 0;


            _dtAllLocalDrivingLicensApplications = clsLocalDrivingLicensApplication.GetAllApplications();


            dgvApplications.DataSource = _dtAllLocalDrivingLicensApplications;
            lbTotalRecords.Text = dgvApplications.Rows.Count.ToString();

        }
        private void ManagePeopleMenu_Load(object sender, EventArgs e)
        {

            _refreshList();

       

            if (dgvApplications.Rows.Count > 0)
            {


                dgvApplications.Columns[0].HeaderText = "application ID";
                dgvApplications.Columns[0].Width = 110;

                dgvApplications.Columns[1].HeaderText = "national number";
                dgvApplications.Columns[1].Width = 110;

                dgvApplications.Columns[2].HeaderText = "driving class";
                dgvApplications.Columns[2].Width = 110;

                dgvApplications.Columns[3].HeaderText = "full name";
                dgvApplications.Columns[3].Width = 110;

                dgvApplications.Columns[4].HeaderText = "application date";
                dgvApplications.Columns[4].Width = 140;

                dgvApplications.Columns[5].HeaderText = "passed tests";
                dgvApplications.Columns[5].Width = 140;


                dgvApplications.Columns[6].HeaderText = "status";
                dgvApplications.Columns[6].Width = 150;

            }

        }

        private void btnAddUpdate_Click(object sender, EventArgs e)
        {
            AddUpdateLocalLicensApplication frm = new AddUpdateLocalLicensApplication();
            frm.ShowDialog();
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
    }
}
