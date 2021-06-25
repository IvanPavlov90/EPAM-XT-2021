using System;
using System.Globalization;

namespace EPAM.AwardsAndUsers
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

        public static int UserChoise(int length)
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

        public static bool AskUserForDeletingAward()
        {
            Console.WriteLine("Some users have this award. Do you really want to delete it? Y/N");
            string answer;
            do
            {
                answer = Console.ReadLine();
                if (answer == "Y")
                    return true;
                else if (answer == "N")
                    return false;
            } while (true);
        }
    }
}
