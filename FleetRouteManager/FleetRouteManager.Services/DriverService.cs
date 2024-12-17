using FleetRouteManager.Common.Exceptions;
using FleetRouteManager.Data.Models;
using FleetRouteManager.Data.Repositories.Interfaces;
using FleetRouteManager.Services.Interfaces;
using FleetRouteManager.Web.Models.InputModels.DriverInputModels;
using FleetRouteManager.Web.Models.ViewModels.DriverViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static FleetRouteManager.Common.Constants.DriverConstants;
using static FleetRouteManager.Common.ErrorMessages.ExceptionMessages;
using static FleetRouteManager.Common.Parsers.CustomDateParsers;



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
            var drivers = await repository.GetAllAsIQueryable()
                .Where(d => d.IsDeleted == false)
                .Include(d => d.Vehicle)
                .OrderBy(d => d.FirstName)
                .ThenBy(d => d.LastName)
                .AsNoTracking()
                .Select(d => new DriverViewModel()
                {
                    Id = d.Id,
                    FullName = FormatDriverToString(d),
                    PhoneNumber = d.PhoneNumber,
                    DrivingLicense = d.DrivingLicense,
                    EmployedAt = d.EmployedOn.ToString(DriverDateFormat),
                    VehicleId = d.VehicleId,
                    Vehicle = FormatVehicleToString(d.Vehicle)
                })
                .ToListAsync();

            return drivers;
        }

        public async Task<DriverDetailsViewModel?> GetDriverDetailsAsync(int id)
        {
            var driver = await repository.GetWhereAsIQueryable(d => !d.IsDeleted && d.Id == id)
                .Include(d => d.Vehicle)
                .AsNoTracking()
                .Select(d => new DriverDetailsViewModel()
                {
                    Id = d.Id,
                    FirstName = d.FirstName,
                    MiddleName = d.MiddleName,
                    LastName = d.LastName,
                    PhoneNumber = d.PhoneNumber,
                    Vehicle = FormatVehicleToString(d.Vehicle),
                    AdditionalPhoneNumber = d.AdditionalPhoneNumber,
                    DrivingLicense = d.DrivingLicense,
                    DrivingLicenseExpirationDate = d.DrivingLicenseExpirationDate.ToString(DriverDateFormat),
                    IdentityCard = d.IdentityCard,
                    IdentityCardExpirationDate = d.IdentityCardExpirationDate.ToString(DriverDateFormat),
                    PersonalIdentificationNumber = d.PersonalIdentificationNumber,
                    ProfessionalQualificationCard = d.ProfessionalQualificationCard,
                    ProfessionalQualificationCardExpirationDate =
                        d.ProfessionalQualificationCardExpirationDate.ToString(DriverDateFormat),
                    DateOfBirth = d.DateOfBirth.ToString(DriverDateFormat),
                    EmployedOn = d.EmployedOn.ToString(DriverDateFormat),
                    MedicalInsurance = d.MedicalInsurance,
                    MedicalInsuranceExpirationDate = CustomNullableDateToStringParseExact(d.MedicalInsuranceExpirationDate, DriverDateFormat)
                })
                .FirstOrDefaultAsync();

            return driver;
        }

        public async Task<DriverDeleteViewModel?> GetDriverDeleteModelAsync(int id)
        {
            return await repository.GetWhereAsIQueryable(d => d.Id == id && !d.IsDeleted)
                .AsNoTracking()
                .Select(d => new DriverDeleteViewModel
                {
                    Id = d.Id,
                    Name = FormatDriverToString(d)
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

        public async Task<int> AssignNewDriverAsync(DriverCreateInputModel model)
        {

            var driver = new Driver()
            {
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                VehicleId = model.VehicleId,
                AdditionalPhoneNumber = model.AdditionalPhoneNumber,
                DrivingLicense = model.DrivingLicense,
                DrivingLicenseExpirationDate = CustomStringToDateParseExact(model.DrivingLicenseExpirationDate, DriverDateFormat, nameof(model.DrivingLicenseExpirationDate)),
                IdentityCard = model.IdentityCard,
                IdentityCardExpirationDate = CustomStringToDateParseExact(model.IdentityCardExpirationDate, DriverDateFormat, nameof(model.IdentityCardExpirationDate)),
                PersonalIdentificationNumber = model.PersonalIdentificationNumber,
                ProfessionalQualificationCard = model.ProfessionalQualificationCard,
                ProfessionalQualificationCardExpirationDate = CustomStringToDateParseExact(model.ProfessionalQualificationCardExpirationDate, DriverDateFormat, nameof(model.ProfessionalQualificationCardExpirationDate)),
                DateOfBirth = CustomStringToDateParseExact(model.DateOfBirth, DriverDateFormat, nameof(model.DateOfBirth)),
                EmployedOn = CustomStringToDateParseExact(model.EmployedOn, DriverDateFormat, nameof(model.EmployedOn)),
                MedicalInsurance = model.MedicalInsurance,
                MedicalInsuranceExpirationDate = CustomNullableStringToDateParseExact(model.MedicalInsuranceExpirationDate, DriverDateFormat, nameof(model.MedicalInsuranceExpirationDate))
            };

            try
            {
                if (await repository.AddAsync(driver))
                {
                    return driver.Id;
                }

                return 0;
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException is SqlException inner)
                {
                    if (inner.Number is 2601 or 2627)
                    {
                        throw new CustomExistingEntityException(string.Format(ExistingEntityExceptionMsg, driver.GetType().Name));
                    }
                }

                throw;
            }
        }

        public async Task<DriverEditInputModel> GetDriverEditModelAsync(int id)
        {
            var driver = await repository.GetByIdAsync(id);

            if (driver == null || driver.IsDeleted)
            {
                return null!;
            }

            var model = new DriverEditInputModel
            {
                Id = driver.Id,
                FirstName = driver.FirstName,
                MiddleName = driver.MiddleName,
                LastName = driver.LastName,
                PhoneNumber = driver.PhoneNumber,
                VehicleId = driver.VehicleId,
                AdditionalPhoneNumber = driver.AdditionalPhoneNumber,
                DrivingLicense = driver.DrivingLicense,
                DrivingLicenseExpirationDate = driver.DrivingLicenseExpirationDate.ToString(DriverDateFormat),
                IdentityCard = driver.IdentityCard,
                IdentityCardExpirationDate = driver.IdentityCardExpirationDate.ToString(DriverDateFormat),
                PersonalIdentificationNumber = driver.PersonalIdentificationNumber,
                ProfessionalQualificationCard = driver.ProfessionalQualificationCard,
                ProfessionalQualificationCardExpirationDate = driver.ProfessionalQualificationCardExpirationDate.ToString(DriverDateFormat),
                DateOfBirth = driver.DateOfBirth.ToString(DriverDateFormat),
                EmployedOn = driver.EmployedOn.ToString(DriverDateFormat),
                MedicalInsurance = driver.MedicalInsurance,
                MedicalInsuranceExpirationDate = CustomNullableDateToStringParseExact(driver.MedicalInsuranceExpirationDate, DriverDateFormat)
            };

            return model;
        }

        public async Task<bool> EditDriverAsync(DriverEditInputModel model)
        {
            var driver = await repository.GetByIdAsync(model.Id);

            if (driver == null || driver.IsDeleted)
            {
                return false;
            }

            driver.FirstName = model.FirstName;
            driver.MiddleName = model.MiddleName;
            driver.LastName = model.LastName;
            driver.PhoneNumber = model.PhoneNumber;
            driver.VehicleId = model.VehicleId;
            driver.AdditionalPhoneNumber = model.AdditionalPhoneNumber;
            driver.DrivingLicense = model.DrivingLicense;
            driver.DrivingLicenseExpirationDate = CustomStringToDateParseExact(model.DrivingLicenseExpirationDate, DriverDateFormat, nameof(model.DrivingLicenseExpirationDate));
            driver.IdentityCard = model.IdentityCard;
            driver.IdentityCardExpirationDate = CustomStringToDateParseExact(model.IdentityCardExpirationDate, DriverDateFormat,
                nameof(model.IdentityCardExpirationDate));
            driver.PersonalIdentificationNumber = model.PersonalIdentificationNumber;
            driver.ProfessionalQualificationCard = model.ProfessionalQualificationCard;
            driver.ProfessionalQualificationCardExpirationDate = CustomStringToDateParseExact(
                model.ProfessionalQualificationCardExpirationDate, DriverDateFormat,
                nameof(model.ProfessionalQualificationCardExpirationDate));
            driver.DateOfBirth = CustomStringToDateParseExact(model.DateOfBirth, DriverDateFormat, nameof(model.DateOfBirth));
            driver.EmployedOn = CustomStringToDateParseExact(model.EmployedOn, DriverDateFormat, nameof(model.EmployedOn));
            driver.MedicalInsurance = model.MedicalInsurance;
            driver.MedicalInsuranceExpirationDate = CustomNullableStringToDateParseExact(model.MedicalInsuranceExpirationDate,
                DriverDateFormat, nameof(model.MedicalInsuranceExpirationDate));


            try
            {
                return await repository.UpdateAsync(driver);
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException is SqlException inner)
                {
                    if (inner.Number is 2601 or 2627)
                    {
                        throw new CustomExistingEntityException(string.Format(EditExistingEntityExceptionMsg, driver.GetType().Name));
                    }
                }

                throw;
            }
        }


        private static string FormatVehicleToString(Vehicle? vehicle)
        {
            if (vehicle == null)
            {
                return string.Empty;
            }

            return vehicle.RegistrationNumber;
        }

        private static string FormatDriverToString(Driver? driver)
        {
            if (driver == null)
            {
                return string.Empty;
            }

            return $"{driver.FirstName} {driver.MiddleName} {driver.LastName}".Trim();
        }
    }
}
