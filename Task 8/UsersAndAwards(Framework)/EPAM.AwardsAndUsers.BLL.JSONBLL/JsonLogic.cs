using System;
using System.Collections.Generic;
using System.Linq;
using EPAM.AwardsAndUsers.BLL.Interfaces;
using EPAM.AwardsAndUsers.Common.Entities;
using EPAM.AwardsAndUsers.DAL.Interfaces;

namespace EPAM.AwardsAndUsers.BLL.JSONBLL
{
    public class JsonLogic: ILogicBLL
    {
        private IDAL _daoLogic;

        public JsonLogic(IDAL daoLogic)
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

        public bool CheckUsersHasAward(Guid id)
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
            }
            else if (result == false)
                _daoLogic.RemoveAward(id);
        }

        public bool FindUser (string username)
        {
            List<User> users = _daoLogic.GetAllUsers();
            User user = users.FirstOrDefault(item => item.Name == username);
            if (user != null)
                return true;
            else
                return false;
        }

        public bool AuthUser(int passwordHash)
        {
            List<AuthData> authData = _daoLogic.LoadAuthData();
            foreach (var item in authData)
            {
                if (item.UserPasswordHash == passwordHash)
                    return true;
            }
            return false;
        }

        public void RecordAuthData(AuthData newData)
        {
            _daoLogic.RecordAuthToFile(newData);
        }

        public void RecordRoleData(RoleData roleData)
        {
            _daoLogic.RecordRolesToFile(roleData);
        }

        public void RemoveUser(Guid id)
        {
            Data data = _daoLogic.LoadData();
            if (data.DataValue.Remove(id))
                _daoLogic.RecordData(data);
            _daoLogic.RemoveUser(id);
        }

        public void RecordData(Guid userID, Guid awardID)
        {
            Data data = _daoLogic.LoadData();
            data.AddData(userID, awardID);
            _daoLogic.RecordData(data);
        }

        public string[] FindRole (string username)
        {
            RoleData user = _daoLogic.LoadRolesData().First(item => item.Usernames[0] == username);
            return user.RoleNames;
        }
    }
}
