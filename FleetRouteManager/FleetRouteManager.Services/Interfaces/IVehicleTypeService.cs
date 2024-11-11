using FleetRouteManager.Data.Models;

namespace FleetRouteManager.Services.Interfaces
{
    public interface IVehicleTypeService
    {
        public Task<IEnumerable<VehicleType>> GetAllTypesAsync();

    }
}
