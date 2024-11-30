using FleetRouteManager.Data.Models;
using FleetRouteManager.Data.Repositories.Interfaces;
using FleetRouteManager.Services.Interfaces;
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

        public async Task<int> GetAddressIdAsync(Address model)
        {
            var address = await repository.GetWhereAsIQueryable(a => a.Street == model.Street
                                                   && a.Number == model.Number
                                                   && a.PostCode == model.PostCode
                                                   && a.City == model.City
                                                   && a.CountryId == model.CountryId
            )
            .FirstOrDefaultAsync();

            if (address == null)
            {
                await repository.AddAsync(model);
                return model.Id;
            }

            if (address.IsDeleted)
            {
                address.IsDeleted = false;
                await repository.UpdateAsync(address);
            }

            return address.Id;
        }
    }
}
