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

        void RemoveUser(Guid id);

        void RemoveAward(Guid id);

        void RemoveAuthData(Guid id);

        void RemoveRolesData(string username);

        IEnumerable<User> GetAllUsers();

        IEnumerable<Award> GetAllAwards();

        Data LoadData();

        void RecordData(Data data);

        IEnumerable<AuthData> LoadAuthData();

        IEnumerable<RoleData> LoadRolesData();

        bool UpdateAward(Award award);
    }
}
