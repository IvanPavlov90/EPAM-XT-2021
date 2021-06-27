using System;
using System.Collections.Generic;
using EPAM.AwardsAndUsers.Common.Entities;

namespace EPAM.AwardsAndUsers.BLL.Interfaces
{
    public interface ILogicBLL
    {
        void AddUser(User user);

        void AddAward(Award award);

        void RemoveUser(Guid id);

        void RemoveAward(Guid id, bool userAction);

        List<User> GetAllUsers();

        List<Award> GetAllAwards();

        void EditUser(User user);

        bool CheckUsersHasAward(Guid id);

        void RecordData(Guid userID, Guid awardID);

        bool AuthUser(string username, int passwordHash);

        void RecordAuthData(AuthData newData);

        void RecordRoleData(RoleData roleData);

        string[] FindRole (string username);
    }
}
