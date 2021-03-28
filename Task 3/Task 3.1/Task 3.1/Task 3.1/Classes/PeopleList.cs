﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task_3._1.Classes
{
    public class PeopleList<T> : ICollection<T>
    {
        public List<T> People { get; set; }

        public PeopleList(List<T> people)
        {
            People = people;
        }

        public int Count => People.Count;

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T item)
        {
            People.Add(item);
        }

        public void Clear()
        {
            People.Clear();
        }

        public bool Contains(T item)
        {
            return People.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            People.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyListEnumerator<T>(People);
        }

        public bool Remove(T item)
        {
            return People.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MyListEnumerator<T>(People);
        }
    }
}