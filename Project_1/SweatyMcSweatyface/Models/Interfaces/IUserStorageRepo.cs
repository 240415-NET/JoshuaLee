using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweatyMcSweatyface.Models
{
    public interface IUserStorageRepo
    {
        public void StoreUser(User user);
        public User FindUser(string usernameToFind);  
        public void updateUser(User user);

        public void UpdateUserFirstName(string userId, string newFirstName);

        public void UpdateUserLastName(string userId, string newLastName);

        public void UpdateUserBirthDateNAge(string userId, DateTime newBirthDateParsed, int newAge);

        public void UpdateUserHeightWeightBMI(string userId, double newHeight, double newWeight, double newBMI);
        
    }
}