using FleetRouteManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetRouteManager.Data.Common.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasData(
                new Address
                {
                    Id = 1,
                    Street = "Am Messesee",
                    Number = "2",
                    PostCode = "81829",
                    City = "Munich",
                    CountryId = 216,
                },
                new Address
                {
                    Id = 2,
                    Street = "Maria Atanasova",
                    Number = "5",
                    PostCode = "1540",
                    City = "Sofia",
                    CountryId = 207,
                },
                new Address
                {
                    Id = 3,
                    Street = "Zeller Str.",
                    Number = "1",
                    PostCode = "6330",
                    City = "Kufstein",
                    CountryId = 203,
                },
                new Address
                {
                    Id = 4,
                    Street = "Europa",
                    Number = "1A",
                    PostCode = "2227",
                    City = "Sofia",
                    CountryId = 207,
                },
                new Address
                {
                    Id = 5,
                    Street = "IZ No-Sud Strasse 14",
                    Number = "1",
                    PostCode = "2355",
                    City = "Wiener Neudorf",
                    CountryId = 203,
                });
        }
    }
}
