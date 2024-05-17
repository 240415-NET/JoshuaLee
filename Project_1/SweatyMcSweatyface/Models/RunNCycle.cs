using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweatyMcSweatyface.Models
{
    public class RunNCycle : Workout
    {
        string CardioType {get; set;}
        double Distance {get; set;}

        string RunOrCycle {get;set;}

        double AverageSpeed {get;set;}

        public RunNCycle(Guid userId, Guid WorkoutId, string WorkoutType, TimeSpan Duration, string Description, string CardioType, double Distance, string RunOrCycle, double AverageSpeed) : base(userId, WorkoutId, WorkoutType, Duration, Description)
        {
            this.CardioType = CardioType;
            this.Distance = Distance;
            this.RunOrCycle = RunOrCycle;
            this.AverageSpeed = AverageSpeed;
        }
        public override string ToString()
        {
            return $"WorkoutId: {WorkoutId}, \nWorkoutType: {WorkoutType}, \nDuration: {Duration}, \nDescription: {Description}, \nCardioType: {CardioType}, \nDistance: {Distance}, \nRunOrCycle: {RunOrCycle}, \nAverageSpeed: {AverageSpeed}";
        }
    }
}