using System;
using System.Collections.Generic;

namespace Course_me.Models
{
    public partial class Reminder
    {
        public int ReminderId { get; set; }
        public int UserId { get; set; }
        public string ReminderText { get; set; } = null!;
        public DateTime ReminderTime { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
