using FleetRouteManager.Data.Models;
using FleetRouteManager.Data.Repositories.Interfaces;
using FleetRouteManager.Services.Interfaces;
using FleetRouteManager.Web.Models.InputModels.AddressInputModels;
using FleetRouteManager.Web.Models.ViewModels.AddressViewModels;
using Microsoft.EntityFrameworkCore;

namespace FleetRouteManager.Services
{
    public class AddressService : IAddressService
    {
        private readonly IRepository<Address, int> repository;

        public AddressService(IRepository<Address, int> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<AddressViewBagListModel>> GetAddressViewBagListAsync()
        {
            var addressList = await repository.GetWhereAsIQueryable(a => !a.IsDeleted)
                .Include(a => a.Country)
                .AsNoTracking()
                .OrderBy(a => a.Country.Name)
                .ThenBy(a => a.PostCode)
                .ThenBy(a => a.Street)
                .Select(a => new AddressViewBagListModel
                {
                    Id = a.Id,
                    Name = $"{a.Street} {a.Number}, {a.PostCode} {a.Country.Name}",
                })
                .ToListAsync();

            addressList.Insert(0, new AddressViewBagListModel()
            {
                Name = "Please select an address"
            });

            return addressList;

        }

        public async Task<bool> AddNewAddressAsync(AddressCreateInputModel model)
        {
            var address = new Address()
            {
                Street = model.StreetName,
                Number = model.StreetNumber,
                PostCode = model.PostCode,
                City = model.City,
                CountryId = model.CountryId
            };

            return await repository.AddAsync(address);
        }
    }
}
