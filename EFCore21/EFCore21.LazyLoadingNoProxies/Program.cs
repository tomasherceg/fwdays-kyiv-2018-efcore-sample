using EFCore21.LazyLoadingNoProxies.Model;
using System;
using System.Linq;

namespace EFCore21.LazyLoadingNoProxies
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BloggingContext())
            {
                var post = context.Posts.Single(p => p.Id == 3);

                // no proxy is generated
                Console.WriteLine(post.Comments.First().GetType());

                Console.ReadKey();
            }
        }
    }
}
