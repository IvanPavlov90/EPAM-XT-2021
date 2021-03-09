using System;

namespace Task_2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomString first = new CustomString();
            first.Concat("Gooooojood ", "day", "?");
            Console.WriteLine(first.CountSymbol(first[5]));
            string reverse = first.Reverse();
            Console.WriteLine(reverse);
        }
    }

    class CustomString
    {
        public string myString = String.Empty;

        public void Print ()
        {
            Console.WriteLine(myString);
        }

        public char[] ConvertToCharArray()
        {
            char[] Symbols = myString.ToCharArray();
            return Symbols;
        }

        public string CreateStringFromChar(params char[] items)
        {
            myString = String.Empty;

            foreach (char item in items)
            {
                myString += item.ToString();
            }

            return myString;
        }

        public string Concat (params string[] items)
        {
            myString = String.Empty;

            foreach (string item in items)
            {
                myString += item;
            }

            return myString;
        }

        public bool ContainsSymbols(char Symbol)
        {
            int index = myString.IndexOf(Symbol);
            if (index == -1)
                return false;
            else
                return true;
        }

        public int CountSymbol (char Symbol)
        {
            int startIndex = 0;
            int count = -1;
            int index;

            do
            {
                index = myString.IndexOf(Symbol, startIndex + 1);
                count++;
                startIndex = index;
            }
            while (index != -1);

            return count;
        }

        public int SearchSymbol(char Symbol)
        {
            int index = myString.IndexOf(Symbol);
            return index;
        }

        public int SearchSubstring(string text)
        {
            int index = myString.IndexOf(text);
            return index;
        }

        public string Reverse ()
        {
            string reverse = string.Empty;

            for (int i = myString.Length - 1; i > 0; i--)
            {
                reverse += myString[i];
            }

            return reverse;
        }

        public bool CheckEquality (CustomString obj1, CustomString obj2)
        {
            return obj1.myString.Equals(obj2.myString);
        }

        public int Comparison (CustomString obj1, CustomString obj2)
        {
            return obj1.myString.CompareTo(obj2.myString);
        }

        public char this[int index]
        {
            get
            {
                if (index > myString.Length - 1 || index < 0)
                {
                    return ' ';
                } else
                {
                    return myString[index];
                }   
            }
            set
            {
                char[] data = ConvertToCharArray();
                if (index > myString.Length - 1 || index < 0)
                {
                    Console.WriteLine("Такого индекса не существует! Сначала инициализируйте строку необходимой длины для того, чтобы что-то менять.");
                } else
                {
                    data[index] = value;
                    CreateStringFromChar(data);
                }
            }
        }
    }
}
