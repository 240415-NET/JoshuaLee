using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SweatyMcSweatyface.Controllers;
using SweatyMcSweatyface.Models;
using SweatyMcSweatyface.Presentation;
using System.Text.Json;

namespace SweatyMcSweatyface.Data;

    public class JsonUserStorage 
    //: IUserStorageRepo
    {

        // public static string filePath = "UsersFile.json";


        // //Changed my methods to be instance methods instead of class methods

        // public void StoreUser(User user)
        // {

        //     if (File.Exists(filePath))
        //     {
        //         string existingUsersJson = File.ReadAllText(filePath);

        //         List<User> existingUsersList = JsonSerializer.Deserialize<List<User>>(existingUsersJson);

        //         existingUsersList?.Add(user);

        //         string jsonExistingUsersListString = JsonSerializer.Serialize(existingUsersList);

        //         File.WriteAllText(filePath, jsonExistingUsersListString);
        //     }
        //     else if (!File.Exists(filePath)) //The first time the program runs, the file probably doesn't exist
        //     {
        //         //Creating a blank list to use later
        //         List<User> initialUsersList = new List<User>();

        //         //Adding our user to our list, PRIOR to serializing it
        //         initialUsersList.Add(user);

        //         //Here we will serialize our list of users, into a JSON text string
        //         string jsonUsersListString = JsonSerializer.Serialize(initialUsersList);

        //         //Now we will store our jsonUsersString to our file
        //         File.WriteAllText(filePath, jsonUsersListString);
        //     }

        // }

        // public User FindUser(string usernameToFind)
        // {
        //     //User object to store a user if they are found or NULL if they are not
        //     User foundUser = new User(usernameToFind);
        //     try
        //     {

        //         //First, read the string back from our .json file
        //         string existingUsersJson = File.ReadAllText(filePath);

        //         //Then, we need to serialize the string back into a List of User objects
        //         List<User> existingUsersList = JsonSerializer.Deserialize<List<User>>(existingUsersJson);
                
        //         foundUser = existingUsersList?.FirstOrDefault(user => user.userName == usernameToFind);
        //         return foundUser;

        //         //The above lambda function is essentially iterating through and querying the list for us, 
        //         //as if we were doing the foreach loop below
        //         // foreach (User user in existingUsersList){
        //         //     if(user.userName == usernameToFind)
        //         //     {
        //         //         return user;
        //         //     }
        //         // }

        //         //If it exists, return that user


        //         //If it doesn't... do something else 


        //     }
        //     catch (Exception e)
        //     {
        //         Console.WriteLine(e.Message);
        //     }

        //     return null;

        // }

        

    }