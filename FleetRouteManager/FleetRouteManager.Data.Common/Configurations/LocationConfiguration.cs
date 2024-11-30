using FleetRouteManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetRouteManager.Data.Common.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {

            builder.HasData(
                new Location
                {
                    Id = 1,
                    Name = "Messe Munich",
                    AddressId = 1
                },
                new Location
                {
                    Id = 2,
                    Name = "DB Schenker Bulgaria",
                    AddressId = 4
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
                    AddressId = 2
                },
                new Location
                {
                    Id = 5,
                    Name = "LKW Walter Wiener Neudorf",
                    AddressId = 5
                });
        }
    }
}
