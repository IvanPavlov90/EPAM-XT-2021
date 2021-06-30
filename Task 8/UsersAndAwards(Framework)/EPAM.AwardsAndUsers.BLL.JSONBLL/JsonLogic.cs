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

        public void SetBase()
        {
            _daoLogic.SetBase();
        }

        public void AddUser(User user)
        {
            _daoLogic.RecordUserToFile(user);
        }

        public void AddAward(Award award)
        {
            _daoLogic.RecordAwardToFile(award);
        }

        public void RemoveUser(Guid id)
        {
            Data data = _daoLogic.LoadData();
            User user = _daoLogic.GetAllUsers().First(item => item.id == id);
            if (data.DataValue.Remove(id))
                _daoLogic.RecordData(data);
            _daoLogic.RemoveUser(id);
            _daoLogic.RemoveAuthData(id);
            _daoLogic.RemoveRolesData(user.Name);
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

        public bool RemoveRole(string username)
        {
            _daoLogic.RemoveRolesData(username);
            return true;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _daoLogic.GetAllUsers();
        }


        public IEnumerable<Award> GetAllAwards()
        {
            return _daoLogic.GetAllAwards();
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

        public void RecordData(Guid userID, Guid awardID)
        {
            Data data = _daoLogic.LoadData();
            data.AddKey(userID);
            data.AddData(userID, awardID);
            _daoLogic.RecordData(data);
        }

        public Data LoadData()
        {
            return _daoLogic.LoadData();
        }

        public bool AuthUser(int passwordHash)
        {
            IEnumerable<AuthData> authData = _daoLogic.LoadAuthData();
            foreach (var item in authData)
            {
                if (item.UserPasswordHash == passwordHash)
                    return true;
            }
            return false;
        }

        public bool FindUser (string username)
        {
            IEnumerable<User> users = _daoLogic.GetAllUsers();
            User user = users.FirstOrDefault(item => item.Name == username);
            if (user != null)
                return true;
            else
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

        public string[] FindRole (string username)
        {
            RoleData user = _daoLogic.LoadRolesData().First(item => item.Usernames[0] == username);
            return user.RoleNames;
        }

        public void UpdateAward(Award award)
        {
            _daoLogic.UpdateAward(award);
        }
    }
}
