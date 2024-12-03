﻿using FleetRouteManager.Data.Models;
using FleetRouteManager.Data.Repositories.Interfaces;
using FleetRouteManager.Services.Interfaces;
using FleetRouteManager.Web.Models.InputModels.VehicleInputModels;
using FleetRouteManager.Web.Models.ViewModels.VehicleViewModels;
using Microsoft.EntityFrameworkCore;
using static FleetRouteManager.Common.Constants.VehicleConstants;
using static FleetRouteManager.Common.Parsers.CustomDateParsers;


namespace FleetRouteManager.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepository<Vehicle, int> repository;

        public VehicleService(IRepository<Vehicle, int> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<VehicleViewModel>> GetAllVehiclesAsync()
        {
            var vehicles = await repository.GetAllAsIQueryable()
                .Where(e => e.IsDeleted == false)
                .Include(v => v.Manufacturer)
                .Include(v => v.VehicleType)
                .AsNoTracking()
                .Select(v => new VehicleViewModel()
                {
                    Id = v.Id,
                    RegistrationNumber = v.RegistrationNumber,
                    Vin = v.Vin,
                    Manufacturer = v.Manufacturer.Name,
                    Model = v.Model,
                    FirstRegistrationDate = v.FirstRegistration.ToString(VehicleDateFormat),
                    EuroClass = v.EuroClass,
                    Type = v.VehicleType.Type
                })
                .OrderBy(v => v.RegistrationNumber)
                .ToListAsync();

            return vehicles;
        }

        public async Task<VehicleDetailsViewModel?> GetVehicleDetailsModelAsync(int id)
        {
            var vehicle = await repository.GetWhereAsIQueryable(v => v.Id == id && v.IsDeleted == false)
                .Include(v => v.Manufacturer)
                .Include(v => v.VehicleType)
                .Include(v => v.Drivers)
                .AsNoTracking()
                .Select(v => new VehicleDetailsViewModel()
                {
                    Id = v.Id,
                    RegistrationNumber = v.RegistrationNumber,
                    Vin = v.Vin,
                    Manufacturer = v.Manufacturer.Name,
                    Model = v.Model,
                    FirstRegistrationDate = v.FirstRegistration.ToString(VehicleDateFormat),
                    EuroClass = v.EuroClass,
                    Type = v.VehicleType.Type,
                    BodyType = v.BodyType,
                    Axles = v.Axles,
                    WeightCapacity = v.WeightCapacity,
                    AcquiredOn = v.AcquiredOn.ToString(VehicleDateFormat),
                    Drivers = v.Drivers.Select(d => $"{d.FirstName} {d.MiddleName} {d.LastName}"),
                    LiabilityInsurance = v.LiabilityInsurance,
                    LiabilityInsuranceExpirationDate = CustomNullableDateToStringParseExact(v.LiabilityInsuranceExpirationDate, VehicleDateFormat),
                    TechnicalReviewExpirationDate = CustomNullableDateToStringParseExact(v.TechnicalReviewExpirationDate, VehicleDateFormat),
                    TachographExpirationDate = CustomNullableDateToStringParseExact(v.TachographExpirationDate, VehicleDateFormat)
                })
                .FirstOrDefaultAsync();


            return vehicle;
        }

        public async Task<VehicleDeleteViewModel?> GetVehicleDeleteModelAsync(int id)
        {
            return await repository.GetWhereAsIQueryable(v => v.Id == id && !v.IsDeleted)
                .AsNoTracking()
                .Select(v => new VehicleDeleteViewModel
                {
                    Id = v.Id,
                    RegistrationNumber = v.RegistrationNumber
                })
                .FirstOrDefaultAsync();

        }

        public async Task<bool> DeleteVehicleAsync(int id)
        {
            var vehicle = await repository.GetByIdAsync(id);

            if (vehicle == null || vehicle.IsDeleted)
            {
                return false;
            }

            vehicle.IsDeleted = true;
            vehicle.DeletedOn = DateTime.Now;

            return await repository.UpdateAsync(vehicle);
        }

        public async Task<int> CreateNewVehicleAsync(VehicleCreateInputModel model)
        {
            if (await CheckForRegistrationNumber(model.RegistrationNumber))
            {
                return 0;
            }

            var vehicle = new Vehicle
            {
                RegistrationNumber = model.RegistrationNumber,
                ManufacturerId = model.ManufacturerId,
                Model = model.VehicleModel,
                Vin = model.Vin,
                FirstRegistration = CustomStringToDateParseExact(model.FirstRegistration, VehicleDateFormat, nameof(model.FirstRegistration)),
                EuroClass = model.EuroClass,
                VehicleTypeId = model.VehicleTypeId,
                BodyType = model.BodyType,
                Axles = model.Axles,
                WeightCapacity = model.WeightCapacity,
                AcquiredOn = CustomStringToDateParseExact(model.AcquiredOn, VehicleDateFormat, nameof(model.AcquiredOn)),
                LiabilityInsurance = model.LiabilityInsurance,
                LiabilityInsuranceExpirationDate = CustomNullableStringToDateParseExact(model.LiabilityInsuranceExpirationDate, VehicleDateFormat, nameof(model.LiabilityInsuranceExpirationDate)),
                TechnicalReviewExpirationDate = CustomNullableStringToDateParseExact(model.TechnicalReviewExpirationDate, VehicleDateFormat, nameof(model.TechnicalReviewExpirationDate)),
                TachographExpirationDate = CustomNullableStringToDateParseExact(model.TachographExpirationDate, VehicleDateFormat, nameof(model.TachographExpirationDate))
            };


            if (await repository.AddAsync(vehicle))
            {
                return vehicle.Id;
            }

            return 0;
        }

        public async Task<VehicleEditInputModel?> GetVehicleEditModelAsync(int id)
        {
            var vehicle = await repository.GetByIdAsync(id);

            if (vehicle == null || vehicle.IsDeleted)
            {
                return null;
            }

            var model = new VehicleEditInputModel
            {
                Id = vehicle.Id,
                RegistrationNumber = vehicle.RegistrationNumber,
                VehicleModel = vehicle.Model,
                ManufacturerId = vehicle.ManufacturerId,
                Vin = vehicle.Vin,
                FirstRegistration = vehicle.FirstRegistration.ToString(VehicleDateFormat),
                EuroClass = vehicle.EuroClass,
                VehicleTypeId = vehicle.VehicleTypeId,
                BodyType = vehicle.BodyType,
                Axles = vehicle.Axles,
                WeightCapacity = vehicle.WeightCapacity,
                AcquiredOn = vehicle.AcquiredOn.ToString(VehicleDateFormat),
                LiabilityInsurance = vehicle.LiabilityInsurance,
                LiabilityInsuranceExpirationDate = vehicle.LiabilityInsuranceExpirationDate?.ToString(VehicleDateFormat) ?? string.Empty,
                TechnicalReviewExpirationDate = vehicle.TechnicalReviewExpirationDate?.ToString(VehicleDateFormat) ?? string.Empty,
                TachographExpirationDate = vehicle.TachographExpirationDate?.ToString(VehicleDateFormat) ?? string.Empty,
            };

            return model;
        }

        public async Task<bool> EditVehicleAsync(VehicleEditInputModel model)
        {
            var vehicle = await repository.GetByIdAsync(model.Id);

            if (vehicle == null || vehicle.IsDeleted)
            {
                return false;
            }

            if (model.RegistrationNumber != vehicle.RegistrationNumber && await CheckForRegistrationNumber(model.RegistrationNumber))
            {
                return false;
            }

            vehicle.RegistrationNumber = model.RegistrationNumber;
            vehicle.ManufacturerId = model.ManufacturerId;
            vehicle.Model = model.VehicleModel;
            vehicle.Vin = model.Vin;
            vehicle.FirstRegistration = CustomStringToDateParseExact(model.FirstRegistration, VehicleDateFormat, nameof(model.FirstRegistration));
            vehicle.EuroClass = model.EuroClass;
            vehicle.VehicleTypeId = model.VehicleTypeId;
            vehicle.BodyType = model.BodyType;
            vehicle.Axles = model.Axles;
            vehicle.WeightCapacity = model.WeightCapacity;
            vehicle.AcquiredOn = CustomStringToDateParseExact(model.AcquiredOn, VehicleDateFormat, nameof(model.AcquiredOn));
            vehicle.LiabilityInsurance = model.LiabilityInsurance;
            vehicle.LiabilityInsuranceExpirationDate = CustomNullableStringToDateParseExact(
                model.LiabilityInsuranceExpirationDate, VehicleDateFormat, nameof(model.LiabilityInsuranceExpirationDate));
            vehicle.TechnicalReviewExpirationDate = CustomNullableStringToDateParseExact(model.TechnicalReviewExpirationDate,
                VehicleDateFormat, nameof(model.TechnicalReviewExpirationDate));
            vehicle.TachographExpirationDate = CustomNullableStringToDateParseExact(model.TachographExpirationDate,
                VehicleDateFormat, nameof(model.TachographExpirationDate));

            return await repository.UpdateAsync(vehicle);
        }

        public async Task<IEnumerable<VehicleViewBagListModel>> GetVehicleViewBagListAsync()
        {
            var vehicleList = await repository.GetWhereAsIQueryable(v => !v.IsDeleted)
                .Select(v => new VehicleViewBagListModel
                {
                    Id = v.Id,
                    RegistrationNumber = v.RegistrationNumber
                })
                .OrderBy(v => v.RegistrationNumber)
                .ToListAsync();

            vehicleList.Insert(0, new VehicleViewBagListModel()
            {
                RegistrationNumber = "You can assign the driver to a vehicle"
            });

            return vehicleList;
        }

        private async Task<bool> CheckForRegistrationNumber(string registrationNumber)
        {
            return await repository.GetAllAsIQueryable()
                .Select(v => v.RegistrationNumber)
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r == registrationNumber) != null;
        }
    }
}
