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
                    Street = "Am Messesee",
                    Number = "2",
                    PostCode = "81829",
                    City = "Munich",
                    CountryId = 216,
                },
                new Location
                {
                    Id = 2,
                    Name = "DB Schenker Bulgaria",
                    Street = "Maria Atanasova",
                    Number = "5",
                    PostCode = "1540",
                    City = "Sofia",
                    CountryId = 207,
                },
                new Location
                {
                    Id = 3,
                    Name = "LKW Walter Kufstein",
                    Street = "Zeller Str.",
                    Number = "1",
                    PostCode = "6330",
                    City = "Kufstein",
                    CountryId = 203,
                },
                new Location
                {
                    Id = 4,
                    Name = "DHL Bulgaria",
                    Street = "Europa",
                    Number = "1A",
                    PostCode = "2227",
                    City = "Sofia",
                    CountryId = 207,
                },
                new Location
                {
                    Id = 5,
                    Name = "LKW Walter Wiener Neudorf",
                    Street = "IZ No-Sud Strasse 14",
                    Number = "1",
                    PostCode = "2355",
                    City = "Wiener Neudorf",
                    CountryId = 203,
                });
        }
    }
}
