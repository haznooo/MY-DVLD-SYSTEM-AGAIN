using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsApplicationTypes
    {

        static public DataTable GetAllApplicationTypes()
        {

            return clsApplicationTypesDataAccess.GetApplicationTypes();

        }

        static public bool UpdateApplicationType(int ApplicationTypeID,string newTitle,float newFees) {

            return clsApplicationTypesDataAccess.UpdateApplicationType(ApplicationTypeID,newTitle,newFees);

        }

        static public void GetApplicationTypeByID(int ApplicationTypeID,ref string ApplicationTypeTitle, ref decimal ApplicationTypeFee)
        {

            clsApplicationTypesDataAccess.GetApplicationTypeInfoByID(ApplicationTypeID, ref ApplicationTypeTitle, ref ApplicationTypeFee);
        }
    }
}
