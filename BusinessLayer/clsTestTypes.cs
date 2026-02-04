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

        public enum enMode { Add, Edit }

         enMode CurrentMode = enMode.Edit;
        public enum enTestType { vissionTest = 1, writtenTest = 2, streetTest = 3 }
        
        public clsTestTypes.enTestType TestType { get; set; }
        public string TestTypeTitle;
        public string TestTypeDescription;
        public decimal TestTypeFee;



        public clsTestTypes(clsTestTypes.enTestType TestTypeID, string newTitle,string newDescription,decimal newFees)
        {

            this.TestType = TestTypeID;
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

        static public clsTestTypes GetTestTypeByID(clsTestTypes.enTestType TestTypeID)
        {
            string TestTypeTitle = "",TestTypeDescription = "";
            decimal TestTypeFee = 0;

            if (clsTestTypesDataAccess.GetTestTypeInfoByID((int)TestTypeID, ref TestTypeTitle,ref TestTypeDescription, ref TestTypeFee))
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

            return clsApplicationTypesDataAccess.UpdateApplicationType((int)this.TestType, this.TestTypeTitle, this.TestTypeFee);

        }


    }
}
