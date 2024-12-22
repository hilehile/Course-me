using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class DishProduct
    {
        public int DishProductId { get; set; }
        public int DishId { get; set; }
        public int ProductId { get; set; }
        public decimal? QuantityGrams { get; set; }

        public virtual Dish Dish { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
