using System;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options){ }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().HasKey(x => x.Id);

            builder.Entity<User>().Property(x => x.Username)
                                  .IsUnicode()
                                  .HasMaxLength(255);

            builder.Entity<User>().Property(x => x.Password)
                                  .IsUnicode()
                                  .HasMaxLength(500);

            builder.Entity<User>().Property(x => x.Email)
                                  .IsUnicode()
                                  .HasMaxLength(255);

            builder.Entity<User>().Property(x => x.IsActive)
                                  .HasAnnotation("Default", true);
        }
    }
}