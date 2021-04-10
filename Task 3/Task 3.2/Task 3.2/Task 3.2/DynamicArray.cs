using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_3._2
{
    public class DynamicArray<T> : IEnumerable<T>, ICloneable
    {
        private protected T[] _myArray { get; set; }

        public int Capacity { get; private set; } = 8;

        public int Length { get; private set; } = 0;

        public DynamicArray()
        {
            _myArray = new T[Capacity];
        }

        public DynamicArray(int capacity)
        {
            if (capacity > Capacity)
            {
                while (Capacity < capacity)
                {
                    Capacity *= 2;
                }
            }
            else if (capacity < Capacity)
                Capacity = capacity;

            _myArray = new T[Capacity];
        }

        public DynamicArray(IEnumerable<T> list)
        {
            if (list.Count() > Capacity)
            {
                while (Capacity < list.Count())
                {
                    Capacity *= 2;
                }
            }
            _myArray = new T[Capacity];
            foreach (var item in list)
            {
                _myArray[Length] = item;
                Length++;
            }
        }

        public void Add(T item)
        {
            if (Length + 1 > Capacity)
            {
                T[] newArray = new T[Capacity * 2];
                Array.Copy(_myArray, newArray, Length);
                newArray[Length] = item;
                _myArray = newArray;
                Capacity = newArray.Length;
                Length++;
            }
            else
            {
                _myArray[Length] = item;
                Length++;
            }
        }

        public void AddRange(IEnumerable<T> list)
        {
            while (Capacity < Length + list.Count())
            {
                Capacity *= 2;
            }
            T[] newArray = new T[Capacity];
            Array.Copy(_myArray, newArray, Length);
            foreach (var item in list)
            {
                newArray[Length] = item;
                Length++;
            }
            _myArray = newArray;
        }

        public bool Remove(T item)
        {
            int index = Array.IndexOf(_myArray, item);
            if (index == -1)
            {
                return false;
            }
            else
            {
                Array.Copy(_myArray, index + 1, _myArray, index, Length - index);
                Length--;
                return true;
            }
        }

        public bool Insert(T item, int index)
        {
            if (index < 0 || index > Length)
            {
                throw new ArgumentOutOfRangeException("Index can't be less then 0 or greater then Length.");
            }
            if (Length < Capacity)
            {
                Array.Copy(_myArray, index, _myArray, index + 1, Length - index);
                _myArray[index] = item;
                Length++;
                return true;
            }
            else
            {
                T[] newArray = new T[Capacity * 2];
                Array.Copy(_myArray, newArray, index);
                newArray[index] = item;
                Array.Copy(_myArray, index, newArray, index + 1, Length - index);
                _myArray = newArray;
                Capacity = newArray.Length;
                Length++;
                return true;
            }
        }

        public void SetCapacity(int value)
        {
            if (value >= Length)
            {
                T[] array = new T[value];
                for (int i = 0; i < Length; i++)
                {
                    array[i] = _myArray[i];
                }
                _myArray = array;
                Capacity = value;
            }
            else
            {
                T[] array = new T[value];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = _myArray[i];
                }
                _myArray = array;
                Capacity = value;
                Length = array.Length;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return _myArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _myArray.GetEnumerator();
        }

        public object Clone()
        {
            DynamicArray<T> newArray = new DynamicArray<T>(Capacity) { };
            Array.Copy(_myArray, newArray._myArray, Length);
            return newArray;
        }

        public T[] ToArray()
        {
            T[] newArray = new T[Length];

            for (int i = 0; i < Length; i++)
            {
                newArray[i] = _myArray[i];
            }

            return newArray;
        }

        public T this[int index]
        {
            get
            {
                if (index >= Length)
                    throw new ArgumentOutOfRangeException("Index out of borders of the array.");
                else if (index < 0)
                {
                    if (index <= -Length)
                    {
                        throw new ArgumentOutOfRangeException("Index out of borders of the array.");
                    }
                    else
                        return _myArray[Length - Math.Abs(index)];
                }
                else
                    return _myArray[index];
            }
            set
            {
                if (index >= Length)
                    throw new ArgumentOutOfRangeException("Index out of borders of the array.");
                else if (index < 0)
                {
                    if (index <= -Length)
                    {
                        throw new ArgumentOutOfRangeException("Index out of borders of the array.");
                    }
                    else
                        _myArray[Length - Math.Abs(index)] = value;
                }
                else
                    _myArray[index] = value;
            }
        }
    }
}
