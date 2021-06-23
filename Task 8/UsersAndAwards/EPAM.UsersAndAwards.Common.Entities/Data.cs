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

        [JsonInclude]
        public Dictionary<Guid, List<Guid>> DataValue { get; private set; } = new Dictionary<Guid, List<Guid>> { };

        public void AddKey (Guid userID)
        {
            DataValue.Add(userID, new List<Guid> { });
        }

        public void AddData (Guid userID, Guid awardID)
        {
            if (!DataValue[userID].Contains(awardID))
                DataValue[userID].Add(awardID);
        }
    }
}
