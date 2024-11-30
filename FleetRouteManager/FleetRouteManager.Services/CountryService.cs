using FleetRouteManager.Data.Models;
using FleetRouteManager.Data.Repositories.Interfaces;
using FleetRouteManager.Services.Interfaces;
using FleetRouteManager.Web.Models.ViewModels.CountryViewModels;
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

        public async Task<IEnumerable<CountryViewBagListModel>> GetCountryViewBagListAsync()
        {
            return await repository.GetWhereAsIQueryable(c => !c.IsDeleted && c.ContinentId == 4)
                .AsNoTracking()
                .Select(c => new CountryViewBagListModel
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .OrderBy(c => c.Name)
                .ToListAsync();
        }
    }
}
