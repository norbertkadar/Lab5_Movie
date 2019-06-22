﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3Movie.Models
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(entity => {
                entity.HasIndex(u => u.Username).IsUnique();
            });

            builder.Entity<Comment>()
               .HasOne(m => m.Movie)
               .WithMany(c => c.Comments)
               .OnDelete(DeleteBehavior.Cascade);

            //cascade pt delete
            builder.Entity<Movie>()
           .HasOne(e => e.Owner)
           .WithMany(c => c.Movies)
           .OnDelete(DeleteBehavior.Cascade);
        }



        public DbSet<Movie> Movies { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
