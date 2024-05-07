using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SweatyMcSweatyface.Controllers;
using SweatyMcSweatyface.DataAccess;
using SweatyMcSweatyface.Models;
using SweatyMcSweatyface.Presentation;

namespace SweatyMcSweatyface.Presentation
{
    public class Menu
    {

    public static void StartMenu() {

        int userChoice = 0;
        bool validInput = true;

        Console.WriteLine("Welcome to TrackMyStuff!");
        Console.WriteLine("1. New user");
        Console.WriteLine("2. Returning user");
        Console.WriteLine("3. Exit program");
        
        do
        {
            try
            {
                userChoice = Convert.ToInt32(Console.ReadLine());
                validInput = true;

                switch (userChoice)
                {
                    case 1: // Creating a new user profile
                        UserCreationMenu();
                        break;
                    case 2:
                        UserSignIn();
                        break;

                    case 3: //User chooses to exit the program
                        return; //This return exits this method, and returns us to where it was called.

                    default: // If the user enters an integer that is not 1, 2, or 3
                        Console.WriteLine("Please enter a valid choice (from the default)!");
                        validInput = false;
                        break;
                }

            }
            catch (Exception ex) 
            {   
                validInput = false;
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("Please enter a valid choice! (from the catch)");
            }

        } while (!validInput);

        
    }

    //This method handles the prompts for creating a new user profile
    public static void UserCreationMenu() 
    {
 
        bool validInput = true;
        string userInput = "";

        do
        {   
            //Prompting the user for a username
            Console.WriteLine("Please enter a username: ");


            userInput = Console.ReadLine() ?? "";

            userInput = userInput.Trim();

            if(String.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Username cannot be blank, please try again.");
                validInput = false;
            }else if(UserController.UserExists(userInput))
            {
                Console.WriteLine("Username already exists, please choose another.");
                
                validInput = false;
            }else{ 
                UserController.CreateUser(userInput);
                Console.WriteLine("Profile created!");
                validInput = true;
            }

        } while (!validInput); 

    }
    
    public static void UserSignIn()
    {
        bool signIn = false;
        Console.WriteLine("Please key username to sign in");
        string userRequest = Console.ReadLine().Trim();
        do
        {
            
            if (UserStorage.FindUser(userRequest) != null)
            {
                User userSignedIn = UserStorage.FindUser(userRequest);
                Console.WriteLine($"User Id: {userSignedIn.userId}");
                Console.WriteLine($"User Name: {userSignedIn.userName}");
                signIn = true;
            }
            else if (UserStorage.FindUser(userRequest) == null)
            {
                Console.WriteLine("User not found! Do you need to create a new user? Key yes to go to creation or rekey email");
                userRequest = Console.ReadLine().Trim();
                if (userRequest == "yes" || userRequest == "y")
                {
                    signIn = true;
                    UserCreationMenu();
                }
            }
        }
        while (signIn == false);
    }
    }
}