using EPAM.AwardsAndUsers.Common.Dependencies;
using EPAM.AwardsAndUsers.Common.Entities;
using System.Web.Security;

namespace EPAM.AwardsAndUsers.PL.WebPL.Models
{
    public class AppRoles : RoleProvider
    {
        public override string ApplicationName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            RoleData roleData = new RoleData(usernames, roleNames);
            DependencyResolver.Instance.UsersAndAwardsBLL.RecordRoleData(roleData);
        }

        public override void CreateRole(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new System.NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new System.NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new System.NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            if (username == "Administrator")
                return new string[] { "Administrator" };
            else
                return DependencyResolver.Instance.UsersAndAwardsBLL.FindRole(username);
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new System.NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new System.NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new System.NotImplementedException();
        }
    }
}