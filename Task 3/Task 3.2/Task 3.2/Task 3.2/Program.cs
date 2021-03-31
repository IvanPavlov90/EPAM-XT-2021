using System;
using System.Collections.Generic;

namespace Task_3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            //DynamicArray<string> newArray = new DynamicArray<string>() { };
            //Console.WriteLine($"our length - {newArray.Length}, real length - {newArray.MyArray.Length}, capacity - {newArray.Capacity}");
            //newArray.Add("h");
            //newArray.Add("e");
            //newArray.Add("l");
            //newArray.Add("l");
            //newArray.Add("o");
            //newArray.Add("!");
            //newArray.Add("!");
            //newArray.Add("!");
            //Console.WriteLine($"our length - {newArray.Length}, real length - {newArray.MyArray.Length}, capacity - {newArray.Capacity}");
            //newArray.Insert("L", 2);
            //Console.WriteLine($"our length - {newArray.Length}, real length - {newArray.MyArray.Length}, capacity - {newArray.Capacity}");
            //foreach (var item in newArray)
            //{
            //    Console.WriteLine($"{item}");
            //}
            //newArray.Remove("l");
            //Console.WriteLine($"our length - {newArray.Length}, real length - {newArray.MyArray.Length}, capacity - {newArray.Capacity}");
            //foreach (var item in newArray)
            //{
            //    Console.WriteLine($"{item}");
            //}
            //newArray.Remove("!");
            //Console.WriteLine($"our length - {newArray.Length}, real length - {newArray.MyArray.Length}, capacity - {newArray.Capacity}");
            //foreach (var item in newArray)
            //{
            //    Console.WriteLine($"{item}");
            //}
            //newArray[-6] = "K";
            //Console.WriteLine(newArray[-5]);
            //foreach (var item in newArray)
            //{
            //    Console.WriteLine($"{item}");
            //}
            //Console.WriteLine($"{newArray[9]}");
            //DynamicArray<int> newArray = new DynamicArray<int>() { 15, 26, 34 };
            //DynamicArray<string> newArray2 = (DynamicArray<string>)newArray.Clone();
            //newArray2.Add("Stop");
            //Console.WriteLine($"our length - {newArray.Length}, real length - {newArray.MyArray.Length}, capacity - {newArray.Capacity}");
            //Console.WriteLine($"our length - {newArray2.Length}, real length - {newArray2.MyArray.Length}, capacity - {newArray2.Capacity}");
            //newArray.Remove("Hi");
            //foreach (var item in newArray)
            //{
            //    Console.WriteLine($"{item}");
            //}
            //string[] array = newArray.ToArray();
            //foreach (var item in array)
            //{
            //    Console.WriteLine($"{item}");
            //}
            //foreach (var item in newArray2)
            //{
            //    Console.WriteLine($"{item}");
            //}
            DynamicArray<float> newArray2 = new DynamicArray<float>() { };
            foreach (var item in newArray2)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine($"our length - {newArray2.length}, real length - {newArray2.MyArray.Length}, capacity - {newArray2.capacity}");
            newArray2.Add(4);
            newArray2.Add(4);
            newArray2.Add(4);
            newArray2.Add(4);
            newArray2.Add(4);
            newArray2.Add(4);
            newArray2.Add(4);
            newArray2.Add(4);
            newArray2.Add(4);
            newArray2.Add(4);
            foreach (var item in newArray2)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine($"our length - {newArray2.length}, real length - {newArray2.MyArray.Length}, capacity - {newArray2.capacity}");
            newArray2.Remove(4);
            foreach (var item in newArray2)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine($"our length - {newArray2.length}, real length - {newArray2.MyArray.Length}, capacity - {newArray2.capacity}");
            newArray2.AddRange(new List<float>() { 5, 7, 8, 14, 16, 76, 88, 121 });
            foreach (var item in newArray2)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine($"our length - {newArray2.length}, real length - {newArray2.MyArray.Length}, capacity - {newArray2.capacity}");
            //DynamicArray<string> newArray = new DynamicArray<string>(12) { };
            //foreach (var item in newArray)
            //{
            //    Console.WriteLine($"{item}");
            //}
            //Console.WriteLine($"our length - {newArray.Length}, real length - {newArray.MyArray.Length}, capacity - {newArray.Capacity}");
            //DynamicArray<char> newArray3 = new DynamicArray<char>() { };
            //foreach (var item in newArray3)
            //{
            //    Console.WriteLine($"{item}");
            //}
            //Console.WriteLine($"our length - {newArray3.Length}, real length - {newArray3.MyArray.Length}, capacity - {newArray3.Capacity}");
        }
    }
}
