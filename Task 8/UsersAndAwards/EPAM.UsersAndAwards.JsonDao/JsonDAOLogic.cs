using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using EPAM.UsersAndAwards.Common.Entities;
using EPAM.UsersAndAwards.DAL.Interfaces;

namespace EPAM.UsersAndAwards.DAL.JsonDao
{
    public class JsonDAOLogic : IJsonDAO
    {
        private string _usersFolderPath = @"D:\Files\Users\";

        private string _awardsFolderPath = @"D:\Files\Awards\";

        private string _dataFilePath = @"D:\Files\data.json";

        public void RecordAwardToFile(Award award)
        {
            using (StreamWriter writer = new StreamWriter(getFilePath(_awardsFolderPath, award.id), true, System.Text.Encoding.UTF8))
            {
                writer.WriteLine(Serialize(award));
            }
        }

        public void RecordUserToFile(User user)
        {
            using (StreamWriter writer = new StreamWriter(getFilePath(_usersFolderPath, user.id), true, System.Text.Encoding.UTF8))
            {
                writer.WriteLine(Serialize(user));
            }
        }

        public List<Award> GetAllAwards()
        {
            string[] filePath = Directory.GetFiles(_awardsFolderPath);
            List<Award> awards = Deserialize<Award>(filePath);
            return awards;
        }

        public List<User> GetAllUsers()
        {
            string[] filePath = Directory.GetFiles(_usersFolderPath);
            List<User> users = Deserialize<User>(filePath);
            return users;
        }

        public void RemoveAward(Guid id)
        {
            string[] filePath = Directory.GetFiles(_awardsFolderPath);
            string pathToDelete = filePath.FirstOrDefault(item => item == getFilePath(_awardsFolderPath, id));
            File.Delete(pathToDelete);
        }

        public void RemoveUser(Guid id)
        {
            string[] filePath = Directory.GetFiles(_usersFolderPath);
            string pathToDelete = filePath.FirstOrDefault(item => item == getFilePath(_usersFolderPath, id));
            File.Delete(pathToDelete);
        }

        public Data LoadData ()
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

        public void RecordData(Data data)
        {
            File.Delete(_dataFilePath);
            using (StreamWriter writer = new StreamWriter(_dataFilePath, true, System.Text.Encoding.UTF8))
            {
                writer.WriteLine(Serialize(data));
            }
        }

        /// <summary>
        /// This function is for building correct filepath
        /// </summary>
        private string getFilePath (string folder, Guid name)
        {
            return folder + name + ".json";
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
        private string ReadFile (string path)
        {
            string content;
            using (StreamReader reader = new StreamReader(path, System.Text.Encoding.UTF8))
            {
                content = reader.ReadToEnd();
            }
            return content;
        }
    }
}
