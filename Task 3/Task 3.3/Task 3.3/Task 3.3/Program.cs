using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Task_3._3
{
    class Program
    {
        static void Main(string[] args)
        {

            //var array = new int[] { 8, 5, 6, 5, 8, 8 };
            //SuperArray superArr = new SuperArray(array) { };
            //superArr.MultiplyElem();
            //foreach (var item in superArr)
            //{
            //    Console.WriteLine($"{item}");
            //}
            //Console.WriteLine(superArr.SumElements());
            //Console.WriteLine(superArr.AverageElements());
            //Console.WriteLine(superArr.MostRepeatedElement());

            string text = "ConsoleWriteLine";
            SuperString.CheckLanguage(text);

        }
    }
}
