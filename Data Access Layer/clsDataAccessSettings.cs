using System.Configuration;

namespace DataAccessLayer
{

    internal class clsDataAccessSettings
    {
        //string skibidi = "Server=.;Database=DVLD;User=sa;Password=sa123456";


        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
            }
        }
    }
}

