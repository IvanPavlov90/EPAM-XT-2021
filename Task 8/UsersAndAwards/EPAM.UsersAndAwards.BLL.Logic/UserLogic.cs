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
            Data data = _daoLogic.LoadData();
            data.AddKey(user.id);
            _daoLogic.RecordUserToFile(user);
            _daoLogic.RecordData(data);
        }

        public List<Award> GetAllAwards()
        {
            return _daoLogic.GetAllAwards();
        }

        public List<User> GetAllUsers()
        {
            return _daoLogic.GetAllUsers();
        }

        public void EditUser(User user)
        {
            _daoLogic.RecordUserToFile(user);
        }

        public bool CheckUsersHasAward (Guid id)
        {
            Data data = _daoLogic.LoadData();
            foreach (var item in data.DataValue)
            {
                if (item.Value.Contains(id))
                    return true;
            }
            return false;
        }

        public void RemoveAward(Guid id, bool result)
        {
            if (result == true)
            {
                Data data = _daoLogic.LoadData();
                foreach (var item in data.DataValue)
                {
                    if (item.Value.Contains(id))
                        item.Value.Remove(id);
                }
                _daoLogic.RecordData(data);
                _daoLogic.RemoveAward(id);
            } else if (result == false)
                _daoLogic.RemoveAward(id);
        }

        public void RemoveUser(Guid id)
        {
            Data data = _daoLogic.LoadData();
            if (data.DataValue.Remove(id))
                _daoLogic.RecordData(data);
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
