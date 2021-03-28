using System;
using System.Collections.Generic;

namespace Task_3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicArray<string> newArray = new DynamicArray<string>() { };
            Console.WriteLine($"{newArray.Length}, {newArray.Capacity}");
            newArray.Add("c");
            newArray.Add("c");
            newArray.Add("c");
            newArray.Add("c");
            newArray.Add("c");
            newArray.Add("c");
            newArray.Add("c");
            newArray.Add("c");
            Console.WriteLine($"our length - {newArray.Length}, real length - {newArray.MyArray.Length}, capacity - {newArray.Capacity}");
            newArray.Add("c");
            //Console.WriteLine(newArray[8]);
            Console.WriteLine($"our length - {newArray.Length}, real length - {newArray.MyArray.Length}, capacity - {newArray.Capacity}");
            List<string> stringlist = new List<string>() { "d", "d", "d", "d", "d" , "d", "d", "d", "d", "d", "d", "d", "d", "d", "d", "d", "d", "d", "d", "d", "d", "d", "d", "d" };
            newArray.AddRange(stringlist);
            Console.WriteLine($"our length - {newArray.Length}, real length - {newArray.MyArray.Length}, capacity - {newArray.Capacity}");
            foreach (var item in newArray.MyArray)
            {
                Console.WriteLine(item);
            }
        }
    }
}
