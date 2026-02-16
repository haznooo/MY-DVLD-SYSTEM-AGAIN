using DataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Data_Access_Layer
{
    public class testDataAccess
    {

        public static bool GetTestInfoByID(int id, ref int TestAppointmentID, ref bool testResults, ref string note, ref int createdByUserID)
        {
            string query = "Select * from Tests where TestID = @TestID";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestID", id);
            bool isFound = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    TestAppointmentID = Convert.ToInt32(reader["TestAppointmentID"]);
                    testResults = Convert.ToBoolean(reader["TestResults"]);
                    note = reader["Notes"].ToString();
                    createdByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    isFound = true;
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();

            }
            return isFound;
        }

        public static DataTable GetAllTests()
        {
            string query = "Select * from Tests";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            DataTable dt = new DataTable();
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }
            return dt;


        }

        public static int addTest(int TestAppointment, bool testResults, string notes, int createdByUserID, out int NewTestID)
        {
            string query = @"Insert into Tests(TestAppointmentID,TestResult, Notes, CreatedByUserID)
                             values(@TestAppointment, @TestResults, @Notes, @CreatedByUserID);

                             Update TestAppointments set IsLocked = 1 where TestAppointmentID = @TestAppointmentID;

                             SELECT SCOPE_IDENTITY();";


            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointment", TestAppointment);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointment);
            command.Parameters.AddWithValue("@TestResults", testResults);
            command.Parameters.AddWithValue("@Notes", notes);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);


            NewTestID = -1;
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    NewTestID = Convert.ToInt32(result);

                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }
            return NewTestID;
            ;



        }
        public static bool UpdateTest(int id, int TestAppointmentID, bool testResults, string note, int createdByUserID)
        {
            string query = "Update Tests set TestAppointmentID = @TestAppointment, TestResults = @TestResults, Notes = @Note, CreatedByUserID = @CreatedByUserID where TestID = @TestID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestID", id);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResults", testResults);
            command.Parameters.AddWithValue("@Notes", note);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
            bool isSuccess = false;
            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }
            return isSuccess;


        }

        public static int GetPassedTestsCount(int LocalDrivingLicenseApplicationID)
        {
            string query = @"SELECT PassedTestCount = count(TestTypeID)
                         FROM Tests INNER JOIN
                         TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
						 where LocalDrivingLicenseApplicationID =@localDrivingApplicationID and TestResult=1";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@localDrivingApplicationID", LocalDrivingLicenseApplicationID);
            int count = 0;
            try
            {
                connection.Open();
                count = (int)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }
            return count;

        }
        public static bool GetLastTestByPersonAndTestTypeAndClass(int personID, int LicenseClass, int testType,
            ref int TestAppointmentID, ref bool testResults, ref string note, ref int createdByUserID)
        {
            string query = @"SELECT Tests.TestID,Tests.TestAppointmentID, Tests.TestResult,Tests.Notes, Tests.CreatedByUserID, Applications.ApplicantPersonID

    FROM LocalDrivingLicenseApplications INNER JOIN Tests INNER JOIN TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
	ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
    Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID

                WHERE        (Applications.ApplicantPersonID = @applicantPersonID) 
                        AND (LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID)
                        AND ( TestAppointments.TestTypeID= @TestTypeID)
                ORDER BY Tests.TestAppointmentID DESC;";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@applicantPersonID", personID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClass);
            command.Parameters.AddWithValue("@TestTypeID", testType);
            bool isFound = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    TestAppointmentID = Convert.ToInt32(reader["TestAppointmentID"]);
                    testResults = Convert.ToBoolean(reader["TestResult"]);
                    note = reader["Notes"].ToString();
                    createdByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    isFound = true;
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }

            return isFound;



        }






    }
}
