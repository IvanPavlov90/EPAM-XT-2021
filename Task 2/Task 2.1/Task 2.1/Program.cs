using System;
using MyString;

namespace Task_2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomString first = new CustomString("Modern");
            CustomString second = new CustomString(" Talking");
            bool f = (first != second);
            bool g = (second == first);
            Console.WriteLine($"{f}, {g}");
            string reverse = second.Reverse();
            Console.WriteLine(reverse);
            first[4] = 'R';
            Console.WriteLine(first[4]);
            second[0] = 'V';
            CustomString third = first + second;

            Console.WriteLine(third.CountSymbol('i'));
            third.Print();

        }
    }
}
