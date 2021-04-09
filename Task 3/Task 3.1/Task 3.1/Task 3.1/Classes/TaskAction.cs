using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3._1.Classes
{
    public static class TaskAction
    {
        /// <summary>
        /// Method for crossing people
        /// </summary>
        public static void CrossPeopleOut(PeopleList<int> people, bool crossingIndicator, int round)
        {
            while (people.Count >= 1)
            {
                foreach (var item in people)
                {
                    if (people.Count == 1)
                    {
                        PrintData.PrintWinner(item);
                        Environment.Exit(0);
                    }
                    else
                    {
                        crossingIndicator = !crossingIndicator;
                        if (crossingIndicator)
                        {
                            if (item == people[people.Count - 1])
                            {
                                PrintData.Print(round, item, people.Count - 1);
                                round++;
                                people.Remove(item);
                            }
                            else
                            {
                                PrintData.Print(round, item, people.Count - 1);
                                round++;
                                people.Remove(item);
                                crossingIndicator = !crossingIndicator;
                            }
                        }
                    }
                }
            }
        }
    }
}
