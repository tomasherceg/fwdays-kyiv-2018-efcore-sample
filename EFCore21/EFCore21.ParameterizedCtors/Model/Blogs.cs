using System;
using System.Collections.Generic;

namespace EFCore21.ParameterizedCtors.Model
{
    public partial class Blogs
    {
        public Blogs(string name)
        {
            Name = name;
            Posts = new HashSet<Posts>();
        }

        public int Id { get; private set; }
        public string Name { get; set; }

        public ICollection<Posts> Posts { get; set; }
    }
}
