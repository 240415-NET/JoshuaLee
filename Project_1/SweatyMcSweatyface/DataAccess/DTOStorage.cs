// Purpose: Contains the DTOStorage class which is responsible for serializing and deserializing the DTOs to and from a JSON file.
using SweatyMcSweatyface.Models;
using System.Text.Json;

namespace SweatyMcSweatyface.Data;  // namespace declaration


public class DTOStorage // class declaration
{
    // public static string filePath = "Workouts.json"; // file path declaration

    // public static List<Workout> DeserializeWorkout() // method declaration
    // {

    //     List<Workout?> existingWorkoutList = new List<Workout?>(); // list declaration
    //     try
    //     {
    //         if (File.Exists(filePath)) 
    //         {
    //             string existingDTOJson = File.ReadAllText(filePath); // read file


    //             WorkoutsDTO existingDTO = JsonSerializer.Deserialize<WorkoutsDTO>(existingDTOJson); // deserialize JSON file

    //             if (existingDTO.Workouts == null)
    //                 return existingWorkoutList; // return list
    //             else
    //                 existingWorkoutList = existingDTO.Workouts.ToList(); // return list
    //         }
    //         else if (!File.Exists(filePath))

    //         {
    //             WorkoutsDTO existingDTO = new();
    //             string existingDTOJson = JsonSerializer.Serialize(existingDTO);
    //             File.WriteAllText(filePath, existingDTOJson);
    //         }
    //     }
    //     catch (Exception e) { }

    //     return existingWorkoutList;

    // }
    // public static List<WeightRoom> DeserializeWeightRoom()
    // {

    //     List<WeightRoom?> existingWeightRoomList = new List<WeightRoom?>();

    //     try
    //     {

    //         if (File.Exists(filePath))
    //         {
    //             string existingDTOJson = File.ReadAllText(filePath);
    //             WorkoutsDTO existingDTO = JsonSerializer.Deserialize<WorkoutsDTO>(existingDTOJson);

    //             if (existingDTO.WeightRooms == null)
    //                 return existingWeightRoomList;
    //             else
    //                 existingWeightRoomList = existingDTO.WeightRooms.ToList();
    //         }
    //         else if (!File.Exists(filePath))
    //         {
    //             WorkoutsDTO existingDTO = new();
    //             string existingDTOJson = JsonSerializer.Serialize(existingDTO);
    //             File.WriteAllText(filePath, existingDTOJson);
    //         }
    //     }
    //     catch (Exception e) { }

    //     return existingWeightRoomList;
    // }
    // public static List<RunNCycle> DeserializeRunNCycle() // method declaration
    // {
    //     List<RunNCycle?> existingRunNCycleList = new List<RunNCycle?>(); // list declaration

    //     try
    //     {
    //         if (File.Exists(filePath))
    //         {

    //             string existingDTOJson = File.ReadAllText(filePath); // read file

    //             WorkoutsDTO? existingDTO = JsonSerializer.Deserialize<WorkoutsDTO>(existingDTOJson); // deserialize JSON file

    //             if (existingDTO?.RunNCycles == null)
    //                 return existingRunNCycleList; // return list
    //             else
    //                 existingRunNCycleList = existingDTO.RunNCycles.ToList(); // return list

    //         }
    //         else if (!File.Exists(filePath))
    //         {
    //             WorkoutsDTO existingDTO = new();
    //             string existingDTOJson = JsonSerializer.Serialize(existingDTO);
    //             File.WriteAllText(filePath, existingDTOJson);
    //         }
    //     }
    //     catch (Exception e) { }

    //     return existingRunNCycleList;

    // }

    // public static void SerializeWorkout(List<WorkoutsDTO> existingWorkoutList)
    // {
    //     string existingDTOJson = File.ReadAllText(filePath);
    //     WorkoutsDTO existingDTO = JsonSerializer.Deserialize<WorkoutsDTO>(existingDTOJson);
    //     existingDTO.Workouts = existingWorkoutList.Cast<Workout>().ToList();
    //     existingDTOJson = JsonSerializer.Serialize(existingDTO);
    //     File.WriteAllText(filePath, existingDTOJson);
    // }

    // public static void SerializeWeightRoom(List<WeightRoom> existingWeightRoomList)
    // {

    //     string existingDTOJson = File.ReadAllText(filePath);


    //     WorkoutsDTO existingDTO = JsonSerializer.Deserialize<WorkoutsDTO>(existingDTOJson);


    //     existingDTO.WeightRooms = existingWeightRoomList;


    //     existingDTOJson = JsonSerializer.Serialize(existingDTO);


    //     File.WriteAllText(filePath, existingDTOJson);
    // }

    // public static void SerializeRunNCycle(List<RunNCycle> existingRunNCycleList)
    // {

    //     string existingDTOJson = File.ReadAllText(filePath);

    //     WorkoutsDTO existingDTO = JsonSerializer.Deserialize<WorkoutsDTO>(existingDTOJson);

    //     existingDTO.RunNCycles = existingRunNCycleList;


    //     existingDTOJson = JsonSerializer.Serialize(existingDTO);

    //     File.WriteAllText(filePath, existingDTOJson);
    // }

    // internal static void SerializeWorkout(List<Workout?> existingWorkoutsList)
    // {
    //     throw new NotImplementedException();
    // }
}
