using System;
using System.Collections.Generic;

namespace EFCore21.GroupByTranslation.EF21.Model
{
    public partial class Posts
    {
        public Posts()
        {
            Comments = new HashSet<Comments>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? PublishedDate { get; set; }
        public int BlogId { get; set; }

        public Blogs Blog { get; set; }
        public ICollection<Comments> Comments { get; set; }
    }
}
