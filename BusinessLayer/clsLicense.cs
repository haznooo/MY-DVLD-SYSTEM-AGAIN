using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsLicense
    {
        enum enMode { add, update }
        enMode _Mode;
        public enum enIssueReason { FirstTime = 1, renew = 2, DamageReplacment = 3, LostReplacment = 4 }
        public int LicneseID { get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClasID { get; set; }
        public int DriverID { get; set; }
        int CreatedByUserID { get; set; }
        DateTime issueDate { get; set; }
        DateTime ExpirationDate { get; set; }
        string Notes { get; set; }
        decimal PaidFees { get; set; }
        bool isActive { get; set; }
        int IssueReasonID { get; set; }
        public clsDriver DriverInfo;
        public clsLicenceClasses LicenceClassesInfo;
        public enIssueReason Issuereason;
        public bool IsDetained;
        public string IssueReasonText { get { return GetIssueReasonTxt(); } }


        public clsLicense()
        {
            LicneseID = -1; ApplicationID = -1; LicenseClasID = -1; CreatedByUserID = -1;
            IssueReasonID = -1; issueDate = DateTime.Now; ExpirationDate = DateTime.Now;
            Notes = string.Empty; isActive = false; PaidFees = 0;

            _Mode = enMode.add;
            ;
        }
        public clsLicense(int LicneseID, int applicationID, int DriverId, int LicenseClassID,
          int CreatedByUserID, DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal paidfees,
          bool isActive, enIssueReason IssueReason)
        {
            this.LicneseID = LicneseID;
            this.ApplicationID = applicationID;
            this.DriverID = DriverId;
            this.LicenseClasID = LicenseClassID;
            this.CreatedByUserID = CreatedByUserID;
            this.issueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.isActive = isActive;
            this.PaidFees = paidfees;
            this.Issuereason = IssueReason;
            this.DriverInfo = clsDriver.GetDriverInfoByID(DriverId);
            this.LicenceClassesInfo = clsLicenceClasses.Find(LicenseClassID);
            _Mode = enMode.update;
        }

        static public clsLicense FindbyID(int LicneseID)
        {
            int applicationID = -1, DriverId = -1, LicenseClass = -1, CreatedByUserID = -1, IssueReason = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = string.Empty;
            decimal paidfees = 0;
            bool isActive = false;

            if (clsLicenseDataAccess.GetLicenseInfobyID(LicneseID, ref applicationID, ref DriverId, ref LicenseClass, ref CreatedByUserID
                , ref IssueDate, ref ExpirationDate, ref Notes, ref paidfees, ref isActive, ref IssueReason))
            {

                return new clsLicense(LicneseID, applicationID, DriverId,
               LicenseClass, CreatedByUserID, IssueDate, ExpirationDate, Notes, paidfees, isActive, (enIssueReason)IssueReason);

            }
            return null;
        }

        static public DataTable GetAllLicenses()
        {
            return clsLicenseDataAccess.GetAllLicenses();
        }
        static public DataTable GetAllDriverLicenses(int DriverID)
        {
            return clsLicenseDataAccess.GetDriverLicenses(DriverID);
        }

        private int _addNewLicense()
        {
            int LicneseID = -1, applicationID = -1, DriverId = -1, LicenseClass = -1, CreatedByUserID = -1, IssueReason = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = string.Empty;
            decimal paidfees = 0;
            bool isActive = false;

            LicneseID = clsLicenseDataAccess.AddNewLicense(ref applicationID, ref DriverId, ref LicenseClass, ref CreatedByUserID
                 , ref IssueDate, ref ExpirationDate, ref Notes, ref paidfees, ref isActive, ref IssueReason);

            return LicneseID;
        }
        private bool _UpdateLicense(int LicneseID)
        {
            int applicationID = -1, DriverId = -1, LicenseClass = -1, CreatedByUserID = -1, IssueReason = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = string.Empty;
            decimal paidfees = 0;
            bool isActive = false;

            if (clsLicenseDataAccess.updateLicense(LicneseID, applicationID, DriverId, LicenseClass, CreatedByUserID
                  , IssueDate, ExpirationDate, Notes, paidfees, isActive, IssueReason))
            {
                return true;
            }
            return false;
        }
        public bool Save()
        {

            switch (_Mode)
            {

                case enMode.update:
                    _UpdateLicense(this.LicneseID); return true;
                case enMode.add:
                    {
                        if (_addNewLicense() > 0)
                            return true;
                        else return false;

                    }
                default: return false;


            }

        }

        public static bool isLicenseExistByPersonID(int personID, int LicenseClassID) 
        {
            return GetActiveLicenseIDbyPersonID(personID, LicenseClassID) > 0;
        }
        public static int GetActiveLicenseIDbyPersonID(int personID,int LicenseClassID)
        {
            return clsLicenseDataAccess.GetActiveLicenseIDByPersonID(personID, LicenseClassID);
        }

        public bool isLiceneseEspired()
        { return (this.ExpirationDate < DateTime.Now); }
        public string GetIssueReasonTxt()
        {
            switch (Issuereason)
            {
                case enIssueReason.FirstTime:
                    return "frist time";
                case enIssueReason.renew:
                    return "renew";
                case enIssueReason.LostReplacment:
                    return "lost Replacement";
                case enIssueReason.DamageReplacment:
                    return "damage replacement";
                default: return "errorL issue reason ";


            }

        }
        public bool DeActivate(int LicneseID)
        {
            return clsLicenseDataAccess.DeActiveLicense(LicneseID);
        }
    }
}
