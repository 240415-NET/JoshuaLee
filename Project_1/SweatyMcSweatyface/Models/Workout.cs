using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweatyMcSweatyface.Models
{
    public class Workout
    {
        public Guid userId { get; set; }
        public Guid WorkoutId { get; set; }
        public string WorkoutType { get; set; }
        public TimeSpan Duration { get; set; }
        public string Description { get; set; }

        public Workout() { }

        public Workout(Guid _userId, Guid _WorkoutId, string _WorkoutType,
            TimeSpan _Duration, string _Description)
        {
            userId = _userId;
            WorkoutId = _WorkoutId;
            WorkoutType = _WorkoutType;
            Duration = _Duration;
            Description = _Description;
        }
    }
    
}