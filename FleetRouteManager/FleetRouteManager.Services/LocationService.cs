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
            var locations = await repository.GetAllAsIQueryable()
                .Where(l => !l.IsDeleted)
                .Include(l => l.Address)
                .ThenInclude(a => a.Country)
                .OrderBy(l => l.Name)
                .AsNoTracking()
                .Select(l => new LocationViewModel()
                {
                    Id = l.Id,
                    Name = l.Name,
                    PostCode = l.Address.PostCode,
                    City = l.Address.City,
                    Country = l.Address.Country.Name
                })
                .ToListAsync();

            return locations;
        }

        public async Task<LocationDetailsViewModel?> GetLocationDetailsAsync(int id)
        {
            var model = await repository.GetWhereAsIQueryable(l => !l.IsDeleted && l.Id == id)
                .Include(l => l.Address)
                .ThenInclude(a => a.Country)
                .AsNoTracking()
                .Select(l => new LocationDetailsViewModel()
                {
                    Id = l.Id,
                    Name = l.Name,
                    PhoneNumber = l.PhoneNumber,
                    StreetName = l.Address.Street,
                    StreetNumber = l.Address.Number,
                    PostCode = l.Address.PostCode,
                    City = l.Address.City,
                    Country = l.Address.Country.Name
                })
                .FirstOrDefaultAsync();

            return model;
        }

        public async Task<LocationDeleteViewModel?> GetLocationDeleteModelAsync(int id)
        {
            var model = await repository.GetWhereAsIQueryable(d => d.Id == id && !d.IsDeleted)
                .Include(d => d.Address)
                .AsNoTracking()
                .Select(l => new LocationDeleteViewModel
                {
                    Id = l.Id,
                    LocationName = l.Name
                })
                .FirstOrDefaultAsync();

            return model;
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

        public async Task<int> CreateNewLocationAsync(LocationCreateInputModel model)
        {
            var location = new Location
            {
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                AddressId = model.AddressId
            };

            if (await repository.AddAsync(location))
            {
                return location.Id;
            }

            return 0;
        }

        public async Task<LocationEditInputModel?> GetLocationEditModelAsync(int id)
        {
            var model = await repository.GetWhereAsIQueryable(l => l.Id == id && !l.IsDeleted)
                .AsNoTracking()
                .Select(l => new LocationEditInputModel()
                {
                    Id = l.Id,
                    Name = l.Name,
                    PhoneNumber = l.PhoneNumber,
                    AddressId = l.AddressId

                })
                .FirstOrDefaultAsync();

            return model;
        }

        public async Task<bool> EditLocationAsync(LocationEditInputModel model)
        {
            var location = await repository.GetByIdAsync(model.Id);

            if (location == null || location.IsDeleted)
            {
                return false;
            }

            location.Id = model.Id;
            location.Name = model.Name;
            location.PhoneNumber = model.PhoneNumber;
            location.AddressId = model.AddressId;

            return await repository.UpdateAsync(location);
        }

        public async Task<IEnumerable<LocationViewBagListModel>> GetLocationsViewBagListAsync()
        {
            var countryList = await repository.GetWhereAsIQueryable(c => !c.IsDeleted)
                .OrderBy(l => l.Name)
                .Include(l => l.Address)
                .ThenInclude(a => a.Country)
                .AsNoTracking()
                .Select(c => new LocationViewBagListModel
                {
                    Id = c.Id,
                    Name = FormatLocationToString(c)
                })
                .ToListAsync();


            countryList.Insert(0, new LocationViewBagListModel()
            {
                Name = "Please select a Location"
            });

            return countryList;
        }


        private static string FormatLocationToString(Location? location)
        {
            if (location?.Address == null)
            {
                return string.Empty;
            }

            return $"{location.Name} - {location.Address.Street} {(location.Address.Number ?? "").Trim()}, {location.Address.PostCode} {location.Address.City}, {location.Address.Country.Name}".Trim();
        }
    }
}
