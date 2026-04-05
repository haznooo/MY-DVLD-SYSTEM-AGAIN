using BusinessLayer;
using MY_DVLD_SYSTEM_AGAIN.People;
using System;
using System.Data;
using System.Windows.Forms;

namespace MY_DVLD_SYSTEM_AGAIN.Users
{
    public partial class ManageUsersMenu : Form
    {
        public ManageUsersMenu()
        {
            InitializeComponent();
        }
        static DataTable _dtAllUsers = clsUser.GetAllUsers();
        int _totalRecords = _dtAllUsers.Rows.Count;
        private void _refreshList()
        {

            cbSearchFilter.SelectedIndex = 0;


            _dtAllUsers = clsUser.GetAllUsers();


            dgvUsers.DataSource = _dtAllUsers;
            lbTotalRecords.Text = dgvUsers.Rows.Count.ToString();

        }
        private void ManageUsersMenu_Load(object sender, EventArgs e)
        {

            _refreshList();

            if (dgvUsers.Rows.Count > 0)
            {

                dgvUsers.Columns[0].HeaderText = "User ID";
                dgvUsers.Columns[0].Width = 75;

                dgvUsers.Columns[1].HeaderText = "Person ID";
                dgvUsers.Columns[1].Width = 110;

                dgvUsers.Columns[2].HeaderText = "Full Name";
                dgvUsers.Columns[2].Width = 300;

                dgvUsers.Columns[3].HeaderText = "User Name";
                dgvUsers.Columns[3].Width = 200;

                dgvUsers.Columns[4].HeaderText = "Is Active";
                dgvUsers.Columns[4].Width = 110;

            }

        }


        private void cbSearchFilter_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (cbSearchFilter.Text == "Is Active")
            {
                cbIsActive.Visible = true;
                txtSearchFilter.Visible = false; ;
                cbIsActive.SelectedIndex = 0;
                return;
            }

            else
            {
                txtSearchFilter.Text = "";

                txtSearchFilter.Visible = (cbSearchFilter.Text != "None");
                cbIsActive.Visible = false;


            }


        }
        private void txtSearchFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbSearchFilter.SelectedIndex == 1 || cbSearchFilter.SelectedIndex == 2)
            {

                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if ((txtSearchFilter.Visible) && string.IsNullOrWhiteSpace(txtSearchFilter.Text))
            {
                return;
            }

            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbSearchFilter.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "User ID":
                    FilterColumn = "UserID";
                    break;

                case "Is Active":
                    FilterColumn = "IsActive";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;


                default:
                    FilterColumn = "None";
                    break;

            }

            if (FilterColumn == "None")
            {

                _dtAllUsers.DefaultView.RowFilter = "";

                if (dgvUsers.Rows.Count != _totalRecords)
                {

                    _refreshList();

                    lbTotalRecords.Text = dgvUsers.Rows.Count.ToString();
                }

                return;


            }

            if (FilterColumn == "PersonID")
                _dtAllUsers.DefaultView.RowFilter = string.Format("Convert([{0}], 'System.String') LIKE '{1}*'", FilterColumn, txtSearchFilter.Text.Trim());

            else if (FilterColumn == "UserID")
            {

                _dtAllUsers.DefaultView.RowFilter = string.Format("Convert([{0}], 'System.String') LIKE '{1}*'", FilterColumn, txtSearchFilter.Text.Trim());

            }
            else if (FilterColumn == "IsActive")
            {

                if (cbIsActive.SelectedIndex == 1) { _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, false); }
                else if (cbIsActive.SelectedIndex == 2) { _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, true); }
                else { _dtAllUsers.DefaultView.RowFilter = ""; }

            }
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}*'", FilterColumn, txtSearchFilter.Text.Trim());



            lbTotalRecords.Text = dgvUsers.Rows.Count.ToString();
        }

        private void btnAddUpdate_Click(object sender, EventArgs e)
        {

            AddUpdateUsersMenu frm = new AddUpdateUsersMenu();
            frm.ShowDialog();
            _refreshList();
        }


        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            UserDetails frm = new UserDetails((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _refreshList();

        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AddUpdateUsersMenu frm = new AddUpdateUsersMenu((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _refreshList();

        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (clsUser.DeleteUser((int)dgvUsers.CurrentRow.Cells[0].Value))
            {

                MessageBox.Show("User deleted succecfully ");

            }
            else
            {

                MessageBox.Show("Failed to deletd the user due to its use in the system ");


            }
            _refreshList();
        }

        private void editToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AddUpdateUsersMenu frm = new AddUpdateUsersMenu((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _refreshList();
        }



        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ChangePasswordMenu frm = new ChangePasswordMenu((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _refreshList();

        }

    }
}
