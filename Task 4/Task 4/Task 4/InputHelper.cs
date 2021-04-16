using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    public static class InputHelper
    {
        public static string EnterFileName()
        {
            string value;
            do
            {
                Print.PrintMessage("Please, enter filename:");
                value = Console.ReadLine();
            } while (value.Trim().Length <= 0);
            return value;
        }
    }
}
