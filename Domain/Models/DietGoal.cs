﻿using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class DietGoal
    {
        public DietGoal()
        {
            Diets = new HashSet<Diet>();
        }

        public int DietGoalId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Diet> Diets { get; set; }
    }
}