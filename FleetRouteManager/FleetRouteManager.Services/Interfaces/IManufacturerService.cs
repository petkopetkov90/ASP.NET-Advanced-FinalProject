using FleetRouteManager.Data.Models;

namespace FleetRouteManager.Services.Interfaces
{
    public interface IManufacturerService
    {
        Task<IEnumerable<Manufacturer>> GetAllManufacturersAsync();
    }
}
