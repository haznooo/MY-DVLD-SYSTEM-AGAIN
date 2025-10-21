using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsPerson
    {
        public int _PersonID { get;private set; }
        public string _NationalNUmber {  get; set; }
        public string _FirstName { get; set; }
        public string _SecondName { get; set; }
        public string _ThirdName { get; set; }
        public string _LastName { get; set; }
        public DateTime _DateOfBirth { get; set; }
        public byte _Gender { get; set; } = 0;
        public string _Address { get; set; }
        public string _Phone { get; set; }
        public string _Email { get; set; }
        public int _CountryID { get; set; }
        public string _ImagePath { get; set; }

       public clsCountry _CountryInfo;

 
     public static DataTable GetAllPeople() { 
        
        return clsPersonDataAccess.GetPeople();

        }


        public enum enMode { AddNew = 0, Update = 1 };
        public enMode _Mode = enMode.AddNew;


        public clsPerson()

        {
            this._PersonID = -1;
            this._NationalNUmber = "";
            this._FirstName = "";
            this._SecondName = "";
            this._ThirdName = "";
            this._LastName = "";
            this._DateOfBirth = DateTime.Now;
            this._Gender = 0;
            this._Address = "";
            this._Phone = "";
            this._Email = "";
            this._CountryID = -1;
            this._ImagePath = "";

            _Mode = enMode.AddNew;

        }

        private clsPerson(int ID, string NationalNumber, string FirstName, string SecondName, string ThirdName, string LastName,
             DateTime DateOfBirth, byte gender, string Address,string Phone,string Email,int CountryID, string ImagePath)

        {
            this._PersonID = ID;
            this._NationalNUmber = NationalNumber;
            this._FirstName = FirstName;
            this._SecondName = SecondName;
            this._ThirdName = ThirdName;
            this._LastName = LastName;
            this._DateOfBirth = DateOfBirth;
            this._Gender = gender;
            this._Address = Address;
            this._Phone = Phone;
            this._Email = Email;
            this._CountryID = CountryID;
            this._ImagePath = ImagePath;
            _CountryInfo = clsCountry.Find(_CountryID);

            _Mode = enMode.Update;

        }
       
        public static bool GetPersonByID(int PersonID,ref string NationalNumber,ref string FirstName,ref string SecondName,ref string ThirdName,ref string LastName,
               ref DateTime DateOfBirth,ref byte Gender, ref string Address,ref string Phone, ref string Email,ref int CountryID,ref string ImagePath) {

  

            if (clsPersonDataAccess.GetPersonInfoByID(PersonID, ref NationalNumber, ref FirstName, ref SecondName, ref ThirdName
             ,ref LastName,ref DateOfBirth,ref Gender, ref Address, ref Phone, ref Email,ref CountryID,ref ImagePath))

            {
                return true;

            }
            else return false;


        }


        public static bool GetPersonByNationalNumber(ref int PersonID, string NationalNumber, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName,
       ref DateTime DateOfBirth, ref byte Gender, ref string Address, ref string Phone, ref string Email, ref int CountryID, ref string ImagePath)
        {


            if (clsPersonDataAccess.GetPersonInfoByNationalNumber(ref PersonID,NationalNumber,ref FirstName,ref SecondName,ref ThirdName
             ,ref LastName,ref DateOfBirth,ref Gender,ref Address,ref Phone,ref Email,ref CountryID,ref ImagePath))

            {
                return true;

            }
            else return false;


        }
     
            
            private bool _AddNewPerson()
        {
            //call DataAccess Layer 

            this._PersonID = clsPersonDataAccess.AddNewPerson(this._NationalNUmber,this._FirstName,this._SecondName,this._ThirdName,this._LastName,
               this._DateOfBirth,this._Gender,this._Address,this._Phone,this._Email,this._CountryID,this._ImagePath );

            return (this._PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            //call DataAccess Layer 

            return clsPersonDataAccess.UpdatePerson(this._PersonID,this._NationalNUmber, this._FirstName, this._SecondName, this._ThirdName, this._LastName,
               this._DateOfBirth, this._Gender, this._Address, this._Phone, this._Email, this._CountryID, this._ImagePath);

        }

        public static clsPerson GetPersonByID(int PersonID)
        {
            
            string NationalNumber="",FirstName = "",SecondName="",ThirdName="", LastName = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            byte Gender = 0;
            int CountryID = -1;

            if (clsPersonDataAccess.GetPersonInfoByID(PersonID, ref NationalNumber, ref FirstName, ref SecondName, ref ThirdName
             ,ref LastName, ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email, ref CountryID, ref ImagePath))

                return new clsPerson(PersonID, NationalNumber, FirstName, SecondName, ThirdName, LastName,
                    DateOfBirth, Gender, Address, Phone, Email, CountryID, ImagePath);

            else
                return null;

        }

        public static clsPerson GetPersonByNationalNumber(string NationalNumber)
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

        public static bool DeletePerson(int ID)
        {
            return clsPersonDataAccess.DeletePerson(ID);
        }

        public static bool isPersonExist(int PersonID)
        {
            return clsPersonDataAccess.IsPersonExist(PersonID);
        }

        public static bool isPersonExist(string NationalNumber)
        {
            return clsPersonDataAccess.IsPersonExist(NationalNumber);
        }



    }
}
