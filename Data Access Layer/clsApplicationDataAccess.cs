using DataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Data_Access_Layer
{
    public class clsApplicationDataAccess
    {


        public static bool GetApplicationInfoByID
            (int ApplicationID, ref int ApplicantID, ref DateTime ApplicationDate,
           ref byte ApplicationType, ref byte ApplicationStatus, ref DateTime LastStatusDate,
           ref decimal paidFee, ref int CreatedByUserID)
        {

            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"select * FROM Applications  where ApplicationID = @applicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@applicationID", ApplicationID);


            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {

                    isFound = true;

                    ApplicantID = (int)reader["ApplicantPersonID"];
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    ApplicationType = Convert.ToByte(reader["ApplicationTypeID"]);
                    ApplicationStatus = Convert.ToByte(reader["ApplicationStatus"]);
                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    paidFee = (decimal)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                }


            }
            catch (Exception e)
            {

            }
            finally
            {

                connection.Close();
            }

            return isFound;

        }

        public static int AddNewApplication(int ApplicantID, DateTime ApplicationDate,
           byte ApplicationType, byte ApplicationStatus, DateTime LastStatusDate,
           decimal paidFee, int CreatedByUserID)
        {


            int newApplicationID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Applications (ApplicantPersonID,ApplicationDate,
                             ApplicationTypeID,ApplicationStatus,LastStatusDate,PaidFees,CreatedByUserID)
                             VALUES (@ApplicantPersonID,@ApplicationDate,
                             @ApplicationTypeID,@ApplicationStatus,@LastStatusDate,@PaidFees,@CreatedByUserID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantID);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationType);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", paidFee);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);



            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    newApplicationID = Convert.ToInt32(result);
                }
            }
            catch (Exception e)
            {
                // Handle exception (e.g., log the error)
                newApplicationID = -1;
            }
            finally
            {
                connection.Close();
            }

            return newApplicationID;

        }

        public static bool UpdateApplicationInfoByID(int applicationID, int ApplicantID, DateTime ApplicationDate,
           byte ApplicationType, byte ApplicationStatus, DateTime LastStatusDate,
           decimal paidFee, int CreatedByUserID)
        {




            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Applications set
                             ApplicantPersonID =@ApplicantPersonID,
                             ApplicationDate = @ApplicationDate,
                             ApplicationTypeID = @ApplicationTypeID,
                             ApplicationStatus = @ApplicationStatus,
                             LastStatusDate = @LastStatusDate,
                              PaidFees = @PaidFees,
                              CreatedByUserID = @CreatedByUserID 
                            where ApplicationID = @applicationID;         
                        ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@applicationID", applicationID);

            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantID);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationType);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", paidFee);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            int effectedRows = 0;
            try
            {
                connection.Open();
                effectedRows = command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                // Handle exception (e.g., log the error)
                effectedRows = -1;
            }
            finally
            {
                connection.Close();
            }

            return (effectedRows > 0);

        }

        public static DataTable GetAllApplications()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select ApplicationID,ApplicantPersonID,ApplicationDate,CreatedByUserID,ApplicationTypeTitle,
                    case when ApplicationStatus = 1 then 'new'
                         when ApplicationStatus = 2 then 'in proccess'
                        else 'complete'
                        end as applicationStatus,
                        LastStatusDate,PaidFees
           from Applications
           inner join ApplicationTypes on ApplicationTypes.ApplicationTypeID = Applications.ApplicationTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;


        }

        public static bool DeleteApplicationInfoByID(int applicationID)
        {

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete from Applications where ApplicationID = @applicationID ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@applicationID", applicationID);

            int effectedRows = 0;

            try
            {
                connection.Open();
                effectedRows = command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                // Handle exception (e.g., log the error)

            }
            finally
            {
                connection.Close();
            }

            return (effectedRows > 0);

        }

        public static bool isApplicationExist(int applicationID)
        {

            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select found=1 from Applications where ApplicationID = @applicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@applicationID", applicationID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    isFound = true;
                }
            }
            catch (Exception e)
            {
                // Handle exception (e.g., log the error)

            }
            finally
            {
                connection.Close();
            }

            return isFound;

        }

        public static bool DoesPersonHaveActiveApplication(int personID, byte applicationType)
        {

            return GetActiveApplicationID(personID, applicationType) != -1;

        }

        public static int GetActiveApplicationID(int personID, int applicationType)
        {

            int ActiveApplicationID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"Select ActiveApplicationID = ApplicationID from Applications
                        where ApplicantPersonID = @applicantPersonID and ApplicationTypeID = @applicationTypeID and ApplicationStatus = 1 ";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@applicantPersonID", personID);
            command.Parameters.AddWithValue("@applicationTypeID", applicationType);


            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    ActiveApplicationID = Convert.ToInt32(result);
                }
            }
            catch (Exception e)
            {
                // Handle exception (e.g., log the error)
                ActiveApplicationID = -1;
            }
            finally
            {
                connection.Close();
            }

            return ActiveApplicationID;
        }

        public static bool UpdateApplicationStatus(int applicationID, byte ApplicationStatus)
        {

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Applications set ApplicationStatus = @ApplicationStatus,
                             LastStatusDate = @LastStatusDate
                            where ApplicationID = @applicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@applicationID", applicationID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);

            int effectedRows = 0;

            try
            {
                connection.Open();
                effectedRows = command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                // Handle exception (e.g., log the error)
                return false;
            }
            finally
            {
                connection.Close();

            }
            return (effectedRows > 0);

        }

        public static int GetActiveApplicationIDForLicenseClass(int personID, int applicationTypeID, int licenseClassID)
        {
            string query = @"SELECT  Applications.ApplicationID
                         FROM Applications INNER JOIN
                         LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID INNER JOIN
                         LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID
						 where LicenseClasses.LicenseClassID = @LicenseClasses and ApplicantPersonID = @ApplicantPersonID 
                         and ApplicationTypeID = @ApplicationTypeID and ApplicationStatus = 1;";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicantPersonID", personID);
            command.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeID);
            command.Parameters.AddWithValue("@LicenseClasses", licenseClassID);
            int ActiveApplicationID = -1;
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    ActiveApplicationID = Convert.ToInt32(result);
                }
            }
            catch (Exception e)
            {
                // Handle exception (e.g., log the error)
                return -1;
            }
            finally
            {
                connection.Close();
            }
            return ActiveApplicationID;


        }
    }
}
