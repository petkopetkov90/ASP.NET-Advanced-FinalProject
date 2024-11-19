using FleetRouteManager.Data.Models;

namespace FleetRouteManager.Services.Interfaces
{
    public interface IVehicleTypeService
    {
        Task<IEnumerable<VehicleType>> GetAllTypesAsync();
    }
}
