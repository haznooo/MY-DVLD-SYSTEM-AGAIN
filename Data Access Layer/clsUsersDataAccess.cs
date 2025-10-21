using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsUsersDataAccess
    {

        public static bool GetUserInfoByUserID(int UserID, ref string UserName,
            ref int PersonID,ref string Password,ref bool isActive)
        {


            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"select * from Users  where UserID = @userID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@userID", UserID);


            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {

                    isFound = true;

                    UserID   = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    Password = (string)reader["Password"];
                    UserName = (string)reader["UserName"];
                    isActive = (bool)reader["IsActive"];
                 
                }
                reader.Close();

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

        public static bool GetUserInfoByUsernameAndPassword(ref int UserID,string UserName,
            ref int PersonID,string Password,ref bool isActive)
        {


            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"select * from Users where UserName = @userName and Password = @password";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@userName", UserName);
            command.Parameters.AddWithValue("@password", Password);


            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {

                    isFound = true;

                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    Password = (string)reader["Password"];
                    UserName = (string)reader["UserName"];
                    isActive = (bool)reader["IsActive"];

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

        public static bool GetUserInfoByPersonID(ref int UserID,ref string UserName,
        int PersonID, ref string Password, ref bool isActive)
        {


            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"select * from Users where PersonID = @personID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@personID", PersonID);

            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {

                    isFound = true;

                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    Password = (string)reader["Password"];
                    UserName = (string)reader["UserName"];
                    isActive = (bool)reader["IsActive"];
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

        public static int AddNewUser( string UserName, int PersonID, string Password
                                       ,bool isActive)
        {

            int UserId = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Users (UserName,PersonID,Password,IsActive)
                             VALUES (@UserName,@PersonID,@Password,@IsActive);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", isActive);
         
    
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    UserId = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return UserId;
        }
        public static bool UpdateUser(int UserID,string UserName,int PersonID,string Password
                                         ,bool isActive)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Users 
                            set UserName = @userName,
                                PersonID = @personID, 
                                Password = @password,
                                IsActive = @isActvie
                                  where UserID = @userID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@userName",  UserName);
            command.Parameters.AddWithValue("@personID", PersonID);
            command.Parameters.AddWithValue("@password", Password);
            command.Parameters.AddWithValue("@isActvie", isActive);
            command.Parameters.AddWithValue("@userID", UserID);




            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
        public static DataTable GetAllUsers()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"select Users.UserID,Users.PersonID,
              FullName = People.FirstName + ' '+ People.SecondName + ' '+ ISNULL(People.ThirdName +' ','') +' ' + People.LastName ,
              Users.UserName,Users.IsActive

              from Users
              inner join People on People.PersonID = Users.PersonID";

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

        public static bool DeleteUser(int UserID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Users
                                where UserID = @userID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@userID", UserID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);

        }

        public static bool IsUserExist(int UserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Users WHERE UserID = @userID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@userID", UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
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

        public static bool IsUserExist(string UserName)
        {

            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Users WHERE UserName = @userName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@userName", UserName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool IsPersonLinkedToUser(int PersonID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT Found=1 FROM Users WHERE PersonID = @personID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@personID", PersonID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

        public static bool ChangeUserPassword(int UserID, string NewPassword)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Update Users 
                            set Password = @password
                                  where UserID = @userID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@password", NewPassword);
            command.Parameters.AddWithValue("@userID", UserID);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
            return (rowsAffected > 0);
        }

    }


}

