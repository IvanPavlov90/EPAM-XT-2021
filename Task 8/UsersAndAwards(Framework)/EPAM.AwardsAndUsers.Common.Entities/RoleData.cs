
using System.Text.Json.Serialization;

namespace EPAM.AwardsAndUsers.Common.Entities
{
    public class RoleData
    {
        public RoleData()
        {

        }

        public RoleData(string[] usernames, string[] roleNames)
        {
            Usernames = usernames;
            RoleNames = roleNames;
        }

        [JsonInclude]
        public string[] Usernames { get; private set; }

        [JsonInclude]
        public string[] RoleNames { get; private set; }
    }
}
