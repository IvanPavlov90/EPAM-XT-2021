using System;
using System.Collections.Generic;

namespace Task_3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create empty DynamicArray
            DynamicArray<float> newArray = new DynamicArray<float>(10) { };

            //Fill it with numbers
            newArray.Add(1);
            newArray.AddRange(new List<float>() { 2, 3, 4 });
            foreach (var item in newArray)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine($"our length - {newArray.length}, capacity - {newArray.capacity}");

            //Insert new elements at the beginning of DynamicArray
            newArray.Insert(100, 0);
            newArray.Insert(101, 0);
            foreach (var item in newArray)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine($"our length - {newArray.length}, capacity - {newArray.capacity}");

            //Remove 100 and 3 from DynamicArray
            newArray.Remove(100);
            newArray.Remove(3);
            foreach (var item in newArray)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine($"our length - {newArray.length}, capacity - {newArray.capacity}");

            //Check Indexes
            Console.WriteLine($"{newArray[-1]}, {newArray[1]}");

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
            Console.WriteLine($"length - {newArray.length}, capacity - {newArray.capacity}");

            //Creating array from our DynamicArray
            float[] array = newArray.ToArray();
            foreach (var item in array)
            {
                Console.WriteLine($"{item}");
            }
            //Creating cycling dynamic array
            CycledDynamicArray<char> newCicledArray = new CycledDynamicArray<char>(new List<char>() { 'H', 'e', 'l', 'l', 'o' }) { };

            //start for each and have a pleasure)...
        }
    }
}
