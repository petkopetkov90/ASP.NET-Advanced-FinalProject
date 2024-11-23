using FleetRouteManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetRouteManager.Data.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasData(
                new Address()
                {
                    Id = 1,
                    Street = "Maria Atanasova",
                    Number = "5",
                    PostCode = 1540,
                    City = "Sofia",
                    CountryId = 207,
                },
                new Address()
                {
                    Id = 2,
                    Street = "Europa",
                    Number = "1A",
                    PostCode = 1540,
                    City = "Sofia",
                    CountryId = 207,
                }
            );
        }
    }
}
