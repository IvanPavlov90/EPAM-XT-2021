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
            EditUser = 7,
            EditAward = 8,
            AddAwardToUser = 9,
            Exit = 10,
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
                        (string username, DateTime birthdate) = AddingUser();
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
                        DependencyResolver.Instance.UsersAndAwardsBLL.RemoveUser(SpecifyUserInList(DependencyResolver.Instance.UsersAndAwardsBLL.GetAllUsers()).id);
                        break;
                    case (int)Actions.RemoveAward:
                        Console.WriteLine("Please specify award number you want to delete: ");
                        Award awardToDelete = SpecifyAwardInList(DependencyResolver.Instance.UsersAndAwardsBLL.GetAllAwards());
                        if(DependencyResolver.Instance.UsersAndAwardsBLL.CheckUsersHasAward(awardToDelete.id))
                        {
                            if(InputHelper.AskUserForDeletingAward())
                                DependencyResolver.Instance.UsersAndAwardsBLL.RemoveAward(awardToDelete.id, true);
                        } 
                        else
                            DependencyResolver.Instance.UsersAndAwardsBLL.RemoveAward(awardToDelete.id, false);
                        break;
                    case (int)Actions.GetAllUsers:
                        ShowUsers(DependencyResolver.Instance.UsersAndAwardsBLL.GetAllUsers());
                        break;
                    case (int)Actions.GetAllAwards:
                        ShowAwards(DependencyResolver.Instance.UsersAndAwardsBLL.GetAllAwards());
                        break;
                    case (int)Actions.EditUser:
                        List<User> users = DependencyResolver.Instance.UsersAndAwardsBLL.GetAllUsers();
                        if (users.Count == 0)
                        {
                            Console.WriteLine("You haven't added any users");
                            break;
                        } else
                        {
                            Console.WriteLine("Please specify user number you want to edit: ");
                            User UserToEditInfo = SpecifyUserInList(users);
                            (string username2, DateTime birthdate2) = AddingUser();
                            UserToEditInfo.EditUser(username2, birthdate2);
                            DependencyResolver.Instance.UsersAndAwardsBLL.EditUser(UserToEditInfo);
                        }
                        break;
                    case (int)Actions.EditAward:
                        List<Award> awards = DependencyResolver.Instance.UsersAndAwardsBLL.GetAllAwards();
                        if (awards.Count == 0)
                        {
                            Console.WriteLine("You haven't added any awards");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please specify user number you want to edit: ");
                            Award awardToEdit = SpecifyAwardInList(awards);
                            Console.WriteLine("Please enter award title.");
                            string title2 = Console.ReadLine();
                            awardToEdit.EdtiTitle(title2);
                            DependencyResolver.Instance.UsersAndAwardsBLL.AddAward(awardToEdit);
                        }
                        break;
                    case (int)Actions.AddAwardToUser:
                        List<User> users2 = DependencyResolver.Instance.UsersAndAwardsBLL.GetAllUsers();
                        List<Award> awards2 = DependencyResolver.Instance.UsersAndAwardsBLL.GetAllAwards();
                        if (users2.Count == 0 || awards2.Count == 0)
                        {
                            Console.WriteLine("You haven't added user or award, please do it before adding award to user");
                            break;
                        } else
                        {
                            Console.WriteLine("Please specify user you want to award: ");
                            ShowUsers(users2);
                            int userToAward = InputHelper.UserChoise(users2.Count);
                            Console.WriteLine("Please specify award you have chosen: ");
                            ShowAwards(awards2);
                            int chosenAward = InputHelper.UserChoise(awards2.Count);
                            DependencyResolver.Instance.UsersAndAwardsBLL.RecordData(users2[userToAward - 1].id, awards2[chosenAward - 1].id);
                            break;
                        }
                    case (int)Actions.Exit:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            } while (result >= 1 && result <= 10);
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

        private (string, DateTime) AddingUser ()
        {
            Console.WriteLine("Please enter username.");
            string username = Console.ReadLine();
            Console.WriteLine("Please, enter date in format day.month.year, for example 18.04.2020");
            DateTime birthdate = InputHelper.InputDate();
            return (username, birthdate);
        }

        private User SpecifyUserInList (List<User> users)
        {
            ShowUsers(users);
            int userChoise = InputHelper.UserChoise(users.Count);
            return users[userChoise - 1];
        }

        private Award SpecifyAwardInList(List<Award> awards)
        {
            ShowAwards(awards);
            int awardChoise = InputHelper.UserChoise(awards.Count);
            return awards[awardChoise - 1];
        }
    }
}
