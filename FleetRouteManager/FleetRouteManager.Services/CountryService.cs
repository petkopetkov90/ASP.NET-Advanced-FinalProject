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
            var countryList = await repository.GetWhereAsIQueryable(c => !c.IsDeleted)
                .OrderBy(c => c.Name)
                .AsNoTracking()
                .Select(c => new CountryViewBagListModel
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();


            countryList.Insert(0, new CountryViewBagListModel()
            {
                Name = "Please select a Country"
            });

            return countryList;
        }
    }
}
