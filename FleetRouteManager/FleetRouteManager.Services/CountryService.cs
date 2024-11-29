using FleetRouteManager.Data.Models;
using FleetRouteManager.Data.Repositories.Interfaces;
using FleetRouteManager.Services.Interfaces;
using FleetRouteManager.Web.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FleetRouteManager.Services
{
    public class CountryService : ICountryService
    {
        private readonly IRepository<Country, int> repository;

        public CountryService(IRepository<Country, int> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<LocationViewBagListModel>> GetCountryViewBagList()
        {
            return await repository.GetAllAsIQueryable()
                .Select(c => new LocationViewBagListModel
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .OrderBy(c => c.Name)
                .ToListAsync();
        }
    }
}
