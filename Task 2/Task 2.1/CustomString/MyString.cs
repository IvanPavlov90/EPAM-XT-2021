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

        public static CustomString operator +(CustomString str1, CustomString str2)
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

        public static bool operator ==(CustomString str1, CustomString str2)
        {
            return str1.Equals(str2);
        }

        public static bool operator !=(CustomString str1, CustomString str2)
        {
            return !str1.Equals(str2);
        }

        /// <summary>
        /// Method that defines presence of symbol into custom string.
        /// </summary>
        /// <param name="Symbol"></param>
        /// <returns>Returns true or false depending on availability of symbol into custom string.</returns>
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
        /// Method that counts symbols in custom string.
        /// </summary>
        /// <param name="Symbol"></param>
        /// <returns>Returns number of symdols.</returns>
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
            Console.WriteLine();
            foreach (char item in myString)
            {
                Console.Write(item);
            }
        }

        /// <summary>
        /// Method that turns custom string backwards.
        /// </summary>
        /// <returns>Returns backward string</returns>
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
            if (obj is null)
                return false;

            return Equals(obj as CustomString);
        }

        public bool Equals(CustomString other)
        {
            int i = 0;
            if (myString.Length != other.myString.Length)
            {
                return false;
            }
            else
            {
                while (i < myString.Length)
                {
                    if (myString[i] != other.myString[i])
                    {
                        return false;
                    }
                    i++;
                }

                return true;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(myString);
        }

        public char this[int index]
        {
            get
            {
                if (index > myString.Length - 1 || index < 0)
                {
                    throw new IndexOutOfRangeException("There is no such index.");
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
                    throw new IndexOutOfRangeException("There is no such index.");
                }
                else
                {
                    myString[index] = value;
                }
            }
        }
    }
}

