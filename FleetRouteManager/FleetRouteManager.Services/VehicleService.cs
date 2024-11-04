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

        public async Task<IEnumerable<VehicleViewModel>> GetAllVehicles()
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
                    TruckType = v.VehicleType.TypeName

                })
                .OrderBy(v => v.RegistrationNumber)
                .ToListAsync();
        }
    }
}
