using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using System.ComponentModel;

namespace BusinessLayer
{
    public class clsLocalDrivingLicensApplication : clsApplication
    {
        enMode _mode;
        enApplicationStatus applicationStatus;
        public int LocalDrivingLicensApplicationID { get; set; }
        public int LicensClassId { get; set; }
        public clsLicenceClasses LicensClassInfo = null;
        public string PersonFullName
        {

            get { return base.ApplicantInfo.FullName; }
        }

        public clsLocalDrivingLicensApplication()
        {

            LocalDrivingLicensApplicationID = -1;
            LicensClassId = -1;

            _mode = enMode.AddNew;
        }

        clsLocalDrivingLicensApplication(int LocalDrivingLicensApplicationID, int LicensClsasID, int applicationID, int applicantID,
           byte applicationTypeID, DateTime applicationDate, decimal paidFee, int createdByUserID, enApplicationStatus applicationStatus,
           DateTime lastStatusDate)
        {

            this.LocalDrivingLicensApplicationID = LocalDrivingLicensApplicationID;
            this.applicantID = applicantID;
            this.applicationDate = applicationDate;
            this.applicationTypeID = applicationTypeID;
            this.LicensClassId = LicensClsasID;
            this.applicationID = applicationID;
            this.applicationStatus = applicationStatus;
            this.lastStatusDate = lastStatusDate;
            this.paidFee = paidFee;
            this.createdByUserID = createdByUserID;  
             this.LicensClassInfo = clsLicenceClasses.Find(LicensClsasID);
            base.ApplicationTypeInfo = clsApplicationTypes.Find(applicationTypeID);
            base.ApplicantInfo = clsPerson.GetPersonInfoByID(applicantID);

            _mode = enMode.Update;
        }


        private bool _addNewLocalDrivingLicensApplication()
        {

            this.LocalDrivingLicensApplicationID = clsLocalDrivingLicensApplicationDataAccess.AddLocalDrivingLicensApplication(this.applicationID, this.LicensClassId);

            return (this.LocalDrivingLicensApplicationID != -1);

        }

        private bool _updateLocalDrivingLicensApplication()
        {
            return clsLocalDrivingLicensApplicationDataAccess.UpdateLocalDrivingLicensApplicationByID(this.LocalDrivingLicensApplicationID,
                this.applicationID, this.LicensClassId);
        }

        public bool save()
        {

            base.CurrentMode = this._mode;
            if (!base.SaveApplication(out int ApplicationID)) { return false; }

            this.applicationID = ApplicationID;
            switch (this._mode)
            {

                case enMode.Update:
                    return _updateLocalDrivingLicensApplication();

                case enMode.AddNew:
                    return _addNewLocalDrivingLicensApplication();

                default: return false;

            }


        }

        public static bool isCompleted(int localDrivingLicneseApplication)
        {
            enApplicationStatus ApplicationStatus;
            ApplicationStatus = clsLocalDrivingLicensApplication.FindLocalDrivingLicensApplicationByID(localDrivingLicneseApplication).applicationStatus;

            if (ApplicationStatus == enApplicationStatus.complete) return true;
            else return false;
        }

        public static clsLocalDrivingLicensApplication FindLocalDrivingLicensApplicationByID(int LocalDrivingapplicationID)
        {
            bool isFound = false;

            int applicationID = -1, licensClassID = -1;

            isFound = clsLocalDrivingLicensApplicationDataAccess.GetLocalDrivingLicensApplicationInfoByID(LocalDrivingapplicationID, ref applicationID, ref licensClassID);


            if (!isFound) { return null; }

            clsApplication application = clsApplication.GetBaseApplicationInfoByID(applicationID);

            if (application == null) { return null; }
            ;

            return new clsLocalDrivingLicensApplication(LocalDrivingapplicationID, licensClassID, application.applicationID,
                application.applicantID, application.applicationTypeID, application.applicationDate, application.paidFee,
                application.createdByUserID, application.applicationStatus, application.lastStatusDate);


        }

