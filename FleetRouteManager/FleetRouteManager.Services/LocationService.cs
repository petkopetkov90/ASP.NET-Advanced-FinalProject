using FleetRouteManager.Data.Models;
using FleetRouteManager.Data.Repositories.Interfaces;
using FleetRouteManager.Services.Interfaces;
using FleetRouteManager.Web.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FleetRouteManager.Services
{
    public class LocationService : ILocationService
    {
        private readonly IRepository<Location, int> repository;

        public LocationService(IRepository<Location, int> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<LocationViewModel>> GetAllLocationsAsync()
        {
            return await repository.GetAllAsIQueryable()
                .Where(l => !l.IsDeleted)
                .Include(l => l.Address)
                .ThenInclude(a => a.Country)
                .AsNoTracking()
                .Select(l => new LocationViewModel
                {
                    Id = l.Id,
                    Name = l.Name,
                    PostCode = l.Address.PostCode,
                    City = l.Address.City,
                    Country = l.Address.Country.Name
                }
                ).ToListAsync();
        }
    }
}
