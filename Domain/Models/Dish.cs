using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Dish
    {
        public Dish()
        {
            DishProducts = new HashSet<DishProduct>();
        }

        public int DishId { get; set; }
        public string Name { get; set; } = null!;
        public string? Recipe { get; set; }
        public decimal? CaloriesPerPortion { get; set; }

        public virtual ICollection<DishProduct> DishProducts { get; set; }
    }
}
