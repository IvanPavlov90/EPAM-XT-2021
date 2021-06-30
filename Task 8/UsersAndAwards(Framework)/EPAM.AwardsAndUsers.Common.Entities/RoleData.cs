
using System;
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
            Usernames = CheckincomingArray(usernames);
            RoleNames = CheckincomingArray(roleNames);
        }

        [JsonInclude]
        public string[] Usernames { get; private set; }

        [JsonInclude]
        public string[] RoleNames { get; private set; }

        private string[] CheckincomingArray (string[] arr)
        {
            if (arr.Length == 0 || arr.Length > 1)
                throw new ArgumentException("You can't put empty array here or array with more then one element.");
            else return arr;
        }
    }
}
