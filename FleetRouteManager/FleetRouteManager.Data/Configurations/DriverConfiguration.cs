using FleetRouteManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetRouteManager.Data.Configurations
{
    public class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder
                .HasIndex(d => d.PersonalIdentificationNumber)
                .IsUnique();

            builder
                .HasData
                (
                    new Driver
                    {
                        Id = 1,
                        FirstName = "Ivan",
                        MiddleName = "Ivanov",
                        LastName = "Ivanov",
                        PhoneNumber = "+359 888 111111",
                        DrivingLicense = "D111111111",
                        DrivingLicenseExpirationDate = new DateTime(2025, 01, 11),
                        IdentityCard = "111111111",
                        IdentityCardExpirationDate = new DateTime(2025, 01, 11),
                        PersonalIdentificationNumber = "0101010101",
                        ProfessionalQualificationCard = "PQ111111",
                        ProfessionalQualificationCardExpirationDate = new DateTime(2025, 01, 11),
                        DateOfBirth = new DateTime(2001, 01, 01),
                        EmployedAt = new DateTime(2021, 01, 01)
                    },
                    new Driver
                    {
                        Id = 2,
                        FirstName = "Georgi",
                        MiddleName = "Georgiev",
                        LastName = "Georgiev",
                        PhoneNumber = "+359 888 222222",
                        DrivingLicense = "D222222222",
                        DrivingLicenseExpirationDate = new DateTime(2025, 02, 12),
                        IdentityCard = "222222222",
                        IdentityCardExpirationDate = new DateTime(2025, 02, 12),
                        PersonalIdentificationNumber = "0202020202",
                        ProfessionalQualificationCard = "PQ222222",
                        ProfessionalQualificationCardExpirationDate = new DateTime(2025, 02, 12),
                        DateOfBirth = new DateTime(2002, 02, 02),
                        EmployedAt = new DateTime(2022, 02, 02)
                    },
                    new Driver
                    {
                        Id = 3,
                        FirstName = "Petar",
                        MiddleName = "Petrov",
                        LastName = "Petrov",
                        PhoneNumber = "+359 888 333333",
                        DrivingLicense = "D333333333",
                        DrivingLicenseExpirationDate = new DateTime(2025, 03, 13),
                        IdentityCard = "333333333",
                        IdentityCardExpirationDate = new DateTime(2025, 03, 13),
                        PersonalIdentificationNumber = "0303030303",
                        ProfessionalQualificationCard = "PQ111111",
                        ProfessionalQualificationCardExpirationDate = new DateTime(2025, 03, 13),
                        DateOfBirth = new DateTime(2003, 03, 03),
                        EmployedAt = new DateTime(2023, 03, 03)
                    }
                );
        }
    }
}
