using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPAM.AwardsAndUsers.PL.WebPL.Models
{
    public static class DataModel
    {
        public static int UserCount { get; set; }

        public static int AwardCount { get; set; }

        public static bool AwardSearchResult { get; set; }

        public static Guid awardID { get; set; }

        public static bool WrongPassword { get; set; }

        public static bool UserAlreadyHasBeenCreated { get; set; }

    }
}