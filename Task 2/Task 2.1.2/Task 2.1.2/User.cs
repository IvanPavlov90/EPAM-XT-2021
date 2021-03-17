using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._1._2
{
    public class User
    {
        public User(string name)
        {
            Name = name;
        }

        private string _name;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        private List<object> _figures = new List<object>();

        public List<object> ShowFigures()
        {
            return _figures;
        }

        public static User SetUser()
        {
            Console.WriteLine("Please enter your name:");
            string username = Console.ReadLine();
            User currentuser = new User(username);
            return currentuser;
        }

        public List<object> AddFigure
        {
            set => _figures.Add(value);
        }
    }
}
