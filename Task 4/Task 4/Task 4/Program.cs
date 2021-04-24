using System;
using System.IO;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var directoryPath = AppMenu.AskUserToSpecifyDirectory();
            AppMenu.MenuStart(directoryPath);
        }
    }
}
