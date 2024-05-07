using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SweatyMcSweatyface.Controllers;
using SweatyMcSweatyface.Models;
using SweatyMcSweatyface.Presentation;
using System.Text.Json;

namespace SweatyMcSweatyface.DataAccess
{
    public class UserStorage
    {

        public static string filePath = "UsersFile.json";

        public static void StoreUser(User user)
        {
            if (File.Exists(filePath))
            {

                string existingUsersJson = File.ReadAllText(filePath);

                List<User> existingUsersList = JsonSerializer.Deserialize<List<User>>(existingUsersJson);

                existingUsersList.Add(user);

                string jsonExistingUsersListString = JsonSerializer.Serialize(existingUsersList);

                File.WriteAllText(filePath, jsonExistingUsersListString);

            }
            else if (!File.Exists(filePath))
            {
                List<User> initialUsersList = new List<User>();

                initialUsersList.Add(user);

                string jsonUsersListString = JsonSerializer.Serialize(initialUsersList);

                File.WriteAllText(filePath, jsonUsersListString);
            }

        }

        public static User FindUser(string usernameToFind)
        {
            User foundUser = new User();

            try
            {

                string existingUsersJson = File.ReadAllText(filePath);

                List<User> existingUsersList = JsonSerializer.Deserialize<List<User>>(existingUsersJson);

                foundUser = existingUsersList.FirstOrDefault(user => user.userName == usernameToFind);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return foundUser;

        }
    }
}