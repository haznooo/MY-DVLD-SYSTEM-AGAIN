using BusinessLayer;
using DVLD.Classes;
using MY_DVLD_SYSTEM_AGAIN.People;
using System;
using System.Data;
using System.Windows.Forms;

namespace MY_DVLD_SYSTEM_AGAIN
{
    public partial class ManagePeopleMenu : Form
    {
        public ManagePeopleMenu()
        {
            InitializeComponent();
        }

        static DataTable _dtAllPeople = clsPerson.GetAllPeople();

        DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNumber", "FirstName", "SecondName", "ThirdName",
           "LastName", "GenderCaption", "Address", "Phone", "Email", "CountryID", "ImagePath");

        private void _refreshList()
        {

            cbSearchFilter.SelectedIndex = 0;


            txtSearchFilter.Text = "";
            txtSearchFilter.Visible = false;

            rdFemale.Visible = false;
            rdMale.Visible = false;

            _dtAllPeople = clsPerson.GetAllPeople();

            _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNumber", "FirstName", "SecondName", "ThirdName",
                "LastName", "DateOfBirth", "GenderCaption", "Address", "Phone", "Email", "CountryID", "ImagePath");

            dgvPeople.DataSource = _dtPeople;
            lbTotalRecords.Text = dgvPeople.Rows.Count.ToString();

        }
        private void ManagePeopleMenu_Load(object sender, EventArgs e)
        {

            _refreshList();

            dgvPeople.DataSource = _dtPeople;

            if (dgvPeople.Rows.Count > 0)
            {


                dgvPeople.Columns[0].HeaderText = "Person ID";
                dgvPeople.Columns[0].Width = 75;

                dgvPeople.Columns[1].HeaderText = "National Number";
                dgvPeople.Columns[1].Width = 110;

                dgvPeople.Columns[2].HeaderText = "First Name";
                dgvPeople.Columns[2].Width = 110;

                dgvPeople.Columns[3].HeaderText = "Second Name";
                dgvPeople.Columns[3].Width = 110;

                dgvPeople.Columns[4].HeaderText = "Third Name";
                dgvPeople.Columns[4].Width = 110;

                dgvPeople.Columns[5].HeaderText = "Last Name";
                dgvPeople.Columns[5].Width = 110;

                dgvPeople.Columns[6].HeaderText = "Date Of Birth";
                dgvPeople.Columns[6].Width = 120;

                dgvPeople.Columns[7].HeaderText = "gender";
                dgvPeople.Columns[7].Width = 60;

                dgvPeople.Columns[10].Width = 150;
                dgvPeople.Columns[11].Width = 70;

                dgvPeople.Columns[12].HeaderText = "Image Path";
                dgvPeople.Columns[8].Width = 200;

            }

        }


        private void cbSearchFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearchFilter.Visible = (cbSearchFilter.Text != "None" && cbSearchFilter.Text != "Gender");


            if (txtSearchFilter.Visible)
            {
                rdFemale.Visible = false;
                rdMale.Visible = false;
                txtSearchFilter.Text = "";
                txtSearchFilter.Focus();
                return;
            }


            if (cbSearchFilter.Text == "Gender")
            {
                txtSearchFilter.Visible = false;
                rdFemale.Visible = true;
                rdMale.Visible = true;
                return;
            }


            rdFemale.Visible = false;
            rdMale.Visible = false;
            txtSearchFilter.Visible = false;

        }
        private void txtSearchFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbSearchFilter.SelectedIndex == 1 || cbSearchFilter.SelectedIndex == 2 || cbSearchFilter.SelectedIndex == 3)
            {

                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbSearchFilter.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNumber";
                    break;

                case "First Name":
                    FilterColumn = "FirstName";
                    break;

                case "Second Name":
                    FilterColumn = "SecondName";
                    break;

                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;

                case "Last Name":
                    FilterColumn = "LastName";
                    break;

                case "CountryID":
                    FilterColumn = "CountryName";
                    break;

                case "Gender":
                    FilterColumn = "GenderCaption";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            if (FilterColumn == "None")
            {

                _dtPeople.DefaultView.RowFilter = "";
                lbTotalRecords.Text = dgvPeople.Rows.Count.ToString();
                return;

            }

            if (FilterColumn == "PersonID")
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtSearchFilter.Text.Trim());

            else if (FilterColumn == "GenderCaption")
            {

                if (rdMale.Checked) { _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, "Male"); }
                else { _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, "Female"); }
            }

            else
            {

                if ((FilterColumn == "Email") && !clsValidatoin.ValidateEmail(txtSearchFilter.Text.Trim()))
                {
                    MessageBox.Show("Please enter a valid email", "Invalid email format");
                    txtSearchFilter.Text = "";
                    return;
                }

                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtSearchFilter.Text.Trim());


            }

            lbTotalRecords.Text = dgvPeople.Rows.Count.ToString();

        }

        private void btnAddUpdate_Click(object sender, EventArgs e)
        {

            AddUpdatePeopleMenu frm = new AddUpdatePeopleMenu();
            frm.ShowDialog();
            _refreshList();
        }
        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            PersonDetails frm = new PersonDetails((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _refreshList();

        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AddUpdatePeopleMenu frm = new AddUpdatePeopleMenu((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _refreshList();

        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (MessageBox.Show("Are you sure you want to delete this person?", "Delete Person", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;


            if (clsPerson.DeletePerson((int)dgvPeople.CurrentRow.Cells[0].Value))
            {
                _refreshList();
                MessageBox.Show("Person Deleted succesfully");
            }
            else
            {

                MessageBox.Show("Failed to delete person due to its use in the system", "Error deleting person", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }




    }
}
