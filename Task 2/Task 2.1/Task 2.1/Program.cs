using System;
using MyString;

namespace Task_2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomString first = new CustomString("Do You");
            CustomString second = new CustomString(" Wanna");
            //bool f = (first != second);
            //bool g = (second == first);
            //Console.WriteLine($"{f}, {g}");
            //string reverse = second.Reverse();
            //Console.WriteLine(reverse);
            //first[4] = 'R';
            //Console.WriteLine(first[4]);
            //second[0] = 'V';
            CustomString third = first + second;

            //Console.WriteLine(third.CountSymbol('i'));
            third.Print();
            first[4] = first[14];
        }
    }
}
