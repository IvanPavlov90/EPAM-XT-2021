using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.AwardsAndUsers.Common.Entities
{
    public class AwardAndUsersData
    {
        public AwardAndUsersData(Guid userid, Guid awardid)
        {
            UserID = userid;
            AwardID = awardid;
        }

        public Guid UserID { get; private set; }

        public Guid AwardID { get; private set; }
    }
}
