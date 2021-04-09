using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3._1.Classes
{
    public static class Validator
    {
        /// <summary>
        /// Method for user input
        /// </summary>
        public static int InputValue ()
        {
            string uservalue = Console.ReadLine();
            int.TryParse(uservalue, out int value);
            return value;
        }

        /// <summary>
        /// Method for checking user input
        /// </summary>
        /// <returns>Valid int intput</returns>
        public static int CheckValue(int value)
        {
            while (value <= 1)
            {
                Console.WriteLine($"Вы ввели неверное значение. Исправьте, пожалуйста.");
                string uservalue = Console.ReadLine();
                int.TryParse(uservalue, out value);
            }
            return value;
        }
    }
}
