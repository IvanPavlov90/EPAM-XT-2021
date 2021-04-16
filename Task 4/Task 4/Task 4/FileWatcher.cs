using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_4
{
    public static class FileWatcher
    {
        public static void WatchFolder (string path)
        {
            if (path == null || path == "")
            {
                throw new IOException("Path to file can't be null or empty");
            }

            using var watcher = new FileSystemWatcher(path, "*.txt");

            watcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.FileName
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.LastAccess;

            watcher.Created += FileCreated;
            watcher.Deleted += FileDeleted;
            watcher.Renamed += FileRenamed;
            watcher.Changed += FileChanged;

            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;

            Print.PrintMessage("Observation mode has benn started. For return to main menu press any key.");
            Console.ReadKey();
        }

        private static void FileCreated(object sender, FileSystemEventArgs fileEvent)
        {
            DateTime date = DateTime.Now;
            FileLog.Record(new FileEventsInfo(fileEvent.FullPath, date, "Create", ""));
        }

        private static void FileDeleted(object sender, FileSystemEventArgs fileEvent)
        {
            DateTime date = DateTime.Now;
            FileLog.Record(new FileEventsInfo(fileEvent.FullPath, date, "Delete", ""));
        }

        private static void FileRenamed(object sender, FileSystemEventArgs fileEvent)
        {
            DateTime date = DateTime.Now;
            var content = Reader.ReadContent(fileEvent.FullPath);
            FileLog.Record(new FileEventsInfo(fileEvent.FullPath, date, "Rename", content));
        }

        private static void FileChanged(object sender, FileSystemEventArgs fileEvent)
        {
            DateTime date = DateTime.Now;
            var content = Reader.ReadContent(fileEvent.FullPath);
            FileLog.Record(new FileEventsInfo(fileEvent.FullPath, date, "Change", content));
        }
    }
}
