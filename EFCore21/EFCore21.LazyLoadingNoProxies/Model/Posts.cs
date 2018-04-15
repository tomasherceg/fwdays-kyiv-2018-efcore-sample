using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;

namespace EFCore21.LazyLoadingNoProxies.Model
{
    public partial class Posts
    {
        private ICollection<Comments> _comments;

        public Posts()
        {
            Comments = new HashSet<Comments>();
        }

        private Posts(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? PublishedDate { get; set; }
        public int BlogId { get; set; }

        public Blogs Blog { get; set; }


        public ICollection<Comments> Comments
        {
            get => LazyLoader?.Load(this, ref _comments);
            set => _comments = value;
        }

        private ILazyLoader LazyLoader { get; set; }
    }
}
