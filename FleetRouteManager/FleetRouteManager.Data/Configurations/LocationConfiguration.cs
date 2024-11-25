
using FleetRouteManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetRouteManager.Data.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder
                .HasOne(l => l.Address)
                .WithMany(a => a.Locations)
                .HasForeignKey(l => l.AddressId)
                .OnDelete(deleteBehavior: DeleteBehavior.Restrict);

            builder.HasData(
                new Location
                {
                    Id = 1,
                    Name = "Messe Munich",
                    AddressId = 4
                },
                new Location
                {
                    Id = 2,
                    Name = "DB Schenker Bulgaria",
                    AddressId = 2
                },
                new Location
                {
                    Id = 3,
                    Name = "LKW Walter Kufstein",
                    AddressId = 3
                },
                new Location
                {
                    Id = 4,
                    Name = "DHL Bulgaria",
                    AddressId = 1
                });
        }
    }
}
