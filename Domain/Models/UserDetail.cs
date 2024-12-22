using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class UserDetail
    {
        public int UserDetailId { get; set; }
        public int UserId { get; set; }
        public string? FullName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Gender { get; set; }
        public decimal? HeightCm { get; set; }
        public decimal? WeightKg { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
