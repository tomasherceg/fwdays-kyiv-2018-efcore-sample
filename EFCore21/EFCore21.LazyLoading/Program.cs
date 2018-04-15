using EFCore21.LazyLoading.Model;
using System;
using System.Linq;

namespace EFCore21.LazyLoading
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BloggingContext())
            {
                var blog = context.Blogs.Single(b => b.Id == 2);

                foreach (var post in blog.Posts)
                {
                    Console.WriteLine($"{post.Id}\t{post.Title}");
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.ReadKey();

                // proxy is generated
                var comments = blog.Posts.Single(p => p.Id == 3).Comments;
                Console.WriteLine(comments.First().GetType());

                Console.ReadKey();
            }
        }
    }
}
