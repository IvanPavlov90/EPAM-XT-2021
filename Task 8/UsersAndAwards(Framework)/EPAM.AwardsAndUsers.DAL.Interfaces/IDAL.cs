using System;
using System.Collections.Generic;
using EPAM.AwardsAndUsers.Common.Entities;

namespace EPAM.AwardsAndUsers.DAL.Interfaces
{
    public interface IDAL
    {
        void RecordUserToFile(User user);

        void RecordAwardToFile(Award award);

        void RecordAuthToFile(AuthData newData);

        void RecordRolesToFile(RoleData roleData);

        void RemoveUser(Guid id);

        void RemoveAward(Guid id);

        List<User> GetAllUsers();

        List<Award> GetAllAwards();

        Data LoadData();

        void RecordData(Data data);

        List<AuthData> LoadAuthData();

        List<RoleData> LoadRolesData();
    }
}
