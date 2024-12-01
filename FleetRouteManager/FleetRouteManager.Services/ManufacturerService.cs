using FleetRouteManager.Data.Models;
using FleetRouteManager.Data.Repositories.Interfaces;
using FleetRouteManager.Services.Interfaces;
using FleetRouteManager.Web.Models.ViewModels.ManufacturerViewModels;
using Microsoft.EntityFrameworkCore;

namespace FleetRouteManager.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IRepository<Manufacturer, int> repository;

        public ManufacturerService(IRepository<Manufacturer, int> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<ManufacturerViewBagListModel>> GetManufacturersViewBagListAsync()
        {
            var manufacturerList = await repository.GetWhereAsIQueryable(m => !m.IsDeleted)
                .Select(m => new ManufacturerViewBagListModel
                {
                    Id = m.Id,
                    Name = m.Name

                })
                .OrderBy(m => m.Name)
                .ToListAsync();

            manufacturerList.Insert(0, new ManufacturerViewBagListModel()
            {
                Name = "Please select a Manufacturer"
            });

            return manufacturerList;
        }
    }
}
