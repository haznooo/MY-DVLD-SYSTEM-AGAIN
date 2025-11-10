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
        static public DataTable GetAllLicencesClasses()
        {

            return clsLicencesClassesDataAccess.GetLicencesClasses();

        }
    }
}
