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
    public class clsLicencesClassesDataAccess
    {

        static public bool GetLicencesClassInfoByID(int LicenseClassID, ref string ClassName, ref string ClassDescription, ref byte minimumAge
            , ref byte validityLength, ref Decimal CassFee)
        {


            string query = "Select * from LicenseClasses where LicenseClassID = @LicenseClassID";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            bool isFound = false;
            try
            {
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    ClassName = reader["ClassName"].ToString();
                    ClassDescription = reader["ClassDescription"].ToString();
                    minimumAge = Convert.ToByte(reader["MinimumAge"]);
                    validityLength = Convert.ToByte(reader["ValidityLength"]);
                    CassFee = Convert.ToDecimal(reader["CassFee"]);
                    isFound = true;
                }
            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }
            return isFound;

        }


        static public DataTable GetLicencesClasses()
        {

            DataTable dt = new DataTable();

            string Query = "Select * from LicenseClasses";

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

        static public int InsertLicenceClass(string ClassName, string ClassDescription, byte minimumAge, byte validityLength, Decimal CassFee)
        {
            int newLicenseClassID = -1;
            string query = "Insert into LicenseClasses (ClassName, ClassDescription, MinimumAge, ValidityLength, CassFee) " +
                "values (@ClassName, @ClassDescription, @MinimumAge, @ValidityLength, @CassFee); " +
                "Select SCOPE_IDENTITY()";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            command.Parameters.AddWithValue("@MinimumAge", minimumAge);
            command.Parameters.AddWithValue("@ValidityLength", validityLength);
            command.Parameters.AddWithValue("@CassFee", CassFee);
            try
            {
                Connection.Open();
                newLicenseClassID = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }
            return newLicenseClassID;
        }

        static public bool UpdateLicenceClass(int LicenseClassID, string ClassName, string ClassDescription, byte minimumAge, byte validityLength, Decimal CassFee)
        {
            bool isUpdated = false;
            string query = "Update LicenseClasses set ClassName = @ClassName, ClassDescription = @ClassDescription, " +
                "MinimumAge = @MinimumAge, ValidityLength = @ValidityLength, CassFee = @CassFee where LicenseClassID = @LicenseClassID";
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            command.Parameters.AddWithValue("@MinimumAge", minimumAge);
            command.Parameters.AddWithValue("@ValidityLength", validityLength);
            command.Parameters.AddWithValue("@CassFee", CassFee);
            try
            {
                Connection.Open();
                isUpdated = command.ExecuteNonQuery() > 0;
            }
            catch (Exception ex) { }
            finally
            {
                Connection.Close();
            }
            return isUpdated;



        }



    }
}
