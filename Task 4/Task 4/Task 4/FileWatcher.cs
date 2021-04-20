using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_4
{
    public class FileWatcher
    {
        private List<FileEventsInfo> _log = new List<FileEventsInfo> { };

        public void WatchFolder (string path)
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

            Print.PrintMessage("Observation mode has been started. For saving data and return to main menu press any key.");
            Console.ReadKey();
            FileLog.Record(_log);
        }

        private void FileCreated(object sender, FileSystemEventArgs fileEvent)
        {
            DateTime date = DateTime.Now;
            FileEventsInfo fileEventInfo = new FileEventsInfo(fileEvent.FullPath, "", date, "Create", "");
            AddFileEventInfoToLog(fileEventInfo);
        }

        private void FileDeleted(object sender, FileSystemEventArgs fileEvent)
        {
            DateTime date = DateTime.Now;
            FileEventsInfo fileEventInfo = new FileEventsInfo(fileEvent.FullPath, "", date, "Delete", "");
            AddFileEventInfoToLog(fileEventInfo);
        }

        private void FileRenamed(object sender, RenamedEventArgs fileRename)
        {
            DateTime date = DateTime.Now;
            var content = Reader.ReadContent(fileRename.FullPath);
            FileEventsInfo fileEventInfo = new FileEventsInfo(fileRename.FullPath, fileRename.OldFullPath, date, "Rename", content);
            AddFileEventInfoToLog(fileEventInfo);
        }

        private void FileChanged(object sender, FileSystemEventArgs fileEvent)
        {
            DateTime date = DateTime.Now;
            var content = Reader.ReadContent(fileEvent.FullPath);
            FileEventsInfo fileEventInfo = new FileEventsInfo(fileEvent.FullPath, "", date, "Change", content);
            AddFileEventInfoToLog(fileEventInfo);
        }

        private void AddFileEventInfoToLog (FileEventsInfo file)
        {
            file.PrintState();
            _log.Add(file);
        }
    }
}
