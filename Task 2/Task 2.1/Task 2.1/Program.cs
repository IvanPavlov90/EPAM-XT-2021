using System;
using MyString;

namespace Task_2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomString firstString = new CustomString("abc");
            char[] array = new char[] { 'a', 'b', 'c' };
            CustomString secondString = new CustomString(array);
            CustomString thirdString = firstString + secondString;
            Console.WriteLine(firstString == secondString);
            Console.WriteLine(firstString.Equals(secondString));
            Console.WriteLine(firstString == thirdString);
            Console.WriteLine($"Count symbol b in first string {firstString.CountSymbol('b')}");
            Console.WriteLine($"Count symbol b in third string {thirdString.CountSymbol('b')}");
            Console.WriteLine($"Find symbol d in third string {thirdString.SearchSymbol('d')}");
            thirdString[2] = 'd';
            Console.WriteLine($"Find symbol d in changed third string {thirdString.SearchSymbol('d')}");
            string reverse = thirdString.Reverse();
            Console.WriteLine(reverse);
        }
    }
}
