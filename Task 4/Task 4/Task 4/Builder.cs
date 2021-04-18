using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    public static class Builder
    {
        public static void BuildFiles (List<FileEventsInfoLog> fileEvent, DateTime date)
        {
            foreach (var item in fileEvent)
            {
                if (item.LastChangesTime <= date)
                    item.PrintState();
            }
        }
    }
}
