using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class clsLicencesClassesDataAccess
    {

        static public DataTable GetLicencesClasses()
        {

            DataTable dt = new DataTable();

            string Query = "Select * from LicenseClasses";

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    dt.Load(reader);

                }


            }
            catch (Exception ex) { }

            finally
            {

                Connection.Close();

            }

            return dt;

        }


    }
}
