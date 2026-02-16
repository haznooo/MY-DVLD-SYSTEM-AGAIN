using Data_Access_Layer;
using System;
using System.Data;

namespace BusinessLayer
{
    public class clsDriver
    {
        enum enMode { add, update }
        enMode _Mode = enMode.update;
        public int DriverID;
        public int CreatedByUserID;
        public DateTime CreatedDate;
        public int PersonID;
        public clsPerson PersonInfo;

        public clsDriver()
        {

            DriverID = -1;
            CreatedByUserID = -1;
            CreatedDate = DateTime.Now;
            PersonInfo = new clsPerson();
            PersonID = -1;
            _Mode = enMode.add;

        }
        public clsDriver(int DriverID, int CreatedByUserID, DateTime CreaetDate, int PersonID)
        {

            this.DriverID = DriverID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreaetDate;
            this.PersonID = PersonID;
            this.PersonInfo = clsPerson.GetPersonInfoByID(PersonID);

            _Mode = enMode.update;
        }


        static public clsDriver GetDriverInfoByID(int DriverID)
        {
            int CreatedByUserID = -1, PersonID = -1;
            DateTime CreateDate = DateTime.Now;


            if (clsDrivierDataAccess.GetDriverInfoByDrivierID(DriverID, ref PersonID, ref CreatedByUserID, ref CreateDate))
            {
                return new clsDriver(DriverID, CreatedByUserID, CreateDate, PersonID);
            }
            return null;

        }

        static public clsDriver GetDriverInfoByPersonID(int PersonID)
        {
            int CreatedByUserID = -1, DriverID = -1;
            DateTime CreateDate = DateTime.Now;


            if (clsDrivierDataAccess.GetDriverInfoByPersonID(ref DriverID, PersonID, ref CreatedByUserID, ref CreateDate))
            {
                return new clsDriver(DriverID, CreatedByUserID, CreateDate, PersonID);
            }
            return null;

        }

        static public DataTable GetAllDrivers()
        {
            return clsDrivierDataAccess.GetAllDriversInf();
        }

        public bool Save()
        {

            switch (_Mode)
            {

                case enMode.add:
                    {
                        if (_AddNewDriver() > 0) return true;
                        else return false;

                    }
                case enMode.update:
                    return _UpdateDriver();

                default: return false;
            }

        }

        private int _AddNewDriver()
        {
            return clsDrivierDataAccess.addNewDriver(ref this.PersonID, ref this.CreatedByUserID, ref this.CreatedDate);
        }
        private bool _UpdateDriver()
        {
            return clsDrivierDataAccess.UpdateDriver(this.DriverID, this.PersonID, this.CreatedByUserID, this.CreatedDate);

        }


    }
}
