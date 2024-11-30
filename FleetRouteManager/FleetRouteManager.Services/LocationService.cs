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
        private readonly IAddressService addressService;
        public LocationService(IRepository<Location, int> repository, IAddressService addressService)
        {
            this.repository = repository;
            this.addressService = addressService;
        }

        public async Task<IEnumerable<LocationViewModel>> GetAllLocationsAsync()
        {
            var locations = await repository.GetAllAsIQueryable()
                .Where(l => !l.IsDeleted)
                .Include(l => l.Address)
                .ThenInclude(a => a.Country)
                .AsNoTracking()
                .ToListAsync();


            var model = locations.Select(l => new LocationViewModel
            {
                Id = l.Id,
                Name = l.Name,
                PostCode = l.Address.PostCode,
                City = l.Address.City,
                Country = l.Address.Country.Name
            });

            return model;
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
                StreetName = location.Address.Street,
                StreetNumber = location.Address.Number,
                PostCode = location.Address.PostCode,
                City = location.Address.City,
                Country = location.Address.Country.Name
            };

            return model;
        }

        public async Task<LocationDeleteViewModel?> GetLocationDeleteModelAsync(int id)
        {
            return await repository.GetWhereAsIQueryable(d => d.Id == id && !d.IsDeleted)
                .Include(d => d.Address)
                .AsNoTracking()
                .Select(l => new LocationDeleteViewModel
                {
                    Id = l.Id,
                    LocationName = $"{l.Name} {l.Address.PostCode} {l.Address.City}"
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
            var address = new Address
            {
                Street = model.StreetName,
                Number = model.StreetNumber,
                PostCode = model.PostCode,
                City = model.City,
                CountryId = model.CountryId
            };

            var addressId = await addressService.GetAddressIdAsync(address);

            var location = new Location
            {
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                AddressId = addressId
            };

            return await repository.AddAsync(location);
        }

        public async Task<LocationEditInputModel> GetLocationEditModelAsync(int id)
        {
            var location = await repository.GetWhereAsIQueryable(l => l.Id == id && !l.IsDeleted)
                .Include(l => l.Address)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (location == null)
            {
                return null!;
            }

            var model = new LocationEditInputModel()
            {
                Id = location.Id,
                Name = location.Name,
                PhoneNumber = location.PhoneNumber,
                StreetName = location.Address.Street,
                StreetNumber = location.Address.Number,
                PostCode = location.Address.PostCode,
                City = location.Address.City,
                CountryId = location.Address.CountryId,
            };

            return model;
        }

        public async Task<bool> EditLocationAsync(LocationEditInputModel model)
        {
            var location = await repository.GetWhereAsIQueryable(l => l.Id == model.Id)
                .Include(l => l.Address)
                .FirstOrDefaultAsync();

            if (location == null || location.IsDeleted)
            {
                return false;
            }

            location.Id = model.Id;
            location.Name = model.Name;
            location.PhoneNumber = model.PhoneNumber;
            location.Address.Street = model.StreetName;
            location.Address.Number = model.StreetNumber;
            location.Address.PostCode = model.PostCode;
            location.Address.City = model.City;
            location.Address.CountryId = model.CountryId;

            return await repository.UpdateAsync(location);
        }
    }
}
