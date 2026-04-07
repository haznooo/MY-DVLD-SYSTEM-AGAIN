using BusinessLayer;
using MY_DVLD_SYSTEM_AGAIN.People;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MY_DVLD_SYSTEM.People.Controls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {

        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();

            if (this.DesignMode)
            {

                return;

            }
        }
        public event Action<int> OnPersonSelected;
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {

                handler(PersonID);
            }
        }
        private void Frm_DataBack(object sender, int PersonID)
        {

            if (PersonID != -1) { LoadAndShowPersonInfo(PersonID); }

            else
            {
                ResetText();

                MessageBox.Show("No Data Recieved from the dialog", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


        }


        private bool _EnableAddButton = true;
        public bool EnableAddButton
        {
            get { return _EnableAddButton; }
            set
            {
                _EnableAddButton = value;
                btnAddNewPerson.Enabled = value;
            }
        }
        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set
            {
                _FilterEnabled = value;
                if (gbFilter != null)
                    gbFilter.Visible = value;
            }
        }
        private int _PersonID = -1;
        public int PersonID
        {
            get { return _PersonID; }

        }
        public clsPerson SelectedPerson
        {
            get { return ctrlPersonCard1.CurrentPerson; }
        }


        // load the control
        public void LoadAndShowPersonInfo(int personID)
        {
            RestControl();
            cbSearchOption.SelectedItem = "PersonID";
            txtSearch.Text = personID.ToString();
            _FindNow();
        }
        private void _FindNow()
        {

            if (this.ValidateChildren())
            {

                if (cbSearchOption.SelectedItem.ToString() == "PersonID")
                {
                    int personID = int.Parse(txtSearch.Text.Trim());
                    ctrlPersonCard1.LoadAndShowPersonInfo(personID);
                    _PersonID = ctrlPersonCard1.PersonID;
                }
                else
                {
                    int nationalNumber = Convert.ToInt32(txtSearch.Text.Trim());
                    ctrlPersonCard1.LoadAndShowPersonInfoByNN(nationalNumber);
                    _PersonID = ctrlPersonCard1.PersonID;
                }

                if (OnPersonSelected != null && FilterEnabled && ctrlPersonCard1.CurrentPerson != null)
                    // Raise the event with a parameter
                    OnPersonSelected(ctrlPersonCard1.PersonID);

            }

        }
        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {

                return;

            }

            txtSearch.Focus();
            cbSearchOption.SelectedIndex = 0;
        }

        // validations
        private void emptyTxtBox_Validating(object sender, CancelEventArgs e)
        {

            TextBox currentTextBox = (TextBox)sender;

            if (string.IsNullOrEmpty(currentTextBox.Text.Trim()))
            {

                e.Cancel = true;
                currentTextBox.Focus();
                errorProvider1.SetError(currentTextBox, "Field can't be empty");

            }
            else
            {

                e.Cancel = false;
                errorProvider1.SetError(currentTextBox, "");
            }
        }
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {

                btnSearchPerson.PerformClick();
            }

            //this will allow only digits if person id is selected
            if (cbSearchOption.Text == "PersonID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        //utility
        public void RestControl()
        {

            ctrlPersonCard1.ResetControl();
            txtSearch.Text = "";
            errorProvider1.SetError(txtSearch, "");
            cbSearchOption.SelectedIndex = 0;


        }

        // UI logic
        private void btnSearchPerson_Click(object sender, EventArgs e)
        {

            _FindNow();

        }
        private void cbSearchOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            errorProvider1.SetError(txtSearch, "");
            txtSearch.Focus();
        }
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            AddUpdatePeopleMenu frm = new AddUpdatePeopleMenu();
            frm.DataBack += Frm_DataBack;
            frm.ShowDialog();

        }


    }
}
