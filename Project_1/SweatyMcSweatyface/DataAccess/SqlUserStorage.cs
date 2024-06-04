using SweatyMcSweatyface.Models;
using SweatyMcSweatyface.Data;
using SweatyMcSweatyface.DataAccess;
using System.Data.SqlClient;
using SweatyMcSweatyface.Presentation;


namespace SweatyMcSweatyface.Data;

public class SqlUserStorage : IUserStorageRepo
{
    //Using a verbatim string literal to ignore all issues related to the slashes for windows file paths
    //And using an absolute file path, starting from my C drive to avoid any relative file path issues
    //If I move my entire project directory, this file path will still work because it's an exact address to my
    //connection string
    public static string connectionString = File.ReadAllText(@"C:\Users\U1C409\Documents\P1Extras\ConnString.txt");

    public User FindUser(string usernameToFind)
    {
        //So just like in the JsonUserStorage method, we will create an empty user to hold a potential
        //user we find in our DB
        User foundUser = new User();

        //Just like with our INSERT we will create a SqlConnection object
        using SqlConnection connection = new SqlConnection(connectionString);

        //We then open the connection
        connection.Open();

        //We start creating our command/Query text
        string cmdText = @"SELECT userId, userName 
                            FROM dbo.Users
                            WHERE userName=@userToFind;";

        //We create our SqlCommand object
        using SqlCommand cmd = new SqlCommand(cmdText, connection);

        //We then fill in the parameter @userToFind with our string usernameToFind that comes in
        //as an argument to our method
        cmd.Parameters.AddWithValue("@userToFind", usernameToFind);

        //To execute a query, we need to use a SqlDataReader object.
        //This object reads whatever is returned from our query, row by row - column by column
        //As the reader passes over the columns and rows we need to take steps to store or work with 
        //the data that comes back - Once the reader moves on from a row, we would need to execute the 
        //command again to re-read the row.
        //It is forward only! No going back up to another row we have already passed.
        using SqlDataReader reader = cmd.ExecuteReader();

        //We are going to use a while-loop to read through our data coming back from our SqlDataReader
        //and execute code until it is done reading
        while (reader.Read())
        {
            //While we are on a particular row, we have to save stuff if we find it.
            //When using reader.GetType() methods, we have to specify which column we are targeting
            //Like arrays, these start at position 0
            foundUser.userId = reader.GetGuid(0);
            foundUser.userName = reader.GetString(1);
        }//Once we are done reading, and no more records are coming back to be read, we exit the while-loop

        //We want to close our connection
        connection.Close();

        //If we get to this point and found a user, we return the filled out user object

        //If the username on foundUser is empty, we manually return a null. 
        if (String.IsNullOrEmpty(foundUser.userName))
            if (foundUser.userId == Guid.Empty)
            {
                return null;
            }

        //Otherwise we return the found filled out user object
        return foundUser;
    }

    public User GetUserData(string usernameToFind)
    {

        User foundUser = new User();

        using SqlConnection connection = new SqlConnection(connectionString); //We create a connection object

        connection.Open(); //We open the connection

        string cmdText = @"SELECT userName, firstName, lastName, birthDate, Age, heightInches, Weight, BMI
                            FROM dbo.Users
                            WHERE userName=@userToFind;"; //We create an SQL query to find the user

        using SqlCommand cmd = new SqlCommand(cmdText, connection); //We create a command object

        cmd.Parameters.AddWithValue("@userToFind", usernameToFind); //We fill in the parameter with the username we are looking for

        using SqlDataReader reader = cmd.ExecuteReader(); //This is the object that will read our data

        while (reader.Read())
        {
            foundUser.userName = reader.GetString(0); //We fill in the user object with the data we find
            foundUser.firstName = reader.GetString(1);
            foundUser.lastName = reader.GetString(2);
            foundUser.birthDate = reader.GetDateTime(3);
            foundUser.Age = reader.GetInt32(4);
            foundUser.heightInches = reader.GetDouble(5);
            foundUser.Weight = reader.GetDouble(6);
            foundUser.BMI = reader.GetDouble(7);
        }
        connection.Close();

        if (String.IsNullOrEmpty(foundUser.userName)) //If the username on foundUser is empty, we manually return a null.
            if (foundUser.userId == Guid.Empty)
            {
                return null;
            }
        return foundUser;
    }
    
    public void StoreUser(User user)
    {

        using SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();

        string cmdText = @"INSERT INTO dbo.Users (userId, userName, firstName, lastName, birthDate, Age, heightInches, Weight, BMI)
                            VALUES (@userId, @userName, @firstName, @lastName, @birthDate, @Age, @heightInches, @Weight, @BMI);";

        using SqlCommand cmd = new SqlCommand(cmdText, connection);


        cmd.Parameters.AddWithValue("@userId", user.userId); //We fill in the parameters with the user object's properties
        cmd.Parameters.AddWithValue("@userName", user.userName);   
        cmd.Parameters.AddWithValue("@firstName", user.firstName); 
        cmd.Parameters.AddWithValue("@lastName", user.lastName); 
        cmd.Parameters.AddWithValue("@birthDate", user.birthDate);
        cmd.Parameters.AddWithValue("@Age", user.Age);
        cmd.Parameters.AddWithValue("@heightInches", user.heightInches);
        cmd.Parameters.AddWithValue("@Weight", user.Weight);
        cmd.Parameters.AddWithValue("@BMI", user.BMI);

        //We then execute our INSERT statement that we created and fleshed out above by running
        //the instance method ExecuteNonQuery() off of our cmd object
        cmd.ExecuteNonQuery();

        //Once that is done, we simply close the connection
        connection.Close();

    }

