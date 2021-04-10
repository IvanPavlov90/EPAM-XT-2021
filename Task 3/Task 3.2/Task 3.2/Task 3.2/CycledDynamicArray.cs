using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3._2
{
    class CycledDynamicArray<T> : DynamicArray<T>
    {
        public CycledDynamicArray() : base() { }

        public CycledDynamicArray(int value) : base(value) { }

        public CycledDynamicArray(ICollection<T> list) : base(list) { }

        public new IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i <= Length; i++)
            {
                if (i == Length)
                {
                    i = 0;
                    yield return _myArray[i];
                }
                else
                    yield return _myArray[i];
            }
        }
    }

}
