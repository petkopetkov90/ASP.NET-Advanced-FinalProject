using FleetRouteManager.Data.Models;
using FleetRouteManager.Data.Repositories.Interfaces;
using FleetRouteManager.Services.Interfaces;

namespace FleetRouteManager.Services
{
    public class VehicleTypeService : IVehicleTypeService
    {
        private readonly IRepository<VehicleType, int> repository;

        public VehicleTypeService(IRepository<VehicleType, int> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<VehicleType>> GetAllTypesAsync()
        {
            return await repository.GetAllAsync();
        }
    }
}
