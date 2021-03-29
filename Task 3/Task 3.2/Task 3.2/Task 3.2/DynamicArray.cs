using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task_3._2
{
    public class DynamicArray<T> : IEnumerable<T>
    {
        public T[] MyArray { get; private set; }

        public int Capacity { get; set; } = 8;

        public DynamicArray()
        {
            MyArray = new T[Capacity];
        }

        public DynamicArray(int value)
        {
            if (value > Capacity)
            {
                while (Capacity < value)
                {
                    Capacity *= 2;
                }
            }

            MyArray = new T[Capacity];
        }

        public DynamicArray(ICollection<T> list)
        {
            if (list.Count > Capacity)
            {
                while (Capacity < list.Count)
                {
                    Capacity *= 2;
                }
            }
            MyArray = new T[Capacity];
            list.CopyTo(MyArray, 0);
        }

        public int Length
        {
            get
            {
                int count = 0;

                foreach (T item in MyArray)
                {
                    if (item != null)
                    {
                        count++;
                    }
                }

                return count;
            }
        }

        public void Add(T item)
        {
            if (Length + 1 <= Capacity)
            {
                MyArray[Length] = item;
            }
            else if (Length + 1 > Capacity)
            {
                DynamicArray<T> newArray = new DynamicArray<T>(Capacity * 2) { };
                for (int i = 0; i < Length; i++)
                {
                    newArray.MyArray[i] = MyArray[i];
                }
                newArray.Add(item);
                MyArray = newArray.MyArray;
                Capacity = newArray.Capacity;
            }
        }

        public void AddRange(ICollection<T> list)
        {
            while (Capacity < Length + list.Count)
            {
                Capacity *= 2;
            }
            DynamicArray<T> newArray = new DynamicArray<T>(Capacity) { };
            for (int i = 0; i < Length; i++)
            {
                newArray.MyArray[i] = MyArray[i];
            }
            list.CopyTo(newArray.MyArray, newArray.Length);
            MyArray = newArray.MyArray;
            Capacity = newArray.Capacity;
        }

        public bool Remove(T item)
        {
            int index = Array.IndexOf(MyArray, item);
            if (index == -1)
            {
                return false;
            }
            else
            {
                MyArray[index] = default(T);
                return true;
            }
        }

        public bool Insert(T item, int index)
        {
            if (index < 0 || index > Length)
            {
                return false;
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                if (Length < Capacity)
                {
                    for (int i = Length; i >= index; i--)
                    {
                        if (i == index)
                        {
                            MyArray[index] = item;
                            return true;
                        }
                        else 
                        {
                            MyArray[i] = MyArray[i - 1];
                        }
                    }
                } 
                DynamicArray<T> newArray = new DynamicArray<T>(Capacity * 2) { };
                for (int i = 0; i < Length; i++)
                {
                    newArray.MyArray[i] = MyArray[i];
                }
                newArray.Insert(item, index);
                MyArray = newArray.MyArray;
                Capacity = newArray.Capacity;
                return true;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DynamicArrayEnumerator<T>(MyArray);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new DynamicArrayEnumerator<T>(MyArray);
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                    throw new ArgumentOutOfRangeException();
                else
                    return MyArray[index];
            }
            set
            {
                if (index < 0 || index >= Length)
                    throw new ArgumentOutOfRangeException();
                else
                    MyArray[index] = value;
            }
        }
    }
}
