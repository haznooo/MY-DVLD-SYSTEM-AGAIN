using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Data_Access_Layer
{
    public class clsInternationalLicenseDataAccess
    {

        public static bool GetInternationalLicenseInfoByID(int internationalLicenseID,ref int applicationID,ref int driverID,ref int localLicenseID,
            ref DateTime IssueDate,ref DateTime ExpirationDate,ref bool isActive,ref int CreatedByUserID) 
        {
            string query = "select * from InternationalLicenses where InternationalLicenseID = @internationalLicenseID";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@internationalLicenseID", internationalLicenseID);

            bool isFound = false;
            try
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        applicationID = Convert.ToInt32(reader["ApplicationID"]);
                        driverID = Convert.ToInt32(reader["DriverID"]);
                        localLicenseID = Convert.ToInt32(reader["LocalLicenseID"]);
                        IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                        ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                        isActive = Convert.ToBoolean(reader["IsActive"]);
                        CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                        isFound = true;
                    }
                }
            }
            catch
            {

            }
            finally
            {
            connection.Close();
            }

            return isFound;


        }

        public static bool UpdateInternationalLicenseInfo(int internationalLicenseID, int applicationID, int driverID, int localLicenseID,
           DateTime IssueDate, DateTime ExpirationDate, bool isActive, int CreatedByUserID)
        { 
            string query = @"UPDATE InternationalLicenses SET
                                ApplicationID = @ApplicationID,
                                DriverID = @DriverID,
                                LocalLicenseID = @LocalLicenseID,
                                IssueDate = @IssueDate,
                                ExpirationDate = @ExpirationDate,
                                IsActive = @IsActive,
                                CreatedByUserID = @CreatedByUserID
                              WHERE InternationalLicenseID = @InternationalLicenseID";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@InternationalLicenseID", internationalLicenseID);
            command.Parameters.AddWithValue("@ApplicationID", applicationID);
            command.Parameters.AddWithValue("@DriverID", driverID);
            command.Parameters.AddWithValue("@LocalLicenseID", localLicenseID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", isActive);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            bool success = false;
            try
            {
                connection.Open();
                int rows = command.ExecuteNonQuery();
                success = rows > 0;
            }
            catch
            {
                success = false;
            }
            finally
            {
                connection.Close();
            }

            return success;
        }

        public static int AddInternationalLicense(int applicationID, int driverID, int localLicenseID,
           DateTime IssueDate, DateTime ExpirationDate, bool isActive, int CreatedByUserID)
        { 
            string query = @" Update InternationalLicenses set IsActive = 0 where DriverID = @DriverID; 

                                INSERT INTO InternationalLicenses
                                (ApplicationID, DriverID, LocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID)
                              VALUES
                                (@ApplicationID, @DriverID, @LocalLicenseID, @IssueDate, @ExpirationDate, @IsActive, @CreatedByUserID);
                              SELECT SCOPE_IDENTITY();";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", applicationID);
            command.Parameters.AddWithValue("@DriverID", driverID);
            command.Parameters.AddWithValue("@LocalLicenseID", localLicenseID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", isActive);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            int insertedId = -1;
            try
            {
                connection.Open();
                object scalar = command.ExecuteScalar();
                if (scalar != null && scalar != DBNull.Value)
                    insertedId = Convert.ToInt32(scalar);
            }
            catch
            {
                insertedId = -1;
            }
            finally
            {
                connection.Close();
            }

            return insertedId;
        }

        public static DataTable GetAllInternationalLicenses() 
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM InternationalLicenses";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }
        public static DataTable GetDriverInternatonalLicenses(int DriverID) 
        { 
            DataTable dt = new DataTable();

            string query = @"SELECT InternationalLicenseID, ApplicationID, LocalLicenseID, IssueDate, ExpirationDate, IsActive
                             FROM InternationalLicenses
                             WHERE DriverID = @DriverID
                             ORDER BY IsActive DESC, ExpirationDate DESC";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID) 
        {

            string query = "select * from InternationalLicenses where IsActive = 1 and DriverID = @DriverID";


                  SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

  
            command.Parameters.AddWithValue("@DriverID", DriverID);

            int ActiveInternatioanlLicenseID = -1;
            try
            {
                connection.Open();
                object scalar = command.ExecuteScalar();
                if (scalar != null && scalar != DBNull.Value)
                    ActiveInternatioanlLicenseID = Convert.ToInt32(scalar);
            }
            catch
            {
                ActiveInternatioanlLicenseID = -1;
            }
            finally
            {
                connection.Close();
            }

            return ActiveInternatioanlLicenseID;

        }


    }
}
