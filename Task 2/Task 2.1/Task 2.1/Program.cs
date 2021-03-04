using System;

namespace Task_2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomString first = new CustomString();
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
