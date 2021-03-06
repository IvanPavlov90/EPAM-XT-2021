﻿using System;
using System.Text.Json.Serialization;

namespace EPAM.AwardsAndUsers.Common.Entities
{
    public class User
    {
        public User()
        {

        }

        public User(Guid ID, string username, string birthDate, int userAge)
        {
            id = ID;
            Name = username;
            DateOfBirth = birthDate;
            Age = userAge;
        }

        public User(string username, DateTime birthDate)
        {
            id = Guid.NewGuid();
            Name = checkUsername(username);
            DateOfBirth = checkBirthDate(birthDate).ToShortDateString();
            Age = Math.Truncate((DateTime.Now - checkBirthDate(birthDate)).TotalDays / 365);
        }

        [JsonInclude]
        public Guid id { get; private set; }

        [JsonInclude]
        public string Name { get; private set; }

        [JsonInclude]
        public string DateOfBirth { get; private set; }

        [JsonInclude]
        public double Age { get; private set; }

        public void EditUser(string username, DateTime birthDate)
        {
            Name = checkUsername(username);
            DateOfBirth = checkBirthDate(birthDate).ToShortDateString();
            Age = Math.Truncate((DateTime.Now - checkBirthDate(birthDate)).TotalDays / 365);
        }

        private string checkUsername(string username)
        {
            if (username.Trim().Length == 0 || username == String.Empty || username == null)
            {
                throw new ArgumentException($"You can't put empty or white space string into username");
            }
            return username;
        }

        private DateTime checkBirthDate(DateTime birthDate)
        {
            if (birthDate >= DateTime.Now)
            {
                throw new ArgumentException($"You can't put date more then today's date into birthdate.");
            }
            return birthDate;
        }
    }
}
