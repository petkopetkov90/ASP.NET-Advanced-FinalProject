using FleetRouteManager.Common.Exceptions;
using FleetRouteManager.Data.Models;
using FleetRouteManager.Data.Repositories.Interfaces;
using FleetRouteManager.Services.Interfaces;
using FleetRouteManager.Web.Models.InputModels.AddressInputModels;
using FleetRouteManager.Web.Models.ViewModels.AddressViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static FleetRouteManager.Common.ErrorMessages.ExceptionMessages;


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
                .OrderBy(a => a.Country.Name)
                .ThenBy(a => a.PostCode)
                .ThenBy(a => a.Street)
                .AsNoTracking()
                .Select(a => new AddressViewBagListModel
                {
                    Id = a.Id,
                    Name = FormatAddressToString(a)

                })
                .ToListAsync();

            return addressList;

        }

        public async Task<int> AddNewAddressAsync(AddressCreateInputModel model)
        {
            var address = new Address()
            {
                Street = model.StreetName,
                Number = model.StreetNumber,
                PostCode = model.PostCode,
                City = model.City,
                CountryId = model.CountryId
            };

            try
            {
                if (await repository.AddAsync(address))
                {
                    return address.Id;
                }
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException is SqlException inner)
                {
                    if (inner.Number is 2601 or 2627)
                    {
                        throw new CustomExistingEntityException(string.Format(ExistingEntityExceptionMsg, address.GetType().Name));
                    }
                }

                throw;
            }

            return 0;
        }

        public async Task<int> GetAddressId(AddressCreateInputModel model)
        {
            var address = await repository.GetWhereAsIQueryable(a =>
                    a.Street == model.StreetName &&
                    (a.Number == model.StreetNumber || (a.Number == null && model.StreetNumber == null)) &&
                    a.PostCode == model.PostCode &&
                    a.CountryId == model.CountryId
                )
                .FirstOrDefaultAsync();

            if (address == null)
            {
                return 0;
            }

            return address.Id;
        }

        private static string FormatAddressToString(Address? address)
        {
            if (address == null)
            {
                return string.Empty;
            }

            return $"{address.Street} {(address.Number ?? "").Trim()}, {address.PostCode} {address.City}, {address.Country.Name}".Trim();
        }
    }
}
