using SweatyMcSweatyface.Models;
using SweatyMcSweatyface.Data;
using SweatyMcSweatyface.DataAccess;
using System.Data.SqlClient;


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
        //if(String.IsNullOrEmpty(foundUser.userName))
        if (foundUser.userId == Guid.Empty)
        {
            return null;
        }

        //Otherwise we return the found filled out user object
        return foundUser;
    }

    public void StoreUser(User user)
    {

        using SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();

        string cmdText = @"INSERT INTO dbo.Users (userId, userName, firstName, lastName, birthDate, Age, heightInches, Weight, BMI)
                            VALUES (@userId, @userName, @firstName, @lastName, @birthDate, @Age, @heightInches, @Weight, @BMI);";

        using SqlCommand cmd = new SqlCommand(cmdText, connection);


        cmd.Parameters.AddWithValue("@userId", user.userId);
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
                            WHERE userName = @userName;";

        using SqlCommand cmd = new SqlCommand(cmdText, connection);

        cmd.Parameters.AddWithValue("@firstName", user.firstName);
        cmd.Parameters.AddWithValue("@lastName", user.lastName);
        cmd.Parameters.AddWithValue("@birthDate", user.birthDate);
        cmd.Parameters.AddWithValue("@Age", user.Age);
        cmd.Parameters.AddWithValue("@heightInches", user.heightInches);
        cmd.Parameters.AddWithValue("@Weight", user.Weight);
        cmd.Parameters.AddWithValue("@BMI", user.BMI);
        cmd.Parameters.AddWithValue("@userName", user.userName);

        cmd.ExecuteNonQuery();

        connection.Close();
    }
    public static void UpdateUserFirstName(string userName, string newFirstName)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string updateQuery = "UPDATE User SET FirstName = @NewFirstName WHERE userName = @UserName";
                SqlCommand cmd = new SqlCommand(updateQuery, connection);
                cmd.Parameters.AddWithValue("@NewFirstName", newFirstName);
                cmd.Parameters.AddWithValue("@UserName", userName);

                cmd.ExecuteNonQuery();
                Console.WriteLine("First name updated successfully!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating first name: {ex.Message}");
        }
    }

    public static void UpdateUserLastName(string userName, string newLastName)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string updateQuery = "UPDATE User SET LastName = @NewLastName WHERE userName = @UserName";
                SqlCommand cmd = new SqlCommand(updateQuery, connection);
                cmd.Parameters.AddWithValue("@NewLastName", newLastName);
                cmd.Parameters.AddWithValue("@UserName", userName);

                cmd.ExecuteNonQuery();
                Console.WriteLine("Last name updated successfully!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating last name: {ex.Message}");
        }
    }

    public static void UpdateUserBirthDateNAge(string userName, DateOnly newBirthDate, int newAge)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string updateQuery = "UPDATE User SET BirthDate = @NewBirthDate WHERE userName = @UserName UPDATE User SET Age = @NewAge WHERE userName = @UserName";
                SqlCommand cmd = new SqlCommand(updateQuery, connection);
                cmd.Parameters.AddWithValue("@NewBirthDate", newBirthDate);
                cmd.Parameters.AddWithValue("@NewAge", newAge);
                cmd.Parameters.AddWithValue("@UserName", userName);

                cmd.ExecuteNonQuery();
                Console.WriteLine("Birth date updated successfully!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating birth date: {ex.Message}");
        }
    }

    public static void UpdateUserHeightWeightBMI(string userName, double newHeight, double newWeight, double newBMI)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string updateQuery = "UPDATE User SET heightInches = @NewHeightInches WHERE userName = @UserName UPDATE User SET Weight = @NewWeight WHERE userName = @UserName UPDATE User SET BMI = @NewBMI WHERE userName = @UserName";
                SqlCommand cmd = new SqlCommand(updateQuery, connection);
                cmd.Parameters.AddWithValue("@heightInches", newHeight);
                cmd.Parameters.AddWithValue("@Weight", newWeight);
                cmd.Parameters.AddWithValue("@BMI", newBMI);
                cmd.Parameters.AddWithValue("@UserName", userName);

                cmd.ExecuteNonQuery();
                Console.WriteLine("Height and Weight updated successfully!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating height: {ex.Message}");
        }
    }

    
}