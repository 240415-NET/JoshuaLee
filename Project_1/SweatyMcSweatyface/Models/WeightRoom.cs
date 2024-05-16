using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweatyMcSweatyface.Models
{
    public class WeightRoom : Workout
    {
        public double Sets {get; set;}
        public double Repetitions {get; set;}
        public double TotalWeight {get; set;}

        ////Maybe add best TotalWeight
        ///Maybe add most reps/sets??
    }
}