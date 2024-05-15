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

    public static void StartStatsMenu() {

        int userChoice = 0;
        bool validInput = true;

        Console.WriteLine("What would you like to do next?");
        Console.WriteLine("1. Add/Edit additional information about yourself");
        Console.WriteLine("2. See your current progress");
        Console.WriteLine("3. Add a workout");
        Console.WriteLine("4. Exit program");
        
        do
        {
            try
            {
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
        public static void CollectAddtlInfo()
        {

            bool validInput = true;
            string userInput = "";

            do
            {
                string firstName = "";
                string lastName = "";
                string Gender = "";
                var birthDate = new DateOnly(2024,01,01);
                var Today = DateOnly.FromDateTime(DateTime.Today);
                var ageInDays = Today.DayNumber - birthDate.DayNumber;
                var Age = ageInDays / 365.25;
                double heightInches = 0;
                double Weight = 0;
                double BMI = 0;
                

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

                Console.WriteLine("Please provide your gender: ");

                Gender = Console.ReadLine() ?? "";
                Gender = Gender.Trim();

                if (String.IsNullOrEmpty(Gender))
                {
                    Console.WriteLine("Whoops! Please provide your gender.\n");
                    validInput = false;
                }

                Console.WriteLine("Please enter your date of birth in this format: MM/DD/YYYY \nSo, if you were born on December 25, 1980, you would enter: 12/25/1980.\n ");
                birthDate =  DateOnly.Parse(Console.ReadLine() ?? "");

                if (String.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Whoops! Please enter your date of birth.\n");
                    validInput = false;
                }

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

                BMI = (Weight / (heightInches * heightInches)) * 703;

                
                {
                    UserController.AddUserInfo(firstName, lastName, Age, Weight, heightInches, Gender, BMI);
                    Console.WriteLine("Profile created!");
                    validInput = true;
                }

            } while (!validInput);

            // additionalUserInfo();
        }