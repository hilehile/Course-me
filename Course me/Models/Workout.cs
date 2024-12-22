using System;
using System.Collections.Generic;

namespace Course_me.Models
{
    public partial class Workout
    {
        public int WorkoutId { get; set; }
        public int UserId { get; set; }
        public int ExerciseId { get; set; }
        public DateTime WorkoutTime { get; set; }
        public decimal? DurationMinutes { get; set; }

        public virtual Exercise Exercise { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
