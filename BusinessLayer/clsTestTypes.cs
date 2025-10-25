using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsTestTypes
    {


        enum enMode { Add, Edit }

        enMode CurrentMode;

        public int TestTypeID;
        public string TestTypeTitle;
        string TestTypeDescription;
        public decimal TestTypeFee;



        public clsTestTypes(int TestTypeID, string newTitle,string newDescription,decimal newFees)
        {

            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = newTitle;
            this.TestTypeDescription = newDescription;
            this.TestTypeFee = newFees;

            CurrentMode = enMode.Edit;

        }

        static public DataTable GetAllTestTypes()
        {

            return clsTestTypesDataAccess.GetTestTypes();

        }

        static public bool UpdateApplicationType(int ApplicationTypeID, string newTitle, decimal newFees)
        {

            return clsApplicationTypesDataAccess.UpdateApplicationType(ApplicationTypeID, newTitle, newFees);

        }

        static public clsApplicationTypes GetApplicationTypeByID(int ApplicationTypeID)
        {
            string ApplicationTypeTitle = "";
            decimal ApplicationTypeFee = 0;

            if (clsApplicationTypesDataAccess.GetApplicationTypeInfoByID(ApplicationTypeID, ref ApplicationTypeTitle, ref ApplicationTypeFee))
            {

                return new clsApplicationTypes(ApplicationTypeID, ApplicationTypeTitle, ApplicationTypeFee);

            }
            else
            {
                return null;

            }
        }


        public bool SaveApplicationType()
        {

            return clsApplicationTypesDataAccess.UpdateApplicationType(this.TestTypeID, this.TestTypeTitle, this.TestTypeFee);

        }


    }
}
