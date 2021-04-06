using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaTime.Classes
{
    public static class InputHelper
    {
        /// <summary>
        /// Method for entering user's name.
        /// </summary>
        /// <returns>User's name.</returns>
        public static string InputName()
        {
            Console.WriteLine("Hello, our wonderful customer, please enter your name.");
            var name = Console.ReadLine();
            return name;
        }
    }
}
