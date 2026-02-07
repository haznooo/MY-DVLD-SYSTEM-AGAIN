using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsUser
    {

        public int UserID { get; private set; }
        public int PersonID { get;set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool isActive { get; set; }
        public clsPerson PersonInfo;


        public enum enMode { AddNew = 0, Update = 1 };
        public enMode _Mode = enMode.AddNew;


        public clsUser()

        {
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = "";
            this.Password = "";
            this.isActive = false;
            this.PersonInfo = null;
    
            _Mode = enMode.AddNew;

        }
        private clsUser(int UserID,int PersonID,string Password,string userName,bool isActive)

        {
            this.PersonID = PersonID;
            this.UserID = UserID; 

            this.UserName = userName;
            this.Password = Password;
            this.isActive = isActive;
            PersonInfo = clsPerson.GetPersonInfoByID(PersonID);
   
            _Mode = enMode.Update;

        }

   
        private bool _AddNewUser()
        {
            //call DataAccess Layer 

            this.UserID = clsUsersDataAccess.AddNewUser(this.UserName, this.PersonID, this.Password, this.isActive);
          

            return (this.UserID != -1);
        }
        private bool _UpdateUser()
        {
            //call DataAccess Layer 

            return clsUsersDataAccess.UpdateUser(this.UserID,this.UserName,this.PersonID,this.Password,this.isActive);

        }


        public static DataTable GetAllUsers()
        {

            return clsUsersDataAccess.GetAllUsers();

        }
        public static clsUser GetUserByID(int UserID)
        {

            string Password = "", UserName = "";
            bool isActive = false;
            int PersonID = -1;
            

            if (clsUsersDataAccess.GetUserInfoByUserID(UserID,ref UserName,ref PersonID,ref Password,ref isActive))

                return new clsUser(UserID,PersonID,Password,UserName,isActive);

            else
                return null;

        }
        public static clsUser GetUserByPersonID(int PersonID)
        {
            string Password = "", UserName = "";
            bool isActive = false;
            int UserID = -1;
            if (clsUsersDataAccess.GetUserInfoByPersonID(ref UserID, ref UserName,PersonID, ref Password, ref isActive))

                return new clsUser(UserID, PersonID, Password, UserName, isActive);

            else
                return null;

        }
        public static clsUser GetUserByUserNameAndPassword(string UserName,string password)
        {

     
            bool isActive = false;
            int PersonID = -1,UserID = -1;


            if (clsUsersDataAccess.GetUserInfoByUsernameAndPassword(ref UserID,UserName, ref PersonID, password, ref isActive))

                return new clsUser(UserID, PersonID, password, UserName, isActive);

            else
                return null;

        }


        public bool Save()
        {

            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {

                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateUser();

            }

            return false;
        }

        public static bool DeleteUser(int UserID)
        {
            return clsUsersDataAccess.DeleteUser(UserID);
        }


        public static bool isUserExist(int UserID)
        {
            return clsUsersDataAccess.IsUserExist(UserID);
        }
        public static bool isUserExist(string UserName)
        {
            return clsUsersDataAccess.IsUserExist(UserName);
        }

        public static bool isPersonLinkedToUser(int PersonID)
        {
            return clsUsersDataAccess.IsPersonLinkedToUser(PersonID);
        }
        public bool ChangePassword(string newPassword)
        {
            //password property is read only

            if (clsUsersDataAccess.ChangeUserPassword(this.UserID, newPassword))
            {
           
                return true;
            }
            else
            {
                return false;
            }
        }


    }



}

