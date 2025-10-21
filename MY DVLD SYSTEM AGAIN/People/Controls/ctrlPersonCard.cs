using BusinessLayer;
using MY_DVLD_SYSTEM_AGAIN.People;
using MY_DVLD_SYSTEM_AGAIN.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MY_DVLD_SYSTEM.People.Controls
{
    public partial class ctrlPersonCard : UserControl
    {

        public ctrlPersonCard()
        {
            InitializeComponent();

            if (this.DesignMode)
            {

                return;
            }
        }
        private void ctrlPersonCard_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {

                return;
            }

        }

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
            pbPersonImage.Image =  Resources.Male_512;
            _PersonID = -1;
            _Person = null;
        }
        private void _FillPersonInfo(clsPerson Person)
        {

            if (Person != null)
            {
                lbPersonID.Text = Person._PersonID.ToString();

                lbAddress.Text = Person._Address;

                string FullName = Person._FirstName + " " + Person._SecondName + " " + Person._ThirdName + " " + Person._LastName;
                lbFullName.Text = FullName;

                lbDateOfBirth.Text = Person._DateOfBirth.ToString("yyyy-MM-dd");

                lbEmail.Text = string.IsNullOrEmpty(Person._Email) ? "No Email Yet" : Person._Email;

                lbPhoneNumber.Text = Person._Phone.ToString();

                lbNationalNumber.Text = Person._NationalNUmber;

                lbCountry.Text = Person._CountryInfo != null ? Person._CountryInfo._CountryName : "Erro Country";


                if (Person._Gender == 0)
                {
                    lbGender.Text = "Male";
                }
                else
                {

                    lbGender.Text = "Female";
                }


                bool hasNotImage = string.IsNullOrEmpty(Person._ImagePath);

                if (Person._Gender == 0 && hasNotImage)
                {

                    pbPersonImage.Image = Resources.Male_512;

                }
                else if (Person._Gender == 1 && hasNotImage)
                {

                    pbPersonImage.Image = Resources.Female_512;
                    Person._ImagePath = null;
                }
                else
                {

                    pbPersonImage.ImageLocation = Person._ImagePath;

                }

            }
            else
            {
                MessageBox.Show("Person not found.");
                _PersonID = -1;
                return;
            }

        }

        public void LoadAndShowPersonInfo(int personID)
        {

            if (this.DesignMode)
            {

                return;
            }
            ResetControl();
            _PersonID = personID;
            _Person = clsPerson.GetPersonByID(personID);


            if (_Person != null)
            {
                _PersonID = _Person._PersonID;
                _FillPersonInfo(_Person);
            }

            else
            {
                MessageBox.Show("Person not found.", "internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



        }

        public void LoadAndShowPersonInfo(string NationalNumber)
        {

            if (this.DesignMode)
            {

                return;
            }
            ResetControl();

            _Person = clsPerson.GetPersonByNationalNumber(NationalNumber);


            if (_Person != null)
            {
                _PersonID = _Person._PersonID;
                _FillPersonInfo(_Person);
            }

            else
            {
                MessageBox.Show("Person not found.", "internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }



        private void llEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            AddUpdatePeopleMenu frm = new AddUpdatePeopleMenu(_PersonID);
            frm.ShowDialog();


            LoadAndShowPersonInfo(_PersonID);


        }


    }
}
