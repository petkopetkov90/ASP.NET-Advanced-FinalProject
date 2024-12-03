using FleetRouteManager.Data.Models;
using FleetRouteManager.Data.Repositories.Interfaces;
using FleetRouteManager.Services.Interfaces;
using FleetRouteManager.Web.Models.ViewModels.ClientViewModels;
using Microsoft.EntityFrameworkCore;

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
                .AsNoTracking()
                .Select(c => new ClientViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    PhoneNumber = c.PhoneNumber,
                    ContactEmail = c.ContactEmail,
                    TaxNumber = c.TaxNumber,
                    LegalName = c.LegalName
                })
                .OrderBy(c => c.Name)
                .ToListAsync();

            return model;
        }
    }
}
