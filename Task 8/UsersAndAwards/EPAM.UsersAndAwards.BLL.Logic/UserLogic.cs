using System;
using System.Collections.Generic;
using EPAM.UsersAndAwards.BLL.Interfaces;
using EPAM.UsersAndAwards.Common.Entities;
using EPAM.UsersAndAwards.DAL.Interfaces;

namespace EPAM.UsersAndAwards.BLL.Logic
{
    public class UserLogic : ILogicBLL
    {
        private IJsonDAO _daoLogic;

        public UserLogic(IJsonDAO daoLogic)
        {
            _daoLogic = daoLogic;
        }

        public void AddAward(Award award)
        {
            _daoLogic.RecordAwardToFile(award);
        }

        public void AddUser(User user)
        {
            _daoLogic.RecordUserToFile(user);
        }

        public List<Award> GetAllAwards()
        {
            return _daoLogic.GetAllAwards();
        }

        public List<User> GetAllUsers()
        {
            return _daoLogic.GetAllUsers();
        }

        public void RemoveAward(Guid id)
        {
            _daoLogic.RemoveAward(id);
        }

        public void RemoveUser(Guid id)
        {
            _daoLogic.RemoveUser(id);
        }

        public void RecordData (Guid userID, Guid awardID)
        {
            Data data = _daoLogic.LoadData();
            data.AddData(userID, awardID);
            _daoLogic.RecordData(data);
        }
    }
}
