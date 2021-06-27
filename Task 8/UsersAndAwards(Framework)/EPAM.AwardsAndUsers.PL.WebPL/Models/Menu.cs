using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPAM.AwardsAndUsers.PL.WebPL.Models
{
    public class Menu
    {
        private Dictionary<string, string> _adminMenu = new Dictionary<string, string> {
            { "AddUser", "Pages/AddUser.cshtml" },
            { "AddAward", "Pages/AddAward.cshtml" },
            { "RemoveUser", "Pages/RemoveUser.cshtml" },
            { "RemoveAward", "Pages/RemoveAward.cshtml" },
            { "GetAllUsers", "Pages/GetAllUsers.cshtml" },
            { "GetAllAwards", "Pages/GetAllAwards.cshtml" },
            { "EditUser", "Pages/EditUser.cshtml" },
            { "EditAward", "Pages/EditAward.cshtml" },
            { "AddAwardToUser", "Pages/AddAwardToUser.cshtml" },
            { "UsersAndAwards", "Pages/UsersAndAwards.cshtml" }
        };

        private Dictionary<string, string> _userMenu = new Dictionary<string, string> {
            { "GetAllUsers", "Pages/GetAllUsers.cshtml" },
            { "GetAllAwards", "Pages/GetAllAwards.cshtml" },
            { "UsersAndAwards", "Pages/UsersAndAwards.cshtml" },
        };

        public Dictionary<string, string> AdminMenu => _adminMenu;

        public Dictionary<string, string> UserMenu => _userMenu;
    }
}