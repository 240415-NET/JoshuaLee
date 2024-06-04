using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SweatyMcSweatyface.Controllers;
using SweatyMcSweatyface.Models;
using SweatyMcSweatyface.Presentation;
using System.Text.Json;
using SweatyMcSweatyface.Data;
using SweatyMcSweatyface.Models.Interfaces; // Add this using directive


namespace SweatyMcSweatyface.Data
{
    

    public class JsonWorkoutStorage //: IWorkoutStorageRepo
    {
//         public static string filePath = "Workouts.json";

//         //If I find myself re-using the same string or object etc, I can go ahead
//         //and make it a member of my class. This way I can reuse this same data without
//         //having to continuously re-initialize it.
//         //The underscore is a common convention to denote variables that are common
//         //to the entire class

//         public void StoreWorkout(Workout newWorkout)
//         {
//             List<Workout?> existingWorkoutsList = DTOStorage.DeserializeWorkout();

//             //Once we deserialize our exisitng JSON text from the file into a new List<Workout> object
//             //We will then simply add it to the list, using the Add() method
//             existingWorkoutsList.Add(newWorkout);

//             DTOStorage.SerializeWorkout(existingWorkoutsList);
//         }
   

//     public List<WeightRoom> GetWeightRooms(Guid userId, int listType)
//     {
//         // Your implementation here
//         return new List<WeightRoom>();
//     }
//     public List<RunNCycle> GetRunNCycles(Guid userId, int listType)
//     {
//         // Your implementation here
//         return new List<RunNCycle>();
//     }
//     public void StoreWeightRoom(WeightRoom newWeightRoom)
//     {

//         List<WeightRoom?> existingWeightRoomsList = DTOStorage.DeserializeWeightRoom();

//         List<WeightRoom> existingWeightRooms = existingWeightRoomsList.Where(x => x != null).Select(x => x!).ToList();

//         //Once we deserialize our exisitng JSON text from the file into a new List<Workout> object
//         //We will then simply add it to the list, using the Add() method
//         existingWeightRooms.Add(newWeightRoom);

//         DTOStorage.SerializeWeightRoom(existingWeightRooms);
//     }

//     public void StoreRunNCycle(RunNCycle newRunNCycle)
//     {

//         List<RunNCycle?> existingRunNCyclesList = DTOStorage.DeserializeRunNCycle();


//         //Once we deserialize our exisitng JSON text from the file into a new List<Workout> object
//         //We will then simply add it to the list, using the Add() method
//         existingRunNCyclesList.Add(newRunNCycle);

//         DTOStorage.SerializeRunNCycle(existingRunNCyclesList);
//     }


    
// public List<Workout> GetWorkouts(Guid userID, int listType)
// {
//     List<Workout> myReturnList = new();
//     WorkoutsDTO allWorkouts = JsonSerializer.Deserialize<WorkoutsDTO>(File.ReadAllText(filePath));

//     if (allWorkouts != null)
//     {
//         if (listType == 4 || listType == 1)
//         {
//             var userWorkouts = allWorkouts.Workouts?.Where(x => x.userId.Equals(userID));
//             if (userWorkouts != null)
//             {
//                 foreach (var Workout in userWorkouts)
//                 {
//                     myReturnList.Add(Workout);
//                 }
//             }
//         }
//         if (listType == 4 || listType == 2)
//         {
//             var userRunNCycles = allWorkouts.RunNCycles?.Where(x => x.userId.Equals(userID));
//             if (userRunNCycles != null)
//             {
//                 foreach (var RunNCycle in userRunNCycles)
//                 {
//                     myReturnList.Add(RunNCycle);
//                 }
//             }
//         }
//         if (listType == 4 || listType == 3)
//         {
//             var userDocs = allWorkouts.WeightRooms?.Where(x => x.userId.Equals(userID));
//             if (userDocs != null)
//             {
//                 foreach (var WeightRoom in userDocs)
//                 {
//                     myReturnList.Add(WeightRoom);
//                 }
//             }
//         }
//     }
//     return myReturnList;
//     }
}
}

