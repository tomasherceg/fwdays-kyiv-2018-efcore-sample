using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCore21.DataSeeding.Model
{
    public class Post
    {

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime? PublishedDate { get; set; }


        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public int BlogId { get; set; }

        public virtual Blog Blog { get; set; }

    }
}