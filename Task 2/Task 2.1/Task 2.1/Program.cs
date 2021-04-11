using System;
using MyString;

namespace Task_2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Creating custom strings */
            CustomString firstString = new CustomString("abc");
            char[] array = new char[] { 'a', 'b', 'c' };
            CustomString secondString = new CustomString(array);

            /* Concatenate them */
            CustomString thirdString = firstString + secondString;

            /* Compare them */
            Console.WriteLine(firstString == secondString);
            Console.WriteLine(firstString.Equals(secondString));
            Console.WriteLine(firstString == thirdString);

            /* Count symbols in this strings */
            Console.WriteLine($"Count symbol b in first string {firstString.CountSymbol('b')}");
            Console.WriteLine($"Count symbol b in third string {thirdString.CountSymbol('b')}");

            /* Checking does string contain symbol */
            Console.WriteLine($"Find symbol d in third string {thirdString.SearchSymbol('d')}");
            thirdString[2] = 'd';
            Console.WriteLine($"Find symbol d in changed third string {thirdString.SearchSymbol('d')}");

            /* reverse string */
            string reverse = thirdString.Reverse();
            Console.WriteLine(reverse);

            /* Checking work of exception */
            //thirdString[112] = 'd';
        }
    }
}
