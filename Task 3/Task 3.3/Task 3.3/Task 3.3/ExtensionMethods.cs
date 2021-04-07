﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Task_3._3
{
    public static class ExtensionMethods
    {
        public static void CheckLanguage(this string text)
        {
            Regex english = new Regex(@"^\W*([a-zA-z]+\W*\s*)+$");
            Regex russian = new Regex(@"^\W*([а-яёА-ЯЁ]+\W*\s*)+$");
            Regex digits = new Regex(@"^\W*([0-9]+\W*\s*)+$");
            if (english.IsMatch(text))
            {
                Console.WriteLine("English");
            }
            else if (russian.IsMatch(text))
            {
                Console.WriteLine("Russian");
            }
            else if (digits.IsMatch(text))
            {
                Console.WriteLine("Digits");
            }
            else 
            {
                Console.WriteLine("Mixed");
            }
        }

        public static int SumIntElements(this int[] array)
        {
            var sum = array.Sum();
            return sum;
        }

        public static float SumFloatElements(this float[] array)
        {
            var sum = array.Sum();
            return sum;
        }

        public static double SumShortElements(this double[] array)
        {
            var sum = array.Sum();
            return sum;
        }

        public static double AverageIntElements(this int[] array)
        {
            var result = array.Average();
            return result;
        }

        public static double AverageFloatElements(this float[] array)
        {
            var result = array.Average();
            return result;
        }

        public static double AverageDoubleElements(this double[] array)
        {
            var result = array.Average();
            return result;
        }

        public static int MostRepeatedIntElement (this int[] array)
        {
            var mostRepeatedElement = 0;
            var maxCount = 1;
            var dictionary = array.GroupBy(item => item);
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

        public static float MostRepeatedFloatElement(this float[] array)
        {
            float mostRepeatedElement = 0;
            int maxCount = 1;
            var dictionary = array.GroupBy(item => item);
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

        public static double MostRepeatedDoubleElement(this double[] array)
        {
            double mostRepeatedElement = 0;
            int maxCount = 1;
            var dictionary = array.GroupBy(item => item);
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

        public static short MostRepeatedShortElement(this short[] array)
        {
            short mostRepeatedElement = 0;
            int maxCount = 1;
            var dictionary = array.GroupBy(item => item);
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

        public static byte MostRepeatedByteElement(this byte[] array)
        {
            byte mostRepeatedElement = 0;
            int maxCount = 1;
            var dictionary = array.GroupBy(item => item);
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

        public static void EachElement<T>(this T[] array, Func<T, T> func)
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = func.Invoke(array[i]);
            }
        }
    }
}
