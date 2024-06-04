
using SweatyMcSweatyface.Controllers;
using SweatyMcSweatyface.Models;


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
            Console.WriteLine("1. New Sweaty user");  //Creating a new user
            Console.WriteLine("2. Returning Sweaty user"); //Already existing users sign in here
            Console.WriteLine("3. Exit program"); //Exit the program

            do
            {
                try
                {
                    userChoice = Convert.ToInt32(Console.ReadLine() ?? ""); // Double ?s (null-coalescing operator/returns the right side when the left is blank) sets it to an empty string instead of it being a null
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
                    // Console.WriteLine(ex.Message); //This will display the error message
                    // Console.WriteLine(ex.StackTrace); //This will display the stack trace
                    Console.WriteLine("That doesn't seem right... Please enter a valid choice!"); //This will display a message to the user
                    validInput = false;
                }


            } while (!validInput);


        }

        public static void UserCreationMenu() // Here's where we create the Users
        {

            bool validInput = true;
            string userInput = "";
  
            Console.Clear();
            Console.WriteLine("Let's get started by creating your username.\n\n");
            do
            {
                //Prompting the user for a username
                Console.WriteLine("Please enter a username:\n");

                userInput = Console.ReadLine() ?? "";   // Double ?s (null-coalescing operatornull-coalescing operator/returns the right side when the left is blank) sets it to an empty string instead of it being a null
                Console.Clear();

                userInput = userInput.Trim();

                if (String.IsNullOrEmpty(userInput)) //If the user doesn't enter anything, we'll prompt them to enter a username
                {
                    Console.WriteLine("Username cannot be blank.\n");
                    validInput = false;
                }
                else if (UserController.UserExists(userInput))
                {
                    Console.WriteLine("Username already exists.\n"); //If the user enters a username that already exists, we'll prompt them to enter a new username
                    validInput = false;
                }
                else
                {
                    validInput = true; //If the username is unique, we'll move on to the next step

                }

            } while (!validInput);

            PromptForUserData(userInput);
            Console.WriteLine("Goodbye and keep it Sweaty!");

        }

        public static void UserSignIn()
        {
            bool signIn = false; //This is a flag to determine if the user has successfully signed in
            Console.Clear();
            Console.WriteLine("Please provide your username to sign in\n");
            string userInput = Console.ReadLine().Trim();
            do
            {

                if (String.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Looks like you forgot to enter a Username. Please try again."); //If the user doesn't enter anything, we'll prompt them to enter a username
                    signIn = false;
                }
                else if (!UserController.UserExists(userInput))
                {
                    Console.WriteLine($"User not found! \nDo you need to create a new user? (yes\\no)"); //If the user doesn't exist, we'll prompt them to create a new user
                    userInput = Console.ReadLine().Trim();
                    if (userInput == "yes" || userInput == "y") //If the user enters yes, we'll take them to the UserCreationMenu
                    {
                        signIn = true;
                        UserCreationMenu(); //Creating a new user
                    }
                    else
                    {
                        Console.WriteLine("Please provide your username to sign in\n"); //If the user enters no, we'll prompt them to enter a username again
                        userInput = Console.ReadLine().Trim();
                    }
                }
                else
                {
                    User userSignedIn = UserController.ReturnUser(userInput);
                    Console.Clear();
                    Console.WriteLine($"User Id: {userSignedIn.userId}"); //If the user exists, we'll display their information
                    Console.WriteLine($"User Name: {userSignedIn.userName}\n"); //If the user exists, we'll display their information
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

                bool validDate = false;
                while (validDate == false)
                {
                    try
                    {
                        birthDate = DateTime.Parse(Console.ReadLine() ?? "");
                        validDate = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Whoops! Please enter your date of birth in the correct format: MM/DD/YYYY\n");
                        validDate = false;
                    }
                }

                //Here we are calculating the user's age based on their birthdate

                var Today = DateTime.Today;
                var Age = Today.Year - birthDate.Year;
                if (birthDate.Date > Today.AddYears(-Age)) Age--;

                Console.Clear();
                Console.WriteLine("Please enter your height in inches: \n");

                bool validHeightInput = false;
                while (validHeightInput == false)
                {
                    try
                    {
                        heightInches = Double.Parse(Console.ReadLine() ?? "");
                        validHeightInput = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Whoops! That doesn't seem right.\nPlease enter your height in inches.\n");
                        validHeightInput = false;
                    }
                }

                bool validWeightInput = false;
                Console.WriteLine("Please enter your weight in pounds: \n");


                while (validWeightInput == false)
                {
                    try
                    {
                        Weight = Convert.ToDouble(Console.ReadLine() ?? "");
                        Console.Clear();
                        validWeightInput = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Whoops! Please enter your weight in pounds.\n");
                        validWeightInput = false;
                    }
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