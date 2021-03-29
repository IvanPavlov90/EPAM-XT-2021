using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task_3._2
{
    public class DynamicArrayEnumerator<T> : IEnumerator<T>
    {
        public T[] MyArray { get; private set; }

        public DynamicArrayEnumerator(T[] array)
        {
            MyArray = array;
        }

        private int position = -1;

        public T Current 
        {
            get
            {
                if (position == -1 || position >= MyArray.Length)
                    throw new InvalidOperationException();
                else
                    return MyArray[position];
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            if (position < MyArray.Length - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
