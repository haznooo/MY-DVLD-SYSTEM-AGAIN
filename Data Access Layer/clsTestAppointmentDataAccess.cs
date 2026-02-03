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
    public class clsTestAppointmentDataAccess
    {

        public static bool GetTestApppointmentByID(int testAppointmentID, ref int testTypeID,
            ref int LocalDrivingLicensApplicationID, ref DateTime appointmentDate, ref float paidFees,
            ref int createdByUserID, ref bool isLocked
            )
        {
            bool isFound = false;

            string query = "SELECT * FROM TestAppointments WHERE TestAppointmentID = @testAppointmentID ";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@testAppointmentID", testAppointmentID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    testTypeID = Convert.ToInt32(reader["TestTypeID"]);
                    LocalDrivingLicensApplicationID = Convert.ToInt32(reader["LocalDrivingLicensApplicationID"]);
                    appointmentDate = Convert.ToDateTime(reader["AppointmentDate"]);
                    paidFees = Convert.ToSingle(reader["PaidFees"]);
                    createdByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    isLocked = Convert.ToBoolean(reader["IsLocked"]);
                    reader.Close();
                    isFound = true;
                }
                else
                {
                    reader.Close();

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

        public static bool GetLastTestAppointmentID(int LocalDrivingLicensApplication, int testTypeID,
            ref int testAppointmentID, ref DateTime appointmentDate, ref float paidFees, ref int createdByUserID
            , ref bool isLocked)
        {
            string query = @"Select top 1 * from TestAppointments 
                        where TestTypeID = @TestTypeID  and LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplication 
                        order by LocalDrivingLicenseApplicationID desc";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", testTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplication", LocalDrivingLicensApplication);
            bool isFound = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    testAppointmentID = Convert.ToInt32(reader["TestAppointmentID"]);
                    appointmentDate = Convert.ToDateTime(reader["AppointmentDate"]);
                    paidFees = Convert.ToSingle(reader["PaidFees"]);
                    createdByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    isLocked = Convert.ToBoolean(reader["IsLocked"]);
                    reader.Close();
                    isFound = true;
                }
                else
                {
                    reader.Close();

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

        public static DataTable GetAllTestAppointments()
        {
            string query = "select * from TestAppointments_View order by AppointmentDate desc ";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            DataTable dtTestAppointments = new DataTable();
            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dtTestAppointments);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return dtTestAppointments;

        }

        public static DataTable GetApplicationTestAppointmentsPerTestType(int localDrivingLicenseApplicationID, int testTypeID)
        {
            string query = @"select * from TestAppointments 
                    where TestTypeID = @TestTypeID 
                    and LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplication 
                    order by TestAppointment desc";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", testTypeID);
            DataTable dtTestAppointments = new DataTable();
            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dtTestAppointments);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return dtTestAppointments;
        }

        public static bool addTestAppointment(int testTypeID, int LocalDrivingLicensApplicationID,
         DateTime appointmentDate, float paidFees, int createdByUserID, bool isLocked)
        {
            string query = @"INSERT INTO TestAppointments
                        (TestTypeID,LocalDrivingLicensApplicationID,AppointmentDate,PaidFees,CreatedByUserID,IsLocked)
                        VALUES
                        (@TestTypeID,@LocalDrivingLicensApplicationID,@AppointmentDate,@PaidFees,@CreatedByUserID,@IsLocked)";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", testTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicensApplicationID", LocalDrivingLicensApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
            command.Parameters.AddWithValue("@PaidFees", paidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
            command.Parameters.AddWithValue("@IsLocked", isLocked);

            bool isAdded = false;
            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    isAdded = true;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return isAdded;



        }

        public static bool updateTestAppointment(int testAppointmentID, int testTypeID, int LocalDrivingLicensApplicationID,
         DateTime appointmentDate, float paidFees, int createdByUserID, bool isLocked)
        {
            string query = @"UPDATE TestAppointments SET
                        TestTypeID = @TestTypeID,
                        LocalDrivingLicensApplicationID = @LocalDrivingLicensApplicationID,
                        AppointmentDate = @AppointmentDate,
                        PaidFees = @PaidFees,
                        CreatedByUserID = @CreatedByUserID,
                        IsLocked = @IsLocked
                        WHERE TestAppointmentID = @TestAppointmentID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);
            command.Parameters.AddWithValue("@TestTypeID", testTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicensApplicationID", LocalDrivingLicensApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
            command.Parameters.AddWithValue("@PaidFees", paidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
            command.Parameters.AddWithValue("@IsLocked", isLocked);
            bool isUpdated = false;
            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    isUpdated = true;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return isUpdated;














































        }

        public static int GetTestID(int testAppointmentID) {
            string query = "select Tests.TestID from Tests where TestAppointmentID = @TestAppointmentID";
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", testAppointmentID);
            int testID = -1;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    testID = Convert.ToInt32(reader["TestID"]);
                    reader.Close();
                }
                else
                {
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }
            return testID;
        }





    }
}
