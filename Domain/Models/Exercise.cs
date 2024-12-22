using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Exercise
    {
        public Exercise()
        {
            Workouts = new HashSet<Workout>();
        }

        public int ExerciseId { get; set; }
        public string Name { get; set; } = null!;
        public decimal? CaloriesBurnedPerMinute { get; set; }

        public virtual ICollection<Workout> Workouts { get; set; }
    }
}
