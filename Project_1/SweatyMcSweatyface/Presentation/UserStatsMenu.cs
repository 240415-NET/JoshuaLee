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
    public class UserStatsMenu : Menu
    {

    public static void StartStatsMenu(User user) {

        int userChoice = 0;
        bool validInput = true;

        Console.WriteLine("What would you like to do next?");
        Console.WriteLine("1. Update my user information");
        Console.WriteLine("2. See your current progress");
        Console.WriteLine("3. Add a workout");
        Console.WriteLine("4. Exit program");
        
        do
        {
            try
            {


                //Need to do a check to see if the user has already entered their information
                //If they haven't, we need to prompt them to enter it before they can do anything else
                //If they have, we can proceed with the menu as normal


                userChoice = Convert.ToInt32(Console.ReadLine());
                validInput = true;

                switch (userChoice)
                {
                    case 1: 
                        UpdateUserInfo(); //Add or Edit current user information
                        break;
                    case 2:
                        ViewProgress(); //Display the current user's progress
                        break;
                    case 3:
                        AddWorkout(); //Add a workout to the user's profile
                        break;                     
                    case 4: //Exit the program
                        return; //This return exits this method, and returns us to where it was called.

                    default: 
                        Console.WriteLine("Please enter a valid choice...Like 1, 2, 3, or 4.");
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
    public class UserStats : Menu // Here's where we add additional information about the user for use in tracking their workout progress
    {
        public static void CollectAddtlInfo(User user)
        {

            bool validInput = true;
            string userInput = "";

            do
            {
                string firstName = "";
                string lastName = "";
                var birthDate = new DateOnly(2024,01,01);
                double heightInches = 0;
                double Weight = 0;
                
                

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


                //Old code for calculating age ----------------- Needed to remove if not reutilized
                // DateTime birthDateTime = new DateTime(birthDate.Year, birthDate.Month, birthDate.Day);
                // DateTime todayDateTime;
                // Today = DateOnly.FromDateTime(DateTime.Today);
                // todayDateTime = new DateTime(Today.Year, Today.Month, Today.Day);
                // Age = (todayDateTime - birthDateTime).Days / 365.25;

                


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
                    UserController.CreateUser(user, firstName, lastName, Age, heightInches, Weight, BMI);
                    Console.WriteLine("Profile created!");
                    validInput = true;
                }

            } while (!validInput);
        }
    }
    }
}

            // additionalUserInfo();
