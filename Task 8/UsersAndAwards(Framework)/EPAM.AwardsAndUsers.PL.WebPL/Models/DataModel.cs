using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPAM.AwardsAndUsers.PL.WebPL.Models
{
    public class DataModel
    {
        public int UserCount { get; set; }

        public int AwardCount { get; set; }

        public bool AwardSearchResult { get; set; }

        public static Guid awardID { get; set; }

        public bool WrongPassword { get; set; }

        public bool UserAlreadyHasBeenCreated { get; set; }

        public bool DeletingAdministrator { get; set; }

    }
}