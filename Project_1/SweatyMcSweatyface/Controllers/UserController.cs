
using SweatyMcSweatyface.Data;
using SweatyMcSweatyface.Models;


namespace SweatyMcSweatyface.Controllers;


public class UserController
{

    // private static Models.Interfaces.IUserStorageRepo _userData = (Models.Interfaces.IUserStorageRepo)new SqlUserStorage();

    private static IUserStorageRepo _userData = new SqlUserStorage();
    public static string CreateUser(string userName, string _firstName, string _lastName, DateTime _birthDate, int _Age, double _heightInches, double _Weight, double _BMI) //This function creates the user
    {
        //Creating the user
        User newUser = new User(userName, _firstName, _lastName, _birthDate, _Age, _heightInches, _Weight, _BMI);

        _userData.StoreUser(newUser);
        return newUser.userId.ToString();
    }

    public static bool UserExists(string userName) //This function checks if the user exists in the database
    {

        if (_userData.FindUser(userName) != null)
        {
            return true;
        }

        return false;
    }
    

    public static string updateUser(string userName, string _firstName, string _lastName, DateTime _birthDate, int _Age, double _heightInches, double _Weight, double _BMI) //This function updates the user information
    {
        User existingUser = _userData.FindUser(userName);
        existingUser.firstName = _firstName;
        existingUser.lastName = _lastName;
        existingUser.birthDate = _birthDate;
        existingUser.Age = _Age;
        existingUser.heightInches = _heightInches;
        existingUser.Weight = _Weight;
        existingUser.BMI = _BMI;
        _userData.updateUser(existingUser);
        return existingUser.userId.ToString();
    }

    // This function returns user information from our data layer
    public static User ReturnUser(string userName) //This function returns the user 

    {
        User existingUser = _userData.FindUser(userName);
        return existingUser;
    }
 
    public static User ReturnCurrentStats(string userName) //This function returns the current stats of the user
    {
        User existingUser = _userData.GetUserData(userName);
        return existingUser;
    }
    public static string UpdateUserFirstName(string userId, string newFirstName) //This function updates the first name of the user 
    {
        User existingUser = _userData.FindUser(userId);
        existingUser.firstName = newFirstName;
        _userData.UpdateUserFirstName(userId, newFirstName);
        return existingUser.userId.ToString();
    }

    public static string UpdateUserBirthDateNAge(string userId, DateTime newBirthDate, int newAge)  //This function updates the birthdate and age of the user
    {
        User existingUser = _userData.FindUser(userId);
        existingUser.birthDate = newBirthDate;
        existingUser.Age = newAge;
        _userData.UpdateUserBirthDateNAge(userId, newBirthDate, newAge);
        return existingUser.userId.ToString();
    }

    public static string UpdateUserLastName(string userId, string newLastName) //This function updates the last name of the user
    {
        User existingUser = _userData.FindUser(userId);
        existingUser.lastName = newLastName;
        _userData.UpdateUserLastName(userId, newLastName);
        return existingUser.userId.ToString();
    }

    public static string UpdateUserHeightWeightBMI(string userId, double newHeight, double newWeight, double newBMI)    //This function updates the height, weight and BMI of the user
    {
        User existingUser = _userData.FindUser(userId);
        existingUser.heightInches = newHeight;
        existingUser.Weight = newWeight;
        existingUser.BMI = newBMI;
        _userData.UpdateUserHeightWeightBMI(userId, newHeight, newWeight, newBMI);
        return existingUser.userId.ToString();
    }

}