        public static clsLocalDrivingLicensApplication FindLocalDrivingLicensApplicationByApplicationID(int applicationID)
        {

            bool isFound = false;
            int localDrivingLicensApplicationID = -1, licensClassID = -1;

            isFound = clsLocalDrivingLicensApplicationDataAccess.GetLocalDrivingLicensApplicationInfoByApplicationID(applicationID, ref localDrivingLicensApplicationID, ref licensClassID);


            if (!isFound) { return null; }

            clsApplication application = clsApplication.GetBaseApplicationInfoByID(applicationID);

            if (application == null) { return null; }
            return new clsLocalDrivingLicensApplication(localDrivingLicensApplicationID, licensClassID, application.applicationID,
                application.applicantID, application.applicationTypeID, application.applicationDate, application.paidFee,
                application.createdByUserID, application.applicationStatus, application.lastStatusDate);


        }

        public bool DeleteLocalDrivingLicensApplicationByID()
        {
            return clsLocalDrivingLicensApplicationDataAccess.DeleteLocalDrivingLicensApplication(this.LocalDrivingLicensApplicationID)
                && clsApplication.DeleteApplicationByID(this.applicationID);


        }
        public static DataTable GetAllLocalDrivingLicensApplications()
        {
            return clsLocalDrivingLicensApplicationDataAccess.GetAllLocalDrivingLicensApplications();
        }

        public bool DoesAttendTestType(int testTypeID)
        {
            return clsLocalDrivingLicensApplicationDataAccess.DoesAttendTestType(this.LocalDrivingLicensApplicationID, testTypeID);
        }

        public bool DoesPassTestType(int testTypeID)
        {
            return clsLocalDrivingLicensApplicationDataAccess.DoesPassTestType(this.LocalDrivingLicensApplicationID, testTypeID);
        }

        public static bool DoesPassAllTests(int localDrivingLicneseApplicationID)
        {
            return clsTest.GetPassedTestsCount(localDrivingLicneseApplicationID) == 3;
    
        }
        public int TotalTrialsForTestType(int testTypeID)
        {
            return clsLocalDrivingLicensApplicationDataAccess.TotalTrailsPerTestType(this.LocalDrivingLicensApplicationID, testTypeID);
        }

        public bool isthereActiveScheduledTest(int testTYpe)
        {
            return clsLocalDrivingLicensApplicationDataAccess.isthereActiveScheduledTest(this.LocalDrivingLicensApplicationID, testTYpe);
        }

        public int IssueLicenseFirstTime(string notes, int CreatedByUserID)
        {
            int driverID = -1;
            clsDriver driver = clsDriver.GetDriverInfoByPersonID(this.applicantID);

            if (driver == null)
            {
                driver = new clsDriver();
                driver.PersonID = this.applicantID;
                driver.CreatedByUserID = CreatedByUserID;
                driver.CreatedDate = DateTime.Now;

                if (driver.Save())
                {
                }
                else { return -1; }

            }

            driverID = driver.DriverID;

            clsLicense license = new clsLicense();
            license.ApplicationID = this.applicationID;
            license.DriverID = driverID;
            license.LicenseClasID = this.LicensClassId;
            license.Issuereason = clsLicense.enIssueReason.FirstTime;
            license.PaidFees = this.LicensClassInfo.Fee;
            license.isActive = true;
            license.issueDate = DateTime.Now;
            license.ExpirationDate = DateTime.Now.AddYears(this.LicensClassInfo.validityYears);
            license.Notes = notes;
            license.CreatedByUserID = CreatedByUserID;

            int newLicenseID = -1;
            if (license.Save(out newLicenseID))
            {
                this.SetComplete();

            }
            else
            {
                return -1;
            }
     
            return newLicenseID;

        }


    }
}
