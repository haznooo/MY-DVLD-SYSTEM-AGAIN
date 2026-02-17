using Data_Access_Layer;
using System.Data;

namespace BusinessLayer
{
    public class clsApplicationTypes
    {

        enum enMode { Add, Edit }

        enMode CurrentMode;

        public int ApplicationTypeID;
        public string ApplicationTypeTitle;
        public decimal ApplicationTypeFee;

        public enum enApplicationType : byte
        {
            NewDrivingLicens = 1,
            RenewDrivingLicens = 2,
            ReplaceLostLicens = 3,
            ReplaceDamagedLicens = 4,
            ReleaseDetainedLicens = 5,
            NewInternationalLicens = 6,
            RetakeDrivingTest = 7

        }

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
