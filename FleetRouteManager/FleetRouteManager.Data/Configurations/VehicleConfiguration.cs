using FleetRouteManager.Common.Enums;
using FleetRouteManager.Data.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetRouteManager.Data.Configurations
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
                .HasOne(e => e.VehicleType)
                .WithMany(vt => vt.Vehicles)
                .OnDelete(deleteBehavior: DeleteBehavior.NoAction);

            builder
                .HasIndex(v => v.RegistrationNumber)
                .IsUnique();

            builder
                .Property(v => v.EuroClass)
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
                        Vin = "MER1111111111",
                        FirstRegistration = DateTime.Today.AddDays(-200).Date,
                        EuroClass = EuroClass.Euro6,
                        VehicleTypeId = 1,
                        AddedOn = DateTime.Today,
                        LiabilityInsurance = "010/LEV/1111111111-11",
                        LiabilityInsuranceExpirationDate = DateTime.Today.AddDays(360).Date
                    },
                    new Vehicle
                    {
                        Id = 2,
                        RegistrationNumber = "CB 2222 CB",
                        ManufacturerId = 6,
                        Model = "TGL",
                        Vin = "MAN2222222222",
                        FirstRegistration = DateTime.Today.AddDays(-400).Date,
                        EuroClass = EuroClass.Euro5,
                        VehicleTypeId = 2,
                        AddedOn = DateTime.Today.AddDays(-1).Date,
                        LiabilityInsurance = "020/LEV/2222222222-22",
                        LiabilityInsuranceExpirationDate = DateTime.Today.AddDays(260).Date,
                        TechnicalReviewExpirationDate = DateTime.Today.AddDays(120).Date
                    },
                    new Vehicle
                    {
                        Id = 3,
                        RegistrationNumber = "CB 3333 CB",
                        ManufacturerId = 6,
                        Model = "TGL",
                        Vin = "MAN3333333333",
                        FirstRegistration = DateTime.Today.AddDays(-420).Date,
                        EuroClass = EuroClass.Euro5,
                        VehicleTypeId = 3,
                        AddedOn = DateTime.Today.AddDays(-14).Date,
                        LiabilityInsurance = "030/LEV/3333333333-33",
                        LiabilityInsuranceExpirationDate = DateTime.Today.AddDays(-30).Date,
                        TachographExpirationDate = DateTime.Today.AddDays(76).Date
                    },
                    new Vehicle
                    {
                        Id = 4,
                        RegistrationNumber = "CB 4444 CB",
                        ManufacturerId = 7,
                        Model = "R420",
                        Vin = "SCA4444444444",
                        FirstRegistration = DateTime.Today.AddDays(-720).Date,
                        EuroClass = EuroClass.Euro4,
                        VehicleTypeId = 5,
                        AddedOn = DateTime.Today.AddDays(-114).Date,
                        LiabilityInsurance = "040/LEV/4444444444-44",
                        LiabilityInsuranceExpirationDate = DateTime.Today.AddDays(55).Date,
                        TechnicalReviewExpirationDate = DateTime.Today.AddDays(60).Date,
                        TachographExpirationDate = DateTime.Today.AddDays(73).Date,
                    }
                );
        }
    }
}
