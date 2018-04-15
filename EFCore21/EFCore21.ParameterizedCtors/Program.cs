using EFCore21.ParameterizedCtors.Model;
using System;
using System.Linq;

namespace EFCore21.ParameterizedCtors
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BloggingContext())
            {
                // Blog instances are created via parameterized ctor
                foreach (var blog in context.Blogs)
                {
                    Console.WriteLine($"{blog.Id}\t{blog.Name}");
                }
                Console.ReadKey();



                // ID can be assigned by Entity Framework
                // but not by us - Id has private setter
                var newBlog = new Blogs("New blog");
                context.Blogs.Add(newBlog);
                context.SaveChanges();

                Console.WriteLine("New blog ID: " + newBlog.Id);

                context.Blogs.Remove(newBlog);
                context.SaveChanges();
                Console.ReadKey();



                // injecting IEntityType to get metadata about type
                var post = context.Posts.Find(3);
                Console.WriteLine(post.EntityType.Name);
                Console.ReadKey();
            }
        }
    }
}
