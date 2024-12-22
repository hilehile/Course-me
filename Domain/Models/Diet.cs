using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Diet
    {
        public int DietId { get; set; }
        public int UserId { get; set; }
        public int DietTypeId { get; set; }
        public int DietGoalId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual DietGoal DietGoal { get; set; } = null!;
        public virtual DietType DietType { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
