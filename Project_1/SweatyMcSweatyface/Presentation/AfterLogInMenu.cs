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

        public static void PostLogInChoiceMenu(string userId)
        {

            int userChoice = 0;
            bool validInput = true;

            Console.WriteLine("What would you like to do next?");
            Console.WriteLine("1. Update my user information");
            Console.WriteLine("2. See my current progress");
            // Console.WriteLine("3. Add a workout");
            Console.WriteLine("3. Exit program");

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
                            UpdateUserInfo(userId); //Add or Edit current user information
                            break;
                        case 2:
                             ViewProgress(userId); //Display the current user's progress
                            break;
                        // case 3:
                        //     UserStats.AddWorkout(userId); //Add a workout to the user's profile
                        //     break;
                        case 3: //Exit the program
                            return; //This return exits this method, and returns us to where it was called.

                        default:
                            Console.WriteLine("Please enter a valid choice...Like 1, 2, or 3");
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

        public static void ViewProgress(string userId)
        { 
            User user = UserController.ReturnUser(userId);
            Console.WriteLine($"User: {user.userName}");
            Console.WriteLine($"Age: {user.Age}");
            
            Console.WriteLine($"Height: {user.heightInches}");
            Console.WriteLine($"Weight: {user.Weight}");
            Console.WriteLine($"It's time to talk about your BMI./n/nYour BMI is a calculation that uses your height and weight to determine if you are at a healthy weight. It is not a perfect system, but it is a good starting point to see if you are at a healthy weight./n/nBelow are the ranges utilized by the CDC:/n/nUnderweight: BMI is less than 18.5/nHealthy weight: BMI is 18.5 to 24.9/nOverweight: BMI is 25 to 29.9/nObese: BMI is 30 or more/n/n");
            
            Console.WriteLine($"****Legal Disclaimer from a Non-Lawyer*****/n/nThe CDC utilizes the BMI calculation as a screening tool and it is not to be used for diagnostic purposes./nIf you have questions about your BMI score, please contact your doctor and they will be able to provide you with information that is most appropriate for your body, age, baseball team preference, etc./n");
            if(user.BMI < 18.5)
            {
                Console.WriteLine("Your BMI calculation is {user.BMI}, which is considered to be in the underweight range. I miss those days.../n/n");
            }
            else if(user.BMI >= 18.5 && user.BMI < 24.9)
            {
                Console.WriteLine("Good for you! Your BMI calculation is {user.BMI}, which is considered at a healthy weight range./n/n");
            }
            else if(user.BMI >= 25 && user.BMI < 29.9)
            {
                Console.WriteLine("Your BMI calculation of {user.BMI} falls in into the very relateable overweight range. It happens to the best of us, but give your doctor a call and see if there is something they can do to get you back to being a better you./n/n");
            }
            else
            {
                Console.WriteLine("Your BMI Calculation is {user.BMI}, which falls into the obese range. Do not panic, but do contact your doctor to see what they can do to help you get back to a healthier you. You wanna know why? Because you're worth it, that's why./n/n");
            }
            Console.WriteLine("Would you like to return to the main menu?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            int userChoice = Convert.ToInt32(Console.ReadLine());
            if (userChoice == 1)
            {
                PostLogInChoiceMenu(userId);
            }
            else
            {
                Console.WriteLine("Goodbye!");
            }
        }

        public static void UpdateUserInfo(string userId)
        { 
            User user = UserController.ReturnUser(userId);
            Console.WriteLine("What would you like to update?");
            Console.WriteLine("1. First Name");
            Console.WriteLine("2. Last Name");
            Console.WriteLine("3. Birth Date");
            Console.WriteLine("4. Height & Weight");
            Console.WriteLine("5. Return to main menu");
            int userChoice = Convert.ToInt32(Console.ReadLine());
            switch (userChoice)
            {
                case 1:
                    Console.WriteLine("Enter your new first name: ");
                    string newFirstName = Console.ReadLine();
                    user.firstName = newFirstName;
                    UserController.UpdateUserFirstName(user.userName, newFirstName);
                    UpdateUserInfo(userId);
                    break;
                case 2:
                    Console.WriteLine("Enter your new last name: ");
                    string newLastName = Console.ReadLine();
                    user.lastName = newLastName;
                    UserController.UpdateUserLastName(user.userName, newLastName);
                    UpdateUserInfo(userId);
                    break;
                case 3:
                    Console.WriteLine("Enter your new birth date (MM/DD/YYYY): ");
                    string newBirthDate = Console.ReadLine();
                    user.birthDate = DateOnly.FromDateTime(Convert.ToDateTime(newBirthDate));
                    //Calculating the age of the user
                    var Today = DateOnly.FromDateTime(DateTime.Today);
                    var ageInDays = Today.DayNumber - user.birthDate.DayNumber;
                    int Age = (int)(ageInDays / 365.25);
                    UserController.UpdateUserBirthDateNAge(user.userName, user.birthDate, Age);
                    UpdateUserInfo(userId);
                    break;
                case 4:
                    Console.WriteLine("Enter your new height in inches: ");
                    double newHeight = Convert.ToDouble(Console.ReadLine());
                    user.heightInches = newHeight;
                    Console.WriteLine("Enter your new weight: ");
                    double newWeight = Convert.ToDouble(Console.ReadLine());
                    user.Weight = newWeight;
                    double newBMI = newWeight / (newHeight * newHeight) * 703;
                    UserController.UpdateUserHeightWeightBMI(user.userName, newHeight, newWeight, newBMI);
                    UpdateUserInfo(userId);
                    break;
                case 5:                       
                    UpdateUserInfo(userId);
                    break;
                case 6:
                    PostLogInChoiceMenu(userId);
                    break;
                default:
                    Console.WriteLine("Please enter a valid choice...Like 1, 2, 3, 4, or 5./n");
                    break;
            }
        }








        // public class UserStats : Menu // Here's where we add additional information about the user for use in tracking their workout progress
        // {
        //     public static void AddWorkout(string userId)
        //     {
        //         User user = UserController.ReturnUser(userId);
            
        //         Console.WriteLine("What type of workout would you like to add?");
        //         Console.WriteLine("1. Weight Room");
        //         Console.WriteLine("2. Run or Cycle");
        //         Console.WriteLine("3. General Workout");
        //         Console.WriteLine("4. Return to main menu");
        //         int userChoice = Convert.ToInt32(Console.ReadLine());
        //         switch (userChoice)
        //         {
        //             case 1:
        //                 AddWeightRoom(user);
        //                 break;
        //             case 2:
        //                 AddRunNCycle(user);
        //                 break;
        //             case 3:
        //                 AddGeneralWorkout(user);
        //                 break;
        //             case 4:
        //                 PostLogInChoiceMenu(userId);
        //                 break;
        //             default:
        //                 Console.WriteLine("Please enter a valid choice...Like 1, 2, or 3.");
        //                 break;
        //         }
        //     }

        //     public static void AddWeightRoom(User user)
        //     {
        //         bool validInput = false;
        //         string WorkoutType = "WeightRoom";
        //         string Description = "";
        //         string ExerciseName = "";
        //         double Sets = 0;
        //         double Repetitions = 0;
        //         double WeightLifted = 0;
        //         double Duration = 0;
        //         do
        //         {
        //             DateTime Date1;
        //             Console.WriteLine("Enter the date of your workout (MM/DD/YYYY): ");
        //             string line = Console.ReadLine();
        //             while (!DateTime.TryParseExact(line, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out Date1))
        //             {
        //                 Console.WriteLine("Invalid date, please retry");
        //                 line = Console.ReadLine();
        //             }

        //             DateOnly Date = DateOnly.FromDateTime(Date1);


        //             try
        //             {
        //                 Console.WriteLine("Enter the name of the exercise you completed: ");
        //                 ExerciseName = Console.ReadLine();
        //             }
        //             catch (Exception ex)
        //             {
        //                 Console.WriteLine($"Invalid entry!/n Enter the name of the exercise you completed:/n");
        //             }

        //             try
        //             {
        //                 Console.WriteLine($"Enter the duration of your {ExerciseName} workout in minutes:/n");
        //                 Duration = Convert.ToDouble(Console.ReadLine());
        //             }
        //             catch (Exception e)
        //             {
        //                 Console.WriteLine($"{e} Invalid entry!/n Enter the duration of your {ExerciseName} workout in minutes:/n");
        //             }

        //             try
        //             {
        //                 Console.WriteLine("Enter the number of sets you completed: ");
        //                 Sets = Convert.ToInt32(Console.ReadLine());
        //             }
        //             catch (Exception e)
        //             {
        //                 Console.WriteLine($"{e} Invalid entry!/n Enter the number of sets you completed:/n");
        //             }

        //             try
        //             {
        //                 Console.WriteLine("Enter the number of reps you completed: ");
        //                 Repetitions = Convert.ToInt32(Console.ReadLine());
        //             }
        //             catch (Exception e)
        //             {
        //                 Console.WriteLine($"{e} Invalid entry!/n Enter the number of reps you completed:/n");
        //             }

        //             try
        //             {
        //                 Console.WriteLine("Enter the amount of weight you lifted: ");
        //                 WeightLifted = Convert.ToInt32(Console.ReadLine());
        //             }
        //             catch (Exception e)
        //             {

        //                 Console.WriteLine($"{e} Invalid entry!/n Enter the amount of weight you lifted:/n");
        //             }

        //             try
        //             {
        //                 Console.WriteLine("Enter a description for your weight room workout: ");
        //                 Description = Console.ReadLine();
        //             }
        //             catch (Exception e)
        //             {
        //                 Console.WriteLine($"{e} Invalid entry!/n Enter a description for your weight room workout:/n");
        //             }

        //             // Console.WriteLine("Enter the number of calories burned: ");
        //             // double caloriesBurned = Convert.ToDouble(Console.ReadLine());
        //             // Console.WriteLine("Enter any additional notes: ");
        //             // string notes = Console.ReadLine();

        //             // , caloriesBurned, notes);
        //             validInput = true;
        //             WorkoutController.createWeightRoom(user, WorkoutType, Date, Duration, Description, ExerciseName, Sets, Repetitions, WeightLifted);
        //             PostLogInChoiceMenu(user.userId.ToString());
        //         }

        //         while (validInput == false);
        //     }

        // }


        // public static void AddRunNCycle(User user) //This method will add a Run or Cycle workout to the user's profile
        // {
        //     string WorkoutType = "RunNCycle"; //This is the type of workout we are adding to the user's profile
        //     double AverageSpeed = 0;
        //     double Duration = 0;

        //     Console.WriteLine("Did you Run or Cycle?/n");
        //     Console.WriteLine("(Enter 'Run' or 'Cycle'):/n");
        //     String RunOrCycle = Console.ReadLine();

        //     DateTime Date1;
        //     Console.WriteLine("Enter the date of your workout (MM/DD/YYYY): ");
        //     string line = Console.ReadLine();
        //     while (!DateTime.TryParseExact(line, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out Date1))
        //     {
        //         Console.WriteLine("Invalid date, please retry");
        //         line = Console.ReadLine();
        //     }

        //     DateOnly Date = DateOnly.FromDateTime(Date1);

        //     try
        //             {
        //                 Console.WriteLine($"Enter the duration of your {RunOrCycle} workout in minutes:/n");
        //                 Duration = Convert.ToDouble(Console.ReadLine());
        //             }
        //             catch (Exception e)
        //             {
        //                 Console.WriteLine($"{e} Invalid entry!/n Enter the duration of your {RunOrCycle} workout in minutes:/n");
        //             }

        //     Console.WriteLine("Enter the distance you ran or cycled: ");
        //     double Distance = Convert.ToDouble(Console.ReadLine());

        //     Console.WriteLine($"Enter a description for your {RunOrCycle}: ");
        //     string Description = Console.ReadLine();

        //     AverageSpeed = Distance / Duration;
        //     // Console.WriteLine("Enter the number of calories burned: ");
        //     // double caloriesBurned = Convert.ToDouble(Console.ReadLine());
        //     // Console.WriteLine("Enter any additional notes: ");
        //     // string notes = Console.ReadLine();
        //     WorkoutController.createRunNCycle(user, WorkoutType, Date, Duration, Description, RunOrCycle, Distance, AverageSpeed);
        //     PostLogInChoiceMenu(user.userId.ToString());
        // }

        // public static void AddGeneralWorkout(User user)
        // {
        //     double Duration = 0;
        //     DateTime Date1;
        //     Console.WriteLine("Enter the date of your workout (MM/DD/YYYY): ");
        //     string line = Console.ReadLine();
        //     while (!DateTime.TryParseExact(line, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out Date1))
        //     {
        //         Console.WriteLine("Invalid date, please retry");
        //         line = Console.ReadLine();
        //     }

        //     DateOnly Date = DateOnly.FromDateTime(Date1);

        //     Console.WriteLine("Enter the duration of your workout in minutes:/n");
        //     Duration = Convert.ToDouble(Console.ReadLine());

        //     Console.WriteLine("Enter the type of workout you completed: ");
        //     string WorkoutType = Console.ReadLine();

        //     Console.WriteLine("Enter a description for your workout: ");
        //     string Description = Console.ReadLine();
            
        //     WorkoutController.createWorkout(user, WorkoutType, Date, Duration, Description);
        //     PostLogInChoiceMenu(user.userId.ToString());
        // }
        //caloriesBurned, notes

        // Console.WriteLine("Enter the number of calories burned: ");
        //             double caloriesBurned = Convert.ToDouble(Console.ReadLine());
        //             Console.WriteLine("Enter any additional notes: ");
        //             string notes = Console.ReadLine();
     
    }

}



// additionalUserInfo();
