using System;
using System.Collections.Generic;
using EPAM.UsersAndAwards.Common.Entities;

namespace EPAM.UsersAndAwards.BLL.Interfaces
{
    public interface ILogicBLL
    {
        void AddAward(Award award);

        void RemoveUser(Guid id);

        void RemoveAward(Guid id, bool userAction);

        List<User> GetAllUsers();

        List<Award> GetAllAwards();

        void EditUser(User user);

        bool CheckUsersHasAward(Guid id);

        void RecordData(Guid userID, Guid awardID);
    }
}
