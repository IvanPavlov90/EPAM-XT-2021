using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public static void ChosingMode ()
        {
            int result;
            do
            {
                ShowModeMenu();
                Print.PrintMessage("Choose your option:");
                string value = Console.ReadLine();
                Int32.TryParse(value, out result);
                switch (result)
                {
                    case 1:
                        FileWatcher fileWatcher = new FileWatcher();
                        fileWatcher.WatchFolder(@"C:\Users\pavlo\Desktop\projects\EPAM-XT-2021\Task 4\Files");
                        break;
                    case 2:
                        DateTime date;
                        DateTime defaultDate = new DateTime(2000, 1, 1);
                        do
                        {
                            date = InputHelper.InputDate();
                        } while (date == defaultDate);
                        List<FileEventsInfo> fileEvent = Reader.ReadLog(@"C:\Users\pavlo\Desktop\projects\EPAM-XT-2021\Task 4\Log.json");
                        Builder.BuildState(fileEvent, date);
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
