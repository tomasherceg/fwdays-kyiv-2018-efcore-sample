using System;
using System.Collections.Generic;

namespace EFCore21.GroupByTranslation.EF21.Model
{
    public partial class Blogs
    {
        public Blogs()
        {
            Posts = new HashSet<Posts>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Posts> Posts { get; set; }
    }
}
