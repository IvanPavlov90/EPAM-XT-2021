using System;
using System.Collections.Generic;
using System.Text;

namespace MyString
{
    public class CustomString
    {
        public CustomString(string text)
        {
            myString = text.ToCharArray();
        }

        public CustomString(char[] text)
        {
            myString = text;
        }

        public char[] myString { get; set; }

        public static CustomString operator + (CustomString str1, CustomString str2)
        {
            char[] result = new char[str1.myString.Length + str2.myString.Length];

            int i = 0;
            int j = 0;

            while (i < str1.myString.Length)
            {
                result[i] = str1.myString[i];
                i++;
            }

            while (j < str2.myString.Length)
            {
                result[i] = str2.myString[j];
                i++;
                j++;
            }

            return new CustomString(result);
        }

        public static bool operator == (CustomString str1, CustomString str2)
        {
            bool flag = true;
            if (str1.myString.Length != str2.myString.Length)
            {
                flag = false;
                return flag;
            }
            else
            {
                for (int i = 0; i < str1.myString.Length; i++)
                {
                    if (!Equals(str1.myString[i], str2.myString[i])) flag = false;
                }

                return flag;
            }
        }

        public static bool operator != (CustomString str1, CustomString str2)
        {
            bool flag = false;
            if (str1.myString.Length != str2.myString.Length)
            {
                flag = true;
                return flag;
            }
            else
            {
                for (int i = 0; i < str1.myString.Length; i++)
                {
                    if (!Equals(str1.myString[i], str2.myString[i])) 
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
            foreach (char item in myString)
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

            foreach (char item in myString)
            {
                if (item == Symbol) count++;
            }

            return count;
        }

        public void Print()
        {
            foreach (char item in myString)
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

            for (int i = myString.Length - 1; i >= 0; i--)
            {
                reverse += myString[i];
            }

            return reverse;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as CustomString);
        }

        //public bool Equals(CustomString other)
        //{
        //    return other != null &&
        //           EqualityComparer<char[]>.Default.Equals(_myString, other._myString) &&
        //           EqualityComparer<char[]>.Default.Equals(MyString, other.MyString);
        //}

        //public override int GetHashCode()
        //{
        //    return HashCode.Combine(_myString, MyString);
        //}

        public char this[int index]
        {
            get
            {
                if (index > myString.Length - 1 || index < 0)
                {
                    throw new IndexOutOfRangeException("Такого индекса не существует! Сначала инициализируйте строку необходимой длины для того, чтобы что-то менять.");
                }
                else
                {
                    return myString[index];
                }
            }
            set
            {
                if (index > myString.Length - 1 || index < 0)
                {
                    throw new IndexOutOfRangeException ("Такого индекса не существует! Сначала инициализируйте строку необходимой длины для того, чтобы что-то менять.");
                }
                else
                {
                    myString[index] = value;
                }
            }
        }
    }
}
