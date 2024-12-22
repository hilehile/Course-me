using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class ExerciseGoal
    {
        public int ExerciseGoalId { get; set; }
        public string Name { get; set; } = null!;
    }
}
