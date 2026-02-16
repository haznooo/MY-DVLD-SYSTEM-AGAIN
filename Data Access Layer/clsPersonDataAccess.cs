using System;
using System.Data;
using System.Data.SqlClient;


namespace DataAccessLayer
{
    public class clsPersonDataAccess
    {

        public static bool GetPersonInfoByID(int PersonID, ref string NationalNumber, ref string FirstName, ref string SecondName, ref string ThirdName
             , ref string LastName, ref DateTime DateOfBirth, ref byte gender, ref string Address, ref string Phone, ref string Email, ref int CountryID, ref string ImagePath)
        {


            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"select PersonID,NationalNumber,FirstName,SecondName,ThirdName,LastName,DateOfBirth,Gender,

                   CASE WHEN Gender = 0 THEN 'Male' 
                      WHEN Gender = 1 THEN 'Female' 
                     ELSE 'Unknown' END AS GenderCaption
                ,Address,Phone,Email,CountryID,ImagePath 
                FROM People  where PersonID = @personID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("personID", PersonID);


            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {

                    isFound = true;

                    NationalNumber = (string)reader["NationalNumber"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    if (reader["ThirdName"] != DBNull.Value)
                    {

                        ThirdName = (string)reader["ThirdName"];
                    }
                    else
                    {
                        ThirdName = "";
                    }

                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    gender = (byte)reader["Gender"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];

                    if (reader["Email"] != DBNull.Value)
                    {
                        Email = (string)reader["Email"];
                    }
                    else
                    {
                        Email = "";
                    }

                    CountryID = (int)reader["CountryID"];

                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }

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


        public static bool GetPersonInfoByNationalNumber(ref int PersonID, string NationalNumber, ref string FirstName, ref string SecondName, ref string ThirdName
      , ref string LastName, ref DateTime DateOfBirth, ref byte gender, ref string Address, ref string Phone, ref string Email, ref int CountryID, ref string ImagePath)
        {


            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"select PersonID,NationalNumber,FirstName,SecondName,ThirdName,LastName,DateOfBirth,Gender,

                   CASE WHEN Gender = 0 THEN 'Male' 
                      WHEN Gender = 1 THEN 'Female' 
                     ELSE 'Unknown' END AS GenderCaption
                ,Address,Phone,Email,CountryID,ImagePath 
                FROM People  where Nationalnumber = @nationalNumber";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("nationalNumber", PersonID);


            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {

                    isFound = true;

                    NationalNumber = (string)reader["NationalNumber"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];

                    if (reader["ThirdName"] != DBNull.Value)
                    {

                        ThirdName = (string)reader["ThirdName"];
                    }
                    else
                    {
                        ThirdName = "";
                    }

                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    gender = (byte)reader["Gender"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];

                    if (reader["Email"] != DBNull.Value)
                    {
                        Email = (string)reader["Email"];
                    }
                    else
                    {
                        Email = "";
                    }

                    CountryID = (int)reader["CountryID"];

                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }


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

        public static int AddNewPerson(string NationalNumber, string FirstName, string SecondName, string ThirdName, string LastName,
           DateTime DateOfBirth, byte Gender, string Address, string Phone, string Email, int CountryID, string ImagePath)
        {
            //this function will return the new person id if succeeded and -1 if not.
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO People (NationalNumber,FirstName,SecondName,ThirdName, LastName, Email,Phone, Address,DateOfBirth, CountryID,ImagePath,Gender)
                             VALUES (@nationalnumber,@FirstName,@secondName,@thirdName,@LastName, @Email, @Phone, @Address,@DateOfBirth, @CountryID,@ImagePath,@Gender);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@nationalnumber", NationalNumber);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@secondName", SecondName);

            if (ThirdName != "")
                command.Parameters.AddWithValue("@thirdName", ThirdName);
            else
                command.Parameters.AddWithValue("@thirdName", System.DBNull.Value);

            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);

            if (Email != "")
                command.Parameters.AddWithValue("@Email", Email);
            else
                command.Parameters.AddWithValue("@Email", System.DBNull.Value);


            command.Parameters.AddWithValue("@CountryID", CountryID);

            if (ImagePath != "")
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);



            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    PersonID = insertedID;
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


            return PersonID;
        }

        public static bool UpdatePerson(int PersonID, string NationalNumber, string FirstName, string SecondName, string ThirdName, string LastName,
             DateTime DateOfBirth, byte gender, string Address, string Phone, string Email, int CountryID, string ImagePath)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update People 
                            set NationalNumber = @nationalNumber,
                                FirstName = @FirstName, 
                                SecondName = @secondName,
                                ThirdName = @thirdName,
                                LastName = @LastName, 
                                DateOfBirth = @DateOfBirth,
                                Gender = @gender,
                                Address = @Address,
                                Phone = @Phone, 
                                Email = @Email,      
                                CountryID = @CountryID,
                                ImagePath =@ImagePath
                                where PersonID = @personID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@personID", PersonID);
            command.Parameters.AddWithValue("@nationalNumber", NationalNumber);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@secondName", SecondName);

            if (!string.IsNullOrEmpty(ThirdName))
                command.Parameters.AddWithValue("@thirdName", ThirdName);
            else
                command.Parameters.AddWithValue("@thirdName", System.DBNull.Value);

            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gender", gender);

            if (!string.IsNullOrEmpty(Email))
                command.Parameters.AddWithValue("@Email", Email);
            else
                command.Parameters.AddWithValue("@Email", System.DBNull.Value);

            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            if (!string.IsNullOrEmpty(ImagePath))
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

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

        public static DataTable GetPeople()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"select PersonID,NationalNumber,FirstName,SecondName,ThirdName,LastName,DateOfBirth,Gender,

                   CASE WHEN Gender = 0 THEN 'Male' 
                      WHEN Gender = 1 THEN 'Female' 
                     ELSE 'Unknown' END AS GenderCaption
                ,Address,Phone,Email,CountryID,ImagePath 
                FROM People";



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

        public static bool DeletePerson(int personID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete People
                                where PersonID = @personID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@personID", personID);

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

        public static bool IsPersonExist(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM People WHERE PersonID = @personID";

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

        public static bool IsPersonExist(string NationalNumber)
        {

            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM People WHERE NationalNumber = @nationalNumber";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@nationalNumber", NationalNumber);

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

    }
}
