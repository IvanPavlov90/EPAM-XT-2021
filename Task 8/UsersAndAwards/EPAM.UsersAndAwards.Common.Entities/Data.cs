using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EPAM.UsersAndAwards.Common.Entities
{
    public class Data
    {
        public Data()
        {

        }

        private Dictionary<Guid, List<Guid>> _dataValue = new Dictionary<Guid, List<Guid>> { };

        public Dictionary<Guid, List<Guid>> DataValue => _dataValue;

        public void AddData (Guid userID, Guid awardID)
        {
            if (DataValue.ContainsKey(userID))
            {
                DataValue[userID].Add(awardID);
                Console.WriteLine("if");
            }
            else
            {
                DataValue.Add(userID, new List<Guid> { awardID });
                Console.WriteLine("else");
            }

            foreach (var item in DataValue)
            {
                Console.WriteLine(item.Key);
                foreach (var value in item.Value)
                {
                    Console.WriteLine(value);
                }
            }
        }
    }
}
