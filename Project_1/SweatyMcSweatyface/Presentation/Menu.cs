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

        Console.WriteLine("Welcome to SweatyMcSweatyface!");
        Console.WriteLine("1. New Sweaty user");
        Console.WriteLine("2. Returning Sweaty user");
        Console.WriteLine("3. Exit program");
        
        do
        {
            try
            {
                userChoice = Convert.ToInt32(Console.ReadLine());
                validInput = true;

                switch (userChoice)
                {
                    case 1: 
                        UserCreationMenu(); //Creating a new user
                        break;
                    case 2:
                        UserSignIn(); //Already existing users sign in here
                        break;

                    case 3: //Exit the program
                        return; //This return exits this method, and returns us to where it was called.

                    default: 
                        Console.WriteLine("Please enter a valid choice...Like 1, 2, or 3.");
                        validInput = false;
                        break;
                }

            }
            catch (Exception ex) 
            {   
                validInput = false;
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("That doesn't seem right... Please enter a valid choice!");
            }
            

        } while (!validInput);

        
    }

    public static void UserCreationMenu() // Here's where we create the Users
    {
 
        bool validInput = true;
        string userInput = "";
        string firstName = "";
        string lastName = "";
        var birthDate = new DateOnly(2024,01,01);
        double heightInches = 0;
        double Weight = 0;

        do
        {   
            //Prompting the user for a username
            Console.WriteLine("Let's get started by creating your username.\n Please enter a username: ");


            userInput = Console.ReadLine() ?? "";   // Double ?s (null-coalescing operator) sets it to an empty string instead of it being a null

            userInput = userInput.Trim();

            if(String.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Whoops! Looks like you forgot to enter a Username. Please try again.");
                validInput = false;
            }
            else if(UserController.UserExists(userInput))
            {
                Console.WriteLine("Doh! That Username is already in use. Please choose another.");
                
                validInput = false;
            }
   
            Console.WriteLine("In order to track your progression, we will need some additional information. \nPlease enter your first name: ");


                firstName = Console.ReadLine() ?? "";

                firstName = firstName.Trim();

                if (String.IsNullOrEmpty(firstName))
                {
                    Console.WriteLine("Whoops! Please enter your first name.\n");
                    validInput = false;
                }
                
                Console.WriteLine("Please enter your last name: ");

                lastName = Console.ReadLine() ?? "";
                lastName = lastName.Trim();

                if (String.IsNullOrEmpty(lastName))
                {
                    Console.WriteLine("Whoops! Please enter your last name.\n");
                    validInput = false;
                }

                Console.WriteLine("Please enter your date of birth in this format: MM/DD/YYYY \nSo, if you were born on December 25, 1980, you would enter: 12/25/1980.\n ");

                try
                {
                    birthDate = DateOnly.Parse(Console.ReadLine() ?? "");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    Console.WriteLine("Whoops! Please enter your date of birth in the correct format.\n");
                    validInput = false;
                }

                
                //Here we are calculating the user's age based on their birthdate

                var Today = DateOnly.FromDateTime(DateTime.Today);
                var ageInDays = Today.DayNumber - birthDate.DayNumber;
                int Age = (int)(ageInDays / 365.25);

                Console.WriteLine("Please enter your height in inches: \n");

                try
                {
                    heightInches = Convert.ToDouble(Console.ReadLine() ?? "");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    Console.WriteLine("Whoops! Please enter your height in inches.\n");
                    validInput = false;
                }

                Console.WriteLine("Please enter your weight in pounds: \n");


                try
                {
                    Weight = Convert.ToDouble(Console.ReadLine() ?? "");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    Console.WriteLine("Whoops! Please enter your weight in pounds.\n");
                    validInput = false;
                }

                double BMI  = (Weight / (heightInches * heightInches)) * 703;

                {
                    UserController.AddUserInfo(userInput, firstName, lastName, Age, heightInches, Weight, BMI);
                    Console.WriteLine("Profile created!");
                    validInput = true;
                }

            // else
            // { 
            //     UserController.CreateUser(userInput);
            //     Console.WriteLine("Profile created!");
            //     validInput = true;
            // }

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
                AfterLogInMenu.PostLogInChoiceMenu();
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
