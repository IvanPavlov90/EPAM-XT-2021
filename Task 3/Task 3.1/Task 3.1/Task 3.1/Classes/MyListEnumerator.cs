using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3._1.Classes
{
    class MyListEnumerator<T> : IEnumerator<T>
    {
        public List<T> People { get; set; }

        public MyListEnumerator(List<T> people)
        {
            People = people;
        }

        int position = -1;

        public T Current
        {
            get
            {
                if (position == -1)
                    throw new InvalidOperationException();
                if (position >= People.Count)
                    position = 0;
                return People[position];
            }
        }

        object System.Collections.IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            if (position <= People.Count - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            position = 0;
        }
    }
}
