using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Task_4
{
    public static class InputHelper
    {
        public static DateTime InputDate()
        {
            try
            {
                string value;
                do
                {
                    Print.PrintMessage("Please, enter date in format day.month.year hour:minute:seconds, for example 18.04.2020 10:01:43");
                    value = Console.ReadLine();
                    CultureInfo provider = CultureInfo.InvariantCulture;
                    string format = "dd.MM.yyyy HH:mm:ss";
                    var dateTime = DateTime.ParseExact(value, format, provider);
                    return dateTime;
                } while (value.Trim().Length <= 0);
            }
            catch (FormatException)
            {
                Print.PrintMessage("Your date is not valid. Try Again.");
                DateTime defaultDate = new DateTime(2000, 1, 1);
                return defaultDate;
            }
        }
    }
}
