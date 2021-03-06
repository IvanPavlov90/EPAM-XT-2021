﻿using System;
using System.Text.Json.Serialization;

namespace EPAM.AwardsAndUsers.Common.Entities
{
    public class Award
    {
        public Award()
        {

        }

        public Award(Guid ID, string awardTitle)
        {
            id = ID;
            Title = checkTitle(awardTitle);
        }

        public Award(string title)
        {
            id = Guid.NewGuid();
            Title = checkTitle(title);
        }

        [JsonInclude]
        public Guid id { get; private set; }

        [JsonInclude]
        public string Title { get; private set; }

        public void EdtiTitle(string title)
        {
            Title = checkTitle(title);
        }

        private string checkTitle(string title)
        {
            if (title.Trim().Length == 0 || title == String.Empty || title == null)
            {
                throw new ArgumentException($"You can't put empty or white space string into title");
            }
            return title;
        }
    }
}
