using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataAccessLayer;

namespace BusinessLayer
{
    public class clsCountry
    {
        public string _CountryName { get; set; }
        public int _CountryID { get; set; }

        private clsCountry(int ID, string CountryName)

        {
            this._CountryID = ID;
            this._CountryName = CountryName;
       
        }

  
        public static clsCountry Find(int CountryID)
        {

            string CountryName = "";

            if (clsCountryDataAccess.GetCountryInfo(CountryID, ref CountryName))

                return new clsCountry(CountryID, CountryName);
            else
                return null;

        }

        public static clsCountry Find(string CountryName)
        {

            int CountryID = -1;

            if (clsCountryDataAccess.GetCountryInfo(ref CountryID, CountryName))

                return new clsCountry(CountryID, CountryName);
            else
                return null;

        }

    
        public static DataTable GetAllCountries()
        {
            return clsCountryDataAccess.GetAllCountries();

        }

        public static bool isCountryExist(int CountryID)
        {
            return clsCountryDataAccess.IsCountryExist(CountryID);
        }

        public static bool isCountryExist(string CountryName)
        {
            return clsCountryDataAccess.IsCountryExist(CountryName);
        }


    }
}
