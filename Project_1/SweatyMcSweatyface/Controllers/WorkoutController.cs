using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SweatyMcSweatyface.Data;
using SweatyMcSweatyface.Models;
using SweatyMcSweatyface.Models.Interfaces;

namespace SweatyMcSweatyface.Controllers
{
    public class WorkoutController
    {
        private static IWorkoutStorageRepo _WorkoutStorageRepo = (IWorkoutStorageRepo)new JsonWorkoutStorage();
                
        public static void createWorkout(User user, string WorkoutType, DateOnly Date, double Duration, string Description)
        {
            Workout newWorkout = new Workout(user.userId, WorkoutType, Date, Duration, Description);
            _WorkoutStorageRepo.StoreWorkout(newWorkout);
        }

        public static void createWeightRoom(User user, string WorkoutType, DateOnly Date, double Duration, string Description, string ExerciseName, double Sets, double Repetitions, double WeightLifted)
        {
            WeightRoom newWeightRoom = new WeightRoom(user.userId, WorkoutType, Date, Duration, Description, ExerciseName, Sets, Repetitions, WeightLifted);
            _WorkoutStorageRepo.StoreWeightRoom(newWeightRoom);
        }

        public static void createRunNCycle(User user, string WorkoutType, DateOnly Date, double Duration, string Description, string RunOrCycle, double Distance, double AverageSpeed)
        {
            RunNCycle newRunNCycle = new RunNCycle(user.userId, WorkoutType, Date, Duration, Description, RunOrCycle, Distance,   AverageSpeed);
            _WorkoutStorageRepo.StoreRunNCycle(newRunNCycle);
        }

        public static WorkoutsDTO GetWorkouts(User user)
        {
            WorkoutsDTO workoutsDTO = new WorkoutsDTO();
            workoutsDTO.Workouts = _WorkoutStorageRepo.GetWorkouts(user.userId, 0);
            workoutsDTO.WeightRooms = _WorkoutStorageRepo.GetWeightRooms(user.userId, 0); // Updated parameter type to Guid
            workoutsDTO.RunNCycles = _WorkoutStorageRepo.GetRunNCycles(user.userId, 0); // Updated parameter type to Guid
            return workoutsDTO;
        }

        public static List<Workout> GetWorkouts(User user, int workoutId)
        {
            return _WorkoutStorageRepo.GetWorkouts(user.userId, workoutId);
        }

        public static List<WeightRoom> GetWeightRooms(User user, int workoutId)
        {
            return _WorkoutStorageRepo.GetWeightRooms(user.userId, workoutId);
        }

        public static List<RunNCycle> GetRunNCycles(User user, int workoutId)
        {
            return _WorkoutStorageRepo.GetRunNCycles(user.userId, workoutId);
        }

        // public static void DeleteWorkout(Guid workoutId)
        // {
        //     _WorkoutStorageRepo.DeleteWorkout(workoutId);
        // }

        // public static void DeleteWeightRoom(Guid workoutId)
        // {
        //     _WorkoutStorageRepo.DeleteWeightRoom(workoutId);
        // }

        // public static void DeleteRunNCycle(Guid workoutId)
        // {
        //     _WorkoutStorageRepo.DeleteRunNCycle(workoutId);
    }
}