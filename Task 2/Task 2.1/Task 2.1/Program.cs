using System;

namespace Task_2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomString first = new CustomString();
            CustomString second = new CustomString();
            first.Concat("modern", "talking");
            second.ConvertToString(first.ConvertToCharArray());
            second.Print();
            Console.WriteLine(second.SearchSymbol('i')); 
        }
    }

    class CustomString
    {
        public string value;

        public void Print ()
        {
            Console.WriteLine(value);
        }

        public char[] ConvertToCharArray()
        {
            char[] Symbols = value.ToCharArray();
            return Symbols;
        }

        public string ConvertToString (char[] SomeSymbols)
        {
            value = String.Empty;

            foreach (char item in SomeSymbols)
            {
                value += item.ToString();
            }

            return value;
        }

        public int SearchSymbol (char Symbol)
        {
            int index = value.IndexOf(Symbol);
            return index;
        }

        public string Concat (params string[] items)
        {
            value = String.Empty;

            foreach (string item in items)
            {
                value += item;
            }

            return value;
        }
    }
}
