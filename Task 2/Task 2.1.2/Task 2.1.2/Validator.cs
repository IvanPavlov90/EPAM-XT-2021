using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2
{
    public static class Validator
    {
        /// <summary>
        /// Method that was created to input user values for figure's coordinats. Also it checks if they are not sring
        /// </summary>
        /// <returns>Returns float value.</returns>
        public static float InputCoordinats ()
        {
            Console.WriteLine("Enter coordinat value (only digit):");
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
