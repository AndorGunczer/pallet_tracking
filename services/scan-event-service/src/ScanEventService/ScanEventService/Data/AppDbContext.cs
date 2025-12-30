using Microsoft.EntityFrameworkCore;
using ScanEventService.Models;

namespace ScanEventService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) { }

        public DbSet<ScanEvent> ScanEvents { get; set; }
        public DbSet<Pallet> Pallets { get; set; }
        public DbSet<PalletLocation> PalletLocations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // jsonb Mapping für PostgreSQL
            modelBuilder.Entity<ScanEvent>()
                .Property(e => e.Payload)
                .HasColumnType("jsonb")
                .IsRequired(false);

            // optional: weitere Fluent-API Konfigurationen
            base.OnModelCreating(modelBuilder);
        }
    }
}