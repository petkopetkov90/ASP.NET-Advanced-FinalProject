using FleetRouteManager.Data.Models;
using FleetRouteManager.Data.Repositories.Interfaces;
using FleetRouteManager.Services.Interfaces;
using FleetRouteManager.Web.Models.InputModels.LocationInputModels;
using FleetRouteManager.Web.Models.ViewModels.LocationViewModels;
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
                })
                .ToListAsync();
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
                StreetName = location.Street,
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
                    LocationDetail = $"{l.Name} {l.PostCode} {l.City}"
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

        public async Task<bool> CreateNewLocationAsync(LocationCreateInputModel model)
        {
            var location = new Location
            {
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                Street = model.StreetName,
                Number = model.StreetNumber,
                PostCode = model.PostCode,
                City = model.City,
                CountryId = model.CountryId,
            };

            return await repository.AddAsync(location);
        }

        public async Task<LocationEditInputModel> GetLocationEditModelAsync(int id)
        {
            var location = await repository.GetByIdAsync(id);

            if (location == null || location.IsDeleted)
            {
                return null!;
            }

            var model = new LocationEditInputModel()
            {
                Id = location.Id,
                Name = location.Name,
                PhoneNumber = location.PhoneNumber,
                StreetName = location.Street,
                StreetNumber = location.Number,
                PostCode = location.PostCode,
                City = location.City,
                CountryId = location.CountryId,
            };

            return model;
        }

        public async Task<bool> EditLocationAsync(LocationEditInputModel model)
        {
            var location = await repository.GetByIdAsync(model.Id);

            if (location == null || location.IsDeleted)
            {
                return false;
            }

            location.Id = location.Id;
            location.Name = location.Name;
            location.PhoneNumber = location.PhoneNumber;
            location.Street = location.Street;
            location.Number = location.Number;
            location.PostCode = location.PostCode;
            location.City = location.City;
            location.CountryId = location.CountryId;

            return await repository.UpdateAsync(location);
        }
    }
}
