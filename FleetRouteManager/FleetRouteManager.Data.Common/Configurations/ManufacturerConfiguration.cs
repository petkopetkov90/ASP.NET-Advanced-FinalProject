using FleetRouteManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetRouteManager.Data.Common.Configurations
{
    public class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder
                .HasIndex(v => v.Name)
                .IsUnique();

            builder
                .HasData
                (
                    new Manufacturer { Id = 1, Name = "Mercedes" },
                    new Manufacturer { Id = 2, Name = "Ford" },
                    new Manufacturer { Id = 3, Name = "Renault" },
                    new Manufacturer { Id = 4, Name = "Volkswagen" },
                    new Manufacturer { Id = 5, Name = "Iveco" },
                    new Manufacturer { Id = 6, Name = "Man" },
                    new Manufacturer { Id = 7, Name = "Scania" },
                    new Manufacturer { Id = 8, Name = "Volvo" },
                    new Manufacturer { Id = 9, Name = "Schmitz" },
                    new Manufacturer { Id = 10, Name = "Krone" },
                    new Manufacturer { Id = 11, Name = "Fruehauf" },
                    new Manufacturer { Id = 12, Name = "Peugeot" }
                );
        }
    }
}
