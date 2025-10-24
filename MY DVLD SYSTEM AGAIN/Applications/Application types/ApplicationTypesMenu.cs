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

namespace MY_DVLD_SYSTEM_AGAIN.Applications.Application_types
{
    public partial class ApplicationTypesMenu : Form
    {
        public ApplicationTypesMenu()
        {
            InitializeComponent();
        }

        static DataTable _dtApplicationTypes = clsApplicationTypes.GetAllApplicationTypes();



        private void _refreshList()
        {

            _dtApplicationTypes = clsApplicationTypes.GetAllApplicationTypes();


            dgvApplications.DataSource = _dtApplicationTypes;
            lbTotalRecords.Text = dgvApplications.Rows.Count.ToString();

        }
      
        private void ApplicationTypesMenu_Load(object sender, EventArgs e)
        {
            _refreshList();

            dgvApplications.DataSource = _dtApplicationTypes;

            if (dgvApplications.Rows.Count > 0)
            {


                dgvApplications.Columns[0].HeaderText = "Application type id";
                dgvApplications.Columns[0].Width = 140;

                dgvApplications.Columns[1].HeaderText = "Application type title";
                dgvApplications.Columns[1].Width = 400;

                dgvApplications.Columns[2].HeaderText = "Application type fees";
                dgvApplications.Columns[2].Width = 140;



            }
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateApplicationTypeMenu frm = new UpdateApplicationTypeMenu((int)dgvApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _refreshList();
        }
    }
}
