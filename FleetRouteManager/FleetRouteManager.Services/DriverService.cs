using FleetRouteManager.Data.Models;
using FleetRouteManager.Data.Repositories.Interfaces;
using FleetRouteManager.Services.Interfaces;
using FleetRouteManager.Web.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using static FleetRouteManager.Common.Constants.DriverConstants;

namespace FleetRouteManager.Services
{
    public class DriverService : IDriverService
    {
        private readonly IRepository<Driver, int> repository;

        public DriverService(IRepository<Driver, int> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<DriverViewModel>> GetAllDriversAsync()
        {
            return await repository.GetAllAsIQueryable()
                .Where(d => d.IsDeleted == false)
                .AsNoTracking()
                .Select(d => new DriverViewModel()
                {
                    Id = d.Id,
                    FullName = $"{d.FirstName} {d.MiddleName} {d.LastName}",
                    PhoneNumber = d.PhoneNumber,
                    DrivingLicense = d.DrivingLicense,
                    EmployedAt = d.EmployedOn.ToString(DriverDateFormat)
                }
                ).OrderBy(d => d.Id)
                .ToListAsync();
        }

        public async Task<DriverDetailsViewModel?> GetDriverDetailsAsync(int id)
        {
            var driver = await repository.GetWhereAsIQueryable(d => !d.IsDeleted && d.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (driver == null)
            {
                return null;
            }

            var model = new DriverDetailsViewModel()
            {
                Id = driver.Id,
                FirstName = driver.FirstName,
                MiddleName = driver.MiddleName,
                LastName = driver.LastName,
                PhoneNumber = driver.PhoneNumber,
                AdditionalPhoneNumber = driver.AdditionalPhoneNumber,
                DrivingLicense = driver.DrivingLicense,
                DrivingLicenseExpirationDate = driver.DrivingLicenseExpirationDate.ToString(DriverDateFormat),
                IdentityCard = driver.IdentityCard,
                IdentityCardExpirationDate = driver.IdentityCardExpirationDate.ToString(DriverDateFormat),
                PersonalIdentificationNumber = driver.PersonalIdentificationNumber,
                ProfessionalQualificationCard = driver.ProfessionalQualificationCard,
                ProfessionalQualificationCardExpirationDate =
                    driver.ProfessionalQualificationCardExpirationDate.ToString(DriverDateFormat),
                DateOfBirth = driver.DateOfBirth.ToString(DriverDateFormat),
                EmployedOn = driver.EmployedOn.ToString(DriverDateFormat),
                MedicalInsurance = driver.MedicalInsurance,
                MedicalInsuranceExpirationDate = driver.MedicalInsuranceExpirationDate?.ToString(DriverDateFormat) ?? string.Empty
            };

            return model;
        }

        public async Task<DriverDeleteModel?> GetDriverDeleteModelAsync(int id)
        {
            return await repository.GetWhereAsIQueryable(d => d.Id == id && d.IsDeleted == false)
                .AsNoTracking()
                .Select(d => new DriverDeleteModel
                {
                    Id = d.Id,
                    Names = $"{d.FirstName} {d.MiddleName} {d.LastName}"
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteDriverAsync(int id)
        {
            var driver = await repository.GetByIdAsync(id);

            if (driver == null || driver.IsDeleted)
            {
                return false;
            }

            driver.IsDeleted = true;
            driver.DeletedOn = DateTime.Now;

            return await repository.UpdateAsync(driver);
        }
    }
}
