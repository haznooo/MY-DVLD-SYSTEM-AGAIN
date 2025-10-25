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

namespace MY_DVLD_SYSTEM_AGAIN.Tests.Test_Types
{
    public partial class TestTypesMenu : Form
    {
        public TestTypesMenu()
        {
            InitializeComponent();
        }

        static DataTable _dtTestTypes = clsTestTypes.GetAllTestTypes();
        private void _refreshList()
        {


            _dtTestTypes = clsTestTypes.GetAllTestTypes();

            dgvTestTypes.DataSource = _dtTestTypes;
            lbTotalRecords.Text = dgvTestTypes.Rows.Count.ToString();

        }

        private void TestTypesMenu_Load(object sender, EventArgs e)
        {
            _refreshList();

            if (dgvTestTypes.Rows.Count > 0)
            {


                dgvTestTypes.Columns[0].HeaderText = "test type id";
                dgvTestTypes.Columns[0].Width = 140;

                dgvTestTypes.Columns[1].HeaderText = "Application type title";
                dgvTestTypes.Columns[1].Width = 150;

                dgvTestTypes.Columns[2].HeaderText = "test type description";
                dgvTestTypes.Columns[2].Width = 750;

               dgvTestTypes.Columns[3].HeaderText = "test type fees";
               dgvTestTypes.Columns[3].Width = 100;



            }
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            EditTestTypeMenu frm = new EditTestTypeMenu((int)dgvTestTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            _refreshList();

        }
    }
}
