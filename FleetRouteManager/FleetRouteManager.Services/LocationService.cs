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
                .Include(a => a.Country)
                .AsNoTracking()
                .Select(l => new LocationViewModel
                {
                    Id = l.Id,
                    Name = l.Name,
                    PostCode = l.PostCode,
                    City = l.City,
                    Country = l.Country.Name
                }
                ).ToListAsync();
        }


        public async Task<LocationDetailsViewModel?> GetLocationDetailsAsync(int id)
        {
            var location = await repository.GetWhereAsIQueryable(l => !l.IsDeleted && l.Id == id)
                .Include(a => a.Country)
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
                Street = location.Street,
                StreetNumber = location.Number,
                PostCode = location.PostCode,
                City = location.City,
                Country = location.Country.Name
            };

            return model;
        }

        public async Task<LocationDeleteViewModel?> GetLocationDeleteModelAsync(int id)
        {
            return await repository.GetWhereAsIQueryable(d => d.Id == id && d.IsDeleted == false)
                .AsNoTracking()
                .Select(l => new LocationDeleteViewModel
                {
                    Id = l.Id,
                    Location = $"{l.Name} {l.PostCode} {l.City}"
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
