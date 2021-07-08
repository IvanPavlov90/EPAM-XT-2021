using System;
using System.Globalization;

namespace EPAM.AwardsAndUsers.PL.WebPL.Models
{
    public class InputHelper
    {
        public DateTime InputDate(string birthdate)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            string format = "dd.MM.yyyy";
            if (DateTime.TryParseExact(birthdate, format, provider, DateTimeStyles.None, out DateTime result))
                return result;
            else
                throw new ArgumentException("Date isn't in correct format");
        }

        public bool CheckAuthParametres(string param)
        {
            if (param.Trim().Length == 0 || param == String.Empty || param == null)
                return false;
            return true;
        }
    }
}