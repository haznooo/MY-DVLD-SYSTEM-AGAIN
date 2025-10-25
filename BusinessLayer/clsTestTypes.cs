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
        public string TestTypeDescription;
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

        static public bool UpdateApplicationType(int ApplicationTypeID,string newDescription,string newTitle, decimal newFees)
        {

            return clsTestTypesDataAccess.UpdateTestType(ApplicationTypeID, newTitle,newDescription,newFees);

        }

        static public clsTestTypes GetTestTypeByID(int TestTypeID)
        {
            string TestTypeTitle = "",TestTypeDescription = "";
            decimal TestTypeFee = 0;

            if (clsTestTypesDataAccess.GetTestTypeInfoByID(TestTypeID, ref TestTypeTitle,ref TestTypeDescription, ref TestTypeFee))
            {

                return new clsTestTypes(TestTypeID, TestTypeTitle, TestTypeDescription,TestTypeFee);

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
