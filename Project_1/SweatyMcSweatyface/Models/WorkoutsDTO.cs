using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweatyMcSweatyface.Models;

    public class WorkoutsDTO
    {
    public List<Workout>? Workouts {get; set;}
    public List<WeightRoom>? WeightRooms {get; set;}
    public List<RunNCycle>? RunNCycles {get; set;}
    
    public WorkoutsDTO()
    {
        this.Workouts = new List<Workout>();
        this.WeightRooms = new List<WeightRoom>();
        this.RunNCycles = new List<RunNCycle>();
    }
}