    public void updateUser(User user)
    {
        using SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();

        string cmdText = @"UPDATE dbo.Users
                            SET firstName = @firstName, lastName = @lastName, birthDate = @birthDate, Age = @Age, heightInches = @heightInches, Weight = @Weight, BMI = @BMI
                            WHERE userName = @userName;"; //We create an SQL query to update the user

        using SqlCommand cmd = new SqlCommand(cmdText, connection); //We create a command object

        cmd.Parameters.AddWithValue("@firstName", user.firstName); //We fill in the parameters with the user object's properties
        cmd.Parameters.AddWithValue("@lastName", user.lastName);
        cmd.Parameters.AddWithValue("@birthDate", user.birthDate);
        cmd.Parameters.AddWithValue("@Age", user.Age);
        cmd.Parameters.AddWithValue("@heightInches", user.heightInches);
        cmd.Parameters.AddWithValue("@Weight", user.Weight);
        cmd.Parameters.AddWithValue("@BMI", user.BMI);
        cmd.Parameters.AddWithValue("@userName", user.userName);

        cmd.ExecuteNonQuery(); //We execute the command

        connection.Close(); //We close the connection
    }

    public void UpdateUserFirstName(string userName, string newFirstName) //This method updates the first name of the user
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {
                connection.Open();

                string updateQuery = "UPDATE dbo.Users SET FirstName = @NewFirstName WHERE userName = @UserName";  //We create an SQL query to update the user
                SqlCommand cmd = new SqlCommand(updateQuery, connection);
                cmd.Parameters.AddWithValue("@NewFirstName", newFirstName);
                cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.ExecuteNonQuery();
                Console.Clear();
                Console.WriteLine("First name updated successfully!\n");
                AfterLogInMenu.UpdateUserInfo(userName);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating first name: {ex.Message}");
        }
    }

    public void UpdateUserLastName(string userName, string newLastName) //This method updates the last name of the user
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string updateQuery = "UPDATE dbo.Users SET LastName = @NewLastName WHERE userName = @UserName";  //We create an SQL query to update the user
                SqlCommand cmd = new SqlCommand(updateQuery, connection);
                cmd.Parameters.AddWithValue("@NewLastName", newLastName);
                cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.ExecuteNonQuery();
                Console.Clear();
                Console.WriteLine("Last name updated successfully!\n");
                AfterLogInMenu.UpdateUserInfo(userName);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating last name: {ex.Message}");
        }
    }

    public void UpdateUserBirthDateNAge(string userName, DateTime newBirthDateParsed, int newAge) //This method updates the birth date and age of the user
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string updateQuery = "UPDATE dbo.Users SET BirthDate = @NewBirthDateParsed WHERE userName = @UserName UPDATE dbo.Users SET Age = @NewAge WHERE userName = @UserName";  //We create an SQL query to update the user
                SqlCommand cmd = new SqlCommand(updateQuery, connection);
                cmd.Parameters.AddWithValue("@NewBirthDateParsed", newBirthDateParsed);
                cmd.Parameters.AddWithValue("@NewAge", newAge);
                cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.ExecuteNonQuery();
                Console.Clear();
                Console.WriteLine("Birth date updated successfully!\n");
                AfterLogInMenu.UpdateUserInfo(userName);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating birth date: {ex.Message}");
        }
    }

    public void UpdateUserHeightWeightBMI(string userName, double newHeightInches, double newWeight, double newBMI) //This method updates the height, weight, and BMI of the user
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string updateQuery = "UPDATE dbo.Users SET heightInches = @NewHeightInches WHERE userName = @UserName UPDATE dbo.Users SET Weight = @NewWeight WHERE userName = @UserName UPDATE dbo.Users SET BMI = @NewBMI WHERE userName = @UserName";  //We create an SQL query to update the user
                SqlCommand cmd = new SqlCommand(updateQuery, connection);
                cmd.Parameters.AddWithValue("@NewHeightInches", newHeightInches);
                cmd.Parameters.AddWithValue("@NewWeight", newWeight);
                cmd.Parameters.AddWithValue("@NewBMI", newBMI);
                cmd.Parameters.AddWithValue("@UserName", userName);

                cmd.ExecuteNonQuery();
                Console.Clear();
                Console.WriteLine("Height and Weight updated successfully!\n"); //We clear the console and print a success message
                AfterLogInMenu.UpdateUserInfo(userName);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating height: {ex.Message}"); //If there is an error, we print an error message
        }
    }


}