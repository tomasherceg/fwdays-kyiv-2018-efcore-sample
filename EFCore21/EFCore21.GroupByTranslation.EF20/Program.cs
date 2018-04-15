using EFCore21.GroupByTranslation.EF20.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCore21.GroupByTranslation.EF20
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BloggingContext())
            {
                var report = context.Posts
                    .GroupBy(p => p.Blog)
                    .Select(p => new ReportItem()
                    {
                        BlogName = p.Key.Name,
                        PostCount = p.Count(),
                        LatestPostDate = p.Max(i => i.PublishedDate),
                        MaxComments = p.Max(i => i.Comments.Count())
                    })
                    .ToList();

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
