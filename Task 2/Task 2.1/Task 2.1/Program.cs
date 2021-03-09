using System;
using MyString;

namespace Task_2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomString first = new CustomString();
            first.Concat("Gooooojood ", "day", "?");
            Console.WriteLine(first.CountSymbol(first[5]));
            string reverse = first.Reverse();
            Console.WriteLine(reverse);
        }
    }
}
