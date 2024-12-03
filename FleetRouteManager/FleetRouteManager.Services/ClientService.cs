using FleetRouteManager.Data.Models;
using FleetRouteManager.Data.Repositories.Interfaces;
using FleetRouteManager.Services.Interfaces;

namespace FleetRouteManager.Services
{
    public class ClientService : IClientService
    {
        private readonly IRepository<Client, int> repository;

        public ClientService(IRepository<Client, int> repository)
        {
            this.repository = repository;
        }
    }
}
