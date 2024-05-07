using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweatyMcSweatyface.Models
{
    public class RunNCycle : Workouts
    {
        double Distance {get; set;}

        string RunOrCycle {get;set;}

        double AverageSpeed {get;set;}
    }
}