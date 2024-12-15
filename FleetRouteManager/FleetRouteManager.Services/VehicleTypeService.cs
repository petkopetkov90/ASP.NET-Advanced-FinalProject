using FleetRouteManager.Data.Models;
using FleetRouteManager.Data.Repositories.Interfaces;
using FleetRouteManager.Services.Interfaces;
using FleetRouteManager.Web.Models.ViewModels.VehicleTypeViewModels;
using Microsoft.EntityFrameworkCore;

namespace FleetRouteManager.Services
{
    public class VehicleTypeService : IVehicleTypeService
    {
        private readonly IRepository<VehicleType, int> repository;

        public VehicleTypeService(IRepository<VehicleType, int> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<VehicleTypeViewBagListModel>> GetVehicleTypeViewBagListAsync()
        {
            var vehicleTypeList = await repository.GetWhereAsIQueryable(v => !v.IsDeleted)
                .OrderBy(v => v.Type)
                .AsNoTracking()
                .Select(v => new VehicleTypeViewBagListModel()
                {
                    Id = v.Id,
                    Type = v.Type

                })
                .ToListAsync();

            return vehicleTypeList;
        }
    }
}
