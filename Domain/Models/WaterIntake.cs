using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class WaterIntake
    {
        public int WaterIntakeId { get; set; }
        public int UserId { get; set; }
        public DateTime IntakeTime { get; set; }
        public decimal? AmountLiters { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
