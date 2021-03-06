﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using EPAM.AwardsAndUsers.Common.Entities;
using EPAM.AwardsAndUsers.DAL.Interfaces;

namespace EPAM.AwardsAndUsers.DAL.JSONDAL
{
    public class JSONDALLogic : IDAL
    {
        private string _usersFolderPath = AppDomain.CurrentDomain.BaseDirectory + @"\Files\Users\";

        private string _awardsFolderPath = AppDomain.CurrentDomain.BaseDirectory + @"\Files\Awards\";

        private string _dataFilePath = AppDomain.CurrentDomain.BaseDirectory + @"\Files\data.json";

        private string _authentificationPath = AppDomain.CurrentDomain.BaseDirectory + @"\Files\Passwords\";

        private string _rolesPath = AppDomain.CurrentDomain.BaseDirectory + @"\Files\Roles\";

        public bool SetBase()
        {
            User user = new User("Administrator", new DateTime(1990, 5, 11));
            if (!Directory.Exists(_usersFolderPath))
            {
                Directory.CreateDirectory(_usersFolderPath);
                RecordUserToFile(user);
            }
            if (!Directory.Exists(_awardsFolderPath))
                Directory.CreateDirectory(_awardsFolderPath);
            if (!Directory.Exists(_authentificationPath))
            {
                Directory.CreateDirectory(_authentificationPath);
                AuthData authAdmin = new AuthData(user.id, "admin".GetHashCode());
                RecordAuthToFile(authAdmin);
            }
            if (!Directory.Exists(_rolesPath))
            {
                Directory.CreateDirectory(_rolesPath);
                RecordRolesToFile(new RoleData(new string[] { "Administrator" }, new string[] { "Administrator" }));
            }
            return true;
        }

        public bool RecordUserToFile(User user)
        {
            using (StreamWriter writer = new StreamWriter(getFilePath(_usersFolderPath, user.id), false, System.Text.Encoding.UTF8))
            {
                writer.WriteLine(Serialize(user));
            }
            return true;
        }

        public bool RecordAwardToFile(Award award)
        {
            using (StreamWriter writer = new StreamWriter(getFilePath(_awardsFolderPath, award.id), false, System.Text.Encoding.UTF8))
            {
                writer.WriteLine(Serialize(award));
            }
            return true;
        }

        public bool RecordAuthToFile(AuthData newData)
        {
            using (StreamWriter writer = new StreamWriter(getFilePath(_authentificationPath, newData.UserID), false, System.Text.Encoding.UTF8))
            {
                writer.WriteLine(Serialize(newData));
            }
            return true;
        }

        public bool RecordRolesToFile(RoleData roleData)
        {
            using (StreamWriter writer = new StreamWriter(_rolesPath + roleData.Usernames[0] + ".json", false, System.Text.Encoding.UTF8))
            {
                writer.WriteLine(Serialize(roleData));
            }
            return true;
        }

        public bool RemoveUser(Guid id)
        {
            string[] filePath = Directory.GetFiles(_usersFolderPath);
            string pathToDelete = filePath.FirstOrDefault(item => item == getFilePath(_usersFolderPath, id));
            File.Delete(pathToDelete);
            return true;
        }

        public bool RemoveAward(Guid id)
        {
            string[] filePath = Directory.GetFiles(_awardsFolderPath);
            string pathToDelete = filePath.FirstOrDefault(item => item == getFilePath(_awardsFolderPath, id));
            File.Delete(pathToDelete);
            return true;
        }

        public bool RemoveAuthData(Guid id)
        {
            string[] filePath = Directory.GetFiles(_authentificationPath);
            string pathToDelete = filePath.FirstOrDefault(item => item == getFilePath(_authentificationPath, id));
            File.Delete(pathToDelete);
            return true;
        }

        public bool RemoveRolesData(string username)
        {
            string[] filePath = Directory.GetFiles(_rolesPath);
            string pathToDelete = filePath.FirstOrDefault(item => item == _rolesPath + username + ".json");
            File.Delete(pathToDelete);
            return true;
        }

        public bool RemoveData (User user)
        {
            Data data = LoadData();
            if (data.DataValue.Remove(user.id))
                RecordData(data);
            return true;
        }

        public IEnumerable<User> GetAllUsers()
        {
            string[] filePath = Directory.GetFiles(_usersFolderPath);
            List<User> users = Deserialize<User>(filePath);
            return users;
        }

        public IEnumerable<Award> GetAllAwards()
        {
            string[] filePath = Directory.GetFiles(_awardsFolderPath);
            List<Award> awards = Deserialize<Award>(filePath);
            return awards;
        }

        public Data LoadData()
        {
            if (File.Exists(_dataFilePath))
            {
                return JsonSerializer.Deserialize<Data>(ReadFile(_dataFilePath));
            }
            else
            {
                return new Data();
            }
        }

        public bool RecordData(Guid userID, Guid awardID)
        {
            Data data = LoadData();
            data.AddKey(userID);
            data.AddData(userID, awardID);
            File.Delete(_dataFilePath);
            using (StreamWriter writer = new StreamWriter(_dataFilePath, true, System.Text.Encoding.UTF8))
            {
                writer.WriteLine(Serialize(data));
            }
            return true;
        }

        public bool RemoveAwardFromTableWithUsersAndAwards(Guid id)
        {
            Data data = LoadData();
            foreach (var item in data.DataValue)
            {
                if (item.Value.Contains(id))
                    item.Value.Remove(id);
            }
            RecordData(data);
            return true;
        }

        public IEnumerable<AuthData> LoadAuthData()
        {
            string[] filePath = Directory.GetFiles(_authentificationPath);
            return Deserialize<AuthData>(filePath);
        }

        public IEnumerable<RoleData> LoadRolesData()
        {
            string[] filePath = Directory.GetFiles(_rolesPath);
            return Deserialize<RoleData>(filePath);
        }

        public bool UpdateAward(Award award)
        {
            return RecordAwardToFile(award);
        }

        public bool UpdateUser(User user)
        {
            return RecordUserToFile(user);
        }

        /// <summary>
        /// This function is for building correct filepath
        /// </summary>
        private string getFilePath(string folder, Guid id)
        {
            return folder + id + ".json";
        }

        /// <summary>
        /// This function is for serializing objects of both Award and User classes
        /// </summary>
        private string Serialize<T>(T item)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize<T>(item, options);
            return json;
        }

        /// <summary>
        /// This function is for deserializing objects of both Award and User classes
        /// </summary>
        private List<T> Deserialize<T>(string[] filePath)
        {
            List<T> items = new List<T> { };
            foreach (var item in filePath)
            {
                T deserializeItem = JsonSerializer.Deserialize<T>(ReadFile(item));
                items.Add(deserializeItem);
            }
            return items;
        }

        /// <summary>
        /// This function is for reading file
        /// </summary>
        /// <returns></returns>
        private string ReadFile(string path)
        {
            string content;
            using (StreamReader reader = new StreamReader(path, System.Text.Encoding.UTF8))
            {
                content = reader.ReadToEnd();
            }
            return content;
        }

        private bool RecordData (Data data)
        {
            File.Delete(_dataFilePath);
            using (StreamWriter writer = new StreamWriter(_dataFilePath, true, System.Text.Encoding.UTF8))
            {
                writer.WriteLine(Serialize(data));
            }
            return true;
        }
    }
}
