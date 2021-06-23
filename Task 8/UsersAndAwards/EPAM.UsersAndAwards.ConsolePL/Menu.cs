using System;
using System.Collections.Generic;
using EPAM.UsersAndAwards.Common.Dependencies;
using EPAM.UsersAndAwards.Common.Entities;

namespace EPAM.UsersAndAwards.PL.ConsolePL
{
    public class Menu
    {
        private enum Actions
        {
            AddUser = 1,
            AddAward = 2,
            RemoveUser = 3,
            RemoveAward = 4,
            GetAllUsers = 5,
            GetAllAwards = 6,
            AddAwardToUser = 7,
            Exit = 8,
            Default = 0
        }

        public void MenuStart()
        {
            Console.WriteLine("Welcome. Choose your option please: ");
            int result;
            do
            {
                ShowMenu();
                string value = Console.ReadLine();
                Int32.TryParse(value, out result);
                switch (result)
                {
                    case (int)Actions.AddUser:
                        Console.WriteLine("Please enter username.");
                        string username = Console.ReadLine();
                        Console.WriteLine("Please, enter date in format day.month.year, for example 18.04.2020");
                        DateTime birthdate = InputHelper.InputDate();
                        User user = new User(username, birthdate);
                        DependencyResolver.Instance.UsersAndAwardsBLL.AddUser(user);
                        break;
                    case (int)Actions.AddAward:
                        Console.WriteLine("Please enter award title.");
                        string title = Console.ReadLine();
                        Award award = new Award(title);
                        DependencyResolver.Instance.UsersAndAwardsBLL.AddAward(award);
                        break;
                    case (int)Actions.RemoveUser:
                        Console.WriteLine("Please specify user number you want to delete: ");
                        List<User> users = DependencyResolver.Instance.UsersAndAwardsBLL.GetAllUsers();
                        ShowUsers(users);
                        int userChoise = InputHelper.UserChoise(users.Count);
                        DependencyResolver.Instance.UsersAndAwardsBLL.RemoveUser(users[userChoise - 1].id);
                        break;
                    case (int)Actions.RemoveAward:
                        Console.WriteLine("Please specify award number you want to delete: ");
                        List<Award> awards = DependencyResolver.Instance.UsersAndAwardsBLL.GetAllAwards();
                        ShowAwards(awards);
                        int awardChoise = InputHelper.UserChoise(awards.Count);
                        /*DependencyResolver.Instance.UsersAndAwardsBLL.AwardToDelete += AskUserForDeletingAward;*/
                        DependencyResolver.Instance.UsersAndAwardsBLL.RemoveAward(awards[awardChoise - 1].id);
                        break;
                    case (int)Actions.GetAllUsers:
                        ShowUsers(DependencyResolver.Instance.UsersAndAwardsBLL.GetAllUsers());
                        break;
                    case (int)Actions.GetAllAwards:
                        ShowAwards(DependencyResolver.Instance.UsersAndAwardsBLL.GetAllAwards());
                        break;
                    case (int)Actions.AddAwardToUser:
                        Console.WriteLine("Please specify user you want to award: ");
                        List<User> users2 = DependencyResolver.Instance.UsersAndAwardsBLL.GetAllUsers();
                        ShowUsers(users2);
                        int userToAward = InputHelper.UserChoise(users2.Count);
                        Console.WriteLine("Please specify award you have chosen: ");
                        List<Award> awards2 = DependencyResolver.Instance.UsersAndAwardsBLL.GetAllAwards();
                        ShowAwards(awards2);
                        int chosenAward = InputHelper.UserChoise(awards2.Count);
                        DependencyResolver.Instance.UsersAndAwardsBLL.RecordData(users2[userToAward - 1].id, awards2[chosenAward - 1].id);
                        break;
                    case (int)Actions.Exit:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            } while (result >= 1 && result <= 7);
        }

        private bool UsersAndAwardsBLL_AwardToDelete()
        {
            throw new NotImplementedException();
        }

        private void ShowMenu()
        {
            foreach (Actions item in Enum.GetValues(typeof(Actions)))
            {
                if ((int)item != 0)
                {
                    Console.WriteLine($"{(int)item}.{item}");
                }
            }
        }

        private void ShowUsers (List<User> users)
        {
            int count = 1;
            foreach (User item in users)
            {
                Console.WriteLine($"{count}. Name - {item.Name}, Birthdate - {item.DateOfBirth}, Age - {item.Age}, ID - {item.id}");
                count++;
            }
        }

        private void ShowAwards(List<Award> awards)
        {
            int count = 1;
            foreach (Award item in awards)
            {
                Console.WriteLine($"{count}. Title - {item.Title}, ID - {item.id}");
                count++;
            }
        }

        private bool AskUserForDeletingAward()
        {
            Console.WriteLine("Some users have this award.");
            return false;
        }
    }
}
