using System;
using System.Collections.Generic;

namespace Task_3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicArray<string> newArray = new DynamicArray<string>() { };
            Console.WriteLine($"our length - {newArray.Length}, real length - {newArray.MyArray.Length}, capacity - {newArray.Capacity}");
            newArray.Add("h");
            newArray.Add("e");
            newArray.Add("l");
            newArray.Add("l");
            newArray.Add("o");
            newArray.Add("!");
            newArray.Add("!");
            newArray.Add("!");
            Console.WriteLine($"our length - {newArray.Length}, real length - {newArray.MyArray.Length}, capacity - {newArray.Capacity}");
            newArray.Insert("L", 2);
            Console.WriteLine($"our length - {newArray.Length}, real length - {newArray.MyArray.Length}, capacity - {newArray.Capacity}");
            foreach (var item in newArray)
            {
                Console.WriteLine($"{item}");
            }
            newArray.Remove("l");
            Console.WriteLine($"our length - {newArray.Length}, real length - {newArray.MyArray.Length}, capacity - {newArray.Capacity}");
            foreach (var item in newArray)
            {
                Console.WriteLine($"{item}");
            }
        }
    }
}
