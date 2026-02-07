using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsLicenceClasses
    {

        enum enMode { AddNew, Update }
        private enMode _Mode;

        public int LicnesClassID { get; set; }
        public string ClassName { get; set; }
        public byte MinimumAge { get; set; }
        public Decimal Fee { get; set; }
        public byte validityYears { get; set; }
        public string classDescription { get; set; }

        public clsLicenceClasses()
        {
            LicnesClassID = -1;
            ClassName = string.Empty;
            MinimumAge = 0;
            Fee = 0;
            validityYears = 0;
            classDescription = string.Empty;
            _Mode = enMode.AddNew;
        }
        private clsLicenceClasses(int LicnesClassID, string ClassName, byte MinimumAge, Decimal Fee, byte validityYears, string classDescription)
        {
            this.LicnesClassID = LicnesClassID;
            this.ClassName = ClassName;
            this.MinimumAge = MinimumAge;
            this.Fee = Fee;
            this.validityYears = validityYears;
            this.classDescription = classDescription;
            _Mode = enMode.Update;
        }
        static public DataTable GetAllLicencesClasses()
        {

            return clsLicencesClassesDataAccess.GetLicencesClasses();

        }

        public static clsLicenceClasses Find(int LicnesClassID)
        {
            string ClassName = string.Empty;
            string ClassDescription = string.Empty;
            byte minimumAge = 0;
            byte validityLength = 0;
            decimal CassFee = 0;


            if (clsLicencesClassesDataAccess.GetLicencesClassInfoByID(LicnesClassID, ref ClassName,
                  ref ClassDescription, ref minimumAge, ref validityLength, ref CassFee))
            {

                return new clsLicenceClasses(LicnesClassID, ClassName, minimumAge, CassFee, validityLength, ClassDescription);
            }
            else
            {
                return null;

            }
        }


        private int _addNewLicenceClass()
        {
            return clsLicencesClassesDataAccess.InsertLicenceClass(this.ClassName, this.classDescription, this.MinimumAge, this.validityYears, this.Fee);
        }
        private bool _updateLicenceClass()
        {
            return clsLicencesClassesDataAccess.UpdateLicenceClass(this.LicnesClassID, this.ClassName, this.classDescription, this.MinimumAge, this.validityYears, this.Fee);
        }

        public bool save()
        {

            switch (_Mode)
            {

                case enMode.AddNew:
                    this.LicnesClassID = _addNewLicenceClass();
                    if (this.LicnesClassID != -1)
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _updateLicenceClass();
                default:
                    return false;


            }

        }
    }
}
