using GildedRose.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace GildedRose.Repository
{
    public class GildedDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public GildedDbContext(DbContextOptions<GildedDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Optional: Define relationships and constraints using Fluent API
        }
    }
}
