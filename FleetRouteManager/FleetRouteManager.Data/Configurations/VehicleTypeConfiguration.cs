using FleetRouteManager.Data.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetRouteManager.Data.Configurations
{
    public class VehicleTypeConfiguration : IEntityTypeConfiguration<VehicleType>
    {
        public void Configure(EntityTypeBuilder<VehicleType> builder)
        {
            builder
                .HasData
                (
                    new VehicleType
                    {
                        Id = 1,
                        Type = "Solo 7.5t",
                    },
                    new VehicleType
                    {
                        Id = 2,
                        Type = "Solo 12.0t",
                    },
                    new VehicleType
                    {
                        Id = 3,
                        Type = "Solo 18.0t",
                    },
                    new VehicleType
                    {
                        Id = 4,
                        Type = "Truck 26.0t",
                    },
                    new VehicleType
                    {
                        Id = 5,
                        Type = "Tractor",
                    },
                    new VehicleType
                    {
                        Id = 6,
                        Type = "Van 3.5t",
                    },
                    new VehicleType
                    {
                        Id = 7,
                        Type = "Semitrailer",
                    },
                    new VehicleType
                    {
                        Id = 8,
                        Type = "Trailer",
                    }
                );
        }
    }
}
