using System;
using System.Collections.Generic;

namespace Course_me.Models
{
    public partial class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; } = null!;
        public string? Content { get; set; }
        public DateTime PublishedAt { get; set; }
    }
}
