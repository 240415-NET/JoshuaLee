using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweatyMcSweatyface.Models
{
    public class Workouts
    {
        public int UserId { get; set; }
        public int WorkoutId { get; private set; }
        public string WorkoutType { get; set; }
        public TimeSpan Duration { get; set; }
        public string Description { get; set; }

        public Workouts() { }

        public Workouts(int _UserId, int _WorkoutId, string _WorkoutType,
            TimeSpan _Duration, string _Description)
        {
            UserId = _UserId;
            WorkoutId = _WorkoutId;
            WorkoutType = _WorkoutType;
            Duration = _Duration;
            Description = _Description;
        }
    }
}