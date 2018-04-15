using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;

namespace EFCore21.LazyLoading.Model
{
    public partial class Comments
    {
        public Comments()
        {

        }
        
        public int Id { get; set; }
        public string Text { get; set; }
        public string AuthorName { get; set; }
        public string IpAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Type { get; set; }
        public int PostId { get; set; }
        public virtual Posts Post { get; set; }
    }
}
