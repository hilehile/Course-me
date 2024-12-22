using System;
using System.Collections.Generic;

namespace Course_me.Models
{
    public partial class Test
    {
        public int TestId { get; set; }
        public int UserId { get; set; }
        public DateTime TestDate { get; set; }
        public string? Result { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
