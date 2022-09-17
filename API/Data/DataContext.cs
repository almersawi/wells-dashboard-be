using API.Entities;
using API.Views;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Well> Wells { get; set; }
        public DbSet<Schematic> Schematic { get; set; }
        public DbSet<Trajectory> Trajectory { get; set; }
        public DbSet<ProductionData> ProductionData { get; set; }

        // Views
        public DbSet<WellSummaryView> Well_Summary_view { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WellSummaryView>(c => 
            {
                c.HasNoKey();
                c.ToView("Well_Summary_view");
            });
        }
    }
}