﻿using System;
using EFCore21.GroupByTranslation.EF20.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;

namespace EFCore21.GroupByTranslation.EF20.Model
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

                entity.Property(e => e.Type).HasMaxLength(100);

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PostId);
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.HasIndex(e => e.BlogId);

                entity.Property(e => e.Content).IsRequired();

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
