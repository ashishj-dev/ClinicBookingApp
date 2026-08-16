using System;
using Microsoft.EntityFrameworkCore;

namespace ClinicBookingAPI;

public class AppointmentsDbContext : DbContext
{
    public AppointmentsDbContext(DbContextOptions<AppointmentsDbContext> options) : base(options)
    {
        
    }

    public DbSet<AppointmentEntity> Appointments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AppointmentEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Reference).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Condition).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Sex).HasConversion<string>();
            entity.Property(e => e.Condition).HasMaxLength(300);
            entity.Property(e => e.Treatment).HasMaxLength(300);
            entity.Property(e => e.Date).HasColumnType("date").IsRequired();
            entity.Property(e => e.StartTime).HasColumnType("time").IsRequired();
            entity.Property(e => e.EndTime).HasColumnType("time").IsRequired();
            entity.Property(e => e.DurationInMinutes).IsRequired();
            entity.Property(e => e.Amount).IsRequired();
            entity.Property(e => e.Status).HasConversion<string>();
            entity.Property(e => e.PaymentStatus).HasConversion<string>();
        });
    }
}
