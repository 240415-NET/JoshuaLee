using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweatyMcSweatyface.Models
{
    public interface IUserStorageRepo //This is our interface for our UserStorageRepo
    {
        public void StoreUser(User user); //This method will store a user to our SQL database
        public User FindUser(string usernameToFind);   //This method will find a user in our SQL database
        public void updateUser(User user); //This method will update a user in our SQL database

        public User GetUserData(string usernameToFind); //This method will return a user's data from our SQL database

        public void UpdateUserFirstName(string userId, string newFirstName); //This method will update a user's first name in our SQL database

        public void UpdateUserLastName(string userId, string newLastName); //This method will update a user's last name in our SQL database

        public void UpdateUserBirthDateNAge(string userId, DateTime newBirthDateParsed, int newAge); //This method will update a user's birth date and age in our SQL database

        public void UpdateUserHeightWeightBMI(string userId, double newHeight, double newWeight, double newBMI);  //This method will update a user's height, weight, and BMI in our SQL database
        
    }
}