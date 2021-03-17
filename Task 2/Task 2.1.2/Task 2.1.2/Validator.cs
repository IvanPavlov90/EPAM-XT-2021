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

        public static string SetUser()
        {
            Console.WriteLine("Please enter your name:");
            string username = Console.ReadLine();
            return username;
        }

        public static bool SearchUser(string username, List<User> users, out int index)
        {
            index = -1;
            for (int i = 0; i <= users.Count; i++)
            {
                if (users[i].Name == username)
                {
                    index = i;
                    return true;
                }
            }

            return false;
        }
    }
}
