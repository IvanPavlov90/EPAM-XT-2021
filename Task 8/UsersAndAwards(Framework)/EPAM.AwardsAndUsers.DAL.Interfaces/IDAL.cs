using System;
using System.Collections.Generic;
using EPAM.AwardsAndUsers.Common.Entities;

namespace EPAM.AwardsAndUsers.DAL.Interfaces
{
    public interface IDAL
    {

        bool SetBase();

        bool RecordUserToFile(User user);

        bool RecordAwardToFile(Award award);

        bool RecordAuthToFile(AuthData newData);

        bool RecordRolesToFile(RoleData roleData);

        bool RemoveUser(Guid id);

        bool RemoveAward(Guid id);

        bool RemoveAuthData(Guid id);

        bool RemoveData(User user);

        bool RemoveRolesData(string username);

        bool RemoveAwardFromTableWithUsersAndAwards(Guid id);

        IEnumerable<User> GetAllUsers();

        IEnumerable<Award> GetAllAwards();

        Data LoadData();

        bool RecordData(Guid userID, Guid awardID);

        IEnumerable<AuthData> LoadAuthData();

        IEnumerable<RoleData> LoadRolesData();

        bool UpdateAward(Award award);

        bool UpdateUser(User user);
    }
}
