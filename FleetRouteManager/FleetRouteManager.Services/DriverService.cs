﻿using FleetRouteManager.Data.Models;
using FleetRouteManager.Data.Repositories.Interfaces;
using FleetRouteManager.Services.Interfaces;
using FleetRouteManager.Web.Models.InputModels.DriverInputModels;
using FleetRouteManager.Web.Models.ViewModels.DriverViewModels;
using Microsoft.EntityFrameworkCore;
using static FleetRouteManager.Common.Constants.DriverConstants;
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
                .AsNoTracking()
                .Select(d => new DriverViewModel()
                {
                    Id = d.Id,
                    FullName = $"{d.FirstName} {d.MiddleName} {d.LastName}",
                    PhoneNumber = d.PhoneNumber,
                    DrivingLicense = d.DrivingLicense,
                    EmployedAt = d.EmployedOn.ToString(DriverDateFormat),
                    Vehicle = d.Vehicle!.RegistrationNumber
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
                    Vehicle = d.Vehicle!.RegistrationNumber,
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
            return await repository.GetWhereAsIQueryable(d => d.Id == id && d.IsDeleted == false)
                .AsNoTracking()
                .Select(d => new DriverDeleteViewModel
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

        public async Task<int> AssignNewDriverAsync(DriverCreateInputModel model)
        {
            if (await CheckForPersonalIdentification(model.PersonalIdentificationNumber))
            {
                return 0;
            }

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


            if (await repository.AddAsync(driver))
            {
                return driver.Id;
            }

            return 0;
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

            if (model.PersonalIdentificationNumber != driver.PersonalIdentificationNumber && await CheckForPersonalIdentification(model.PersonalIdentificationNumber))
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

            return await repository.UpdateAsync(driver);
        }

        private async Task<bool> CheckForPersonalIdentification(string registrationNumber)
        {
            return await repository.GetAllAsIQueryable()
                .Select(d => d.PersonalIdentificationNumber)
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d == registrationNumber) != null;
        }
    }
}
