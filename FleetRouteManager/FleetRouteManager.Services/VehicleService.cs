﻿using FleetRouteManager.Data.Models.Models;
using FleetRouteManager.Data.Repositories.Interfaces;
using FleetRouteManager.Services.Interfaces;
using FleetRouteManager.Web.Models.InputModels;
using FleetRouteManager.Web.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using static FleetRouteManager.Common.Constants.VehicleConstants;
using static FleetRouteManager.Common.Parsers.CustomDateParser;


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
            return await repository.GetAllAsIQueryable()
                .Where(e => e.IsDeleted == false)
                .Include(v => v.Manufacturer)
                .Include(v => v.VehicleType)
                .AsNoTracking()
                .Select(v => new VehicleViewModel
                {
                    Id = v.Id,
                    RegistrationNumber = v.RegistrationNumber,
                    Vin = v.Vin,
                    Manufacturer = v.Manufacturer.Name,
                    Model = v.Model,
                    FirstRegistrationDate = v.FirstRegistration,
                    EuroClass = v.EuroClass,
                    Type = v.VehicleType.Type

                })
                .OrderBy(v => v.RegistrationNumber)
                .ToListAsync();
        }

        public async Task<VehicleDetailsViewModel?> GetVehicleDetailsModelAsync(int id)
        {
            var vehicle = await repository.GetWhereAsIQueryable(v => v.Id == id && v.IsDeleted == false)
                .Include(v => v.Manufacturer)
                .Include(v => v.VehicleType)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (vehicle == null)
            {
                return null;
            }

            var model = new VehicleDetailsViewModel()
            {
                Id = vehicle.Id,
                RegistrationNumber = vehicle.RegistrationNumber,
                Vin = vehicle.Vin,
                Manufacturer = vehicle.Manufacturer.Name,
                Model = vehicle.Model,
                FirstRegistrationDate = vehicle.FirstRegistration.ToString("dd-MM-yyyy"),
                EuroClass = vehicle.EuroClass,
                Type = vehicle.VehicleType.Type,
                BodyType = vehicle.BodyType,
                Axles = vehicle.Axles,
                WeightCapacity = vehicle.WeightCapacity,
                AcquiredOn = vehicle.AcquiredOn.ToString("dd-MM-yyyy"),
                LiabilityInsurance = vehicle.LiabilityInsurance,
                LiabilityInsuranceExpirationDate = vehicle.LiabilityInsuranceExpirationDate?.ToString("dd-MM-yyyy") ?? "",
                TechnicalReviewExpirationDate = vehicle.TechnicalReviewExpirationDate?.ToString("dd-MM-yyyy") ?? "",
                TachographExpirationDate = vehicle.TachographExpirationDate?.ToString("dd-MM-yyyy") ?? ""
            };

            return model;
        }

        public async Task<VehicleDeleteModel?> GetVehicleDeleteModelAsync(int id)
        {
            return await repository.GetWhereAsIQueryable(v => v.Id == id && v.IsDeleted == false)
                .AsNoTracking()
                .Select(v => new VehicleDeleteModel
                {
                    Id = v.Id,
                    RegistrationNumber = v.RegistrationNumber
                })
                .FirstOrDefaultAsync();

        }

        public async Task<bool> DeleteVehicleAsync(int id)
        {
            var vehicle = await repository.GetByIdAsync(id);

            if (vehicle == null)
            {
                return false;
            }

            vehicle.IsDeleted = true;

            return await repository.SaveAsync();
        }

        public async Task<bool> AddNewVehicle(VehicleCreateInputModel model)
        {
            if (await repository.GetAllAsIQueryable().FirstOrDefaultAsync(v => v.RegistrationNumber == model.RegistrationNumber) != null)
            {
                return false;
            }

            var vehicle = new Vehicle
            {
                RegistrationNumber = model.RegistrationNumber,
                ManufacturerId = model.ManufacturerId,
                Model = model.VehicleModel,
                Vin = model.Vin,
                FirstRegistration = CustomDateParseExact(model.AcquiredOn, VehicleDateFormat, "FirstRegistration"),
                EuroClass = model.EuroClass,
                VehicleTypeId = model.VehicleTypeId,
                BodyType = model.BodyType,
                Axles = model.Axles,
                WeightCapacity = model.WeightCapacity,
                AcquiredOn = CustomDateParseExact(model.AcquiredOn, VehicleDateFormat, "AcquiredOn"),
                LiabilityInsurance = model.LiabilityInsurance,
                LiabilityInsuranceExpirationDate = CustomDateParseExact(model.AcquiredOn, VehicleDateFormat, "LiabilityInsuranceExpirationDate"),
                TechnicalReviewExpirationDate = CustomDateParseExact(model.AcquiredOn, VehicleDateFormat, "TechnicalReviewExpirationDate"),
                TachographExpirationDate = CustomDateParseExact(model.AcquiredOn, VehicleDateFormat, "TachographExpirationDate")
            };


            return await repository.AddAsync(vehicle);
        }
    }
}
