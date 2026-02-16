using BusinessLayer;
using MY_DVLD_SYSTEM_AGAIN.licenses.local_Licenses;
using MY_DVLD_SYSTEM_AGAIN.People;
using System;
using System.Data;
using System.Windows.Forms;

namespace MY_DVLD_SYSTEM_AGAIN.Drivers
{
    public partial class ListDrivers : Form
    {
        DataTable _AllDrivers;
        public ListDrivers()
        {
            InitializeComponent();
        }

        private void ListDrivers_Load(object sender, EventArgs e)
        {
            _AllDrivers = clsDriver.GetAllDrivers();
            dgvAllDrivers.DataSource = _AllDrivers;
            lbRecordsCount.Text = dgvAllDrivers.Rows.Count.ToString();
            if (dgvAllDrivers.Rows.Count > 0)
            {

                dgvAllDrivers.Columns[0].HeaderText = "Full Name";
                dgvAllDrivers.Columns[0].Width = 200;

                dgvAllDrivers.Columns[1].HeaderText = "Create Date";
                dgvAllDrivers.Columns[1].Width = 150;

                dgvAllDrivers.Columns[2].HeaderText = "active Licenses";
                dgvAllDrivers.Columns[2].Width = 100;

                dgvAllDrivers.Columns[3].HeaderText = "National Number";
                dgvAllDrivers.Columns[3].Width = 100;

                dgvAllDrivers.Columns[4].HeaderText = "Person ID";
                dgvAllDrivers.Columns[4].Width = 100;

                dgvAllDrivers.Columns[5].HeaderText = "driver ID";
                dgvAllDrivers.Columns[5].Width = 100;




            }
        }

        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonDetails frm = new PersonDetails((int)dgvAllDrivers.CurrentRow.Cells[4].Value);
            frm.ShowDialog();
        }

        private void showLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonLicenseHistory frm = new PersonLicenseHistory((int)dgvAllDrivers.CurrentRow.Cells[4].Value);
            frm.ShowDialog();
        }
    }
}
