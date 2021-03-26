using System;
using System.Collections.Generic;
using System.Text;

namespace Text_Analysis.Classes
{
    public class Data
    {
        public Data()
        {
            QuantityWordsData = new SortedDictionary<string, int> ();
            PercentWordsData = new SortedDictionary<string, double>();
        }

        public SortedDictionary<string, int> QuantityWordsData { get; private set; }

        public SortedDictionary<string, double> PercentWordsData { get; private set; }

        public void ShowQuantityWordsData()
        {
            foreach (var item in QuantityWordsData)
            {
                Console.WriteLine(string.Format("{0} : {1}", item.Key, item.Value));
            }
        }

        public void ShowPercentWordsData()
        {
            foreach (var item in PercentWordsData)
            {
                if (item.Value > 5)
                {
                    Console.WriteLine(string.Format("{0} : {1}", item.Key, item.Value));
                }
            }
        }

        public void AddData <T1, T2> (SortedDictionary <T1, T2> dictionary, T1 word, T2 count)
        {
            if (!dictionary.ContainsKey(word))
                 dictionary.Add(word, count);
        }
    }
}
