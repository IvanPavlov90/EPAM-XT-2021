using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Task_4
{
    public static class AppMenu
    {
        enum Mode
        {
            Default = 0,
            ObservationMode = 1,
            RollingChanges = 2
        }

        /// <summary>
        /// This method asks user to specify folder he wants to observe.
        /// </summary>
        public static string AskUserToSpecifyDirectory()
        {
            Console.WriteLine("Please, specify directory to observe.");
            do
            {
                var directoryPath = Console.ReadLine();
                if (Directory.Exists(directoryPath))
                    return directoryPath;
                else
                    Console.WriteLine("You have entered wrong path to directory or directory doesn't exist, please try again.");
            } while (true);
        }

        public static void MenuStart (string directoryPath)
        {
            int result;
            do
            {
                string logPath = @"D:Log.json";
                string backupPath = @"D:\BackUp";
                Directory.CreateDirectory(backupPath);
                ShowModeMenu();
                Print.PrintMessage("Choose your option:");
                string value = Console.ReadLine();
                Int32.TryParse(value, out result);
                switch (result)
                {
                    case 1:
                        Builder.CreateBackUp(directoryPath, backupPath);
                        FileWatcher fileWatcher = new FileWatcher();
                        fileWatcher.WatchFolder(directoryPath, logPath);
                        break;
                    case 2:
                        DateTime date;
                        DateTime defaultDate = new DateTime(2000, 1, 1);
                        do
                        {
                            date = InputHelper.InputDate();
                        } while (date == defaultDate);
                        List<FileEventsInfo> fileEvent = Reader.ReadLog(logPath);
                        Builder.BuildState(fileEvent, date, directoryPath);
                        break;
                    default:
                        break;
                }
            } while (result >= 1 && result <= 2);
        }

        private static void ShowModeMenu ()
        {
            foreach (Mode item in Enum.GetValues(typeof(Mode)))
            {
                if ((int)item != 0)
                    Console.WriteLine($"{(int)item}. {item}");
            }
        }
    }
}
