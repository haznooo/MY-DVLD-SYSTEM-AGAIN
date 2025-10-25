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
    public class clsTestTypesDataAccess
    {
        static public DataTable GetTestTypes()
        {

            DataTable dt = new DataTable();

            string Query = "Select * from TestTypes";

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

        public static bool UpdateTestType(int TestTypeID, string TestTypeTitle,string TestTypeDesription, decimal TestTypeFee)
        {

            int rowsEffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Update TestTypes 
             
                                      set  TestTypeTitle = @TestTypeTitle, 
                                           TestTypeFees = @TestFees,
                                             TestTypeDescription = @TestTypeDescription
             
                                          where TestTypeID = @TestTypesID";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            command.Parameters.AddWithValue("@TestFees", TestTypeFee);
            command.Parameters.AddWithValue("@TestTypesID", TestTypeID);
            command.Parameters.AddWithValue("@TestTypeDescription",TestTypeDesription);




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

        public static bool GetTestTypeInfoByID(int TestTypeID, ref string TestTypeTitle,ref string TestTypeDesrcription, ref decimal TestTypeFee)

        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"select * FROM TestTypes   where TestTypeID = @TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


            try
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {

                    isFound = true;

                    TestTypeTitle = (string)reader["TestTypeTitle"];
                    TestTypeFee = (decimal)reader["TestTypeFees"];
                    TestTypeDesrcription = (string)reader["TestTypeDescription"];

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

