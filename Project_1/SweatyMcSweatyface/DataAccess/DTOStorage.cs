using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SweatyMcSweatyface.Controllers;
using SweatyMcSweatyface.Models;
using SweatyMcSweatyface.Presentation;
using System.Text.Json;
using SweatyMcSweatyface.Data;

namespace SweatyMcSweatyface.Data;


public class DTOStorage
{
    public static string filePath = "Workouts.json";

    public static List<Workout> DeserializeWorkout()
    {

        List<Workout?> existingWorkoutList = new List<Workout?>();
        try
        {
            if (File.Exists(filePath))
            {
                string existingDTOJson = File.ReadAllText(filePath);


                WorkoutsDTO existingDTO = JsonSerializer.Deserialize<WorkoutsDTO>(existingDTOJson);

                if (existingDTO.Workouts == null)
                    return existingWorkoutList;
                else
                    existingWorkoutList = existingDTO.Workouts.ToList();
            }
            else if (!File.Exists(filePath))

            {
                WorkoutsDTO existingDTO = new();
                string existingDTOJson = JsonSerializer.Serialize(existingDTO);
                File.WriteAllText(filePath, existingDTOJson);
            }
        }
        catch (Exception e) { }

        return existingWorkoutList;

    }
    public static List<WeightRoom> DeserializeWeightRoom()
    {

        List<WeightRoom?> existingWeightRoomList = new List<WeightRoom?>();

        try
        {

            if (File.Exists(filePath))
            {
                string existingDTOJson = File.ReadAllText(filePath);
                WorkoutsDTO existingDTO = JsonSerializer.Deserialize<WorkoutsDTO>(existingDTOJson);

                if (existingDTO.WeightRooms == null)
                    return existingWeightRoomList;
                else
                    existingWeightRoomList = existingDTO.WeightRooms.ToList();
            }
            else if (!File.Exists(filePath))
            {
                WorkoutsDTO existingDTO = new();
                string existingDTOJson = JsonSerializer.Serialize(existingDTO);
                File.WriteAllText(filePath, existingDTOJson);
            }
        }
        catch (Exception e) { }

        return existingWeightRoomList;
    }
    public static List<RunNCycle> DeserializeRunNCycle()
    {
        List<RunNCycle?> existingRunNCycleList = new List<RunNCycle?>();

        try
        {
            if (File.Exists(filePath))
            {

                string existingDTOJson = File.ReadAllText(filePath);

                WorkoutsDTO? existingDTO = JsonSerializer.Deserialize<WorkoutsDTO>(existingDTOJson);

                if (existingDTO?.RunNCycles == null)
                    return existingRunNCycleList;
                else
                    existingRunNCycleList = existingDTO.RunNCycles.ToList();

            }
            else if (!File.Exists(filePath))
            {
                WorkoutsDTO existingDTO = new();
                string existingDTOJson = JsonSerializer.Serialize(existingDTO);
                File.WriteAllText(filePath, existingDTOJson);
            }
        }
        catch (Exception e) { }

        return existingRunNCycleList;

    }

    public static void SerializeWorkout(List<WorkoutsDTO> existingWorkoutList)
    {
        string existingDTOJson = File.ReadAllText(filePath);
        WorkoutsDTO existingDTO = JsonSerializer.Deserialize<WorkoutsDTO>(existingDTOJson);
        existingDTO.Workouts = existingWorkoutList.Cast<Workout>().ToList();
        existingDTOJson = JsonSerializer.Serialize(existingDTO);
        File.WriteAllText(filePath, existingDTOJson);
    }

    public static void SerializeWeightRoom(List<WeightRoom> existingWeightRoomList)
    {

        string existingDTOJson = File.ReadAllText(filePath);


        WorkoutsDTO existingDTO = JsonSerializer.Deserialize<WorkoutsDTO>(existingDTOJson);


        existingDTO.WeightRooms = existingWeightRoomList;


        existingDTOJson = JsonSerializer.Serialize(existingDTO);


        File.WriteAllText(filePath, existingDTOJson);
    }

    public static void SerializeRunNCycle(List<RunNCycle> existingRunNCycleList)
    {

        string existingDTOJson = File.ReadAllText(filePath);

        WorkoutsDTO existingDTO = JsonSerializer.Deserialize<WorkoutsDTO>(existingDTOJson);

        existingDTO.RunNCycles = existingRunNCycleList;


        existingDTOJson = JsonSerializer.Serialize(existingDTO);

        File.WriteAllText(filePath, existingDTOJson);
    }

    internal static void SerializeWorkout(List<Workout?> existingWorkoutsList)
    {
        throw new NotImplementedException();
    }
}
