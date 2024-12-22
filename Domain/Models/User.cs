using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class User
    {
        public User()
        {
            Analytics = new HashSet<Analytic>();
            Diets = new HashSet<Diet>();
            Favorites = new HashSet<Favorite>();
            Reminders = new HashSet<Reminder>();
            Tests = new HashSet<Test>();
            UserDetails = new HashSet<UserDetail>();
            WaterIntakes = new HashSet<WaterIntake>();
            Workouts = new HashSet<Workout>();
        }

        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Analytic> Analytics { get; set; }
        public virtual ICollection<Diet> Diets { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<Reminder> Reminders { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
        public virtual ICollection<UserDetail> UserDetails { get; set; }
        public virtual ICollection<WaterIntake> WaterIntakes { get; set; }
        public virtual ICollection<Workout> Workouts { get; set; }
    }
}
