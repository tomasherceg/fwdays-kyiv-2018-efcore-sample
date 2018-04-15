using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore21.DataSeeding.Model
{
    public class Comment
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string AuthorName { get; set; }

        public string IpAddress { get; set; }

        public DateTime CreatedDate { get; set; }

        [StringLength(100)]
        public string Type { get; set; }



        public int PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}