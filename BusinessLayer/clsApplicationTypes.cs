using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsApplicationTypes
    {

        enum enMode { Add, Edit }

        enMode CurrentMode;

        public int ApplicationTypeID;
        public string ApplicationTypeTitle;
        public decimal ApplicationTypeFee;



        public clsApplicationTypes(int ApplicationTypeID, string newTitle, decimal newFees)
        {

            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = newTitle;
            this.ApplicationTypeFee = newFees;

            CurrentMode = enMode.Edit;

        }

        static public DataTable GetAllApplicationTypes()
        {

            return clsApplicationTypesDataAccess.GetApplicationTypes();

        }

        static public bool UpdateApplicationType(int ApplicationTypeID, string newTitle, decimal newFees)
        {

            return clsApplicationTypesDataAccess.UpdateApplicationType(ApplicationTypeID, newTitle, newFees);

        }

        static public clsApplicationTypes Find(int ApplicationTypeID)
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

            return clsApplicationTypesDataAccess.UpdateApplicationType(this.ApplicationTypeID, this.ApplicationTypeTitle, this.ApplicationTypeFee);

        }
    }
}
