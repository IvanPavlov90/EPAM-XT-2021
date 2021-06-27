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

        public string CheckAuthParametres(string param)
        {
            if (param.Trim().Length == 0 || param == String.Empty)
            {
                throw new ArgumentException($"You can't put empty or white space string into username");
            }
            return param;
        }
    }
}