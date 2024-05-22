using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweatyMcSweatyface.Models
{
    public class RunNCycle : Workout
    {
        string RunOrCycle {get;set;}
        double Distance {get; set;}
        double AverageSpeed {get;set;}

        public RunNCycle(Guid userId, string WorkoutType, DateOnly Date, double Duration, string Description,  string RunOrCycle,  
        //string CardioType, 
        double Distance, double AverageSpeed) : base(userId, WorkoutType, Date, Duration, Description)
        {
            this.RunOrCycle = RunOrCycle;
            this.Distance = Distance;
            // this.CardioType = CardioType;
            this.AverageSpeed = AverageSpeed;
        }
        public override string ToString()
        {
            return $"WorkoutType: {WorkoutType}, \nDate: {Date}, \nDuration: {Duration}, \nDescription: {Description}, \nRunOrCycle: {RunOrCycle}, \nDistance: {Distance}, \nAverageSpeed: {AverageSpeed}";
        }
    }
}