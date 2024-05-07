using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SweatyMcSweatyface.Controllers;
using SweatyMcSweatyface.DataAccess;
using SweatyMcSweatyface.Presentation;

namespace SweatyMcSweatyface.Models
{
    public class User
    {

        public Guid userId { get; set; }
        public string userName { get; set; }

        //Constructors

        //Default/No argument constructor
        public User() { }

        //This constructor takes two arguments
        public User(string _userName)
        {
            userId = Guid.NewGuid(); //This creates a random Guid for us, without us having to worry about it
            userName = _userName;
        }

    }
}