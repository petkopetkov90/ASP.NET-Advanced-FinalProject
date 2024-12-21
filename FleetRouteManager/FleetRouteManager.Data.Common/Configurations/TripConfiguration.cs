using FleetRouteManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetRouteManager.Data.Common.Configurations
{
    public class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {

            builder
                .HasOne(t => t.Driver)
                .WithMany(d => d.Trips)
                .HasForeignKey(t => t.DriverId)
                .OnDelete(deleteBehavior: DeleteBehavior.Restrict);

            builder
                .HasOne(t => t.StartingLocation)
                .WithMany(l => l.TripsStart)
                .HasForeignKey(t => t.StartLocationId)
                .OnDelete(deleteBehavior: DeleteBehavior.Restrict);

            builder
                .HasOne(t => t.EndingLocation)
                .WithMany(l => l.TripsEnd)
                .HasForeignKey(t => t.EndLocationId)
                .OnDelete(deleteBehavior: DeleteBehavior.Restrict);

            builder
                .HasOne(t => t.Vehicle)
                .WithMany(v => v.Trips)
                .HasForeignKey(t => t.VehicleId)
                .OnDelete(deleteBehavior: DeleteBehavior.Restrict);

            builder
                .HasIndex(t => new { t.TripNumber, t.VehicleId })
                .IsUnique();

            builder.HasData(
                new Trip()
                {
                    Id = 1,
                    TripNumber = "1/1/2024",
                    StartDate = new DateTime(2024, 12, 05),
                    EndDate = new DateTime(2024, 12, 06),
                    StartLocationId = 1,
                    EndLocationId = 2,
                    VehicleId = 1,
                    DriverId = 1,
                    User = "admin@myapp.com"
                },
                new Trip()
                {
                    Id = 2,
                    TripNumber = "1/2/2024",
                    StartDate = new DateTime(2024, 11, 03),
                    EndDate = new DateTime(2024, 11, 05),
                    StartLocationId = 2,
                    EndLocationId = 3,
                    VehicleId = 2,
                    DriverId = 2,
                    User = "admin@myapp.com"
                },
                new Trip()
                {
                    Id = 3,
                    TripNumber = "2/2/2024",
                    StartDate = new DateTime(2024, 05, 12),
                    EndDate = new DateTime(2024, 06, 11),
                    StartLocationId = 2,
                    EndLocationId = 3,
                    VehicleId = 3,
                    DriverId = 3,
                    User = "admin@myapp.com"
                },
                new Trip()
                {
                    Id = 4,
                    TripNumber = "13/3/2024",
                    StartDate = new DateTime(2024, 05, 03),
                    EndDate = new DateTime(2024, 05, 05),
                    StartLocationId = 4,
                    EndLocationId = 1,
                    VehicleId = 4,
                    DriverId = 3,
                    User = "petkopetkov900808@gmail.com"
                },
                new Trip()
                {
                    Id = 5,
                    TripNumber = "16/4/2024",
                    StartDate = new DateTime(2024, 08, 08),
                    EndDate = new DateTime(2024, 08, 09),
                    StartLocationId = 1,
                    EndLocationId = 4,
                    VehicleId = 1,
                    DriverId = 1,
                    User = "petkopetkov900808@gmail.com"
                });
        }
    }
}
