using DataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Data_Access_Layer
{
    public class clsApplicationTypesDataAccess
    {
        static public DataTable GetApplicationTypes()
        {

            DataTable dt = new DataTable();

            string Query = "Select * from ApplicationTypes";

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            SqlCommand command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    dt.Load(reader);

                }


            }
            catch (Exception ex) { }

            finally
            {

                Connection.Close();

            }

            return dt;

        }
        public static bool UpdateApplicationType(int ApplicationTypeID, string ApplicationTypeTitle, decimal ApplicationTYpeFee)
        {


            int rowsEffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"Update ApplicationTypes 

                            set  ApplicationTypeTitle = @ApplicationTypeTitle, 
                                 ApplicationFees = @ApplicationFees

                                where ApplicationTypeID = @ApplicationTypesID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
            command.Parameters.AddWithValue("@ApplicationFees", ApplicationTYpeFee);
            command.Parameters.AddWithValue("@ApplicationTypesID", ApplicationTypeID);



            try
            {
                connection.Open();
                rowsEffected = command.ExecuteNonQuery();

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

            return (rowsEffected > 0);
        }
        public static bool GetApplicationTypeInfoByID(int ApplicationTypeID, ref string ApplicationTypeTitle, ref decimal ApplicationTYpeFee)
        {


            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"select * FROM ApplicationTypes   where ApplicationTypeID = @applicationTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("applicationTypeID", ApplicationTypeID);


            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {

                    isFound = true;

                    ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                    ApplicationTYpeFee = (decimal)reader["ApplicationFees"];

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


    }

}

