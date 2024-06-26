using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SweatyMcSweatyface.Controllers;
using SweatyMcSweatyface.Data;
using SweatyMcSweatyface.Presentation;

namespace SweatyMcSweatyface.Models
{
    public class User 
    {

        public Guid userId { get; set; } 
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime birthDate { get; set; }
        public int Age { get; set; }
        public double heightInches { get; set; }
        public double Weight { get; set; }
        public double BMI { get; set; }

        //Constructors

        //Default/No argument constructor
        public User() { }

        //This constructor takes in all the properties of the User class
        public User(string _userName, string _firstName, string _lastName, DateTime _birthDate, int _Age, double _heightInches, double _Weight, double _BMI)
        {
            userId = Guid.NewGuid(); //This creates a random Guid for us, without us having to worry about it
            userName = _userName;
            firstName = _firstName;
            lastName = _lastName;
            birthDate = _birthDate;
            Age = _Age;
            heightInches = _heightInches;
            Weight = _Weight;
            BMI = _BMI;
        }
        public override string ToString() //This method is used to display the object in a readable format
        {
            return $"userId: {userId}, userName: {userName}, firstName: {firstName}, lastName: {lastName}, birthDate: {birthDate}, Age: {Age}, heightInches: {heightInches}, Weight: {Weight}, BMI: {BMI}"; //This is the format in which the object will be displayed
        }

        static KeyValuePair<int, double> ToFeetInches(double totalInches)
        {
            int feet = (int)(totalInches / 12);
            double remainingInches = totalInches % 12;
            return new KeyValuePair<int, double>(feet, remainingInches);
        }

        class Program
        {
            // static void Main()
            // {
            //     var result1 = ToFeetInches(70.0);
            //     Console.WriteLine(result1); // Output: 5 feet 10 inches

            //     var result2 = ToFeetInches(61.5);
            //     Console.WriteLine(result2); // Output: 5 feet 1.5 inches

            //     var result3 = ToFeetInches(72.0);
            //     Console.WriteLine(result3); // Output: 6 feet 0 inches
            // }


        }



    }
}