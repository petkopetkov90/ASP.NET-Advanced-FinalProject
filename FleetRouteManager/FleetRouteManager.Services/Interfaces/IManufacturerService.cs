using FleetRouteManager.Data.Models.Models;

namespace FleetRouteManager.Services.Interfaces
{
    public interface IManufacturerService
    {
        public Task<IEnumerable<Manufacturer>> GetAllManufacturersAsync();
    }
}
