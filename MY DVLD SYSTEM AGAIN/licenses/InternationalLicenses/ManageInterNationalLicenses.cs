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

namespace MY_DVLD_SYSTEM_AGAIN.licenses.InternationalLicenses
{
    public partial class ManageInterNationalLicenses : Form
    {
        public ManageInterNationalLicenses()
        {
            InitializeComponent();
        }
        DataTable _dtInternationalLicenses;

        private void ManageInterNationalLicenses_Load(object sender, EventArgs e)
        {

            _dtInternationalLicenses = clsInternationalLicense.GetAllInternationalLicenses();

            if (_dtInternationalLicenses == null) 
            {
                MessageBox.Show("failed to load international licneses");
                this.Close();
                return;

            }
            dgvAllInternationalLicenses.DataSource = _dtInternationalLicenses;

            lbTotalRecords.Text = dgvAllInternationalLicenses.RowCount.ToString();

        }
    }
}
