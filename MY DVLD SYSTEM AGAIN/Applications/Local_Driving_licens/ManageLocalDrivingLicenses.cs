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

        static DataTable _dtAllApplications = null;


        private void _refreshList()
        {

            cbSearchFilter.SelectedIndex = 0;


            _dtAllApplications = clsApplication.GetAllApplications();


            dgvApplications.DataSource = _dtAllApplications;
            lbTotalRecords.Text = dgvApplications.Rows.Count.ToString();

        }
        private void ManagePeopleMenu_Load(object sender, EventArgs e)
        {

            _refreshList();

            dgvApplications.DataSource = _dtAllApplications;

            if (dgvApplications.Rows.Count > 0)
            {


                dgvApplications.Columns[0].HeaderText = "application ID";
                dgvApplications.Columns[0].Width = 110;

                dgvApplications.Columns[1].HeaderText = "applicant ID";
                dgvApplications.Columns[1].Width = 110;

                dgvApplications.Columns[2].HeaderText = "application date";
                dgvApplications.Columns[2].Width = 110;

                dgvApplications.Columns[3].HeaderText = "created by user";
                dgvApplications.Columns[3].Width = 110;

                dgvApplications.Columns[4].HeaderText = "application type";
                dgvApplications.Columns[4].Width = 140;

                dgvApplications.Columns[5].HeaderText = "application status";
                dgvApplications.Columns[5].Width = 140;


                dgvApplications.Columns[6].HeaderText = "last status date";
                dgvApplications.Columns[6].Width = 150;

                dgvApplications.Columns[7].HeaderText = "paid fee";
               dgvApplications.Columns[7].Width = 110;

            }

        }

        private void btnAddUpdate_Click(object sender, EventArgs e)
        {
            AddUpdateLocalLicensApplication frm = new AddUpdateLocalLicensApplication();
            frm.ShowDialog();
        }
    }
}
