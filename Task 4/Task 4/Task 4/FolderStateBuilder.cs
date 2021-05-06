using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Task_4
{
    public static class FolderStateBuilder
    {
        /// <summary>
        /// This method saves folder's state at the beginning of odservation.
        /// </summary>
        public static void CreateBackUp(string sourcePath, string backUpPath)
        {
            ClearDirectory(backUpPath);
            foreach (string subDirectoryPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(subDirectoryPath.Replace(sourcePath, backUpPath));
            }
            foreach (string filePath in Directory.GetFiles(sourcePath, "*", SearchOption.AllDirectories))
            {
                File.Copy(filePath, filePath.Replace(sourcePath, backUpPath), true);
            }
        }

        /// <summary>
        /// This method build folder's state on certain date.
        /// </summary>
        public static void BuildState (List<FileEventsInfo> fileEvent, DateTime date, string directoryPath, string backUpPath)
        {
            ClearDirectory(directoryPath);
            CreateBackUp(backUpPath, directoryPath);
            foreach (var item in fileEvent)
            {
                if (item.LastChangesTime <= date)
                    BuildFiles(item, directoryPath);
            }
        }

        /// <summary>
        /// Method that clears directory, it is needed to create clear structure. For example,
        /// we need to build state for certain date, folder's state before starting to observe is saved
        /// in backup direrctory. We clear our observing directory with the help of this method
        /// and then copy state from backup directory to our observing directory. Then we 
        /// create remaining structure from our log.
        /// </summary>
        /// <param name="path"></param>
        private static void ClearDirectory(string path)
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

        private static void BuildFiles(FileEventsInfo file, string directoryPath)
        {
            switch (file.EventType)
            {
                case FileActions.Create:
                    try
                    {
                        FileCreation(file);
                    }
                    catch (DirectoryNotFoundException)
                    {
                        CreateSubFolders(file.FullPath);
                        FileCreation(file);
                    }
                    break;
                case FileActions.Delete:
                    File.Delete(file.FullPath);
                    break;
                case FileActions.Change:
                    try
                    {
                        FileChanging(file);
                    }
                    catch (DirectoryNotFoundException)
                    {
                        CreateSubFolders(file.FullPath);
                        FileChanging(file);
                    }
                    break;
                case FileActions.Rename:
                    FileRenaiming(file);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// This method creates files with the help of information from example of
        /// FileEventsInfo class.
        /// </summary>
        private static void FileCreation (FileEventsInfo file)
        {
            using (var stream = File.Create(file.FullPath)) { };
            if (file.Content.Length != 0)
            {
                using (StreamWriter writer = new StreamWriter(file.FullPath, true, System.Text.Encoding.UTF8))
                {
                    writer.WriteLine(file.Content);
                }
            }
            File.SetCreationTime(file.FullPath, file.LastChangesTime);
            File.SetLastWriteTime(file.FullPath, file.LastChangesTime);
        }

        /// <summary>
        /// This method creates subfolders, if they were created during observation mode.
        /// It is necessary, because creating empty subfolder is not tracked, and doesn't 
        /// record in log.
        /// </summary>
        private static void CreateSubFolders(string path)
        {
            string[] separateString = path.Split('\\');
            string subFolderPath = String.Empty;
            for (int i = 0; i < separateString.Length - 1; i++)
            {
                subFolderPath += separateString[i];
                Directory.CreateDirectory(subFolderPath);
                subFolderPath += @"\";
            }
        }

        /// <summary>
        /// This method removes text from file and record to file necessary stand text.
        /// </summary>
        private static void FileChanging(FileEventsInfo file)
        {
            File.WriteAllText(file.FullPath, String.Empty);
            using (StreamWriter writer = new StreamWriter(file.FullPath, true, System.Text.Encoding.UTF8))
            {
                writer.Write(file.Content);
            }
            File.SetLastWriteTime(file.FullPath, file.LastChangesTime);
        }

        /// <summary>
        /// This method contains logic of renaiming file.
        /// </summary>
        /// <param name="file"></param>
        private static void FileRenaiming(FileEventsInfo file)
        {
            File.Delete(file.OldFullPath);
            using (var stream = File.Create(file.FullPath)) { };
            using (StreamWriter writer = new StreamWriter(file.FullPath, true, System.Text.Encoding.UTF8))
            {
                writer.WriteLine(file.Content);
            }
            File.SetLastWriteTime(file.FullPath, file.LastChangesTime);
        }
    }
}
