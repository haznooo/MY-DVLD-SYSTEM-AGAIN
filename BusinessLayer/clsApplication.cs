using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer;
using DataAccessLayer;

namespace BusinessLayer
{
    public class clsApplication
    {

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
        public enum enApplicationStatus : byte
        {
            New = 1,
            canceled = 2,
            complete = 3,

        }
       protected enum enMode { AddNew = 0, Update = 1 }

       protected enMode CurrentMode;


        public int applicationID { get; set; }
        public int applicantID { get; set; }
        public string applicantFullName
        {

            get { return clsPerson.GetPersonInfoByID(applicantID).FullName; }
           private set { }

        }
        public DateTime applicationDate { get; set; }
        public byte applicationTypeID { get; set; }
        public enApplicationStatus applicationStatus { get; set; }
        public string ApplicationStatusText
        {
            get
            {
                switch (applicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.canceled:
                        return "Canceled";
                    case enApplicationStatus.complete:
                        return "Complete";
                    default:
                        return "Unknown";
                }
            }
        }
        public DateTime lastStatusDate { get; set; }
        public decimal paidFee { get; set; }
        public int createdByUserID { get; set; }
        public clsApplicationTypes ApplicationTypeInfo { get; set; }
        public clsUser CreatedByUser
        {
            get
            {
                return clsUser.GetUserByID(createdByUserID);
            }
            set { }
        }

        public clsPerson ApplicantInfo { get; }
        
        public clsApplication()
        {

            applicationID = -1;
            applicantID = -1;
            applicationDate = DateTime.MinValue;
            applicationTypeID = 0;
            applicationStatus = enApplicationStatus.New;
            lastStatusDate = DateTime.MinValue;
            paidFee = 0;
            createdByUserID = -1;
            ApplicationTypeInfo = null;

            CurrentMode = enMode.AddNew;
        }

        private clsApplication(int applicationID, int applicantID, DateTime applicationDate, byte applicationType,
            byte applicationStatus, DateTime lastStatusDate, decimal paidFee, int createdByUserID)
        {

            this.applicationID = applicationID;
            this.applicantID = applicantID;
            this.applicationDate = applicationDate;
            this.applicationTypeID = applicationType;
            this.applicationStatus = (enApplicationStatus)applicationStatus;
            this.lastStatusDate = lastStatusDate;
            this.paidFee = paidFee;
            this.createdByUserID = createdByUserID;

            this.CreatedByUser = clsUser.GetUserByID(createdByUserID);
            this.ApplicantInfo = clsPerson.GetPersonInfoByID(applicantID);
            this.ApplicationTypeInfo = clsApplicationTypes.Find(applicationType);

            if (this.ApplicantInfo == null || CreatedByUser == null || ApplicationTypeInfo == null)
            {
                throw new Exception("failed to load data for clsApplication initialization");
               
            }

          this.applicantFullName = ApplicantInfo.FullName; 
       
            CurrentMode = enMode.Update;
        }

        private int _addNewApplication()
        {
            this.applicationID = clsApplicationDataAccess.AddNewApplication(applicantID, applicationDate,
                applicationTypeID, (byte)applicationStatus, lastStatusDate, paidFee, createdByUserID);
            if (this.applicationID > 0)
            {

                return this.applicationID;
            }
            else
            {
           
                return -1;
            }
        }

        private bool _UpdateApplication()
        {

            return clsApplicationDataAccess.UpdateApplicationInfoByID(applicationID, applicantID, applicationDate,
                  applicationTypeID, (byte)applicationStatus, lastStatusDate, paidFee, createdByUserID);
        }

        public bool Cancel()
        {

            return clsApplicationDataAccess.UpdateApplicationStatus(applicationID, (byte)enApplicationStatus.canceled);

        }

        public bool SetComplete()
        {
            return clsApplicationDataAccess.UpdateApplicationStatus(applicationID, (byte)enApplicationStatus.complete);

        }
        public static clsApplication GetBaseApplicationInfoByID(int ApplicationID)
        {
            int ApplicantID = -1;
            DateTime ApplicationDate = DateTime.MinValue;
            byte ApplicationType = 0;
            byte ApplicationStatus = 0;
            DateTime LastStatusDate = DateTime.MinValue;
            decimal paidFee = 0m;
            int CreatedByUserID = -1;

            if (clsApplicationDataAccess.GetApplicationInfoByID(ApplicationID, ref ApplicantID, ref ApplicationDate,
                  ref ApplicationType, ref ApplicationStatus, ref LastStatusDate, ref paidFee, ref CreatedByUserID))
            {
                return new clsApplication(ApplicationID, ApplicantID, ApplicationDate, ApplicationType,
                    ApplicationStatus, LastStatusDate, paidFee, CreatedByUserID);

            }
            else
            {
                return null;
            }
        }
     
        protected bool SaveApplication(out int ApplicationID )
        {
            if (CurrentMode == enMode.AddNew)
            {


                if (_addNewApplication() > 0)
                {
                    ApplicationID = this.applicationID;
                    return true;
                }
                else
                {
                    ApplicationID = -1;
                    return false;
                }
            }
            else
            {

                if (_UpdateApplication())
                {
                    ApplicationID = this.applicationID;
                    return true;
                }
                else
                {
                    ApplicationID = this.applicationID;
                    return false;
               
                }
            }

        }


        public static DataTable GetAllApplications()
        {
            return clsApplicationDataAccess.GetAllApplications();
        }

        public static bool DeleteApplicationByID(int applicationID)
        {
            return clsApplicationDataAccess.DeleteApplicationInfoByID(applicationID);
        }

        public static bool isApplicationExists(int applicationID)
        {
            return clsApplicationDataAccess.isApplicationExist(applicationID);

        }

        public bool DoesPersonHaveActiveApplication(byte ApplicationType)
        {
            return clsApplicationDataAccess.DoesPersonHaveActiveApplication(this.applicantID,ApplicationType);
        }

        public static int GetActiveApplicationID(int personID, byte ApplicationType)
        {
            return clsApplicationDataAccess.GetActiveApplicationID(personID, ApplicationType);
        }

        public static int GetActiveApplicationIDForLicensClass(int PersonID,byte ApplicationType,int LicenseClassID) { 
        return clsApplicationDataAccess.GetActiveApplicationIDForLicenseClass(PersonID, ApplicationType, LicenseClassID);
        }

    }
}