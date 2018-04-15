using EFCore21.ValueConversions.Model;
using System;
using System.Linq;

namespace EFCore21.ValueConversions
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BloggingContext())
            {
                var comments = context.Comments
                    .Where(c => c.Type == CommentType.Suggestion);

                foreach (var comment in comments)
                {
                    Console.WriteLine(comment.Text);
                }

                Console.ReadKey();
            }
        }
    }
}
