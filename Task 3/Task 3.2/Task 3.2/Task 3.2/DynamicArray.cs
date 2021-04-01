using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task_3._2
{
    public class DynamicArray<T> : IEnumerable<T>, ICloneable
    {
        private protected T[] _myArray { get; set; }

        public int capacity { get; private set; } = 8;

        public int length { get; private set; } = 0;

        public DynamicArray()
        {
            _myArray = new T[capacity];
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

            _myArray = new T[capacity];
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
            _myArray = new T[capacity];
            list.CopyTo(_myArray, 0);
            length = list.Count;
        }

        public void Add(T item)
        {
            if (length + 1 <= capacity)
            {
                _myArray[length] = item;
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
                        array[i] = _myArray[i];
                }
                _myArray = array;
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
                array[i] = _myArray[i];
            }
            list.CopyTo(array, length);
            _myArray = array;
            length += list.Count;
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
                _myArray[index] = default(T);
                for (int i = index; i <= length; i++)
                {
                    _myArray[i] = _myArray[i + 1];
                    if (i == length)
                    {
                        _myArray[i] = default(T);
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
                            _myArray[index] = item;
                        }
                        else
                        {
                            _myArray[i] = _myArray[i - 1];
                        }
                    }
                    length++;
                    return true;
                }
                else
                {
                    T[] array = new T[capacity * 2];
                    for (int i = 0; i <= length; i++)
                    {
                        if (i < index)
                            array[i] = _myArray[i];
                        else if (i == index)
                            array[i] = item;
                        else
                            array[i] = _myArray[i - 1];
                    }
                    _myArray = array;
                    capacity = array.Length;
                    length++;
                    return true;
                }
            }
        }

        public void SetCapacity(int value)
        {
            if (value >= length)
            {
                T[] array = new T[value];
                for (int i = 0; i < length; i++)
                {
                    array[i] = _myArray[i];
                }
                _myArray = array;
                capacity = value;
            }
            else
            {
                T[] array = new T[value];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = _myArray[i];
                }
                _myArray = array;
                capacity = value;
                length = array.Length;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < length; i++)
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
            DynamicArray<T> newArray = new DynamicArray<T>(capacity) { };
            for (int i = 0; i < capacity; i++)
            {
                newArray._myArray[i] = _myArray[i];
            }
            return newArray;
        }

        public T[] ToArray()
        {
            T[] newArray = new T[length];

            for (int i = 0; i < length; i++)
            {
                newArray[i] = _myArray[i];
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
                        return _myArray[length - Math.Abs(index)];
                }
                else
                    return _myArray[index];
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
                        _myArray[length - Math.Abs(index)] = value;
                }
                else
                    _myArray[index] = value;
            }
        }
    }
}
