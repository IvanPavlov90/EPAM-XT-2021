using System;
using MyString;

namespace Task_2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomString first = new CustomString("Modern");
            CustomString second = new CustomString("Modern");
            CustomString third = first + second;
            bool f = (first == second);
            Console.WriteLine(f);

            //Console.WriteLine(third.SearchSymbol('i'));
            //foreach (char item in second.MyString)
            //{
            //    Console.WriteLine(item);
            //}

        }
    }
}
