using EPAM.UsersAndAwards.BLL.Interfaces;
using EPAM.UsersAndAwards.BLL.Logic;
using EPAM.UsersAndAwards.DAL.Interfaces;
using EPAM.UsersAndAwards.DAL.JsonDao;

namespace EPAM.UsersAndAwards.Common.Dependencies
{
    public class DependencyResolver
    {
        private static DependencyResolver _instance;

        public static DependencyResolver Instance => _instance ??= new DependencyResolver();

        public IJsonDAO UsersAndAwardsDAO => new JsonDAOLogic();

        public ILogicBLL UsersAndAwardsBLL => new UserLogic(UsersAndAwardsDAO);

    };
}
