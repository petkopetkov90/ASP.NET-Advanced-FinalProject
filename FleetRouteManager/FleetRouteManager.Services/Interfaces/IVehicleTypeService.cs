using FleetRouteManager.Data.Models.Models;

namespace FleetRouteManager.Services.Interfaces
{
    public interface IVehicleTypeService
    {
        public Task<IEnumerable<VehicleType>> GetAllTypesAsync();

    }
}
