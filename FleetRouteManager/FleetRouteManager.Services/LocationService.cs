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


        public async Task<LocationDetailsViewModel?> GetLocationDetailsAsync(int id)
        {
            var location = await repository.GetWhereAsIQueryable(l => !l.IsDeleted && l.Id == id)
                .Include(l => l.Address)
                .ThenInclude(a => a.Country)
                .AsNoTracking().
                FirstOrDefaultAsync();

            if (location == null)
            {
                return null;
            }

            var model = new LocationDetailsViewModel
            {
                Id = location.Id,
                Name = location.Name,
                PhoneNumber = location.PhoneNumber,
                Street = location.Address.Street,
                StreetNumber = location.Address.Number,
                PostCode = location.Address.PostCode,
                City = location.Address.City,
                Country = location.Address.Country.Name
            };

            return model;
        }

        public async Task<LocationDeleteViewModel?> GetLocationDeleteModelAsync(int id)
        {
            return await repository.GetWhereAsIQueryable(d => d.Id == id && d.IsDeleted == false)
                .Include(d => d.Address)
                .AsNoTracking()
                .Select(l => new LocationDeleteViewModel
                {
                    Id = l.Id,
                    Location = $"{l.Name} {l.Address.PostCode} {l.Address.City}"
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteLocationAsync(int id)
        {
            var location = await repository.GetByIdAsync(id);

            if (location == null || location.IsDeleted)
            {
                return false;
            }

            location.IsDeleted = true;
            location.DeletedOn = DateTime.Now;

            return await repository.UpdateAsync(location);
        }
    }
}
