using System.Text.RegularExpressions;

namespace DVLD.Classes
{
    public class clsValidatoin
    {

        public static bool ValidateEmail(string emailAddress)
        {

            var pattern = @"^[a-z0-9]+@gmail\.com$";

            var regex = new Regex(pattern);

            return regex.IsMatch(emailAddress.ToLower());
        }

        public static bool ValidateInteger(string Number)
        {
            var pattern = @"^[0-9]*$";

            var regex = new Regex(pattern);

            return regex.IsMatch(Number);
        }

        public static bool ValidateFloat(string Number)
        {
            var pattern = @"^[0-9]*(?:\.[0-9]*)?$";

            var regex = new Regex(pattern);

            return regex.IsMatch(Number);
        }

        public static bool IsNumber(string Number)
        {
            return (ValidateInteger(Number) || ValidateFloat(Number));
        }


    }
}
