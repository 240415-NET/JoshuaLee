using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SweatyMcSweatyface.Models.Interfaces;

namespace SweatyMcSweatyface.DataAccess
{
    public class JsonWorkoutStorage : IWorkoutStorageRepo
    // {
    //     public void StoreWorkout(Workout newWorkout)
    //     {
    //         List<Workout?> existingWorkoutsList = DTOStorage.DeserializeWorkout();

    //         //Once we deserialize our exisitng JSON text from the file into a new List<Workout> object
    //         //We will then simply add it to the list, using the Add() method
    //         existingWorkoutsList.Add(newWorkout);

    //         DTOStorage.SerializeWorkout(existingWorkoutsList);
    //     }

    //     public List<Workout> GetWorkouts()
    //     {
    //         List<Workout> myReturnList = new();
    //         WorkoutsDTO allMyWorkouts = JsonSerializer.Deserialize<WorkoutsDTO>(File.ReadAllText(filePath));
    //         foreach (var workout in allMyWorkouts.Workouts)
    //         {
    //             myReturnList.Add(workout);
    //         }
    //         foreach (var weightRoom in allMyWorkouts.WeightRooms)
    //         {
    //             myReturnList.Add(weightRoom);
    //         }
    //         foreach (var runNCycle in allMyWorkouts.RunNCycles)
    //         {
    //             myReturnList.Add(runNCycle);
    //         }
    //         return myReturnList;
    //     }
    // }
  {

    public static string filePath = "Workouts.json";

    //If I find myself re-using the same string or object etc, I can go ahead
    //and make it a member of my class. This way I can reuse this same data without
    //having to continuously re-initialize it.
    //The underscore is a common convention to denote variables that are common
    //to the entire class


    //Changed my methods to be instance methods instead of class methods

    public void StoreWorkout(Workout newWorkout)
    {
        List<Workout?> existingWorkoutsList = DTOStorage.DeserializeWorkout();

        //Once we deserialize our exisitng JSON text from the file into a new List<Workout> object
        //We will then simply add it to the list, using the Add() method
        existingWorkoutsList.Add(newWorkout);

        DTOStorage.SerializeWorkout(existingWorkoutsList);
    }

    public void StoreWeightRoom(WeightRoom newWeightRoom)
    {

        List<WeightRoom?> existingWeightRoomsList = DTOStorage.DeserializeWeightRoom();


        //Once we deserialize our exisitng JSON text from the file into a new List<Workout> object
        //We will then simply add it to the list, using the Add() method
        existingWeightRoomsList.Add(newWeightRoom);

        DTOStorage.SerializeWeightRoom(existingWeightRoomsList);
    }

    public void StoreRunNCycle(RunNCycle newRunNCycle)
    {

        List<RunNCycle?> existingRunNCyclesList = DTOStorage.DeserializeRunNCycle();


        //Once we deserialize our exisitng JSON text from the file into a new List<Workout> object
        //We will then simply add it to the list, using the Add() method
        existingRunNCyclesList.Add(newRunNCycle);

        DTOStorage.SerializeRunNCycle(existingRunNCyclesList);
    }
    
    public List<Workout> GetWorkouts(Guid userID, int listType)
    {
        List<Workout> myReturnList = new();
        WorkoutsDTO allWorkouts = JsonSerializer.Deserialize<WorkoutsDTO>(File.ReadAllText(filePath));
        if (listType == 4 || listType == 1)
        {
            var userWorkouts = allWorkouts.Workouts.Where(x => x.userId.Equals(userID));
            foreach (var Workout in userWorkouts)
            {
                myReturnList.Add(Workout);
            }
        }
        if (listType == 4 || listType == 2)
        {
            var userRunNCycles = allWorkouts.RunNCycles.Where(x => x.userId.Equals(userID));
            foreach (var RunNCycle in userRunNCycles)
            {
                myReturnList.Add(RunNCycle);
            }
        }
        if (listType == 4 || listType == 3)
        {
            var userDocs = allWorkouts.WeightRooms.Where(x => x.userId.Equals(userID));
            foreach (var WeightRoom in userDocs)
            {
                myReturnList.Add(WeightRoom);
            }
        }
        return myReturnList;
    }
}

