using BusinessLayer;
using DVLD.Classes;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;
namespace MY_DVLD_SYSTEM_AGAIN.People
{
    public partial class AddUpdatePeopleMenu : Form
    {

        int _PersonID = -1;
        clsPerson _Person;
        enum enMode { update, add };
        enMode _FormMode;



        public AddUpdatePeopleMenu()
        {
            InitializeComponent();

            _FormMode = enMode.add;
        }
        public AddUpdatePeopleMenu(int PersonID)
        {
            InitializeComponent();


            _FormMode = enMode.update;
            _PersonID = PersonID;


        }

        public delegate void DataBackHandler(object sender, int PersonID);

        public event DataBackHandler DataBack;

        //functions related to loading the form
        private void _AddUpdatePeopleMenu_Load(object sender, EventArgs e)
        {

            _resetFormValues();

            if (_FormMode == enMode.update)
            {

                _LoadPersonInfosToForm(_PersonID);
            }
        }
        private void _resetFormValues()
        {


            if (_FormMode == enMode.update)
            {
                lbCurrentMode.Text = $"Update person";
                lbPersonID.Text = _PersonID.ToString();

            }
            else
            {
                lbCurrentMode.Text = "Add new Person";
                _Person = new clsPerson();
            }

            _LoadCountries();
            dtpDateOfBirth.MaxDate = (DateTime.Now.AddYears(-18));

            cbCountries.SelectedIndex = 0;

            rdMale.Checked = true;
            pbPersonImage.SizeMode = PictureBoxSizeMode.StretchImage;

            if (rdMale.Checked == true) { pbPersonImage.Image = Properties.Resources.Male_512; }
            else pbPersonImage.Image = Properties.Resources.Female_512;

            llRemoveImage.Visible = (pbPersonImage.ImageLocation != null);

            txtNationalNumber.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtSecondName.Text = string.Empty;
            txtThirdName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtAdress.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;


        }
        private void _LoadPersonInfosToForm(int PersonID)
        {

            _Person = clsPerson.GetPersonInfoByID(PersonID);

            if (_Person == null)
            {
                MessageBox.Show($"person witht the id : {_PersonID} is not found", "no person found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtNationalNumber.Text = _Person.NationalNUmber.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtAdress.Text = _Person.Address;
            txtEmail.Text = _Person.Email;
            txtPhone.Text = _Person.Phone;
            dtpDateOfBirth.Value = _Person.DateOfBirth;
            txtNationalNumber.Text = _Person.NationalNUmber.ToString();
            cbCountries.SelectedIndex = cbCountries.FindString(_Person.CountryInfo._CountryName);

            // if there is no attached image to this person then we will use a default one
            bool NoImagedAttached = (string.IsNullOrEmpty(_Person.ImagePath));

            // 0 equals male
            if (_Person.Gender == 0)
            {
                rdMale.Checked = true;
                rdFemale.Checked = false;

                if (NoImagedAttached)
                {
                    pbPersonImage.Image = Properties.Resources.Male_512;

                    _Person.ImagePath = null;
                }

            }
            else
            {
                rdFemale.Checked = true;
                rdMale.Checked = false;

                if (NoImagedAttached)
                {
                    pbPersonImage.Image = Properties.Resources.Female_512;
                    _Person.ImagePath = null;
                }
            }


            if (!NoImagedAttached)
            {

                pbPersonImage.ImageLocation = _Person.ImagePath;

                llRemoveImage.Visible = (pbPersonImage.ImageLocation != null);

            }


        }
        private void _LoadCountries()
        {

            DataTable countries = clsCountry.GetAllCountries();

            foreach (DataRow row in countries.Rows)
            {

                cbCountries.Items.Add(row["CountryName"].ToString());

            }


        }


        //functions related to saving data
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {

                MessageBox.Show("failed to save please enter correct infos", "wrong infos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_handelImages())
            {
                MessageBox.Show("failed to save image", "internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            _LoadFormInfosToPerson();

            if (_Person.Save())
            {

                DataBack?.Invoke(this, _Person.PersonID);

                MessageBox.Show("Person Saved succesfully", "confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);


                _FormMode = enMode.update;
                lbCurrentMode.Text = $"Update person";
                lbPersonID.Text = _Person.PersonID.ToString();


            }
            else
            {
                MessageBox.Show("failed to save", "internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }
        private void _LoadFormInfosToPerson()
        {

            _Person.NationalNUmber = Convert.ToInt32(txtNationalNumber.Text);
            _Person.FirstName = txtFirstName.Text;
            _Person.SecondName = txtSecondName.Text;
            _Person.ThirdName = txtThirdName.Text;
            _Person.LastName = txtLastName.Text;
            _Person.Email = txtEmail.Text;
            _Person.Phone = txtPhone.Text;
            _Person.Address = txtAdress.Text;
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            // combo box starts with the index 0 but in the database everything starts with the index 1
            _Person.CountryID = cbCountries.SelectedIndex + 1;

            if (rdMale.Checked == true) { _Person.Gender = 0; }
            else { _Person.Gender = 1; }





        }
        private bool _handelImages()
        {



            // if person's image path and the picture box are the same then this means that there is not changes happend to
            //the picture box and it is loading rn the path that the person have when loaded from the database

            if (pbPersonImage.ImageLocation != _Person.ImagePath)
            {

                // if the user changed the image of the picture box then we have to update the image of the person (the path in database and the actuall place we store images in  )
                // if the there is an image then we update the person's path to a new path 
                if (pbPersonImage.ImageLocation != null)
                {

                    if (!string.IsNullOrEmpty(_Person.ImagePath))
                    {
                        File.Delete(_Person.ImagePath);
                        _Person.ImagePath = null;
                    }


                    string sourceFile = pbPersonImage.ImageLocation;

                    if (clsUtil.CopyImageToProjectImagesFolder(ref sourceFile))
                    {

                        _Person.ImagePath = sourceFile;
                        pbPersonImage.ImageLocation = sourceFile;


                    }
                }
                else
                {
                    // if there is no image in the picture box then we just check
                    // if there is an image in the database and we remove it  and remove it from the folder

                    if (!string.IsNullOrEmpty(_Person.ImagePath))
                    {
                        File.Delete(_Person.ImagePath);
                        _Person.ImagePath = null;

                    }


                }


            }

            return true;
        }


         //functions related to validating the data
        private void emptyTxtBox_Validating(object sender, CancelEventArgs e)
        {

            TextBox currentTextBox = (TextBox)sender;

            if (string.IsNullOrEmpty(currentTextBox.Text.Trim()))
            {

                e.Cancel = true;
                currentTextBox.Focus();
                errorProvider1.SetError(currentTextBox, "This info is required");

            }
            else
            {

                e.Cancel = false;
                errorProvider1.SetError(currentTextBox, "");
            }
        }
        private void txtNationalNumber_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtNationalNumber.Text.Trim()))
            {

                e.Cancel = true;
                txtNationalNumber.Focus();
                errorProvider1.SetError(txtNationalNumber, "This info is required");

            }
            else
            {

                e.Cancel = false;
                errorProvider1.SetError(txtNationalNumber, "");
            }
   
            bool DoesNNExists = false;

            if (_FormMode == enMode.add)
                DoesNNExists = clsPerson.DoesNationalNumberExist(Convert.ToInt32(txtNationalNumber.Text));
            else
                DoesNNExists = clsPerson.DoesNationalNumberExist(Convert.ToInt32(txtNationalNumber.Text), _PersonID);

                if (DoesNNExists)
                {

                    e.Cancel = true;
                    txtNationalNumber.Focus();
                    errorProvider1.SetError(txtNationalNumber, "This national number already exist");

                }
                else
                {

                    e.Cancel = false;
                    errorProvider1.SetError(txtNationalNumber, "");
                }
        }
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {


            if (!string.IsNullOrEmpty(txtEmail.Text) && !clsValidatoin.ValidateEmail(txtEmail.Text.Trim()))
            {

                e.Cancel = true;
                txtEmail.Focus();
                errorProvider1.SetError(txtEmail, "Please enter a valid email");

            }
            else
            {

                e.Cancel = false;
                errorProvider1.SetError(txtEmail, "");
            }
        }
        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtPhone.Text.Trim()))
            {

                e.Cancel = true;
                txtPhone.Focus();
                errorProvider1.SetError(txtPhone, "this field is required");
                return;
            }
            else
            {

                e.Cancel = false;
                errorProvider1.SetError(txtPhone, "");
            }


            if (!clsValidatoin.IsNumber(txtPhone.Text.Trim()))
            {

                e.Cancel = true;
                txtPhone.Focus();
                errorProvider1.SetError(txtPhone, "Please enter a valid number");

            }
            else
            {

                e.Cancel = false;
                errorProvider1.SetError(txtPhone, "");
            }
        }
        private void txtNationalNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }


        // functions related to UI logic (user interaction)
        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            //there is a method called _HandelImages and it will will handel chagning the values in the database
            // here we just change the picture box


            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string imagePath = openFileDialog1.FileName;
                pbPersonImage.ImageLocation = imagePath;
                llRemoveImage.Visible = true;
            }

        }
        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //there is a method called _HandelImages and it will will handel chagning the values in the database
            // here we just change the picture box
            pbPersonImage.ImageLocation = null;

            llRemoveImage.Visible = false;

            if (rdMale.Checked == true) { pbPersonImage.Image = Properties.Resources.Male_512; }
            else pbPersonImage.Image = Properties.Resources.Female_512;


        }
        private void rdMale_CheckedChanged(object sender, EventArgs e)
        {
            //if there is already an image then we do not change it when the user change the gender
            if (pbPersonImage.ImageLocation != null) { return; }

            if (rdMale.Checked == true)
            {

                pbPersonImage.Image = Properties.Resources.Male_512;

            }
            else
            {
                pbPersonImage.Image = Properties.Resources.Female_512;

            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
