using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaTime.Classes
{
    public class User
    {
        public User(string username)
        {
            if (username == string.Empty)
                throw new ArgumentException("Name can't be empty.");
            else
                name = username;
        }

        public string name { get; }
    }
}
