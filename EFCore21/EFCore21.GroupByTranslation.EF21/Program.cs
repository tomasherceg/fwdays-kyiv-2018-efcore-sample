using EFCore21.GroupByTranslation.EF21.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCore21.GroupByTranslation.EF21
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BloggingContext())
            {
                var report = context.Posts
                    .GroupBy(p => p.Blog.Name)
                    .Select(p => new ReportItem()
                    {
                        BlogName = p.Key,
                        PostCount = p.Count(),
                        LatestPostDate = p.Max(i => i.PublishedDate),
                        //MaxComments = p.Max(i => i.Comments.Count())  
                            // GROUP BY is not generated with this line
                    })
                    .ToList();

                //var report = context.Posts
                //    .Select(p => new
                //    {
                //        BlogName = p.Blog.Name,
                //        PublishedDate = p.PublishedDate,
                //        CommentsCount = p.Comments.Count()
                //    })
                //    .GroupBy(p => p.BlogName)
                //    .Select(p => new ReportItem()
                //    {
                //        BlogName = p.Key,
                //        PostCount = p.Count(),
                //        LatestPostDate = p.Max(i => i.PublishedDate),
                //        MaxComments = p.Max(i => i.CommentsCount)
                //    })
                //    .ToList();
                //// reported as https://github.com/aspnet/EntityFrameworkCore/issues/10472

                WriteTable(report, new(string label, Func<ReportItem, object> selector)[]
                {
                    ("BLOG", i => i.BlogName),
                    ("POSTS", i => i.PostCount.ToString()),
                    ("LATEST POST", i => i.LatestPostDate?.ToString("d")),
                    ("COMMENTS", i => i.MaxComments.ToString())
                });
            }
            Console.ReadKey();
        }

        private static void WriteTable<T>(IEnumerable<T> items, (string label, Func<T, object> selector)[] columns)
        {
            var materialized = Enumerable.Concat(
                new[] { columns.Select(c => c.label).ToArray() },
                items.Select(i => columns.Select(c => c.selector(i)?.ToString() ?? "").ToArray()).ToArray()
            );

            var columnWidths = Enumerable.Range(0, columns.Length)
                .Select(c => materialized.Max(r => r[c].Length))
                .ToArray();

            foreach (var row in materialized)
            {
                for (int i = 0; i < columns.Length; i++)
                {
                    var cell = row[i];

                    if (i > 0)
                    {
                        Console.Write("|");
                    }
                    Console.Write(cell.PadRight(columnWidths[i]));
                }
                Console.WriteLine();
            }
        }
    }
}
