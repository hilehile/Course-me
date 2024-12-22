using System;
using System.Collections.Generic;

namespace Course_me.Models
{
    public partial class DietType
    {
        public DietType()
        {
            Diets = new HashSet<Diet>();
        }

        public int DietTypeId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Diet> Diets { get; set; }
    }
}
