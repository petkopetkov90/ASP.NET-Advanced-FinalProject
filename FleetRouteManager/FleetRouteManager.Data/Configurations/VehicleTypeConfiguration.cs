using FleetRouteManager.Common.Enums;
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
                .Property(vt => vt.TruckType)
                .HasConversion<string>();

            builder
                .Property(vt => vt.BodyType)
                .HasConversion<string>();

            builder
                .HasData
                (
                    new VehicleType
                    {
                        Id = 1,
                        TypeName = "Solo 7.5t",
                        TruckType = CargoType.Truck,
                        BodyType = BodyType.Curtain,
                        Axles = 2,
                        WeightCapacity = 1.63,
                    },
                    new VehicleType
                    {
                        Id = 2,
                        TypeName = "Solo 12.0t",
                        TruckType = CargoType.Truck,
                        BodyType = BodyType.Curtain,
                        Axles = 2,
                        WeightCapacity = 4.3,
                    },
                    new VehicleType
                    {
                        Id = 3,
                        TypeName = "Solo 18.0t",
                        TruckType = CargoType.Truck,
                        BodyType = BodyType.Curtain,
                        Axles = 3,
                        WeightCapacity = 9.80,
                    },
                    new VehicleType
                    {
                        Id = 4,
                        TypeName = "Solo 26.0t",
                        TruckType = CargoType.Truck,
                        BodyType = BodyType.Curtain,
                        Axles = 3,
                        WeightCapacity = 14,
                    },
                    new VehicleType
                    {
                        Id = 5,
                        TypeName = "Tractor",
                        TruckType = CargoType.Tractor,
                        BodyType = BodyType.None,
                        Axles = 2,
                        WeightCapacity = 0,
                    },
                    new VehicleType
                    {
                        Id = 6,
                        TypeName = "Van 3.5t",
                        TruckType = CargoType.Van,
                        BodyType = BodyType.Box,
                        Axles = 2,
                        WeightCapacity = 1.33,
                    },
                    new VehicleType
                    {
                        Id = 7,
                        TypeName = "Semitrailer",
                        TruckType = CargoType.Semitrailer,
                        BodyType = BodyType.Open,
                        Axles = 3,
                        WeightCapacity = 24.99,
                    },
                    new VehicleType
                    {
                        Id = 8,
                        TypeName = "Trailer",
                        TruckType = CargoType.Trailer,
                        BodyType = BodyType.Open,
                        Axles = 2,
                        WeightCapacity = 8.10,
                    }
                );
        }
    }
}
