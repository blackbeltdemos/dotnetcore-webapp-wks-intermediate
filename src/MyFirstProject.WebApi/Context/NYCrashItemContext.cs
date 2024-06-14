using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using MyFirstProject.Shared.Models;

namespace MyFirstProject.WebApi.Context
{
    public class NYCrashItemContext : DbContext
    {

        public NYCrashItemContext(DbContextOptions<NYCrashItemContext> options)
           : base(options)
        {
        }

        public DbSet<NYCrashItem> NYCrashItems { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NYCrashItem>(entity =>
            {
                entity.HasKey(e => new { e.CRASH_DATE, e.CRASH_TIME, e.COLLISION_ID });
                // Additional configurations can go here
            });

            base.OnModelCreating(modelBuilder);
        }
    }

}


