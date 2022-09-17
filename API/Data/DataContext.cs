using API.Entities;
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
    }
}