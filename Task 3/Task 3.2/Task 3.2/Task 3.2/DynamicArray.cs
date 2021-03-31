using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task_3._2
{
    public class DynamicArray<T> : IEnumerable<T>, ICloneable
    {
        public T[] MyArray { get; private set; }

        public int capacity { get; private set; } = 8;

        public int length { get; private set; } = 0;

        public DynamicArray()
        {
            MyArray = new T[capacity];
        }

        public DynamicArray(int value)
        {
            if (value > capacity)
            {
                while (capacity < value)
                {
                    capacity *= 2;
                }
            }

            MyArray = new T[capacity];
        }

        public DynamicArray(ICollection<T> list)
        {
            if (list.Count > capacity)
            {
                while (capacity < list.Count)
                {
                    capacity *= 2;
                }
            }
            MyArray = new T[capacity];
            list.CopyTo(MyArray, 0);
        }

        public void Add(T item)
        {
            if (length + 1 <= capacity)
            {
                MyArray[length] = item;
                length++;
            }
            else if (length + 1 > capacity)
            {
                T[] array = new T[capacity * 2];
                for (int i = 0; i <= length; i++)
                {
                    if (i == length)
                        array[i] = item;
                    else
                        array[i] = MyArray[i];
                }
                MyArray = array;
                capacity = array.Length;
                length++;
            }
        }

        public void AddRange(ICollection<T> list)
        {
            while (capacity < length + list.Count)
            {
                capacity *= 2;
            }
            T[] array = new T[capacity];
            for (int i = 0; i < length; i++)
            {
                array[i] = MyArray[i];
            }
            list.CopyTo(array, length);
            MyArray = array;
            length += list.Count;
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
                for (int i = index; i <= length; i++)
                {
                    MyArray[i] = MyArray[i + 1];
                    if (i == length)
                    {
                        MyArray[i] = default(T);
                    }
                }
                length--;
                return true;
            }
        }

        public bool Insert(T item, int index)
        {
            if (index < 0 || index >= length)
            {
                return false;
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                if (length < capacity)
                {
                    for (int i = length; i >= index; i--)
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
                DynamicArray<T> newArray = new DynamicArray<T>(capacity * 2) { };
                for (int i = 0; i < length; i++)
                {
                    newArray.MyArray[i] = MyArray[i];
                }
                newArray.Insert(item, index);
                MyArray = newArray.MyArray;
                capacity = newArray.capacity;
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

        public object Clone()
        {
            DynamicArray<T> newArray = new DynamicArray<T>(capacity) { };
            for (int i = 0; i < capacity; i++)
            {
                newArray.MyArray[i] = MyArray[i];
            }
            return newArray;
        }

        public T[] ToArray()
        {
            T[] newArray = new T[length];

            for (int i = 0; i < length; i++)
            {
                newArray[i] = MyArray[i];
            }

            return newArray;
        }

        public T this[int index]
        {
            get
            {
                if (index >= length)
                    throw new ArgumentOutOfRangeException();
                else if (index < 0)
                {
                    if (Math.Abs(index) > length)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    else
                        return MyArray[length - Math.Abs(index)];
                } else
                    return MyArray[index];
            }
            set
            {
                if (index >= length)
                    throw new ArgumentOutOfRangeException();
                else if (index < 0)
                {
                    if (Math.Abs(index) > length)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    else
                        MyArray[length - Math.Abs(index)] = value;
                }
                else
                    MyArray[index] = value;
            }
        }
    }
}
