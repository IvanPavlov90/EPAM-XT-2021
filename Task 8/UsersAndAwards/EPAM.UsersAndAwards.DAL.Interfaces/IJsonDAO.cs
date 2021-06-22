using System;
using System.Collections.Generic;
using EPAM.UsersAndAwards.Common.Entities;

namespace EPAM.UsersAndAwards.DAL.Interfaces
{
    public interface IJsonDAO
    {
        void RecordUserToFile(User user);

        void RecordAwardToFile(Award award);

        void RemoveUser(Guid id);

        void RemoveAward(Guid id);

        List<User> GetAllUsers();

        List<Award> GetAllAwards();
    }
}
