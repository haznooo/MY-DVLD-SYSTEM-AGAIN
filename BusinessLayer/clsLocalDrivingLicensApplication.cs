using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsLocalDrivingLicensApplication : clsApplication
    {
        enMode _mode;
        enApplicationStatus applicationStatus;
        public int ApplicationID { get; set; }
        public int LocalDrivingLicensApplicationID { get; set; }
        public int LicensClassId { get; set; }
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
           DateTime lastStatusDate, int licensClassID)
        {

            this.LocalDrivingLicensApplicationID = LocalDrivingLicensApplicationID;
            this.applicantID = applicantID;
            this.applicationDate = applicationDate;
            this.applicationTypeID = applicationTypeID;
            this.LicensClassId = LicensClsasID;
            this.ApplicationID = applicationID;
            this.applicationStatus = applicationStatus;
            this.lastStatusDate = lastStatusDate;
            this.paidFee = paidFee;
            this.createdByUserID = createdByUserID;
            this.LicensClassId = licensClassID;
            // this.LicensClassInfo = ;

            _mode = enMode.Update;
        }


        private bool _addNewLocalDrivingLicensApplication()
        {

            this.LocalDrivingLicensApplicationID = clsLocalDrivingLicensApplicationDataAccess.AddLocalDrivingLicensApplication(this.ApplicationID, this.LicensClassId);

            return (this.LocalDrivingLicensApplicationID != -1);

        }

        private bool _updateLocalDrivingLicensApplication()
        {
            return clsLocalDrivingLicensApplicationDataAccess.UpdateLocalDrivingLicensApplicationByID(this.LocalDrivingLicensApplicationID,
                this.ApplicationID, this.LicensClassId);
        }

        public bool save()
        {

            base.CurrentMode = this._mode;
            if (!base.SaveApplication()) { return false; }

            switch (this._mode)
            {

                case enMode.Update:
                    return _updateLocalDrivingLicensApplication();

                case enMode.AddNew:
                    return _addNewLocalDrivingLicensApplication();

                default: return false;

            }


        }


        public static clsLocalDrivingLicensApplication FindLocalDrivingLicensApplicationByID(int LocalDrivingapplicationID)
        {
            bool isFound = false;

            int applicationID = -1, licensClassID = -1;

            isFound = clsLocalDrivingLicensApplicationDataAccess.GetLocalDrivingLicensApplicationInfoByID(LocalDrivingapplicationID, ref applicationID, ref licensClassID);


            if (!isFound) { return null; }

            clsApplication application = clsApplication.GetApplicationInfoByID(applicationID);

            if (application == null) { return null; }
            ;

            return new clsLocalDrivingLicensApplication(LocalDrivingapplicationID, licensClassID, application.applicationID,
                application.applicantID, application.applicationTypeID, application.applicationDate, application.paidFee,
                application.createdByUserID, application.applicationStatus, application.lastStatusDate, licensClassID);


        }

        public static clsLocalDrivingLicensApplication FindLocalDrivingLicensApplicationByApplicationID(int applicationID)
        {

            bool isFound = false;
            int localDrivingLicensApplicationID = -1, licensClassID = -1;

            isFound = clsLocalDrivingLicensApplicationDataAccess.GetLocalDrivingLicensApplicationInfoByApplicationID(applicationID, ref localDrivingLicensApplicationID, ref licensClassID);


            if (!isFound) { return null; }

            clsApplication application = clsApplication.GetApplicationInfoByID(applicationID);

            if (application == null) { return null; }
            ;

            return new clsLocalDrivingLicensApplication(localDrivingLicensApplicationID, licensClassID, application.applicationID,
                application.applicantID, application.applicationTypeID, application.applicationDate, application.paidFee,
                application.createdByUserID, application.applicationStatus, application.lastStatusDate, licensClassID);


            return null;
        }

        public bool DeleteLocalDrivingLicensApplicationByID()
        {
            return clsLocalDrivingLicensApplicationDataAccess.DeleteLocalDrivingLicensApplication(this.LocalDrivingLicensApplicationID)
                && clsApplication.DeleteApplicationByID(this.ApplicationID);


        }
        public DataTable GetAllLocalDrivingLicensApplications()
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
        public int TotalTrialsForTestType(int testTypeID)
        {
            return clsLocalDrivingLicensApplicationDataAccess.TotalTrailsPerTestType(this.LocalDrivingLicensApplicationID, testTypeID);
        }

        public bool isthereActiveScheduledTest(int testTYpe)
        {
            return clsLocalDrivingLicensApplicationDataAccess.isthereActiveScheduledTest(this.LocalDrivingLicensApplicationID, testTYpe);
        }


    }
}
