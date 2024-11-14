using ElectroHub.Domain.ChargePoint;
using Microsoft.EntityFrameworkCore;

namespace ElectroHub.Infrastructure.Context;

public class ElectroHubDbContext(string connectionString) : DbContext
{
    public virtual DbSet<ChargePoint> ChargePoints { get; set; }
    public virtual DbSet<ChargePointReservation> ChargePointReservations { get; set; }
    public virtual DbSet<ChargingHub> ChargingHubs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString).UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChargePoint>(x =>
        {
            x.HasKey(p => p.Id);
            x.Property(p => p.SpotNumber).HasMaxLength(5);
            x.HasOne(s => s.ChargingHub).WithMany(s => s.ChargePoints).HasForeignKey("ChargingHubId")
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ChargePointReservation>(x =>
        {
            x.HasKey(p => p.Id);
            x.HasOne(s => s.ChargePoint).WithMany(s => s.ChargePointReservations).OnDelete(DeleteBehavior.Cascade);
            x.OwnsOne(p => p.User, p => { p.Property(vo => vo.UserId).HasColumnName("UserId"); });
        });

        modelBuilder.Entity<ChargingHub>(x =>
        {
            x.HasKey(p => p.Id);
            x.Property(e => e.Address).HasMaxLength(100);
        });
    }
}