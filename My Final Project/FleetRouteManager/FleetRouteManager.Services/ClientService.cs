using FleetRouteManager.Common.Exceptions;
using FleetRouteManager.Data.Models;
using FleetRouteManager.Data.Repositories.Interfaces;
using FleetRouteManager.Services.Interfaces;
using FleetRouteManager.Web.Models.InputModels.ClientInputModels;
using FleetRouteManager.Web.Models.ViewModels.ClientViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static FleetRouteManager.Common.ErrorMessages.ExceptionMessages;


namespace FleetRouteManager.Services
{
    public class ClientService : IClientService
    {
        private readonly IRepository<Client, int> repository;

        public ClientService(IRepository<Client, int> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<ClientViewModel>> GetAllClientsAsync()
        {
            var model = await repository.GetAllAsIQueryable()
                .Where(c => !c.IsDeleted)
                .Include(c => c.Address)
                .ThenInclude(a => a.Country)
                .AsNoTracking()
                .Select(c => new ClientViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    PhoneNumber = c.PhoneNumber,
                    ContactEmail = c.ContactEmail,
                    Address = FormatAddressToString(c.Address),
                })
                .ToListAsync();

            return model.OrderBy(c => c.Name);
        }

        public async Task<ClientDetailsViewModel?> GetClientDetailsAsync(int id)
        {
            var client = await repository.GetWhereAsIQueryable(d => !d.IsDeleted && d.Id == id)
                .Include(c => c.Address)
                .ThenInclude(a => a.Country)
                .Include(c => c.LegalAddress)
                .ThenInclude(a => a!.Country)
                .Include(c => c.PostalLocation)
                .ThenInclude(l => l!.Address)
                .ThenInclude(a => a.Country)
                .OrderBy(c => c.Name)
                .AsNoTracking()
                .Select(c => new ClientDetailsViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    PhoneNumber = c.PhoneNumber,
                    ContactEmail = c.ContactEmail,
                    Address = FormatAddressToString(c.Address),
                    LegalName = c.LegalName,
                    TaxNumber = c.TaxNumber,
                    LegalAddress = FormatAddressToString(c.LegalAddress),
                    PaymentEmail = c.PaymentEmail,
                    PodEmail = c.PodEmail,
                    InvoicingEmail = c.InvoicingEmail,
                    PostalAddress = FormatLocationToString(c.PostalLocation)
                })
                .FirstOrDefaultAsync();

            return client;
        }

        public async Task<ClientDeleteViewModel?> GetClientDeleteModelAsync(int id)
        {
            return await repository.GetWhereAsIQueryable(c => c.Id == id && !c.IsDeleted)
                .AsNoTracking()
                .Select(c => new ClientDeleteViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteClientAsync(int id)
        {
            var client = await repository.GetByIdAsync(id);

            if (client == null || client.IsDeleted)
            {
                return false;
            }

            client.IsDeleted = true;
            client.DeletedOn = DateTime.Now;

            return await repository.UpdateAsync(client);
        }

        public async Task<int> CrateNewClientAsync(ClientCreateInputModel model)
        {
            var client = new Client
            {
                Name = model.Name,
                TaxNumber = model.TaxNumber,
                LegalName = model.LegalName,
                AddressId = model.AddressId,
                LegalAddressId = model.LegalAddressId,
                PostalAddressId = model.PostalAddressId,
                PhoneNumber = model.PhoneNumber,
                ContactEmail = model.ContactEmail,
                PodEmail = model.PodEmail,
                InvoicingEmail = model.InvoicingEmail,
                PaymentEmail = model.PaymentEmail
            };

            try
            {
                if (await repository.AddAsync(client))
                {
                    return client.Id;
                }

                return 0;

            }
            catch (DbUpdateException e)
            {
                if (e.InnerException is SqlException inner)
                {
                    if (inner.Number is 2601 or 2627)
                    {
                        throw new CustomExistingEntityException(string.Format(ExistingEntityExceptionMsg, client.GetType().Name));
                    }
                }

                throw;
            }
        }

        public async Task<ClientEditInputModel?> GetClientEditModelAsync(int id)
        {
            var model = await repository.GetWhereAsIQueryable(l => l.Id == id && !l.IsDeleted)
                .AsNoTracking()
                .Select(l => new ClientEditInputModel()
                {
                    Id = l.Id,
                    Name = l.Name,
                    TaxNumber = l.TaxNumber,
                    LegalName = l.LegalName,
                    AddressId = l.AddressId,
                    LegalAddressId = l.LegalAddressId,
                    PostalAddressId = l.PostalAddressId,
                    PhoneNumber = l.PhoneNumber,
                    ContactEmail = l.ContactEmail,
                    PodEmail = l.PodEmail,
                    InvoicingEmail = l.InvoicingEmail,
                    PaymentEmail = l.PaymentEmail

                })
                .FirstOrDefaultAsync();

            return model;
        }

        public async Task<bool> EditClientAsync(ClientEditInputModel model)
        {
            var client = await repository.GetByIdAsync(model.Id);

            if (client == null || client.IsDeleted)
            {
                return false;
            }

            client.Name = model.Name;
            client.TaxNumber = model.TaxNumber;
            client.LegalName = model.LegalName;
            client.AddressId = model.AddressId;
            client.LegalAddressId = model.LegalAddressId;
            client.PostalAddressId = model.PostalAddressId;
            client.PhoneNumber = model.PhoneNumber;
            client.ContactEmail = model.ContactEmail;
            client.PodEmail = model.PodEmail;
            client.InvoicingEmail = model.InvoicingEmail;
            client.PaymentEmail = model.PaymentEmail;

            try
            {
                return await repository.UpdateAsync(client);
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException is SqlException inner)
                {
                    if (inner.Number is 2601 or 2627)
                    {
                        throw new CustomExistingEntityException(string.Format(EditExistingEntityExceptionMsg, client.GetType().Name));
                    }
                }

                throw;
            }
        }


        private static string FormatAddressToString(Address? address)
        {
            if (address == null)
            {
                return string.Empty;
            }

            return $"{address.Street} {(address.Number ?? "").Trim()}, {address.PostCode} {address.City}, {address.Country.Name}".Trim();
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
