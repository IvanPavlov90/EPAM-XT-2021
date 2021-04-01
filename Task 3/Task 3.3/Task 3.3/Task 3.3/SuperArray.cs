using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace Task_3._3
{
    public class SuperArray : IEnumerable
    {
        private int[] _myArray { get; set; }

        public SuperArray(int[] array)
        {
            _myArray = array;
        }

        //public int SumElements ()
        //{

        //}

        //public float AverageElements()
        //{

        //}

        //public T MostRepeatedElement()
        //{

        //}

        private readonly Func<int, int> func = new Func<int, int>(Multiply);

        public void MultiplyElem()
        {
            for (int i = 0; i < _myArray.Length; i++)
            {
                _myArray[i] = func(_myArray[i]);
            }
        }

        private static int Multiply(int value)
        {
            return value * 2;
        }

        private IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < _myArray.Length; i++)
            {
                yield return _myArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
