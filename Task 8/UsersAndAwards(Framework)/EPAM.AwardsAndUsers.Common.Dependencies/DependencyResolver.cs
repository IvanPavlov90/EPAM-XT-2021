using EPAM.AwardsAndUsers.BLL.Interfaces;
using EPAM.AwardsAndUsers.BLL.JSONBLL;
using EPAM.AwardsAndUsers.DAL.Interfaces;
using EPAM.AwardsAndUsers.DAL.JSONDAL;
using EPAM.AwardsAndUsers.DAL.SQLDAL;

namespace EPAM.AwardsAndUsers.Common.Dependencies
{
    public class DependencyResolver
    {
        private static DependencyResolver _instance;

        public static DependencyResolver Instance => _instance ?? new DependencyResolver();

        public IDAL UsersAndAwardsDAO => new SQLDAL();

        public ILogicBLL UsersAndAwardsBLL => new JsonLogic(UsersAndAwardsDAO);

    };
}
