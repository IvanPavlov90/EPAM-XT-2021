﻿using System;
using System.Globalization;


namespace EPAM.UsersAndAwards.PL.ConsolePL
{
    public static class InputHelper
    {
        public static DateTime InputDate()
        {
            string value;
            do
            {
                value = Console.ReadLine();
                CultureInfo provider = CultureInfo.InvariantCulture;
                string format = "dd.MM.yyyy";
                if (DateTime.TryParseExact(value, format, provider, DateTimeStyles.None, out DateTime result))
                    return result;
                else
                    Console.WriteLine("You have entered uncorrect date.");
            } while (true);
        }

        public static int UserChoise (int length)
        {
            int result;
            do
            {
                string value = Console.ReadLine();
                Int32.TryParse(value, out result);
                if (result >= 1 && result <= length)
                    return result;
                else
                    Console.WriteLine("You have entered wrong index.");
            } while (true);
        }
    }
}
