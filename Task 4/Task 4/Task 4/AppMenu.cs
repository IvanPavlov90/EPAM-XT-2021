using System;
using System.Collections.Generic;
using System.IO;

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

        public static void ChosingMode ()
        {
            int result;
            do
            {
                string directoryPath = GetDirectory() + @"\Files";
                string logPath = GetDirectory() + @"\Log.json";
                ShowModeMenu();
                Print.PrintMessage("Choose your option:");
                string value = Console.ReadLine();
                Int32.TryParse(value, out result);
                switch (result)
                {
                    case 1:
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

        private static string GetDirectory ()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.FullName;
            return path;
        }
    }
}
