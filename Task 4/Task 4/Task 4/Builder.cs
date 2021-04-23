using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Task_4
{
    public static class Builder
    {
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
                    ClearDirectory(subDir.FullName);
                }
                foreach (FileInfo file in dir.GetFiles())
                {
                    file.Delete();
                }
            }
            else
                throw new IOException("Directopry doesn't exists");
        }
    }
}
