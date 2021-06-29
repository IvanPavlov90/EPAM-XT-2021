using System;
using System.Collections.Generic;
using EPAM.AwardsAndUsers.Common.Entities;

namespace EPAM.AwardsAndUsers.BLL.Interfaces
{
    public interface ILogicBLL
    {
        void SetBase();

        void AddUser(User user);

        void AddAward(Award award);

        void RemoveUser(Guid id);

        void RemoveAward(Guid id, bool userAction);

        bool RemoveRole(string username);

        IEnumerable<User> GetAllUsers();

        List<Award> GetAllAwards();

        void EditUser(User user);

        bool CheckUsersHasAward(Guid id);

        void RecordData(Guid userID, Guid awardID);

        Data LoadData();

        bool AuthUser(int passwordHash);

        bool FindUser(string username);

        void RecordAuthData(AuthData newData);

        void RecordRoleData(RoleData roleData);

        string[] FindRole (string username);
    }
}
