using System;
using System.Collections.Generic;

namespace Course_me.Models
{
    public partial class Favorite
    {
        public int FavoriteId { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public string ItemType { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
