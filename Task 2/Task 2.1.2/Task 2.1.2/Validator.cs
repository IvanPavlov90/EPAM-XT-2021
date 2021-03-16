using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2
{
    public static class Validator
    {
        /// <summary>
        /// Method that was created to validate values
        /// </summary>
        /// <returns>Returns valid float value.</returns>
        public static float CheckIfValueMoreThanVerificationValue (float checkvalue)
        {
            string uservalue = Console.ReadLine();
            float.TryParse(uservalue, out float value);
            while (value <= checkvalue)
            {
                Console.WriteLine($"Your value is uncorrect. It should be greater then {checkvalue}. Please, try once again.");
                uservalue = Console.ReadLine();
                float.TryParse(uservalue, out value);
            }
            return value;
        }

        /// <summary>
        /// Method that was created to input user values. Also it checks if they are not sring
        /// </summary>
        /// <returns>Returns float value.</returns>
        public static float InputValues ()
        {
            Console.WriteLine("Enter your value (only digit):");
            do
            {
                string usercoordinate = Console.ReadLine();
                if (float.TryParse(usercoordinate, out float coordinate))
                    return coordinate;
            }
            while (true);
        }
    }
}
