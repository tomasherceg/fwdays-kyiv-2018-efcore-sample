using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore21.DataSeeding.Model
{
    public class BloggingContext : DbContext
    {

        public virtual DbSet<Blog> Blogs { get; set; }

        public virtual DbSet<Post> Posts { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source=.\\SQLEXPRESS; Initial Catalog=EFCore21; Integrated Security=true");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .HasData(
                    new Blog() { Id = 1, Name = "Entity Framework Team Blog" },
                    new Blog() { Id = 2, Name = ".NET Team Blog" }
                );

            modelBuilder.Entity<Post>()
                .HasData(
                    new Post() { Id = 1, BlogId = 1, Title = "Announcing Entity Framework Core 2.1 Preview 2", Content = "Today, we are announcing .NET Core 2.1 Preview 2. The release is now ready for broad testing, as we get closer to a final build within the next two to three months. We’d appreciate any feedback that you have. ASP.NET Core 2.1 Preview 2 and Entity Framework 2.1 Preview 2 are also releasing today. You…", PublishedDate = new DateTime(2018, 4, 11) },
                    new Post() { Id = 2, BlogId = 2, Title = "Explore CosmosDB with .NET Core and MongoDB", Content = "Have you had to design general purpose “metadata” tables in your SQL database that basically store column names and values? Do you often serialize/de-serialize XML or JSON from your SQL tables to handle volatile schemas and data? .NET developers have traditionally worked with relational database management systems (RDMS) like SQL Server. RDMS systems have withstood…", PublishedDate = new DateTime(2018, 4, 9) },
                    new Post() { Id = 3, BlogId = 2, Title = "Calling all Desktop Developers: how should UI development be improved?", Content = "The user interface (UI) of any application is critical in making your app convenient and efficient for the folks using it. When developing applications for Enterprise use, a good UI can shave time off an entire company’s workflow. Visual Studio is investing in new tools to improve the productivity of Windows desktop developers and we’d love your…", PublishedDate = new DateTime(2018, 3, 23) },
                    new Post() { Id = 4, BlogId = 2, Title = ".NET Framework 4.7.2 Developer Pack Early Access build 3056 is available!", Content = "Today, we are happy to share an Early Access build with the .NET Framework 4.7.2 Developer Pack. The .NET Framework 4.7.2 Developer Pack lets developers build applications that target the .NET Framework 4.7.2 by using Visual Studio 2017, Visual Studio 2015 or other IDEs. This is a single package that bundles the .NET Framework 4.7.2, the…", PublishedDate = new DateTime(2018, 3, 8) }
                );

            modelBuilder.Entity<Comment>()
                .HasData(
                    new Comment() { Id = 1, PostId = 3, Text = "Awesome news!", AuthorName = "Thomas", IpAddress = "218.1.146.14", CreatedDate = new DateTime(2018, 4, 12), Type = "Question" },
                    new Comment() { Id = 2, PostId = 3, Text = "Thank you, we hope this helps.", AuthorName = "Bill [MSFT]", IpAddress = "199.34.52.20", CreatedDate = new DateTime(2018, 4, 14), Type = "General" },
                    new Comment() { Id = 3, PostId = 1, Text = "Cannot wait til I try it!", AuthorName = "Greg", IpAddress = "134.56.2.34", CreatedDate = new DateTime(2018, 4, 14), Type = "Suggestion" }
                );

            base.OnModelCreating(modelBuilder);
        }

    }
}
