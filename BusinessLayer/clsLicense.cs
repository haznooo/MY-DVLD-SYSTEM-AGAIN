using Data_Access_Layer;
using System;
using System.Data;

namespace BusinessLayer
{
    public class clsLicense
    {
        enum enMode { add, update }
        enMode _Mode;
        public enum enIssueReason { FirstTime = 1, renew = 2, DamageReplacment = 3, LostReplacment = 4 }
        public int LicneseID { get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        public int DriverID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime issueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool isActive { get; set; }
        public int IssueReasonID { get; set; }
        public clsDriver DriverInfo;
        public clsLicenceClasses LicenceClassesInfo;
        public enIssueReason Issuereason;
        public bool IsDetained;
        public string IssueReasonText { get { return GetIssueReasonTxt(); } }


        public clsLicense()
        {
            LicneseID = -1; ApplicationID = -1; LicenseClassID = -1; CreatedByUserID = -1;
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
            this.LicenseClassID = LicenseClassID;
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
        static public clsLicense FindByApplicationID(int applicationID)
        {
            int LicneseID = -1, DriverId = -1, LicenseClass = -1, CreatedByUserID = -1, IssueReason = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = string.Empty;
            decimal paidfees = 0;
            bool isActive = false;

            if (clsLicenseDataAccess.GetLicenseInfobyApplicatoinID(ref LicneseID, applicationID, ref DriverId, ref LicenseClass, ref CreatedByUserID
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


            LicneseID = clsLicenseDataAccess.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClassID, this.CreatedByUserID
                 , this.issueDate, this.ExpirationDate, this.Notes, this.PaidFees, this.isActive, (int)this.Issuereason);

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
        public bool Save(out int newID)
        {
            newID = -1;
            switch (_Mode)
            {

                case enMode.update:
                    _UpdateLicense(this.LicneseID); return true;
                case enMode.add:
                    {
                        newID = _addNewLicense();
                        if (newID > 0)
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
        public static int GetActiveLicenseIDbyPersonID(int personID, int LicenseClassID)
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

        public clsLicense RenewLicense(string notes, int userID)
        {

            clsApplication newApplication = new clsApplication();

            newApplication.applicantID = this.DriverInfo.PersonID;
            newApplication.applicationDate = DateTime.Now;
            newApplication.applicationTypeID = (int)clsApplication.enApplicationType.RenewDrivingLicens;
            newApplication.paidFee = clsApplicationTypes.Find((int)clsApplication.enApplicationType.RenewDrivingLicens).ApplicationTypeFee;
            newApplication.lastStatusDate = DateTime.Now;
            newApplication.createdByUserID = userID;

            if (!newApplication.SaveApplication(out int newApplicationID))
            {
                return null;
            }
            clsLicense newLicense = new clsLicense();



            int DefaultValidityLength = this.LicenceClassesInfo.validityYears;
            decimal LicenseFees = this.LicenceClassesInfo.Fee;
            decimal ApplicationFees = this.PaidFees;
            decimal TotalFees = ApplicationFees + LicenseFees;

            newLicense.ExpirationDate = DateTime.Now.AddYears(DefaultValidityLength);
            newLicense.IssueReasonID = (int)clsApplication.enApplicationType.RenewDrivingLicens;
            newLicense.DriverID = this.DriverID;
            newLicense.Notes = notes;
            newLicense.PaidFees = newApplication.paidFee;
            newLicense.isActive = true;
            newLicense.ApplicationID = newApplicationID;
            newLicense.CreatedByUserID = userID;
            newLicense.issueDate = DateTime.Now;
            newLicense.LicenseClassID = this.LicenseClassID;


            if (!newLicense.Save(out int newLicenseID))
            { return null; }

            DeActivate(this.LicneseID);

            return newLicense;



        }

        public clsLicense Replace(int userID, byte issueReasonID)
        {

            clsApplication newApplication = new clsApplication();

            newApplication.applicantID = this.DriverInfo.PersonID;
            newApplication.applicationDate = DateTime.Now;
            newApplication.applicationTypeID = issueReasonID;
            newApplication.paidFee = clsApplicationTypes.Find((int)clsApplication.enApplicationType.RenewDrivingLicens).ApplicationTypeFee;
            newApplication.lastStatusDate = DateTime.Now;
            newApplication.createdByUserID = userID;

            if (!newApplication.SaveApplication(out int newApplicationID))
            {
                return null;
            }
            clsLicense newLicense = new clsLicense();



            int DefaultValidityLength = this.LicenceClassesInfo.validityYears;
            decimal LicenseFees = this.LicenceClassesInfo.Fee;
            decimal ApplicationFees = this.PaidFees;
            decimal TotalFees = ApplicationFees + LicenseFees;

            newLicense.ExpirationDate = DateTime.Now.AddYears(DefaultValidityLength);
            newLicense.IssueReasonID = (int)clsApplication.enApplicationType.RenewDrivingLicens;
            newLicense.DriverID = this.DriverID;
            newLicense.Notes = this.Notes;
            newLicense.PaidFees = newApplication.paidFee;
            newLicense.isActive = true;
            newLicense.ApplicationID = newApplicationID;
            newLicense.CreatedByUserID = userID;
            newLicense.issueDate = DateTime.Now;
            newLicense.LicenseClassID = this.LicenseClassID;


            if (!newLicense.Save(out int newLicenseID))
            { return null; }

            DeActivate(this.LicneseID);

            return newLicense;



        }


    }
}
