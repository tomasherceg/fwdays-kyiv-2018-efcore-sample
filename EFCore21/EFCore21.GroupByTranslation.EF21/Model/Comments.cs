﻿using System;
using System.Collections.Generic;

namespace EFCore21.GroupByTranslation.EF21.Model
{
    public partial class Comments
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string AuthorName { get; set; }
        public string IpAddress { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Type { get; set; }
        public int PostId { get; set; }

        public Posts Post { get; set; }
    }
}
