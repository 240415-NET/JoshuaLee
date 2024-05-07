using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SweatyMcSweatyface.DataAccess;
using SweatyMcSweatyface.Models;
using SweatyMcSweatyface.Presentation;

namespace SweatyMcSweatyface.Controllers
{
    public class UserController
    {
        public static void CreateUser(string userName)
        {
            User newUser = new User(userName);

            UserStorage.StoreUser(newUser);
        }

        public static bool UserExists(string userName)
        {
            if (UserStorage.FindUser(userName) != null)
            {
                return true;
            }

            return false;
        }
    }
}