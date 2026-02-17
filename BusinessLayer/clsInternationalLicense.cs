using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public  class clsInternationalLicense : clsApplication
    {
        public int internationalLicenseID {  get; set; }
        public int driverID { get; set; }
        public int localLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool isActive { get; set; }

        clsDriver DriverInfo { get; set; }


        enMode _Mode;

        public clsInternationalLicense() 
        {

            applicationID = -1; driverID = -1;
            localLicenseID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            isActive = false;
            createdByUserID = -1;

            _Mode = enMode.AddNew;
        }

        public clsInternationalLicense(int internationalLicenseID, int applicationID, int driverID, int localLicenseID,
           DateTime IssueDate, DateTime ExpirationDate, bool isActive, int CreatedByUserID,int applicantID,DateTime applicationDate,
           enApplicationStatus applicationStatus,DateTime lastStatusDate,decimal paidFees) 
        {

            this.internationalLicenseID = internationalLicenseID;
            this.driverID = driverID; 
            this.localLicenseID = localLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.isActive = isActive;
            this.createdByUserID = CreatedByUserID;
            this.DriverInfo = clsDriver.GetDriverInfoByID(driverID);

            base.createdByUserID = CreatedByUserID;
            base.applicationID = applicationID;
            base.applicantID = applicantID;
            base.applicationDate = applicationDate;
            base.applicationStatus = applicationStatus;
            base.lastStatusDate = lastStatusDate;
            base.applicationTypeID = (int)clsApplicationTypes.enApplicationType.NewInternationalLicens;
            base.paidFee = paidFees;

            _Mode = enMode.Update;    
        
        }


        public static DataTable GetAllInternationalLicenses() 
        {
            return clsInternationalLicenseDataAccess.GetAllInternationalLicenses();
        }

        public static DataTable GetDriverInternatonalLicenses(int DriverID) 
        {
            return clsInternationalLicenseDataAccess.GetDriverInternatonalLicenses(DriverID);
        }

        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID) 
        {
            return clsInternationalLicenseDataAccess.GetActiveInternationalLicenseIDByDriverID(DriverID);
        }

        public static clsInternationalLicense FindByID(int internationalLicenseID) 
        {
            int applicationID = -1, driverID = -1, localLicenseID = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            bool isActive = false;

      

            if (clsInternationalLicenseDataAccess.GetInternationalLicenseInfoByID(internationalLicenseID, ref applicationID, ref driverID, ref localLicenseID,
            ref IssueDate, ref ExpirationDate, ref isActive, ref CreatedByUserID)) 
            {

                clsApplication app = clsApplication.GetBaseApplicationInfoByID(applicationID);

                return new clsInternationalLicense(internationalLicenseID, applicationID, driverID, localLicenseID,
                IssueDate, ExpirationDate, isActive, CreatedByUserID,app.applicationID,app.applicationDate,app.applicationStatus,app.lastStatusDate,app.paidFee);
            }
            return null;

        }


        bool _UpdateInternationalLicense() 
        {

            if (clsInternationalLicenseDataAccess.UpdateInternationalLicenseInfo(internationalLicenseID, applicationID, driverID, localLicenseID,
                IssueDate, ExpirationDate, isActive,this.createdByUserID)) 
            {
                return true;
            }
            return false;
        }

        int _AddInternationalLicense() 
        {

            return clsInternationalLicenseDataAccess.AddInternationalLicense(this.applicationID, driverID, localLicenseID, IssueDate, ExpirationDate, isActive, createdByUserID);
        
        }

        public bool save() 
        {

            base.CurrentMode = _Mode;
            switch (_Mode) 
            {

                case enMode.AddNew:
                    {
                        if (base.SaveApplication(out int applicationID)) 
                        {
                        this.applicationID = applicationID;
                            return _AddInternationalLicense() != -1;
                        }
                        return false ;
                    }
                   
                case enMode.Update:
                    {
                        if (base.SaveApplication(out int applicationID))
                        {
                            return _UpdateInternationalLicense();
                        }
                        return false;
                    }
                 
                default: return false;

          
            }
        
        }

    }
}
