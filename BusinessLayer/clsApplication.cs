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
            New = 1,
            Renewal = 2,
            Update = 3
        }
        enum enApplicationStatus : byte
        {
            Submitted = 1,
            InReview = 2,
            Approved = 3,
            Rejected = 4
        }

        enum enMode { AddNew, Update }

        enMode CurrentMode;

        public int applicationID { get; set; }
        public int applicantID { get; set; }
        public DateTime applicationDate { get; set; }
        public byte applicationType { get; set; }
        public byte applicationStatus { get; set; }
        public DateTime lastStatusDate { get; set; }
        public decimal paidFee { get; set; }
        public int createdByUserID { get; set; }


        public clsApplication()
        {

            applicationID = -1;
            applicantID = -1;
            applicationDate = DateTime.MinValue;
            applicationType = 0;
            applicationStatus = 0;
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
            this.applicationDate = applicationDate;
            this.applicationType = applicationType;
            this.applicationStatus = applicationStatus;
            this.lastStatusDate = lastStatusDate;
            this.paidFee = paidFee;
            this.createdByUserID = createdByUserID;
            CurrentMode = enMode.Update;
        }

        private bool _addNewApplication()
        {
            int newApplicationID = clsApplicationDataAccess.AddNewApplication(applicantID, applicationDate,
                applicationType, applicationStatus, lastStatusDate, paidFee, createdByUserID);
            if (newApplicationID > 0)
            {
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
                  applicationType, applicationStatus, lastStatusDate, paidFee, createdByUserID);
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
    }
}