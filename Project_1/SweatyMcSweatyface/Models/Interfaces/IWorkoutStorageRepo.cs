using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweatyMcSweatyface.Models.Interfaces
{
    public interface IWorkoutStorageRepo

    {
        public void StoreWorkout(Workout newWorkout);

        public void StoreWeightRoom(WeightRoom newWeightRoom);

        public void StoreRunNCycle(RunNCycle newRunNCycle);

        public WorkoutsDTO GetAllWorkouts();

        public Workout GetWorkout(int workoutId);

        public WeightRoom GetWeightRoom(int workoutId);

        public RunNCycle GetRunNCycle(int workoutId);

        // public void DeleteWorkout(int workoutId);

        // public void DeleteWeightRoom(int workoutId);

        // public void DeleteRunNCycle(int workoutId);

        // public void UpdateWorkout(Workout updatedWorkout);

        // public void UpdateWeightRoom(WeightRoom updatedWeightRoom);

        // public void UpdateRunNCycle(RunNCycle updatedRunNCycle);

        // public void DeleteAllWorkouts();

    }
}

