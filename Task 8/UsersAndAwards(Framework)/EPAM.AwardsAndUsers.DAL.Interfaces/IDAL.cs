using System;
using System.Collections.Generic;
using EPAM.AwardsAndUsers.Common.Entities;

namespace EPAM.AwardsAndUsers.DAL.Interfaces
{
    public interface IDAL
    {

        bool SetBase();

        bool RecordUserToFile(User user);

        void RecordAwardToFile(Award award);

        bool RecordAuthToFile(AuthData newData);

        bool RecordRolesToFile(RoleData roleData);

        void RemoveUser(Guid id);

        void RemoveAward(Guid id);

        void RemoveAuthData(Guid id);

        void RemoveRolesData(string username);

        IEnumerable<User> GetAllUsers();

        List<Award> GetAllAwards();

        Data LoadData();

        void RecordData(Data data);

        IEnumerable<AuthData> LoadAuthData();

        List<RoleData> LoadRolesData();
    }
}
