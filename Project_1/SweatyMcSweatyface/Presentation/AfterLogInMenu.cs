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
    public class AfterLogInMenu : Menu
    {

    public static void PostLogInChoiceMenu() {

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
        public static void AddWorkout()
        {
            Console.WriteLine("What type of workout would you like to add?");
            Console.WriteLine("1. Weight Room");
            Console.WriteLine("2. Run or Cycle");
            Console.WriteLine("3. General Workout");
            Console.WriteLine("4. Return to main menu");
            int userChoice = Convert.ToInt32(Console.ReadLine());
            switch (userChoice)
            {
                case 1:
                    AddWeightRoom();
                    break;
                case 2:
                    AddRunNCycle();
                    break;
                case 3:
                    AddGeneralWorkout();
                    break;
                case 4:
                    PostLogInChoiceMenu();
                    break;
                default:
                    Console.WriteLine("Please enter a valid choice...Like 1, 2, or 3.");
                    break;
            }
        }

        public static void AddWeightRoom()
        {
            Console.WriteLine("Enter the date of your workout (MM/DD/YYYY): ");
            DateTime date = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter the duration of your workout (in minutes): ");
            int duration = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the number of sets you completed: ");
            int sets = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the number of reps you completed: ");
            int reps = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the weight you lifted: ");
            double weight = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the type of workout you completed: ");
            string workoutType = Console.ReadLine();
            Console.WriteLine("Enter the number of calories burned: ");
            double caloriesBurned = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter any additional notes: ");
            string notes = Console.ReadLine();
            WeightRoom newWeightRoom = new WeightRoom(date, duration, sets, reps, weight, workoutType, caloriesBurned, notes);
            UserController.AddWorkout(newWeightRoom);
            PostLogInChoiceMenu();
        }

        
        public static void AddRunNCycle()
        {
            Console.WriteLine("Enter the date of your workout (MM/DD/YYYY): ");
            DateTime date = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter the duration of your workout (in minutes): ");
            int duration = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the distance you ran or cycled: ");
            double distance = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the type of workout you completed: ");
            string workoutType = Console.ReadLine();
            Console.WriteLine("Enter the number of calories burned: ");
            double caloriesBurned = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter any additional notes: ");
            string notes = Console.ReadLine();
            RunNCycle newRunNCycle = new RunNCycle(CardioType, Distance, RunOrCycle, AverageSpeed);
            UserController.AddWorkout(newRunNCycle);
            PostLogInChoiceMenu();
        }

        public static void AddGeneralWorkout()
        {
            Console.WriteLine("Enter the date of your workout (MM/DD/YYYY): ");
            DateTime date = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter the duration of your workout (in minutes): ");
            int duration = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the type of workout you completed: ");
            string workoutType = Console.ReadLine();
            Workout newWorkout = new Workout(date, duration, workoutType);
            UserController.AddWorkout(newWorkout);
            PostLogInChoiceMenu();
        }
//caloriesBurned, notes

// Console.WriteLine("Enter the number of calories burned: ");
//             double caloriesBurned = Convert.ToDouble(Console.ReadLine());
//             Console.WriteLine("Enter any additional notes: ");
//             string notes = Console.ReadLine();
        public static void ViewProgress()
        {}

        public static void UpdateUserInfo()
        {}
    }   

    }
    
}

            // additionalUserInfo();
