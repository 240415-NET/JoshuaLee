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

        public static void PostLogInChoiceMenu(User user)
        {

            int userChoice = 0;
            bool validInput = true;

            Console.WriteLine("What would you like to do next?");
            Console.WriteLine("1. Update my user information");
            Console.WriteLine("2. See my current progress");
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
                            // UpdateUserInfo(user); //Add or Edit current user information
                            break;
                        case 2:
                            // ViewProgress(user); //Display the current user's progress
                            break;
                        case 3:
                            UserStats.AddWorkout(user); //Add a workout to the user's profile
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
            public static void AddWorkout(User user)
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
                        AddWeightRoom(user);
                        break;
                    case 2:
                        AddRunNCycle(user);
                        break;
                    case 3:
                        AddGeneralWorkout(user);
                        break;
                    case 4:
                        PostLogInChoiceMenu(user);
                        break;
                    default:
                        Console.WriteLine("Please enter a valid choice...Like 1, 2, or 3.");
                        break;
                }
            }

            public static void AddWeightRoom(User user)
            {
                bool validInput = false;
                string WorkoutType = "WeightRoom";
                string Description = "";
                string ExerciseName = "";
                double Sets = 0;
                double Repetitions = 0;
                double WeightLifted = 0;
                double Duration = 0;
                do
                {
                    DateTime Date1;
                    Console.WriteLine("Enter the date of your workout (MM/DD/YYYY): ");
                    string line = Console.ReadLine();
                    while (!DateTime.TryParseExact(line, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out Date1))
                    {
                        Console.WriteLine("Invalid date, please retry");
                        line = Console.ReadLine();
                    }

                    DateOnly Date = DateOnly.FromDateTime(Date1);


                    try
                    {
                        Console.WriteLine("Enter the name of the exercise you completed: ");
                        ExerciseName = Console.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Invalid entry!/n Enter the name of the exercise you completed:/n");
                    }

                    try
                    {
                        Console.WriteLine($"Enter the duration of your {ExerciseName} workout in minutes:/n");
                        Duration = Convert.ToDouble(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"{e} Invalid entry!/n Enter the duration of your {ExerciseName} workout in minutes:/n");
                    }

                    try
                    {
                        Console.WriteLine("Enter the number of sets you completed: ");
                        Sets = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"{e} Invalid entry!/n Enter the number of sets you completed:/n");
                    }

                    try
                    {
                        Console.WriteLine("Enter the number of reps you completed: ");
                        Repetitions = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"{e} Invalid entry!/n Enter the number of reps you completed:/n");
                    }

                    try
                    {
                        Console.WriteLine("Enter the amount of weight you lifted: ");
                        WeightLifted = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine($"{e} Invalid entry!/n Enter the amount of weight you lifted:/n");
                    }

                    try
                    {
                        Console.WriteLine("Enter a description for your weight room workout: ");
                        Description = Console.ReadLine();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"{e} Invalid entry!/n Enter a description for your weight room workout:/n");
                    }

                    // Console.WriteLine("Enter the number of calories burned: ");
                    // double caloriesBurned = Convert.ToDouble(Console.ReadLine());
                    // Console.WriteLine("Enter any additional notes: ");
                    // string notes = Console.ReadLine();

                    // , caloriesBurned, notes);
                    validInput = true;
                    WorkoutController.createWeightRoom(user, WorkoutType, Date, Duration, Description, ExerciseName, Sets, Repetitions, WeightLifted);
                    PostLogInChoiceMenu(user);
                }

                while (validInput == false);
            }

        }


        public static void AddRunNCycle(User user) //This method will add a Run or Cycle workout to the user's profile
        {
            string WorkoutType = "RunNCycle"; //This is the type of workout we are adding to the user's profile
            double AverageSpeed = 0;
            double Duration = 0;

            Console.WriteLine("Did you Run or Cycle?/n");
            Console.WriteLine("(Enter 'Run' or 'Cycle'):/n");
            String RunOrCycle = Console.ReadLine();

            DateTime Date1;
            Console.WriteLine("Enter the date of your workout (MM/DD/YYYY): ");
            string line = Console.ReadLine();
            while (!DateTime.TryParseExact(line, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out Date1))
            {
                Console.WriteLine("Invalid date, please retry");
                line = Console.ReadLine();
            }

            DateOnly Date = DateOnly.FromDateTime(Date1);

            try
                    {
                        Console.WriteLine($"Enter the duration of your {RunOrCycle} workout in minutes:/n");
                        Duration = Convert.ToDouble(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"{e} Invalid entry!/n Enter the duration of your {RunOrCycle} workout in minutes:/n");
                    }

            Console.WriteLine("Enter the distance you ran or cycled: ");
            double Distance = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"Enter a description for your {RunOrCycle}: ");
            string Description = Console.ReadLine();

            AverageSpeed = Distance / Duration;
            // Console.WriteLine("Enter the number of calories burned: ");
            // double caloriesBurned = Convert.ToDouble(Console.ReadLine());
            // Console.WriteLine("Enter any additional notes: ");
            // string notes = Console.ReadLine();
            WorkoutController.createRunNCycle(user, WorkoutType, Date, Duration, Description, RunOrCycle, Distance, AverageSpeed);
            PostLogInChoiceMenu(user);
        }

        public static void AddGeneralWorkout(User user)
        {
            double Duration = 0;
            DateTime Date1;
            Console.WriteLine("Enter the date of your workout (MM/DD/YYYY): ");
            string line = Console.ReadLine();
            while (!DateTime.TryParseExact(line, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out Date1))
            {
                Console.WriteLine("Invalid date, please retry");
                line = Console.ReadLine();
            }

            DateOnly Date = DateOnly.FromDateTime(Date1);

            Console.WriteLine("Enter the duration of your workout in minutes:/n");
            Duration = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the type of workout you completed: ");
            string WorkoutType = Console.ReadLine();

            Console.WriteLine("Enter a description for your workout: ");
            string Description = Console.ReadLine();
            
            WorkoutController.createWorkout(user, WorkoutType, Date, Duration, Description);
            PostLogInChoiceMenu(user);
        }
        //caloriesBurned, notes

        // Console.WriteLine("Enter the number of calories burned: ");
        //             double caloriesBurned = Convert.ToDouble(Console.ReadLine());
        //             Console.WriteLine("Enter any additional notes: ");
        //             string notes = Console.ReadLine();
        public static void ViewProgress()
        { }

        public static void UpdateUserInfo()
        { }
    }

}



// additionalUserInfo();
