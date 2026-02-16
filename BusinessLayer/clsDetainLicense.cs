using Data_Access_Layer;
using System;
using System.Data;

namespace BusinessLayer
{
    public class clsDetainLicense
    {
        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal fineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool isReleased { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? ReleasedByUserID { get; set; }
        public int? ReleaseApplicationID { get; set; }

        public clsUser CreatedByUserInfo;
        enum enMode {add,update}
        enMode _mode;


        public clsDetainLicense(int DetainID, int LicenseID, DateTime DetainDate, decimal fineFees,
            int CreatedByUserID, bool isReleased, DateTime? ReleaseDate, int? ReleasedByUserID, int? ReleaseApplicationID) 
        {
        
            this.DetainDate = DetainDate;
            this.DetainID = DetainID;
            this.LicenseID = LicenseID;
            this.fineFees = fineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.isReleased = isReleased;
            this.ReleaseApplicationID = ReleaseApplicationID;
            this.ReleaseDate = ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
            this.CreatedByUserInfo = clsUser.GetUserByID(CreatedByUserID);

            _mode = enMode.update;
          
        
        }
        public clsDetainLicense() 
        {
            this.DetainDate = DateTime.Now;
            this.DetainID = DetainID -1;
            this.LicenseID = LicenseID = -1;
            this.fineFees = fineFees = 0;
            this.CreatedByUserID = -1;
            this.isReleased = false;
            this.ReleaseApplicationID = null;
            this.ReleaseDate = null;
            this.ReleasedByUserID = null;

            _mode = enMode.add;
        }

        public static clsDetainLicense GetDetainedLicenseInfoByID(int DetainID) 
        {

            int LicenseID = -1; DateTime DetainDate = DateTime.Now;  decimal fineFees = 0;
            int CreatedByUserID = -1; bool isReleased = false;
            DateTime? ReleaseDate = null; int? ReleasedByUserID = null; int? ReleaseApplicationID = null;


            if (clsDetainLicenseDataAccess.GetDetainedLicenseInfoByID(DetainID, ref LicenseID, ref DetainDate, ref fineFees,
              ref CreatedByUserID, ref isReleased, ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID)) 
            {

                return new clsDetainLicense(DetainID, LicenseID, DetainDate, fineFees,
              CreatedByUserID, isReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            
            }
            return null;

        }

        public static clsDetainLicense GetDetainedLicenseInfoByLicenseID(int searchLicenseID)
        {
            int DetainID = -1; DateTime DetainDate = DateTime.Now;  decimal fineFees = 0;
            int CreatedByUserID = -1; bool isReleased = false;
            DateTime? ReleaseDate = null; int? ReleasedByUserID = null; int? ReleaseApplicationID = null;

            if (clsDetainLicenseDataAccess.GetDetainedLicenseInfoByLicenseID(searchLicenseID, ref DetainID, ref DetainDate, ref fineFees,
              ref CreatedByUserID, ref isReleased, ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID))
            {
                return new clsDetainLicense(DetainID, searchLicenseID, DetainDate, fineFees,
                    CreatedByUserID, isReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            }
            return null;
        }

        public static DataTable GetAllDetainedLicenses()
        {
            return clsDetainLicenseDataAccess.GetAllDetainedLicenses();
        }

        public bool Save()
        {
            if (_mode == enMode.add)
            {
                int id = clsDetainLicenseDataAccess.AddDetainedLicense(LicenseID, DetainDate, fineFees, CreatedByUserID, isReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
                if (id > 0)
                {
                    DetainID = id;
                    _mode = enMode.update;
                    return true;
                }
                return false;
            }

            // update
            return clsDetainLicenseDataAccess.UpdateDetainedLicense(DetainID, LicenseID, DetainDate, fineFees, CreatedByUserID, isReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
        }

        public static bool IsDetained(int licenseID)
        {
            return clsDetainLicenseDataAccess.IsDetained(licenseID);
        }

        public bool Release(int releasedByUserID, int releaseApplicationID)
        {
            bool ok = clsDetainLicenseDataAccess.ReleaseLicense(DetainID, releasedByUserID, releaseApplicationID);
            if (ok)
            {
                isReleased = true;
                ReleaseDate = DateTime.Now;
                ReleasedByUserID = releasedByUserID;
                ReleaseApplicationID = releaseApplicationID;
            }
            return ok;
        }




    }
}
