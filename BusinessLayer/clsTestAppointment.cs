using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsTestAppointment
    {

        enum enTestType
        {
            Written = 1,
            Road = 2,
            Vision = 3
        }
        enum enMode { Add = 1, update = 2 }


        enMode _mode;
        public int TestAppointmentID { get; set; }
        public int applicantID { get; set; }
        public clsTestTypes TestType { get; set; }
        public int TestTypeID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public float paidFees { get; set; }
        public int createdByUserID;
        public int localDrivingLicensesApplicantID { get; set; }
        public bool isLocked;
        public int RetakeTestApplicationID { get; set; }
        public clsApplication RetakeTestApplicationInfo { get; set; }

        public int testID;
        public clsTestAppointment(int appointmentID,int applicantid,DateTime appointmentDate,
            float paidFees,int createdByuserid,int localDrivinglicensesapplicationId,bool islooked,int RetakeTestApplicationID)
        {
            TestAppointmentID = appointmentID;
            applicantID = applicantid;
            AppointmentDate = appointmentDate;
            this.paidFees = paidFees;
            createdByUserID = createdByuserid;
            localDrivingLicensesApplicantID = localDrivinglicensesapplicationId;
            this.isLocked = islooked;
            RetakeTestApplicationInfo = clsApplication.GetBaseApplicationInfoByID(RetakeTestApplicationID);
            _mode = enMode.update;

        }
        
        public clsTestAppointment()
        {
            _mode = enMode.Add;
        }

        private bool _AddNewTestAppointment() {
            
        return clsTestAppointmentDataAccess.addTestAppointment((int)this.TestTypeID,this.localDrivingLicensesApplicantID,this.AppointmentDate,this.paidFees,this.createdByUserID,this.isLocked);
        }
        private bool _UpdateTestAppointment() {
        
            return clsTestAppointmentDataAccess.updateTestAppointment(TestAppointmentID, (int)TestType.TestType, localDrivingLicensesApplicantID, AppointmentDate, paidFees, createdByUserID, isLocked);

        }

        public static clsTestAppointment Find(int testAppointmentID) {
        
            int applicantID =0,testTypeID = 0, LocalDrivingLicensApplicationID = 0, createdByUserID = 0;
            DateTime appointmentDate = DateTime.MinValue;
            float paidFees = 0;
             bool isLocked = false;
            int retakeTestApplicationID = 0;
            if (clsTestAppointmentDataAccess.GetTestApppointmentByID(testAppointmentID, ref testTypeID, ref LocalDrivingLicensApplicationID, ref appointmentDate, ref paidFees, ref createdByUserID, ref isLocked))
            {
                return new clsTestAppointment(testAppointmentID,applicantID, appointmentDate, paidFees, createdByUserID, LocalDrivingLicensApplicationID, isLocked,retakeTestApplicationID);
            }
            else
            {
                return null;
            }
        
        }

        public static clsTestAppointment GetLastTestAppointment(
            int localDrivingLicensApp, int testType) {


            int testAppointmentID=0 ,applicantID =0, LocalDrivingLicensApplicationID = 0, createdByUserID = 0;
            DateTime appointmentDate = DateTime.MinValue;
            float paidFees = 0;
            bool isLocked = false;
            int retakeTestApplicationID = 0;

            clsTestAppointmentDataAccess.GetLastTestAppointment
             (LocalDrivingLicensApplicationID,testType, ref testAppointmentID, ref appointmentDate, ref paidFees, ref createdByUserID, ref isLocked);
            if (testAppointmentID != 0)
            {
                return new clsTestAppointment(testAppointmentID, applicantID, appointmentDate, paidFees, createdByUserID, LocalDrivingLicensApplicationID, isLocked,retakeTestApplicationID);
            }
            else
            {
                return null;
            }
            
        }

        public static DataTable GetAllTestAppointments() {

            return clsTestAppointmentDataAccess.GetAllTestAppointments();
        
        }

        public static DataTable GetAllTestAppointmentsPerTestType(int localDrivingLicensApplication,int testType) {

         return clsTestAppointmentDataAccess.GetApplicationTestAppointmentsPerTestType(localDrivingLicensApplication, testType);
        
        }
        public bool save() {
        
            switch(_mode)
            {
                case enMode.Add:
                    return _AddNewTestAppointment();
                case enMode.update:
                    return _UpdateTestAppointment();
                default:
                    return false;
                }
            }
        private int _getTestID() {
        
            return clsTestAppointmentDataAccess.GetTestID(TestAppointmentID);

        }

        public static bool DoesHaveActiveTestAppointment(int localDrivingLicensApplication, int testTypeID)
        {
            return clsTestAppointmentDataAccess.DoesHaveActiveTestAppointment(localDrivingLicensApplication, testTypeID);
        
        }
        public static bool CancelTestAppointment(int testAppointment) 
        {
        return clsTestAppointmentDataAccess.CancelTestAppointment(testAppointment);
        }
    }
}
