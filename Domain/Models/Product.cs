using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Product
    {
        public Product()
        {
            DishProducts = new HashSet<DishProduct>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public decimal? CaloriesPer100g { get; set; }
        public decimal? ProteinsPer100g { get; set; }
        public decimal? FatsPer100g { get; set; }
        public decimal? CarbsPer100g { get; set; }

        public virtual ICollection<DishProduct> DishProducts { get; set; }
    }
}
