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
    }
}