using System;
using System.Collections.Generic;
using System.Text;

namespace MyString
{
    public class CustomString : IEquatable<CustomString>
    {
        public CustomString(string text)
        {
            MyString = text.ToCharArray();
        }

        private char[] _myString;

        public char[] MyString
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

        public static CustomString operator + (CustomString str1, CustomString str2)
        {
            string result = String.Empty;

            foreach (char item in str1.MyString)
            {
                result += item;
            }

            foreach (char item in str2.MyString)
            {
                result += item;
            }

            return new CustomString(result);
        }

        public static bool operator == (CustomString str1, CustomString str2)
        {
            bool flag = true;
            if (str1.MyString.Length != str2.MyString.Length)
            {
                flag = false;
                return flag;
            }
            else
            {
                for (int i = 0; i < str1.MyString.Length; i++)
                {
                    if (!Equals(str1.MyString[i], str2.MyString[i])) flag = false;
                }

                return flag;
            }
        }

        public static bool operator != (CustomString str1, CustomString str2)
        {
            bool flag = false;
            if (str1.MyString.Length != str2.MyString.Length)
            {
                flag = true;
                return flag;
            }
            else
            {
                for (int i = 0; i < str1.MyString.Length; i++)
                {
                    if (!Equals(str1.MyString[i], str2.MyString[i])) 
                    {
                        flag = true;
                    }
                }

                return flag;
            }
        }

        /// <summary>
        /// Метод, определяющий, есть ли искомый символ в кастомной строке.
        /// </summary>
        /// <param name="Symbol"></param>
        /// <returns>Возвращает true или false, в зависимости от наличия символа в строке.</returns>
        public bool SearchSymbol(char Symbol)
        {
            bool flag = false;
            foreach (char item in MyString)
            {
                if (item == Symbol)
                    flag = true;
            }
            return flag;
        }

        /// <summary>
        /// Метод, подсчитывающий количество искомых символов в кастомной строке.
        /// </summary>
        /// <param name="Symbol"></param>
        /// <returns>Возвращает количество символов.</returns>
        public int CountSymbol(char Symbol)
        {
            int count = 0;

            foreach (char item in MyString)
            {
                if (item == Symbol) count++;
            }

            return count;
        }

        public void Print()
        {
            foreach (char item in MyString)
            {
                Console.Write(item);
            }
        }

        /// <summary>
        /// Метод, возвращающий строку, состоящую из символов, хранящихся в кастомной строке,
        /// собранных в порядке справа-налево.
        /// </summary>
        /// <returns></returns>
        public string Reverse()
        {
            string reverse = string.Empty;

            for (int i = MyString.Length - 1; i >= 0; i--)
            {
                reverse += MyString[i];
            }

            return reverse;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as CustomString);
        }

        public bool Equals(CustomString other)
        {
            return other != null &&
                   EqualityComparer<char[]>.Default.Equals(_myString, other._myString) &&
                   EqualityComparer<char[]>.Default.Equals(MyString, other.MyString);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_myString, MyString);
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
                if (index > MyString.Length - 1 || index < 0)
                {
                    Console.WriteLine("Такого индекса не существует! Сначала инициализируйте строку необходимой длины для того, чтобы что-то менять.");
                }
                else
                {
                    MyString[index] = value;
                }
            }
        }
    }
}
