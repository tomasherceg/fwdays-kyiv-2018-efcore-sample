using System;
using EFCore21.ValueConversions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;

namespace EFCore21.ValueConversions.Model
{
    public partial class BloggingContext : DbContext
    {
        public virtual DbSet<Blogs> Blogs { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Data Source=.\\SQLEXPRESS; Initial Catalog=EFCore21; Integrated Security=true")
                    .UseLoggerFactory(new LoggerFactory(new[]
                    {
                        new SqlQueryLoggerProvider()
                    }));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blogs>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.HasIndex(e => e.PostId);

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PostId);

                entity.Property(e => e.Type)
                    .HasConversion(new EnumToStringConverter<CommentType>());

                entity.Property(e => e.AuthorName)
                    .HasConversion(
                        v => v.Trim().ToUpper(),
                        v => v
                    );
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.HasIndex(e => e.BlogId);

                entity.Property(e => e.Content)
                    .IsRequired();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.BlogId);
            });
        }
    }
}
