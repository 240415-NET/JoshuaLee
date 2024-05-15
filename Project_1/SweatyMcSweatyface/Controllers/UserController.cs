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

                // New method to add additional user information
        public static void AddUserInfo(string userName, string firstName, string lastName, double Age, string Gender, double heightInches, double Weight, double BMI)
        {
            // Find the existing user (assuming the user already exists)
            User existingUser = UserStorage.FindUser(userName);

            if (existingUser != null)
            {
                // Update user details
                existingUser.firstName = firstName;
                existingUser.Age = Age;
        {
            // Find the existing user (assuming the user already exists)
            User existingUser = UserStorage.FindUser(userName);

            if (existingUser != null)
            {
                // Update user details
                existingUser.firstName = _firstName;
                existingUser.Age = _age;
                existingUser.Gender = _gender;
                existingUser.heightInches = _heightInches;
                existingUser.Weight = _weight;
                existingUser.BMI = _bmi;

                // Save the updated user profile
                UserStorage.UpdateUserInfo(existingUser);
            }
            else
            {
                Console.WriteLine($"User '{userName}' not found. Please create the user first.");
            }
        }
    }
}



////StoreUser(newUser); heads to 
///


        // public string firstName { get; set; }
        // public string lastName { get; set; }
        // public double heightInches { get; set; }
        // public double Weight { get; set; }
        // public double BMI { get; set; }
        // , string firstName, string lastName, double heightInches, double weight, double BMI
        // , newfirstName, newlastName, newheightInches, newWeight, newBMI
            //         User newfirstName = new User(firstName);
            // User newlastName = new User(lastName);
            // User newheightInches = new User(heightInches);
            // User newWeight = new User(Weight);
            // User newBMI = new User(BMI);