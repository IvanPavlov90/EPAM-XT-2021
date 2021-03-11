using System;

namespace MyString
{
    public class CustomString
    {
        private string _myString = String.Empty;

        public string MyString
        {
            get
            {
                return _myString;
            }
            set
            {
                _myString = value;
            }
        }

        public void Print()
        {
            Console.WriteLine(MyString);
        }

        public char[] ConvertToCharArray()
        {
            char[] Symbols = MyString.ToCharArray();
            return Symbols;
        }

        public string CreateStringFromChar(params char[] items)
        {
            MyString = String.Empty;

            foreach (char item in items)
            {
                MyString += item.ToString();
            }

            return MyString;
        }

        public string Concat(params string[] items)
        {
            MyString = String.Empty;

            foreach (string item in items)
            {
                MyString += item;
            }

            return MyString;
        }

        public bool ContainsSymbols(char Symbol)
        {
            int index = MyString.IndexOf(Symbol);
            if (index == -1)
                return false;
            else
                return true;
        }

        public int CountSymbol(char Symbol)
        {
            int startIndex = 0;
            int count = -1;
            int index;

            do
            {
                index = MyString.IndexOf(Symbol, startIndex + 1);
                count++;
                startIndex = index;
            }
            while (index != -1);

            return count;
        }

        public int SearchSymbol(char Symbol)
        {
            int index = MyString.IndexOf(Symbol);
            return index;
        }

        public int SearchSubstring(string text)
        {
            int index = MyString.IndexOf(text);
            return index;
        }

        public string Reverse()
        {
            string reverse = string.Empty;

            for (int i = MyString.Length - 1; i > 0; i--)
            {
                reverse += MyString[i];
            }

            return reverse;
        }

        public bool CheckEquality(CustomString obj1, CustomString obj2)
        {
            return obj1.MyString.Equals(obj2.MyString);
        }

        public int Comparison(CustomString obj1, CustomString obj2)
        {
            return obj1.MyString.CompareTo(obj2.MyString);
        }

        public char this[int index]
        {
            get
            {
                if (index > MyString.Length - 1 || index < 0)
                {
                    return ' ';
                }
                else
                {
                    return MyString[index];
                }
            }
            set
            {
                char[] data = ConvertToCharArray();
                if (index > MyString.Length - 1 || index < 0)
                {
                    Console.WriteLine("Такого индекса не существует! Сначала инициализируйте строку необходимой длины для того, чтобы что-то менять.");
                }
                else
                {
                    data[index] = value;
                    CreateStringFromChar(data);
                }
            }
        }
    }
}
