using FleetRouteManager.Common.Enums;
using FleetRouteManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetRouteManager.Data.Common.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder
                .HasOne(v => v.Manufacturer)
                .WithMany(m => m.Vehicles)
                .HasForeignKey(v => v.ManufacturerId)
                .OnDelete(deleteBehavior: DeleteBehavior.Restrict);

            builder
                .HasOne(v => v.VehicleType)
                .WithMany(t => t.Vehicles)
                .HasForeignKey(v => v.VehicleTypeId)
                .OnDelete(deleteBehavior: DeleteBehavior.Restrict);

            builder
                .HasIndex(v => v.RegistrationNumber)
                .IsUnique();

            builder
                .Property(v => v.EuroClass)
                .HasConversion<string>();


            builder
                .Property(v => v.BodyType)
                .HasConversion<string>();

            builder
                .HasData
                (
                    new Vehicle
                    {
                        Id = 1,
                        RegistrationNumber = "CB 1111 CB",
                        ManufacturerId = 1,
                        Model = "Atego",
                        Vin = "MER11111111111111",
                        FirstRegistration = new DateTime(2011, 01, 01),
                        EuroClass = EuroClass.Euro6,
                        VehicleTypeId = 1,
                        BodyType = BodyType.Curtain,
                        Axles = 2,
                        WeightCapacity = 1.64,
                        AcquiredOn = new DateTime(2024, 01, 01),
                        LiabilityInsurance = "010/LEV/1111111111-11",
                        LiabilityInsuranceExpirationDate = new DateTime(2025, 01, 01)
                    },
                    new Vehicle
                    {
                        Id = 2,
                        RegistrationNumber = "CB 2222 CB",
                        ManufacturerId = 6,
                        Model = "TGL",
                        Vin = "MAN22222222222222",
                        FirstRegistration = new DateTime(2012, 02, 02),
                        EuroClass = EuroClass.Euro5,
                        VehicleTypeId = 2,
                        BodyType = BodyType.Box,
                        Axles = 2,
                        WeightCapacity = 4.7,
                        AcquiredOn = new DateTime(2024, 02, 02),
                        LiabilityInsurance = "020/LEV/2222222222-22",
                        LiabilityInsuranceExpirationDate = new DateTime(2025, 02, 02),
                        TechnicalReviewExpirationDate = new DateTime(2025, 02, 02)
                    },
                    new Vehicle
                    {
                        Id = 3,
                        RegistrationNumber = "CB 3333 CB",
                        ManufacturerId = 6,
                        Model = "TGL",
                        Vin = "MAN33333333333333",
                        FirstRegistration = new DateTime(2013, 03, 03),
                        EuroClass = EuroClass.Euro5,
                        VehicleTypeId = 3,
                        BodyType = BodyType.Frigo,
                        Axles = 3,
                        WeightCapacity = 9,
                        AcquiredOn = new DateTime(2024, 03, 03),
                        LiabilityInsurance = "030/LEV/3333333333-33",
                        LiabilityInsuranceExpirationDate = new DateTime(2025, 03, 03),
                        TachographExpirationDate = new DateTime(2025, 03, 03)
                    },
                    new Vehicle
                    {
                        Id = 4,
                        RegistrationNumber = "CB 4444 CB",
                        ManufacturerId = 7,
                        Model = "R420",
                        Vin = "SCA44444444444444",
                        FirstRegistration = new DateTime(2014, 04, 04),
                        EuroClass = EuroClass.Euro4,
                        VehicleTypeId = 5,
                        BodyType = BodyType.None,
                        Axles = 2,
                        WeightCapacity = 0,
                        AcquiredOn = new DateTime(2024, 04, 04),
                        LiabilityInsurance = "040/LEV/4444444444-44",
                        LiabilityInsuranceExpirationDate = new DateTime(2025, 04, 04),
                        TechnicalReviewExpirationDate = new DateTime(2025, 04, 04),
                        TachographExpirationDate = new DateTime(2025, 04, 04),
                    }
                );
        }
    }
}
