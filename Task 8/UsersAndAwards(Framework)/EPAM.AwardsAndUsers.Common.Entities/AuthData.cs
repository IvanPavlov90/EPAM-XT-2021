using System;
using System.Text.Json.Serialization;

namespace EPAM.AwardsAndUsers.Common.Entities
{
    public class AuthData
    {
        public AuthData()
        {

        }

        public AuthData(Guid id, int hash)
        {
            UserID = id;
            UserPasswordHash = hash;
        }

        [JsonInclude]
        public Guid UserID { get; private set; }

        [JsonInclude]
        public int UserPasswordHash { get; private set; }

    }
}
