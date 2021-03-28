using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Text_Analysis.Classes
{
    public class Data
    {
        public Data(int quantity)
        {
            QuantityWordsData = new Dictionary<string, int> ();
            PercentWordsData = new Dictionary<string, double>();
            QuantityOfWords = CheckQuantity(quantity);
        }

        public Dictionary<string, int> QuantityWordsData { get; private set; }

        public Dictionary<string, double> PercentWordsData { get; private set; }

        public int QuantityOfWords { get; private set; }

        public void ShowQuantityWordsData()
        {
            int count = 0;

            Console.WriteLine("Here is five words that were most frequently used in your text.");

            foreach (var item in QuantityWordsData.OrderByDescending(item => item.Value))
            {
                Console.WriteLine(string.Format("{0} : {1}", item.Key, item.Value));
                count++;
                if (count == 5)
                {
                    break;
                }
            }

            Console.ReadKey();
        }

        public void ShowPercentWordsData()
        {
            Console.WriteLine($"There are {QuantityOfWords} words in your text");

            Console.WriteLine("Here you can see words that consist more then one percent of your text.");

            foreach (var item in PercentWordsData.OrderByDescending(item => item.Value))
            {
                if (item.Value > 1)
                {
                    Console.WriteLine(string.Format("{0} : {1}", item.Key, item.Value));
                }
            }

            Console.ReadKey();
        }

        public void ShowFullstatistic()
        {
            Console.WriteLine($"There are {QuantityOfWords} words in your text");

            Console.WriteLine("Here is full statistic about your text.");

            foreach (var item in QuantityWordsData.OrderBy(item => item.Key))
            {
                Console.WriteLine(string.Format("{0} : {1}", item.Key, item.Value));
            }

            Console.ReadKey();
        }

        public void AddData <T1, T2> (Dictionary <T1, T2> dictionary, T1 word, T2 count)
        {
            if (!dictionary.ContainsKey(word))
                 dictionary.Add(word, count);
        }

        public int CheckQuantity (int value)
        {
            if (value <= 0)
            {
                throw new ArgumentException();
            }
            else
                return value;
        }
    }
}
