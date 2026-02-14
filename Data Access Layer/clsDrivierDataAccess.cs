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
    public class clsDrivierDataAccess
    {

        public static bool GetDriverInfoByDrivierID(int DriverID, ref int personID, ref int CreatedByUserID,
            ref DateTime CreateDate)
        {
            string query = "select * from Drivers where DriverID = @driverID";

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Coomand = new SqlCommand(query, Connection);
            Coomand.Parameters.AddWithValue("@driverID", DriverID);
            bool isFound = false;

            try
            {

                Connection.Open();
                SqlDataReader reader = Coomand.ExecuteReader();

                while (reader.HasRows)
                {

                    personID = Convert.ToInt32(reader["PersonID"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    CreateDate = Convert.ToDateTime(reader["CreateDate"]);
                    isFound = true;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
            }
            finally {

                Connection.Close();
            }
            return isFound;



        }

        public static DataTable GetAllDriversInf() 
      {
        
            DataTable dt = new DataTable();
            string query = "select * from Drivers_View";

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Coomand = new SqlCommand(query,Connection);

            try
            {

                Connection.Open();
                SqlDataReader reader = Coomand.ExecuteReader();

                if (reader.HasRows)
                {

                    dt.Load(reader);
                }
                reader.Close() ;


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }


            return dt;

        }

        public static int addNewDriver(ref int personID, ref int CreatedByUserID,
            ref DateTime CreateDate)     
        {
            string query = "insert into Drivers (personID,CreatedByUserID,CreateDate) values (@personID,@CreatedByUserID,@CreateDate);SELECT SCOPE_IDENTITY();";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Coomand = new SqlCommand( query,Connection);

            Coomand.Parameters.AddWithValue("@personID", personID);
            Coomand.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Coomand.Parameters.AddWithValue("@CreateDate", CreateDate);

            int NewID = -1;

            try 
            {
                Connection.Open();
                object result = Coomand.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    NewID = insertedID;
                }


            }
            catch (Exception ex) { }
            finally { Connection.Close(); }
            return NewID;


        }

        public static bool UpdateDriver(int driverID, int personID, int CreatedByUserID,
            DateTime CreateDate)
        {

            string query = @"update Drivers 
                             set PersonID = @PersonID,
                             CreatedByUserID = @CreatedByUserID,
                             CreateDate = @CreateDate 
                             where DriverID = @DriverID;
                                                          ";

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Coomand = new SqlCommand(query, Connection);
            int rowEffected = 0;
            try
            {

                Connection.Open();
                rowEffected = Coomand.ExecuteNonQuery();

          
            }
            catch (Exception ex) { }
            finally { Connection.Close(); }

            return rowEffected > 0;
            

        }

        public static bool GetDriverInfoByPersonID(ref int DriverID,int personID, ref int CreatedByUserID,
            ref DateTime CreateDate)
        {
            string query = "select * from Drivers where PersonID = @PersonId";

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand Coomand = new SqlCommand(query, Connection);
            Coomand.Parameters.AddWithValue("@PersonId", personID);
            bool isFound = false;

            try
            {

                Connection.Open();
                SqlDataReader reader = Coomand.ExecuteReader();

                while (reader.Read())
                {

                    DriverID = Convert.ToInt32(reader["DriverID"]);
                    CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"]);
                    CreateDate = Convert.ToDateTime(reader["CreateDate"]);
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

    }

    }

    

    

