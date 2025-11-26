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
    public class clsLocalDrivingLicensApplicationDataAccess
    {

        public static bool GetLocalDrivingLicensApplicationInfoByID(int LocalDrivingLicenseApplicationID,ref int ApplicationID,
            ref int LicenseClassID)
        {


            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID = @localDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@localDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try { 
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                        LicenseClassID = Convert.ToInt32(reader["LicenseClassID"]);
                    }
                    isFound = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // Handle exception (log it, rethrow it, etc.)
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound; 
        }

        public static bool GetLocalDrivingLicensApplicationInfoByApplicationID(int ApplicationID, ref int LocalDrivingLicenseApplicationID,
            ref int LicenseClassID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM LocalDrivingLicenseApplications where ApplicationID = @applicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@applicationID", ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        LocalDrivingLicenseApplicationID = Convert.ToInt32(reader["LocalDrivingLicenseApplicationID"]);
                        LicenseClassID = Convert.ToInt32(reader["LicenseClassID"]);
                    }
                    isFound = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // Handle exception (log it, rethrow it, etc.)
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
            return true; // Placeholder return value
        }
        public static int AddLocalDrivingLicensApplication(int ApplicationID,
            int LicenseClassID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "INSERT INTO LocalDrivingLicenseApplications (ApplicationID, LicenseClassID) " +
                           "VALUES (@applicationID, @licenseClassID);SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@applicationID", ApplicationID);
            command.Parameters.AddWithValue("@licenseClassID", LicenseClassID);

            int insertedId = -1;

            try
            {
                connection.Open();
                // Execute the command and get the inserted ID if needed
                 insertedId = (int)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                // Handle exception (log it, rethrow it, etc.)
          
            }
            finally
            {
                connection.Close();
            }

            return insertedId;
        }

        public static bool UpdateLocalDrivingLicensApplicationByID(int LocalDrivingLicenseApplicationID,
            int ApplicationID, int LicenseClassID)
        {
           
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "UPDATE LocalDrivingLicenseApplications SET ApplicationID = @applicationID, " +
                           "LicenseClassID = @licenseClassID WHERE LocalDrivingLicenseApplicationID = @localDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@localDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            command.Parameters.AddWithValue("@applicationID", ApplicationID);
            command.Parameters.AddWithValue("@licenseClassID", LicenseClassID);

            int rowsAffected = 0;
            try
            {
                connection.Open();
               rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
              
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0); 
        }

        public static bool DeleteLocalDrivingLicensApplication(int LocalDrivingLicenseApplicationID)
        {
          
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "DELETE FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @localDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@localDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            int rowsAffected = 0;
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
          
               
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0); ;
        }

        public static DataTable GetAllLocalDrivingLicensApplications()
        {
            // This method is used to get all local driving license applications
            // Implement database access logic here
            return new DataTable(); // Placeholder return value
        }


    }
}
