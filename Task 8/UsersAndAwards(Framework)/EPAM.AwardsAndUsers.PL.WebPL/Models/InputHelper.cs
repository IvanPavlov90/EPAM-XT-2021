using System;
using System.Globalization;

namespace EPAM.AwardsAndUsers.PL.WebPL.Models
{
    public static class InputHelper
    {
        public static DateTime InputDate(string birthdate)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            string format = "dd.MM.yyyy";
            if (DateTime.TryParseExact(birthdate, format, provider, DateTimeStyles.None, out DateTime result))
                return result;
            else
                throw new ArgumentException("Date isn't in correct format");
        }
    }
}