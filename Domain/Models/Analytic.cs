using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Analytic
    {
        public int AnalyticsId { get; set; }
        public int UserId { get; set; }
        public DateTime DataDate { get; set; }
        public decimal? CaloriesConsumed { get; set; }
        public decimal? CaloriesBurned { get; set; }
        public decimal? WaterIntakeLiters { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
