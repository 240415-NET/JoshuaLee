using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SweatyMcSweatyface.Controllers;
using SweatyMcSweatyface.Models;
using SweatyMcSweatyface.Presentation;
using System.Text.Json;
using SweatyMcSweatyface.Models.Interfaces;

namespace SweatyMcSweatyface.DataAccess;

    public class JsonBodyStatsStorage : IBodyStatsStorageRepo
    {

        // public static string filePath = "BodyStatsFile.json";


        // //Changed my methods to be instance methods instead of class methods

        // public void StoreBodyStats(BodyStats newBodyStats)
        // {

        //     if (File.Exists(filePath))
        //     {
        //         string existingBodyStatssJson = File.ReadAllText(filePath);

        //         List<BodyStats> existingBodyStatssList = JsonSerializer.Deserialize<List<BodyStats>>(existingBodyStatssJson);

        //         existingBodyStatssList?.Add(newBodyStats);

        //         string jsonExistingBodyStatssListString = JsonSerializer.Serialize(existingBodyStatssList);

        //         File.WriteAllText(filePath, jsonExistingBodyStatssListString);
        //     }
        //     else if (!File.Exists(filePath)) //The first time the program runs, the file probably doesn't exist
        //     {
        //         //Creating a blank list to use later
        //         List<BodyStats> initialBodyStatssList = new List<BodyStats>();

        //         //Adding our BodyStats to our list, PRIOR to serializing it
        //         initialBodyStatssList.Add(newBodyStats);

        //         //Here we will serialize our list of BodyStatss, into a JSON text string
        //         string jsonBodyStatssListString = JsonSerializer.Serialize(initialBodyStatssList);

        //         //Now we will store our jsonBodyStatssString to our file
        //         File.WriteAllText(filePath, jsonBodyStatssListString);
        //     }

        // }

}