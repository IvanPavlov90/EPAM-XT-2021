using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Task_4
{
    public static class Builder
    {
        /// <summary>
        /// This method saves folder's state at the beginning of odservation.
        /// </summary>
        public static void CreateBackUp(string sourcePath, string backupPath)
        {
            ClearDirectory(backupPath);
            foreach (string subDirectoryPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(subDirectoryPath.Replace(sourcePath, backupPath));
            }
            foreach (string filePath in Directory.GetFiles(sourcePath, "*", SearchOption.AllDirectories))
            {
                File.Copy(filePath, filePath.Replace(sourcePath, backupPath), true);
            }
        }

        public static void BuildState (List<FileEventsInfo> fileEvent, DateTime date, string directoryPath)
        {
            ClearDirectory(directoryPath);
            foreach (var item in fileEvent)
            {
                if (item.LastChangesTime <= date)
                    BuildFiles(item, directoryPath);
            }
        }

        private static void BuildFiles(FileEventsInfo file, string directoryPath)
        {
            string path = file.FullPath;
            switch (file.EventType)
            {
                case "Create":
                    using (var stream = File.Create(path)) { };
                    File.SetCreationTime(path, file.LastChangesTime);
                    File.SetLastWriteTime(path, file.LastChangesTime);
                    break;
                case "Delete":
                    File.Delete(path);
                    break;
                case "Change":
                    using (StreamWriter writer = new StreamWriter(path, true, System.Text.Encoding.UTF8))
                    {
                        writer.WriteLine(file.Content);
                    }
                    File.SetLastWriteTime(path, file.LastChangesTime);
                    break;
                case "Rename":
                    File.Delete(file.OldFullPath);
                    using (var stream = File.Create(path)) { };
                    using (StreamWriter writer = new StreamWriter(path, true, System.Text.Encoding.UTF8))
                    {
                        writer.WriteLine(file.Content);
                    }
                    File.SetLastWriteTime(path, file.LastChangesTime);
                    break;
                default:
                    break;
            }
        }

        private static void ClearDirectory (string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);

            if (dir.Exists)
            {
                foreach (DirectoryInfo subDir in dir.GetDirectories())
                {
                    subDir.Delete(true);
                }
                foreach (FileInfo file in dir.GetFiles())
                {
                    file.Delete();
                }
            }
            else
                throw new IOException("Directopry doesn't exist");
        }
    }
}
