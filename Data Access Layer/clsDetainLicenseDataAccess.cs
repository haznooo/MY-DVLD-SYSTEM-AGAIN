using DataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Data_Access_Layer
{
    public class clsDetainLicenseDataAccess
    {
        public static bool GetDetainedLicenseInfoByID(int DetainID, ref int LicenseID, ref DateTime DetainDate, ref decimal fineFees,
            ref int CreatedByUserID, ref bool isReleased, ref DateTime? ReleaseDate, ref int? ReleasedByUserID, ref int? ReleaseApplicationID)
        {

            string query = "select * from DetainedLicenses where DetainID = @detainID";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@detainID", DetainID);


            bool found = false;
            try
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        found = true;

                        LicenseID = reader["LicenseID"] != DBNull.Value ? Convert.ToInt32(reader["LicenseID"]) : LicenseID;
                        DetainDate = reader["DetainDate"] != DBNull.Value ? Convert.ToDateTime(reader["DetainDate"]) : DetainDate;
                        fineFees = reader["FineFees"] != DBNull.Value ? Convert.ToDecimal(reader["FineFees"]) : fineFees;
                        CreatedByUserID = reader["CreatedByUserID"] != DBNull.Value ? Convert.ToInt32(reader["CreatedByUserID"]) : CreatedByUserID;
                        isReleased = reader["IsReleased"] != DBNull.Value ? Convert.ToBoolean(reader["IsReleased"]) : isReleased;

                        // Nullable release-related fields
                        if (reader["ReleaseDate"] != DBNull.Value)
                            ReleaseDate = Convert.ToDateTime(reader["ReleaseDate"]);
                        else
                            ReleaseDate = null;

                        if (reader["ReleasedByUserID"] != DBNull.Value)
                            ReleasedByUserID = Convert.ToInt32(reader["ReleasedByUserID"]);
                        else
                            ReleasedByUserID = null;

                        if (reader["ReleaseApplicationID"] != DBNull.Value)
                            ReleaseApplicationID = Convert.ToInt32(reader["ReleaseApplicationID"]);
                        else
                            ReleaseApplicationID = null;
                    }
                }
            }
            catch (Exception)
            {
                // swallow or log as needed
                found = false;
            }
            finally
            {
                connection.Close();
            }

            return found;
        }

        public static bool GetDetainedLicenseInfoByLicenseID(int searchLicenseID, ref int DetainID, ref DateTime DetainDate, ref decimal fineFees,
            ref int CreatedByUserID, ref bool isReleased, ref DateTime? ReleaseDate, ref int? ReleasedByUserID, ref int? ReleaseApplicationID)
        {
            string query = "select top 1 * from DetainedLicenses where LicenseID = @licenseID order by DetainDate desc";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@licenseID", searchLicenseID);

            bool found = false;
            try
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        found = true;

                        DetainID = reader["DetainID"] != DBNull.Value ? Convert.ToInt32(reader["DetainID"]) : DetainID;
                        DetainDate = reader["DetainDate"] != DBNull.Value ? Convert.ToDateTime(reader["DetainDate"]) : DetainDate;
                        fineFees = reader["FineFees"] != DBNull.Value ? Convert.ToDecimal(reader["FineFees"]) : fineFees;
                        CreatedByUserID = reader["CreatedByUserID"] != DBNull.Value ? Convert.ToInt32(reader["CreatedByUserID"]) : CreatedByUserID;
                        isReleased = reader["IsReleased"] != DBNull.Value ? Convert.ToBoolean(reader["IsReleased"]) : isReleased;

                        if (reader["ReleaseDate"] != DBNull.Value)
                            ReleaseDate = Convert.ToDateTime(reader["ReleaseDate"]);
                        else
                            ReleaseDate = null;

                        if (reader["ReleasedByUserID"] != DBNull.Value)
                            ReleasedByUserID = Convert.ToInt32(reader["ReleasedByUserID"]);
                        else
                            ReleasedByUserID = null;

                        if (reader["ReleaseApplicationID"] != DBNull.Value)
                            ReleaseApplicationID = Convert.ToInt32(reader["ReleaseApplicationID"]);
                        else
                            ReleaseApplicationID = null;
                    }
                }
            }
            catch (Exception)
            {
                found = false;
            }
            finally
            {
                connection.Close();
            }

            return found;
        }

        public static DataTable GetAllDetainedLicenses()
        {
            DataTable dataTable = new DataTable();

            string query = "select * from DetainedLicenses_View order By IsReleased,DetainID";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    dataTable.Load(reader);
                }
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return dataTable;

        }

        public static int AddDetainedLicense(int LicenseID, DateTime DetainDate, decimal fineFees,
            int CreatedByUserID, bool isReleased, DateTime? ReleaseDate, int? ReleasedByUserID, int? ReleaseApplicationID)
        {
            string query = "INSERT INTO DetainedLicenses (LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleasedByUserID, ReleaseApplicationID) " +
                           "VALUES (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, @IsReleased, @ReleaseDate, @ReleasedByUserID, @ReleaseApplicationID); SELECT SCOPE_IDENTITY();";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", fineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", isReleased);
            command.Parameters.AddWithValue("@ReleaseDate", (object)ReleaseDate ?? DBNull.Value);
            command.Parameters.AddWithValue("@ReleasedByUserID", (object)ReleasedByUserID ?? DBNull.Value);
            command.Parameters.AddWithValue("@ReleaseApplicationID", (object)ReleaseApplicationID ?? DBNull.Value);

            int insertedId = -1;
            try
            {
                connection.Open();
                object scalar = command.ExecuteScalar();
                if (scalar != null && scalar != DBNull.Value)
                {
                    // SCOPE_IDENTITY() is returned as decimal; convert safely
                    insertedId = Convert.ToInt32(scalar);
                }
            }
            catch (Exception)
            {
                insertedId = -1;
            }
            finally
            {
                connection.Close();
            }

            return insertedId;
        }

        public static bool UpdateDetainedLicense(int DetainID, int LicenseID, DateTime DetainDate, decimal fineFees,
            int CreatedByUserID, bool isReleased, DateTime? ReleaseDate, int? ReleasedByUserID, int? ReleaseApplicationID)
        {
            string query = "UPDATE DetainedLicenses SET LicenseID = @LicenseID, DetainDate = @DetainDate, FineFees = @FineFees, CreatedByUserID = @CreatedByUserID, " +
                           "IsReleased = @IsReleased, ReleaseDate = @ReleaseDate, ReleasedByUserID = @ReleasedByUserID, ReleaseApplicationID = @ReleaseApplicationID " +
                           "WHERE DetainID = @DetainID";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DetainID", DetainID);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", fineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", isReleased);
            command.Parameters.AddWithValue("@ReleaseDate", (object)ReleaseDate ?? DBNull.Value);
            command.Parameters.AddWithValue("@ReleasedByUserID", (object)ReleasedByUserID ?? DBNull.Value);
            command.Parameters.AddWithValue("@ReleaseApplicationID", (object)ReleaseApplicationID ?? DBNull.Value);

            bool success = false;
            try
            {
                connection.Open();
                int rows = command.ExecuteNonQuery();
                success = rows > 0;
            }
            catch (Exception)
            {
                success = false;
            }
            finally
            {
                connection.Close();
            }

            return success;
        }

        public static bool IsDetained(int licenseID)
        {
            string query = "SELECT COUNT(1) FROM DetainedLicenses WHERE LicenseID = @licenseID AND IsReleased = 0";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@licenseID", licenseID);
                try
                {
                    connection.Open();
                    object scalar = command.ExecuteScalar();
                    if (scalar != null && scalar != DBNull.Value)
                    {
                        return Convert.ToInt32(scalar) > 0;
                    }
                }
                catch (Exception)
                {
                    // swallow or log
                }
            }

            return false;
        }

        public static bool ReleaseLicense(int detainID, int ReleasedByUserID, int ReleaseApplicationID)
        {
            string query = "UPDATE DetainedLicenses SET IsReleased = 1, ReleaseDate = @ReleaseDate, ReleasedByUserID = @ReleasedByUserID, ReleaseApplicationID = @ReleaseApplicationID " +
                           "WHERE DetainID = @DetainID AND IsReleased = 0";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@DetainID", detainID);
                command.Parameters.AddWithValue("@ReleaseDate", DateTime.Now);
                command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
                command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);

                try
                {
                    connection.Open();
                    int rows = command.ExecuteNonQuery();
                    return rows > 0;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

    }
}
