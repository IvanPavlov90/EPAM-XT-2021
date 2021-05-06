using System;
using System.Collections.Generic;
using System.IO;

namespace Task_4
{
    public enum FileActions
    {
        Default = 0,
        Create = 1,
        Delete = 2,
        Rename = 3,
        Change = 4
    }
    public class FileWatcher
    {
        private List<FileEventsInfo> _log = new List<FileEventsInfo> { };

        public void WatchFolder (string folderPath, LogsSerializer log)
        {
            if (folderPath == null || folderPath == String.Empty)
                throw new ArgumentException("Path to file or folder can't be null or empty");

            using var watcher = new FileSystemWatcher(folderPath, "*.txt");

            watcher.NotifyFilter = NotifyFilters.FileName
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.LastWrite;

            watcher.Created += FileCreated;
            watcher.Deleted += FileDeleted;
            watcher.Renamed += FileRenamed;
            watcher.Changed += FileChanged;

            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;

            Console.WriteLine("Observation mode has been started. For saving data and return to main menu press any key.");
            Console.ReadKey();
            log.Record(_log);
        }

        private void FileCreated(object sender, FileSystemEventArgs fileEvent)
        {
            DateTime date = DateTime.Now;
            FileEventsInfo fileEventInfo = new FileEventsInfo(fileEvent.FullPath, null, date, FileActions.Create, "");
            AddFileEventInfoToLog(fileEventInfo);
        }

        private void FileDeleted(object sender, FileSystemEventArgs fileEvent)
        {
            DateTime date = DateTime.Now;
            FileEventsInfo fileEventInfo = new FileEventsInfo(fileEvent.FullPath, null, date, FileActions.Delete, String.Empty);
            AddFileEventInfoToLog(fileEventInfo);
        }

        private void FileRenamed(object sender, RenamedEventArgs fileRename)
        {
            DateTime date = DateTime.Now;
            var content = File.ReadAllText(fileRename.FullPath);
            FileEventsInfo fileEventInfo = new FileEventsInfo(fileRename.FullPath, fileRename.OldFullPath, date, FileActions.Rename, content);
            AddFileEventInfoToLog(fileEventInfo);
        }

        private void FileChanged(object sender, FileSystemEventArgs fileEvent)
        {
            DateTime date = DateTime.Now;
            var content = File.ReadAllText(fileEvent.FullPath);
            FileEventsInfo fileEventInfo = new FileEventsInfo(fileEvent.FullPath, null, date, FileActions.Change, content);
            AddFileEventInfoToLog(fileEventInfo);
        }

        private void AddFileEventInfoToLog (FileEventsInfo file)
        {
            file.PrintState();
            _log.Add(file);
        }
    }
}
