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

        enum enApplicationType : byte
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
        enum enMode { AddNew = 0, Update = 1 }

        enMode CurrentMode;


        public int applicationID { get; set; }
        public int applicantID { get; set; }
        public string applicantName
        {

            get { return clsPerson.GetPersonByID(applicantID)._FullName; }
            set { }

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

        public clsApplicationTypes ApplicationType { get; set; }
        public clsUser CreatedByUser
        {
            get
            {
                return clsUser.GetUserByID(createdByUserID);
            }
            set { }
        }

        public clsPerson ApplicantInfo { get;set; }
        
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

            CurrentMode = enMode.AddNew;
        }

        public clsApplication(int applicationID, int applicantID, DateTime applicationDate, byte applicationType,
            byte applicationStatus, DateTime lastStatusDate, decimal paidFee, int createdByUserID)
        {

            this.applicationID = applicationID;
            this.applicantID = applicantID;
            this.applicantName = clsPerson.GetPersonByID(applicantID)._FullName;
            this.applicationDate = applicationDate;
            this.ApplicationType = clsApplicationTypes.GetApplicationTypeByID(applicationType);
            this.applicationTypeID = applicationType;
            this.applicationStatus = (enApplicationStatus)applicationStatus;
            this.lastStatusDate = lastStatusDate;
            this.paidFee = paidFee;
            this.createdByUserID = createdByUserID;
            this.CreatedByUser = clsUser.GetUserByID(createdByUserID);
            this.ApplicantInfo = clsPerson.GetPersonByID(applicantID);
            CurrentMode = enMode.Update;
        }

        private bool _addNewApplication()
        {
            int newApplicationID = clsApplicationDataAccess.AddNewApplication(applicantID, applicationDate,
                applicationTypeID, (byte)applicationStatus, lastStatusDate, paidFee, createdByUserID);
            if (newApplicationID > 0)
            {

                applicationID = newApplicationID;
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool _UpdateApplication()
        {

            return clsApplicationDataAccess.UpdateApplicationInfoByID(applicationID, applicantID, applicationDate,
                  applicationTypeID, (byte)applicationStatus, lastStatusDate, paidFee, createdByUserID);
        }

        public bool Cancel()
        {

            return clsApplicationDataAccess.UpdateApplicationStatusByID(applicationID, (byte)enApplicationStatus.canceled);

        }

        public bool SetComplete()
        {
            return clsApplicationDataAccess.UpdateApplicationStatusByID(applicationID, (byte)enApplicationStatus.complete);

        }

        public static bool GetApplicationInfoByID(int ApplicationID, ref int ApplicantID, ref DateTime ApplicationDate,
           ref byte ApplicationType, ref byte ApplicationStatus, ref DateTime LastStatusDate,
           ref decimal paidFee, ref int CreatedByUserID)
        {

            if (clsApplicationDataAccess.GetApplicationInfoByID(ApplicationID, ref ApplicantID, ref ApplicationDate,
                  ref ApplicationType, ref ApplicationStatus, ref LastStatusDate, ref paidFee, ref CreatedByUserID))

            {
                return true;
            }

            else
            {
                return false;


            }

        }


        public bool SaveApplication()
        {
            if (CurrentMode == enMode.AddNew)
            {


                if (_addNewApplication())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (CurrentMode == enMode.Update)
            {

                if (_UpdateApplication())
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

            return true;
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

        public static bool DoesPersonHaveActiveApplication(int personID,byte ApplicationType)
        {
            return clsApplicationDataAccess.DoesPersonHaveActiveApplication(personID,ApplicationType);
        }

        public static int GetActiveApplicationID(int personID, byte ApplicationType)
        {
            return clsApplicationDataAccess.GetActiveApplicationID(personID, ApplicationType);
        }


    }
}