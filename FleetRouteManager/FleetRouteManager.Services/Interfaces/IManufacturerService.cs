using FleetRouteManager.Data.Models;

namespace FleetRouteManager.Services.Interfaces
{
    public interface IManufacturerService
    {
        public Task<IEnumerable<Manufacturer>> GetAllManufacturersAsync();
    }
}
