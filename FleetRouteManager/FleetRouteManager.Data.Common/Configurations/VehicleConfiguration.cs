using FleetRouteManager.Data.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetRouteManager.Data.Common.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder
                .HasOne(e => e.Manufacturer)
                .WithMany(m => m.Vehicles)
                .OnDelete(deleteBehavior: DeleteBehavior.NoAction);

            builder
                .HasIndex(v => v.RegistrationNumber)
                .IsUnique();

            builder
                .Property(v => v.EuroClass)
                .HasConversion<string>();

            builder
                .Property(v => v.VehicleType)
                .HasConversion<string>();

            builder
                .ToTable(t => t.HasCheckConstraint("CK_Vehicles_Axles", "Axles >= 2 AND Axles <= 6"));
        }
    }
}
