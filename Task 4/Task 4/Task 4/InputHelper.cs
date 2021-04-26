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
            string value;
            do
            {
                Print.PrintMessage("Please, enter date in format day.month.year hour:minute:seconds, for example 18.04.2020 10:01:43");
                value = Console.ReadLine();
                CultureInfo provider = CultureInfo.InvariantCulture;
                string format = "dd.MM.yyyy HH:mm:ss";
                if (DateTime.TryParseExact(value, format, provider, DateTimeStyles.None, out DateTime result))
                    return result;
                else
                    Console.WriteLine("You have entered uncorrect date.");
            } while (true);
        }
    }
}
