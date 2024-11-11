using FleetRouteManager.Data.Models;
using FleetRouteManager.Data.Repositories.Interfaces;
using FleetRouteManager.Services.Interfaces;

namespace FleetRouteManager.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IRepository<Manufacturer, int> repository;

        public ManufacturerService(IRepository<Manufacturer, int> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Manufacturer>> GetAllManufacturersAsync()
        {
            return await repository.GetAllAsync();
        }
    }
}
