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
            QuantityOfWords = CheckQuantity(quantity);
        }

        public Dictionary<string, int> QuantityWordsData { get; private set; }

        public int QuantityOfWords { get; private set; }

        public void ShowQuantityWordsData()
        {
            int count = 0;

            PrintData.PrintMessage("Here is five words that were most frequently used in your text.");

            foreach (var item in QuantityWordsData.OrderByDescending(item => item.Value))
            {
                PrintData.PrintInfo<string, int>(item.Key, item.Value);
                count++;
                if (count == 5)
                {
                    break;
                }
            }
        }

        public void ShowPercentWordsData()
        {
            PrintData.PrintMessage("Here you can see words that consist more then one percent of your text.");

            foreach (var item in QuantityWordsData)
            {
                double percent = (double)item.Value / (double)QuantityOfWords * 100;
                if (percent > 1) 
                {
                    PrintData.PrintInfo<string, double>(item.Key, Math.Round(percent, 2, MidpointRounding.AwayFromZero));
                }
            }

            Console.ReadKey();
        }

        public void ShowFullStatisticAboutWords()
        {
            PrintData.PrintQuantityOfWords(QuantityOfWords);

            PrintData.PrintMessage("Here is full statistic about your text.");

            foreach (var item in QuantityWordsData.OrderBy(item => item.Key))
            {
                PrintData.PrintInfo<string, int>(item.Key, item.Value);
            }
        }

        public void ShowFullStatisticAboutText()
        {
            ShowFullStatisticAboutWords();
            ShowQuantityWordsData();
            ShowPercentWordsData();
        }

        public void AddQuantityWordsData(string word)
        {
            if (!QuantityWordsData.ContainsKey(word))
                QuantityWordsData.Add(word, 1);
            else
            {
                QuantityWordsData[word] += 1;
            }
        }

        private int CheckQuantity (int value)
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
