using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class clsLicenseDataAccess
    {
        static public bool GetLicenseInfobyID(int LicneseID,ref int applicationID,ref int DriverId,ref int LicenseClass,
            ref int CreatedByUserID,ref DateTime IssueDate,ref DateTime ExpirationDate, ref string Notes,ref decimal paidfees,
            ref bool isActive,ref int IssueReason)
        {
            string query = "select * from Licenses where LicenseID = @LicenseID";

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Coomand = new SqlCommand(query, Connection);
            Coomand.Parameters.AddWithValue("@LicenseID", LicneseID);
            bool isFound = false;

            try
            {

                Connection.Open();
                SqlDataReader reader = Coomand.ExecuteReader();

                while (reader.Read())
                {
               
                    applicationID =   Convert.ToInt32(reader["ApplicationID"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    DriverId =        Convert.ToInt32(reader["DriverID"]);
                    LicenseClass = Convert.ToInt32(reader["LicenseClass"]);
                    IssueDate   = Convert.ToDateTime(reader["IssueDate"]);
                    ExpirationDate  = Convert.ToDateTime(reader["ExpirationDate"]);
                    paidfees = Convert.ToInt32(reader["PaidFees"]);
                    isActive = Convert.ToBoolean(reader["IsActive"]);
                    IssueReason = Convert.ToInt32(reader["IssueReason"]);
                    if (reader["Notes"] == DBNull.Value)
                    {
                        Notes = "";
                    }
                    else 
                    { Notes = reader["Notes"].ToString(); }
                    isFound = true;

                   



                }
                reader.Close();

            }
            catch (Exception ex)
            {
            }
            finally
            {

                Connection.Close();
            }
            return isFound;


        }

        static public bool GetLicenseInfobyApplicatoinID(ref int LicneseID,int applicationID, ref int DriverId, ref int LicenseClass,
           ref int CreatedByUserID, ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes, ref decimal paidfees,
           ref bool isActive, ref int IssueReason)
        {
            string query = "select * from Licenses where ApplicationID = @applicationID;";

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Coomand = new SqlCommand(query, Connection);
            Coomand.Parameters.AddWithValue("@applicationID", applicationID);
            bool isFound = false;

            try
            {

                Connection.Open();
                SqlDataReader reader = Coomand.ExecuteReader();

                while (reader.Read())
                {

                    LicneseID = Convert.ToInt32(reader["LicenseID"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    DriverId = Convert.ToInt32(reader["DriverID"]);
                    LicenseClass = Convert.ToInt32(reader["LicenseClass"]);
                    IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                    ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                    paidfees = Convert.ToInt32(reader["PaidFees"]);
                    isActive = Convert.ToBoolean(reader["IsActive"]);
                    IssueReason = Convert.ToInt32(reader["IssueReason"]);
                    if (reader["Notes"] == DBNull.Value)
                    {
                        Notes = "";
                    }
                    else
                    { Notes = reader["Notes"].ToString(); }
                    isFound = true;





                }
                reader.Close();

            }
            catch (Exception ex)
            {
            }
            finally
            {

                Connection.Close();
            }
            return isFound;


        }
        static public DataTable GetAllLicenses() 
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select * from Licenses";

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
        static public DataTable GetDriverLicenses(int driverID) 
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT     
                           Licenses.LicenseID,
                           ApplicationID,
		                   LicenseClasses.ClassName, Licenses.IssueDate, 
		                   Licenses.ExpirationDate, Licenses.IsActive
                           FROM Licenses INNER JOIN
                                LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID
                            where DriverID=@DriverID
                            Order By IsActive Desc, ExpirationDate Desc";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", driverID);

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
        static public int AddNewLicense(int applicationID,int DriverId,int LicenseClass,
         int CreatedByUserID,DateTime IssueDate,DateTime ExpirationDate,string Notes,decimal paidfees,
         bool isActive,int IssueReason) 

        {
            string query = @"insert into Licenses
(ApplicationID,CreatedByUserID,DriverID,
LicenseClass,IssueDate,ExpirationDate,PaidFees,IssueReason,IsActive,Notes) values
(@ApplicationID,@CreatedByUserID,@DriverID,
@LicenseClass,@IssueDate,@ExpirationDate,@PaidFees,@IssueReason,@IsActive,@Notes);
 SELECT SCOPE_IDENTITY();
";

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Coomand = new SqlCommand(query, Connection);


            Coomand.Parameters.AddWithValue("@ApplicationID", applicationID);
            Coomand.Parameters.AddWithValue("@DriverID", DriverId);
            Coomand.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            Coomand.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Coomand.Parameters.AddWithValue("@IssueDate", IssueDate);
            Coomand.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            Coomand.Parameters.AddWithValue("@PaidFees", paidfees);
            Coomand.Parameters.AddWithValue("@IsActive", isActive);
            Coomand.Parameters.AddWithValue("@IssueReason", IssueReason);
            if (Notes == "")
                Coomand.Parameters.AddWithValue("@Notes", DBNull.Value);
            else Coomand.Parameters.AddWithValue("@Notes", Notes);

            int isAdded = -1;

            try
            {

                Connection.Open();
                isAdded = Convert.ToInt32(Coomand.ExecuteScalar());

            }
            catch (Exception ex)
            {
            }
            finally
            {

                Connection.Close();
            }
            return isAdded;


        }
        static public bool updateLicense(int LicneseID,int applicationID,int DriverId,int LicenseClass,
          int CreatedByUserID,DateTime IssueDate,DateTime ExpirationDate,string Notes,decimal paidfees,
          bool isActive,int IssueReason) 
        {
            string query = @"Update Licenses set
                             ApplicationID = @ApplicationID,                 
                             CreatedByUserID = @CreatedByUserID,
                             DriverID = @DriverID,
                             LicenseClass = @LicenseClass
                             IssueDate = @IssueDate,
                             ExpirationDate = @ExpirationDate,
                             PaidFees = @PaidFees,
                             IsActive = @IsActive,
                             IssueReason = @IssueReason,
                             Notes = @Notes
                             where LicenseID = @LicenseID ";

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Coomand = new SqlCommand(query, Connection);

            Coomand.Parameters.AddWithValue("@LicenseID", LicneseID);
            Coomand.Parameters.AddWithValue("@ApplicationID", applicationID);
            Coomand.Parameters.AddWithValue("@DriverID", DriverId);
            Coomand.Parameters.AddWithValue("@DriverID", LicenseClass);
            Coomand.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Coomand.Parameters.AddWithValue("@IssueDate", IssueDate);
            Coomand.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            Coomand.Parameters.AddWithValue("@PaidFees", paidfees);
            Coomand.Parameters.AddWithValue("@IsActive", isActive);
            Coomand.Parameters.AddWithValue("@IssueReason", IssueReason);
            if(Notes == "")
            Coomand.Parameters.AddWithValue("@Notes", DBNull.Value);
            else Coomand.Parameters.AddWithValue("@Notes",Notes);

            bool isFound = false;

            try
            {

                Connection.Open();
                SqlDataReader reader = Coomand.ExecuteReader();

                while (reader.HasRows)
                {

                   

                    applicationID = Convert.ToInt32(reader["ApplicationID"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    DriverId = Convert.ToInt32(reader["DriverID"]);
                    LicenseClass = Convert.ToInt32(reader["LicenseClass"]);
                    IssueDate = Convert.ToDateTime(reader["IssueDate"]);
                    ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]);
                    paidfees = Convert.ToInt32(reader["PaidFees"]);
                    isActive = Convert.ToBoolean(reader["IsActive"]);
                    IssueReason = Convert.ToInt32(reader["IssueReason"]);
                    if (reader["Notes"] == DBNull.Value)
                    {
                        Notes = "";
                    }
                    else
                    { Notes = reader["Notes"].ToString(); }

                    isFound = true;



                }
                reader.Close();

            }
            catch (Exception ex)
            {
            }
            finally
            {

                Connection.Close();
            }
            return isFound;


        }
        static public int GetActiveLicenseIDByPersonID(int personID, int LicenseClassID) {

            int LicenseID = -1;

            string query = @"SELECT        Licenses.LicenseID
                            FROM Licenses INNER JOIN
                                                     Drivers ON Licenses.DriverID = Drivers.DriverID
                            WHERE  
                             
                             Licenses.LicenseClass = @LicenseClass 
                              AND Drivers.PersonID = @PersonID
                              And IsActive=1;";


            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClassID);
            command.Parameters.AddWithValue("@PersonID", personID);

            try
            {
                Connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LicenseID = insertedID;
                }
            }
            catch
            {
            }
            finally 
            {
                Connection.Close();
            }
            return LicenseID;


        }
        static public bool DeActiveLicense(int LicneseID) 
        {
            string query = "update Licenses set IsActive = 0 where LicneseID = @licneseID ";

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Coomand = new SqlCommand(query, Connection);
            Coomand.Parameters.AddWithValue("@licneseID", LicneseID);

            int rowEffected = 0;

            try
            {
                Connection.Open();
                rowEffected = Coomand.ExecuteNonQuery();

            }
            catch
            { }
            finally
            { Connection.Close(); }


            return rowEffected > 0;

        }


    }
}
