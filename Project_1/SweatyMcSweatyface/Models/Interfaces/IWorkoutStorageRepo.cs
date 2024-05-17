using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweatyMcSweatyface.Models.Interfaces
{
    public interface IWorkoutStorageRepo

    {
        public void StoreWorkout(Workout newWorkout);

        public List<Workout> GetWorkouts(Guid userID, int listType);

        public void StoreWeightRoom(WeightRoom newWeightRoom);

        public List<WeightRoom> GetWeightRooms(Guid userID, int listType);

        public void StoreRunNCycle(RunNCycle newRunNCycle);

        public List<RunNCycle> GetRunNCycles(Guid userID, int listType);

        // public WorkoutsDTO GetAllWorkouts(Guid userID, int listType);

        // public List<Workout> GetWorkouts(Guid userID);
        
        // public Workout GetWorkout(int workoutId);

        // public List<Workout> GetWorkouts(int workoutId);

        // public WeightRoom GetWeightRoomsByWorkoutId(int workoutId);

        // public List<WeightRoom> GetWeightRooms(int workoutId);

        // public RunNCycle GetRunNCycles(int workoutId);

        // public List<RunNCycle> GetRunNCyclesByWorkoutId(int workoutId);
        // List<WeightRoom>? GetWeightRooms(Guid userId);

        // public void DeleteWorkout(int workoutId);

        // public void DeleteWeightRoom(int workoutId);

        // public void DeleteRunNCycle(int workoutId);

        // public void UpdateWorkout(Workout updatedWorkout);

        // public void UpdateWeightRoom(WeightRoom updatedWeightRoom);

        // public void UpdateRunNCycle(RunNCycle updatedRunNCycle);

        // public void DeleteAllWorkouts();

    }
}

