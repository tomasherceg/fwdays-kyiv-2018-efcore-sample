using System;
using System.Collections.Generic;

namespace EFCore21.ValueConversions.Model
{
    public partial class Comments
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string AuthorName { get; set; }
        public string IpAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public CommentType Type { get; set; }
        public int PostId { get; set; }
        public Posts Post { get; set; }
    }
}
