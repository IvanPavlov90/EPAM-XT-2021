using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Task_3._3
{
    public static class ExtensionMethods
    {
        public enum TextType
        {
            Russian,
            English,
            Digits,
            Mixed,
            Default
        }

        public static TextType CheckLanguage(this string text)
        {
            Regex english = new Regex(@"^([a-zA-z]+)$");
            Regex russian = new Regex(@"^([а-яёА-ЯЁ]+)$");
            Regex digits = new Regex(@"^([0-9]+)$");
            if (english.IsMatch(text))
            {
                return TextType.English;
            }
            else if (russian.IsMatch(text))
            {
                return TextType.Russian;
            }
            else if (digits.IsMatch(text))
            {
                return TextType.Digits;
            }
            else 
            {
                return TextType.Mixed;
            }
        }

        public static int Sum(this int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }

        public static float Sum(this float[] array)
        {
            float sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }

        public static double Sum(this double[] array)
        {
            double sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }

        public static double Average(this int[] array)
        {
            double result = Sum(array) / array.Length;
            return result;
        }

        public static double Average(this float[] array)
        {
            double result = Sum(array) / array.Length;
            return result;
        }

        public static double Average(this double[] array)
        {
            double result = Sum(array) / array.Length;
            return result;
        }

        public static int MostRepeatedElement (this int[] array)
        {
            var mostRepeatedElement = 0;
            var dictionary = array.GroupBy(item => item).OrderByDescending(item => item.Count());
            mostRepeatedElement = dictionary.FirstOrDefault().Key;
            return mostRepeatedElement;
        }

        public static float MostRepeatedElement(this float[] array)
        {
            float mostRepeatedElement = 0;
            var dictionary = array.GroupBy(item => item).OrderByDescending(item => item.Count());
            mostRepeatedElement = dictionary.FirstOrDefault().Key;
            return mostRepeatedElement;
        }

        public static double MostRepeatedElement(this double[] array)
        {
            double mostRepeatedElement = 0;
            var dictionary = array.GroupBy(item => item).OrderByDescending(item => item.Count());
            mostRepeatedElement = dictionary.FirstOrDefault().Key;
            return mostRepeatedElement;
        }

        public static short MostRepeatedElement(this short[] array)
        {
            short mostRepeatedElement = 0;
            var dictionary = array.GroupBy(item => item).OrderByDescending(item => item.Count());
            mostRepeatedElement = dictionary.FirstOrDefault().Key;
            return mostRepeatedElement;
        }

        public static byte MostRepeatedElement(this byte[] array)
        {
            byte mostRepeatedElement = 0;
            var dictionary = array.GroupBy(item => item).OrderByDescending(item => item.Count());
            mostRepeatedElement = dictionary.FirstOrDefault().Key;
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
