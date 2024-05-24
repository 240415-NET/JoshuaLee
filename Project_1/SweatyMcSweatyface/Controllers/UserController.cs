
using SweatyMcSweatyface.Data;
using SweatyMcSweatyface.Models;
using SweatyMcSweatyface.Models.Interfaces;



namespace SweatyMcSweatyface.Controllers;


public class UserController
{

    // private static Models.Interfaces.IUserStorageRepo _userData = (Models.Interfaces.IUserStorageRepo)new SqlUserStorage();

    private static IUserStorageRepo _userData = new SqlUserStorage();
    public static string CreateUser(string userName, string _firstName, string _lastName, DateTime _birthDate, int _Age, double _heightInches, double _Weight, double _BMI)
    {
        //Creating the user
        User newUser = new User(userName, _firstName, _lastName, _birthDate, _Age, _heightInches, _Weight, _BMI);

        _userData.StoreUser(newUser);
        return newUser.userId.ToString();
    }

    public static bool UserExists(string userName)
    {

        if (_userData.FindUser(userName) != null)
        {
            return true;
        }

        return false;
    }
    

    public static string updateUser(string userName, string _firstName, string _lastName, DateTime _birthDate, int _Age, double _heightInches, double _Weight, double _BMI)
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
    public static User ReturnUser(string userName)

    {
        User existingUser = _userData.FindUser(userName);
        return existingUser;
    }
 
    public static User ReturnCurrentStats(string userName)
    {
        User existingUser = _userData.GetUserData(userName);
        return existingUser;
    }
    public static string UpdateUserFirstName(string userId, string newFirstName)
    {
        User existingUser = _userData.FindUser(userId);
        existingUser.firstName = newFirstName;
        _userData.UpdateUserFirstName(userId, newFirstName);
        return existingUser.userId.ToString();
    }

    public static string UpdateUserBirthDateNAge(string userId, DateTime newBirthDate, int newAge)
    {
        User existingUser = _userData.FindUser(userId);
        existingUser.birthDate = newBirthDate;
        existingUser.Age = newAge;
        _userData.UpdateUserBirthDateNAge(userId, newBirthDate, newAge);
        return existingUser.userId.ToString();
    }

    public static string UpdateUserLastName(string userId, string newLastName)
    {
        User existingUser = _userData.FindUser(userId);
        existingUser.lastName = newLastName;
        _userData.UpdateUserLastName(userId, newLastName);
        return existingUser.userId.ToString();
    }

    public static string UpdateUserHeightWeightBMI(string userId, double newHeight, double newWeight, double newBMI)
    {
        User existingUser = _userData.FindUser(userId);
        existingUser.heightInches = newHeight;
        existingUser.Weight = newWeight;
        existingUser.BMI = newBMI;
        _userData.UpdateUserHeightWeightBMI(userId, newHeight, newWeight, newBMI);
        return existingUser.userId.ToString();
    }

}