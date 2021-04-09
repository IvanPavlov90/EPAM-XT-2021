using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task_3._1.Classes
{
    public class PeopleList<T> : ICollection<int>
    {
        public List<int> People { get; private set; }

        public PeopleList(int value)
        {
            if (value <= 0)
                throw new ArgumentException("This value will be used for filling List, it couldn't be less or equal 0.");
            People = FillList(value);
        }

        public int Count => People.Count;

        public bool IsReadOnly => throw new NotImplementedException();

        /// <summary>
        /// Method for filling collection
        /// </summary>
        private static List<int> FillList(int value)
        {
            List<int> people = new List<int> { };
            int count = 1;
            while (count <= value)
            {
                people.Add(count);
                count++;
            }
            return people;
        }

        public void Add(int item)
        {
            People.Add(item);
        }

        public void Clear()
        {
            People.Clear();
        }

        public bool Contains(int item)
        {
            return People.Contains(item);
        }

        public void CopyTo(int[] array, int arrayIndex)
        {
            People.CopyTo(array, arrayIndex);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i <= Count; i++)
            {
                if (i == Count)
                    i = 0;

                yield return People[i];
            }

        }

        public bool Remove(int item)
        {
            return People.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int this[int index]
        {
            get
            {
                return People[index];
            }
        }
    }
}
