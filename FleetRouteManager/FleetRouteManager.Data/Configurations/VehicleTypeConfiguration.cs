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
        }
    }
}
