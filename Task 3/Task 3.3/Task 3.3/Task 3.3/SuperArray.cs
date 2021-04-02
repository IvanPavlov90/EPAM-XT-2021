using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace Task_3._3
{
    public class SuperArray
    {
        private int[] _myArray { get; set; }

        public SuperArray(int[] array)
        {
            _myArray = array;
        }

        public int SumElements()
        {
            var sum = _myArray.Sum();
            return sum;
        }

        public double AverageElements()
        {
            var result = _myArray.Average();
            return result;
        }

        public int MostRepeatedElement()
        {
            int mostRepeatedElement = 0;
            int maxCount = 1;
            var dictionary = _myArray.GroupBy(item => item);
            foreach (var item in dictionary)
            {
                if (item.Count() > maxCount)
                {
                    maxCount = item.Count();
                    mostRepeatedElement = item.Key;
                }
            }
            return mostRepeatedElement;
        }

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

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < _myArray.Length; i++)
            {
                yield return _myArray[i];
            }
        }
    }

}
