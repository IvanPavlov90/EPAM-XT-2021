using System;
using System.Collections.Generic;
using EPAM.UsersAndAwards.Common.Entities;

namespace EPAM.UsersAndAwards.BLL.Interfaces
{
    public interface ILogicBLL
    {
        void AddUser(User user);

        void AddAward(Award award);

        void RemoveUser(Guid id);

        void RemoveAward(Guid id);

        List<User> GetAllUsers();

        List<Award> GetAllAwards();

        void RecordData(Guid userID, Guid awardID);
    }
}
