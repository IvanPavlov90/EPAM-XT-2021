using System;
using System.Collections.Generic;

namespace Task_3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create empty DynamicArray
            DynamicArray<float> newArray = new DynamicArray<float>(6) { };
            //DynamicArray<float> newArray2 = new DynamicArray<float>(new List<float> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 }) { };
            //Console.WriteLine($"our length - {newArray2.Length}, capacity - {newArray2.Capacity}");

            //Fill it with numbers
            newArray.Add(1);
            newArray.AddRange(new List<float>() { 2, 3, 4 });
            newArray.AddRange(new List<float>() { 5, 6, 7 });
            foreach (var item in newArray)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine($"our length - {newArray.Length}, capacity - {newArray.Capacity}");

            //Insert new elements at the beginning of DynamicArray
            newArray.Insert(100, 4);
            Console.WriteLine($"our length - {newArray.Length}, capacity - {newArray.Capacity}");
            newArray.Insert(101, 5);
            Console.WriteLine($"our length - {newArray.Length}, capacity - {newArray.Capacity}");
            newArray.Insert(102, 6);
            foreach (var item in newArray)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine($"our length - {newArray.Length}, capacity - {newArray.Capacity}");

            //Remove 1, 3 and 4 from DynamicArray
            newArray.Remove(1);
            newArray.Remove(3);
            newArray.Remove(4);
            foreach (var item in newArray)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine($"our length - {newArray.Length}, capacity - {newArray.Capacity}");

            //Check Indexes
            Console.WriteLine($"{newArray[-4]}, {newArray[1]}");

            //Creating array from our DynamicArray
            float[] arr = newArray.ToArray();
            foreach (var item in arr)
            {
                Console.WriteLine($"{item}");
            }

            //Set capacity = 3
            newArray.SetCapacity(3);
            foreach (var item in newArray)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine($"length - {newArray.Length}, capacity - {newArray.Capacity}");

            //Creating cycling dynamic array
            CycledDynamicArray<char> newCicledArray = new CycledDynamicArray<char>(new List<char>() { 'H', 'e', 'l', 'l', 'o' }) { };

            //start for each and have a pleasure)...
        }
    }
}
