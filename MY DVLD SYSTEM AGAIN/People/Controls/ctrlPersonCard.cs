using BusinessLayer;
using MY_DVLD_SYSTEM_AGAIN.People;
using MY_DVLD_SYSTEM_AGAIN.Properties;
using System;
using System.Windows.Forms;

namespace MY_DVLD_SYSTEM.People.Controls
{
    public partial class ctrlPersonCard : UserControl
    {

        private int _PersonID = -1;
        clsPerson _Person = null;
        public int PersonID
        {
            get { return _PersonID; }
        }
        public clsPerson CurrentPerson
        {
            get { return _Person; }
        }


        public ctrlPersonCard()
        {
            InitializeComponent();

            if (this.DesignMode)
            {

                return;
            }
        }


        // loading the control
        public void LoadAndShowPersonInfo(int personID)
        {

            if (this.DesignMode)
            {

                return;
            }
            ResetControl();
            _PersonID = personID;
            _Person = clsPerson.GetPersonInfoByID(personID);


            if (_Person != null)
            {
                _PersonID = _Person.PersonID;
                _FillPersonInfo(_Person);
            }

            else
            {
                MessageBox.Show("Person not found.", "internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



        }
        public void LoadAndShowPersonInfoByNN(int NationalNumber)
        {

            if (this.DesignMode)
            {

                return;
            }
            ResetControl();

            _Person = clsPerson.GetPersonInfoByNationalNumber(NationalNumber);


            if (_Person != null)
            {
                _PersonID = _Person.PersonID;
                _FillPersonInfo(_Person);
            }

            else
            {
                MessageBox.Show("Person not found.", "internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }
        private void _FillPersonInfo(clsPerson Person)
        {

            if (Person != null)
            {
                lbPersonID.Text = Person.PersonID.ToString();

                lbAddress.Text = Person.Address;

                string FullName = Person.FirstName + " " + Person.SecondName + " " + Person.ThirdName + " " + Person.LastName;
                lbFullName.Text = FullName;

                lbDateOfBirth.Text = Person.DateOfBirth.ToString("yyyy-MM-dd");

                lbEmail.Text = string.IsNullOrEmpty(Person.Email) ? "No Email Yet" : Person.Email;

                lbPhoneNumber.Text = Person.Phone.ToString();

                lbNationalNumber.Text = Person.NationalNUmber.ToString();

                lbCountry.Text = Person.CountryInfo != null ? Person.CountryInfo._CountryName : "Erro Country";


                if (Person.Gender == 0)
                {
                    lbGender.Text = "Male";
                }
                else
                {

                    lbGender.Text = "Female";
                }


                bool hasNotImage = string.IsNullOrEmpty(Person.ImagePath);

                if (Person.Gender == 0 && hasNotImage)
                {

                    pbPersonImage.Image = Resources.Male_512;

                }
                else if (Person.Gender == 1 && hasNotImage)
                {

                    pbPersonImage.Image = Resources.Female_512;
                    Person.ImagePath = null;
                }
                else
                {

                    pbPersonImage.ImageLocation = Person.ImagePath;

                }

            }
            else
            {
                MessageBox.Show("Person not found.");
                _PersonID = -1;
                return;
            }

        }


        //utitlity
        public void ResetControl()
        {
            lbPersonID.Text = "";
            lbAddress.Text = "";
            lbFullName.Text = "";
            lbDateOfBirth.Text = "";
            lbEmail.Text = "";
            lbPhoneNumber.Text = "";
            lbNationalNumber.Text = "";
            lbGender.Text = "";
            pbPersonImage.Image = Resources.Male_512;
            _PersonID = -1;
            _Person = null;
        }
     
        // UI logic
        private void llEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            AddUpdatePeopleMenu frm = new AddUpdatePeopleMenu(_PersonID);
            frm.ShowDialog();


            LoadAndShowPersonInfo(_PersonID);


        }


    }
}
