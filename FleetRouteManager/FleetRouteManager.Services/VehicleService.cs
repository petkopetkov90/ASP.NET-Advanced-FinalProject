using FleetRouteManager.Data.Models;
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
                    FirstRegistrationDate = v.FirstRegistration.ToString("dd-MM-yyyy"),
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

            return await repository.UpdateAsync(vehicle);
        }

        public async Task<bool> CreateNewVehicle(VehicleCreateInputModel model)
        {
            if (await CheckForRegistrationNumber(model.RegistrationNumber))
            {
                return false;
            }

            var vehicle = new Vehicle
            {
                RegistrationNumber = model.RegistrationNumber,
                ManufacturerId = model.ManufacturerId,
                Model = model.VehicleModel,
                Vin = model.Vin,
                FirstRegistration = CustomDateParseExact(model.FirstRegistration, VehicleDateFormat, "FirstRegistration"),
                EuroClass = model.EuroClass,
                VehicleTypeId = model.VehicleTypeId,
                BodyType = model.BodyType,
                Axles = model.Axles,
                WeightCapacity = model.WeightCapacity,
                AcquiredOn = CustomDateParseExact(model.AcquiredOn, VehicleDateFormat, "AcquiredOn"),
                LiabilityInsurance = model.LiabilityInsurance,
                LiabilityInsuranceExpirationDate = CustomNullableDateParseExact(model.LiabilityInsuranceExpirationDate, VehicleDateFormat, "LiabilityInsuranceExpirationDate"),
                TechnicalReviewExpirationDate = CustomNullableDateParseExact(model.TechnicalReviewExpirationDate, VehicleDateFormat, "TechnicalReviewExpirationDate"),
                TachographExpirationDate = CustomNullableDateParseExact(model.TachographExpirationDate, VehicleDateFormat, "TachographExpirationDate")
            };


            return await repository.AddAsync(vehicle);
        }

        public async Task<VehicleEditInputModel> GetVehicleEditModel(int id)
        {
            var vehicle = await repository.GetByIdAsync(id);

            if (vehicle == null)
            {
                return null!;
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

        public async Task<bool> EditVehicle(VehicleEditInputModel model)
        {
            var vehicle = await repository.GetByIdAsync(model.Id);

            if (vehicle == null)
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
            vehicle.FirstRegistration = CustomDateParseExact(model.FirstRegistration, VehicleDateFormat, "FirstRegistration");
            vehicle.EuroClass = model.EuroClass;
            vehicle.VehicleTypeId = model.VehicleTypeId;
            vehicle.BodyType = model.BodyType;
            vehicle.Axles = model.Axles;
            vehicle.WeightCapacity = model.WeightCapacity;
            vehicle.AcquiredOn = CustomDateParseExact(model.AcquiredOn, VehicleDateFormat, "AcquiredOn");
            vehicle.LiabilityInsurance = model.LiabilityInsurance;
            vehicle.LiabilityInsuranceExpirationDate = CustomNullableDateParseExact(
                model.LiabilityInsuranceExpirationDate, VehicleDateFormat, "LiabilityInsuranceExpirationDate");
            vehicle.TechnicalReviewExpirationDate = CustomNullableDateParseExact(model.TechnicalReviewExpirationDate,
                VehicleDateFormat, "TechnicalReviewExpirationDate");
            vehicle.TachographExpirationDate = CustomNullableDateParseExact(model.TachographExpirationDate,
                VehicleDateFormat, "TachographExpirationDate");

            return await repository.UpdateAsync(vehicle);
        }

        private async Task<bool> CheckForRegistrationNumber(string registrationNumber)
        {
            return await repository.GetAllAsIQueryable()
                .FirstOrDefaultAsync(v => v.RegistrationNumber == registrationNumber) != null;
        }
    }
}
