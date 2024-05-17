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
                
        public static void createWorkout(User user, Guid workoutId, string workoutType, TimeSpan Duration, string Description)
        {
            Workout newWorkout = new Workout(user.userId, workoutId, workoutType, Duration, Description);
            _WorkoutStorageRepo.StoreWorkout(newWorkout);
        }

        public static WorkoutsDTO GetWorkouts(User user)
        {
            WorkoutsDTO workoutsDTO = new WorkoutsDTO();
            workoutsDTO.Workouts = _WorkoutStorageRepo.GetWorkouts(user.userId, 0);
            workoutsDTO.WeightRooms = _WorkoutStorageRepo.GetWeightRooms(user.userId, 0); // Updated parameter type to Guid
            workoutsDTO.RunNCycles = _WorkoutStorageRepo.GetRunNCycles(user.userId, 0); // Updated parameter type to Guid
            return workoutsDTO;
        }
    }
}