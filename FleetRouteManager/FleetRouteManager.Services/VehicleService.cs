using FleetRouteManager.Data.Models.Models;
using FleetRouteManager.Data.Repositories.Interfaces;
using FleetRouteManager.Services.Interfaces;
using FleetRouteManager.Web.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FleetRouteManager.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly ISoftDeleteRepository<Vehicle, int> repository;

        public VehicleService(ISoftDeleteRepository<Vehicle, int> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<VehicleViewModel>> GetAllVehiclesAsync()
        {
            return await repository.GetAllAsIQueryable()
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

        public async Task<VehicleDetailsViewModel?> GetVehicleDetailsAsync(int id)
        {
            var vehicle = await repository.GetWhereAsIQueryable(v => v.Id == id)
                .Include(v => v.Manufacturer)
                .Include(v => v.VehicleType)
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
    }
}
