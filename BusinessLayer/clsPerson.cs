using DataAccessLayer;
using System;
using System.Data;

namespace BusinessLayer
{
    public class clsPerson
    {

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;
        public int PersonID { get; private set; }
        public int NationalNUmber { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return string.Format("{0} {1} {2} {3}", FirstName, SecondName, ThirdName, LastName);
            }
        }
        public DateTime DateOfBirth { get; set; }
        public byte Gender { get; set; } = 0;
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int CountryID { get; set; }
        public string ImagePath { get; set; }
        public string GenderTxt
        {
            get
            {

                if (Gender == 0) return "Male";
                else return "Female";
            }
        }
        public clsCountry CountryInfo;




        public clsPerson()

        {
            this.PersonID = -1;
            this.NationalNUmber = 0;
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = DateTime.Now;
            this.Gender = 0;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.CountryID = -1;
            this.ImagePath = "";

            _Mode = enMode.AddNew;

        }

        private clsPerson(int PersonID,int NationalNumber, string FirstName, string SecondName, string ThirdName, string LastName,
             DateTime DateOfBirth, byte gender, string Address, string Phone, string Email, int CountryID, string ImagePath)

        {
            this.PersonID = PersonID;
            this.NationalNUmber = NationalNumber;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.CountryID = CountryID;
            this.ImagePath = ImagePath;
            CountryInfo = clsCountry.Find(this.CountryID);

            _Mode = enMode.Update;

        }


        // save
        private bool _AddNewPerson()
        {

            this.PersonID = clsPersonDataAccess.AddNewPerson(this.NationalNUmber, this.FirstName, this.SecondName, this.ThirdName, this.LastName,
               this.DateOfBirth, this.Gender, this.Address, this.Phone, this.Email, this.CountryID, this.ImagePath);

            return (this.PersonID != -1);
        }
        private bool _UpdatePerson()
        {

            return clsPersonDataAccess.UpdatePerson(this.PersonID, this.NationalNUmber, this.FirstName, this.SecondName, this.ThirdName, this.LastName,
               this.DateOfBirth, this.Gender, this.Address, this.Phone, this.Email, this.CountryID, this.ImagePath);
        }
        public bool Save()
        {


            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {

                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePerson();

            }

            return false;
        }


        // get data
        public static DataTable GetAllPeople()
        {

            return clsPersonDataAccess.GetPeople();

        }
        public static clsPerson GetPersonInfoByID(int PersonID)
        {

            string  FirstName = "", SecondName = "", ThirdName = "", LastName = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            byte Gender = 0;
            int CountryID = -1, NationalNumber = -1;

            if (clsPersonDataAccess.GetPersonInfoByID(PersonID, ref NationalNumber, ref FirstName, ref SecondName, ref ThirdName
             , ref LastName, ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email, ref CountryID, ref ImagePath))

                return new clsPerson(PersonID, NationalNumber, FirstName, SecondName, ThirdName, LastName,
                    DateOfBirth, Gender, Address, Phone, Email, CountryID, ImagePath);

            else
                return null;

        }
        public static clsPerson GetPersonInfoByNationalNumber(int NationalNumber)
        {

            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            byte Gender = 0;
            int CountryID = -1;
            int PersonID = -1;

            if (clsPersonDataAccess.GetPersonInfoByNationalNumber(ref PersonID, NationalNumber, ref FirstName, ref SecondName, ref ThirdName
             , ref LastName, ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email, ref CountryID, ref ImagePath))

                return new clsPerson(PersonID, NationalNumber, FirstName, SecondName, ThirdName, LastName,
                    DateOfBirth, Gender, Address, Phone, Email, CountryID, ImagePath);

            else
                return null;

        }


        //delete
        public static bool DeletePerson(int ID)
        {
            return clsPersonDataAccess.DeletePerson(ID);
        }


        //check
        public static bool isPersonExist(int PersonID)
        {
            return clsPersonDataAccess.IsPersonExist(PersonID);
        }
        public static bool DoesNationalNumberExist(int NationalNumber,int PersonID = -1)
        {
            return clsPersonDataAccess.DoesNationalNumberExist(NationalNumber,PersonID);
        }



    }
}
