using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SweatyMcSweatyface.Controllers;
using SweatyMcSweatyface.Data;
using SweatyMcSweatyface.Models;
using SweatyMcSweatyface.Presentation;

namespace SweatyMcSweatyface.Presentation
{
    public class Menu
    {

        public static void StartMenu()
        {

            int userChoice = 0;
            bool validInput = true;
            Console.Clear();
            Console.WriteLine("Welcome to SweatyMcSweatyface!");
            Console.WriteLine("1. New Sweaty user");
            Console.WriteLine("2. Returning Sweaty user");
            Console.WriteLine("3. Exit program");

            do
            {
                try
                {
                    userChoice = Convert.ToInt32(Console.ReadLine() ?? "");
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
            string userId;

            Console.Clear();
            Console.WriteLine("Let's get started by creating your username.\n\n");
            do
            {
                //Prompting the user for a username
                Console.WriteLine("Please enter a username:\n");

                userInput = Console.ReadLine() ?? "";   // Double ?s (null-coalescing operator) sets it to an empty string instead of it being a null
                Console.Clear();

                userInput = userInput.Trim();

                if (String.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Username cannot be blank.\n");
                    validInput = false;
                }
                else if (UserController.UserExists(userInput))
                {
                    Console.WriteLine("Username already exists.\n");
                    validInput = false;
                }
                else
                {
                    validInput = true;

                }

            } while (!validInput);

            PromptForUserData(userInput);
            Console.WriteLine("Goodbye and keep it Sweaty!");

        }

        public static void UserSignIn()
        {
            bool signIn = false;
            Console.Clear();
            Console.WriteLine("Please provide your username to sign in\n");
            string userInput = Console.ReadLine().Trim();
            do
            {

                if (String.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Looks like you forgot to enter a Username. Please try again.");
                    signIn = false;
                }
                else if (!UserController.UserExists(userInput))
                {
                    Console.WriteLine($"User not found! \nDo you need to create a new user? (yes\\no)");
                    userInput = Console.ReadLine().Trim();
                    if (userInput == "yes" || userInput == "y")
                    {
                        signIn = true;
                        UserCreationMenu();
                    }
                    else
                    {
                        Console.WriteLine("Please provide your username to sign in\n");
                        userInput = Console.ReadLine().Trim();
                    }
                }
                else
                {
                    User userSignedIn = UserController.ReturnUser(userInput);
                    Console.Clear();
                    Console.WriteLine($"User Id: {userSignedIn.userId}");
                    Console.WriteLine($"User Name: {userSignedIn.userName}");
                    signIn = true;
                }

            }
            while (signIn == false);
            AfterLogInMenu.PostLogInChoiceMenu(userInput);
        }

        public static void PromptForUserData(string userName)
        {
            bool validInput = true;

            do
            {
                string firstName = "";
                string lastName = "";
                var birthDate = new DateTime();
                double heightInches = 0;
                double Weight = 0;

                //Prompting the user for their additional information

                Console.Clear();
                Console.WriteLine($"In order to track your progress, we will need some additional information.\n\nPlease enter your first name:\n");


                firstName = Console.ReadLine() ?? "";
                Console.Clear();
                firstName = firstName.Trim();

                if (String.IsNullOrEmpty(firstName))
                {
                    Console.WriteLine("Whoops! Please enter your first name.\n");
                    validInput = false;
                }

                Console.WriteLine("Please enter your last name:\n");

                lastName = Console.ReadLine() ?? "";
                lastName = lastName.Trim();
                Console.Clear();
                if (String.IsNullOrEmpty(lastName))
                {
                    Console.WriteLine("Whoops! Looks like you forgot something.\n");
                    validInput = false;
                }

                Console.WriteLine("Please enter your date of birth in this format: MM/DD/YYYY \nSo, if you were born on December 25, 1980, you would enter: 12/25/1980.\n ");

                try
                {
                    birthDate = DateTime.Parse(Console.ReadLine() ?? "");
                    Console.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Whoops! Please enter your date of birth in the correct format.\n");
                    validInput = false;
                }


                //Here we are calculating the user's age based on their birthdate

                var Today = DateTime.Today;
                var Age = Today.Year - birthDate.Year;
                if (birthDate.Date > Today.AddYears(-Age)) Age--;


                Console.WriteLine("Please enter your height in inches: \n");

                try
                {
                    heightInches = Convert.ToDouble(Console.ReadLine() ?? "");
                    Console.Clear();
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine("Whoops! Please enter your height in inches.\n");
                    validInput = false;
                }

                Console.WriteLine("Please enter your weight in pounds: \n");


                try
                {
                    Weight = Convert.ToDouble(Console.ReadLine() ?? "");
                    Console.Clear();
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine("Whoops! Please enter your weight in pounds.\n");
                    validInput = false;
                }

                double BMI = Weight / (heightInches * heightInches) * 703;


                {
                    UserController.CreateUser(userName, firstName, lastName, birthDate, Age, heightInches, Weight, BMI);
                    Console.WriteLine("User Data Stored!\n\n");
                    validInput = true;
                }

            } while (!validInput);

            AfterLogInMenu.PostLogInChoiceMenu(userName);

        }

    }
}