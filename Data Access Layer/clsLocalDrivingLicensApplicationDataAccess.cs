using DataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Data_Access_Layer
{
    public class clsLocalDrivingLicensApplicationDataAccess
    {

        public static bool GetLocalDrivingLicensApplicationInfoByID(int LocalDrivingLicenseApplicationID, ref int ApplicationID,
            ref int LicenseClassID)
        {


            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID = @localDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@localDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
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
                insertedId = Convert.ToInt32(command.ExecuteScalar());
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

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from LocalDrivingLicenseApplications_View";

            SqlCommand command = new SqlCommand(query, connection);

            DataTable localDrivingLicensApplications = new DataTable();


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    localDrivingLicensApplications.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {


            }
            finally
            {
                connection.Close();
            }

            return localDrivingLicensApplications;

        }

        public static bool DoesPassTestType(int localDrivingLicensApplicationID, int testTYpe)
        {

            string query = @" SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID) and TestResult = 1
                            ORDER BY TestAppointments.TestAppointmentID desc";

            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicensApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", testTYpe);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    isFound = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // Handle exception (log it, rethrow it, etc.)

            }
            finally
            {
                connection.Close();
            }
            return isFound;



        }
        public static bool DoesAttendTestType(int localDrivingLicensApplicationID, int testTYpe)
        {
            string query = @" SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY TestAppointments.TestAppointmentID desc";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicensApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", testTYpe);
            bool isfound = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    isfound = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // Handle exception (log it, rethrow it, etc.)

            }
            finally
            {
                connection.Close();
            }
            return isfound;
        }
        public static int TotalTrailsPerTestType(int localDrivingLicensApplicationID, int testTYpe)
        {

            string query = @"	 SELECT count(*)
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)";
            int totalTrails = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicensApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", testTYpe);

            try
            {
                connection.Open();
                totalTrails = (int)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                // Handle exception (log it, rethrow it, etc.)

            }
            finally
            {
                connection.Close();
            }
            return totalTrails;



        }
        public static bool isthereActiveScheduledTest(int localDrivingLicensApplicationID, int testTYpe)
        {
            string query = @" SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @localDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @testType) and IsLocked = 0";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@localDrivingLicenseApplicationID", localDrivingLicensApplicationID);
            command.Parameters.AddWithValue("@testType", testTYpe);
            bool isfound = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    isfound = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                // Handle exception (log it, rethrow it, etc.)
            }
            finally
            {
                connection.Close();
            }
            return isfound;



        }

        public static bool DoesPassAllTests(int localDrivingLicneseApplicationID)
        {
            return testDataAccess.GetPassedTestsCount(localDrivingLicneseApplicationID) == 3;

        }
    }

}




