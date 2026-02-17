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

namespace MY_DVLD_SYSTEM_AGAIN.licenses.local_Licenses.Detain
{
    public partial class ManageDetainedLicenses : Form
    {
        public ManageDetainedLicenses()
        {
            InitializeComponent();
        }
        DataTable _detainedLicenses;
        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            DetainLicense frm = new DetainLicense();
            frm.ShowDialog();
        }

        private void ManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            _detainedLicenses = clsDetainLicense.GetAllDetainedLicenses();

            if (_detainedLicenses == null) 
            {
                MessageBox.Show("Failed to retrive detained licenses","fail",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            dgvDetainedLicenses.DataSource = _detainedLicenses;

            lbTotalRecords.Text = dgvDetainedLicenses.RowCount.ToString();

            dgvDetainedLicenses.Columns[0].HeaderText = "Detain ID";
            dgvDetainedLicenses.Columns[0].Width = 100;

            dgvDetainedLicenses.Columns[1].HeaderText = "License ID";
            dgvDetainedLicenses.Columns[1].Width = 100;

            dgvDetainedLicenses.Columns[2].HeaderText = "Detain date";
            dgvDetainedLicenses.Columns[2].Width = 220;

            dgvDetainedLicenses.Columns[3].HeaderText = "is released";
            dgvDetainedLicenses.Columns[3].Width = 100;

            dgvDetainedLicenses.Columns[4].HeaderText = "Fine fees";
            dgvDetainedLicenses.Columns[4].Width = 100;

            dgvDetainedLicenses.Columns[5].HeaderText = "National number";
            dgvDetainedLicenses.Columns[5].Width = 100;

            dgvDetainedLicenses.Columns[6].HeaderText = "Full name";
            dgvDetainedLicenses.Columns[6].Width = 250;

            dgvDetainedLicenses.Columns[5].HeaderText = "Release application ID";
            dgvDetainedLicenses.Columns[5].Width = 250;

            dgvDetainedLicenses.Columns[6].HeaderText = "Releas Date";
            dgvDetainedLicenses.Columns[6].Width = 220;


        }
    }
}
