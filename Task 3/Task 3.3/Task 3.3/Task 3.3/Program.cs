using System;
using System.Linq;

namespace Task_3._3
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] array = new int[] { 2, 4, 5, 7, 8 };
            SuperArray newSuperArray = new SuperArray(array);

            newSuperArray.MultiplyElem();

            foreach (var item in newSuperArray)
            {
                Console.WriteLine($"{item}");
            }
        }
    }
}
