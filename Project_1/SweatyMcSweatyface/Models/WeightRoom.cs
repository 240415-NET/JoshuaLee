using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweatyMcSweatyface.Models
{
    public class WeightRoom : Workout
    {
        public string ExerciseName {get; set;}
        public double Sets {get; set;}
        public double Repetitions {get; set;}
        public double WeightLifted {get; set;}

        public WeightRoom() : base() { }

        public WeightRoom(Guid _userId, Guid _WorkoutId, string _WorkoutType,
            TimeSpan _Duration, string _Description, string _ExerciseName, double _Sets, double _Repetitions, double _WeightLifted)
        {
            ExerciseName = _ExerciseName;
            Sets = _Sets;
            Repetitions = _Repetitions;
            WeightLifted = _WeightLifted;
        }

        public override string ToString()
        {
            return $"WorkoutId: {WorkoutId}, \nWorkoutType: {WorkoutType}, \nDuration: {Duration}, \nDescription: {Description}, \nExerciseName: {ExerciseName}, \nSets: {Sets}, \nRepetitions: {Repetitions}, \nWeightLifted: {WeightLifted}";
        }

        ///Maybe add most reps/sets??
    }
}