using FleetRouteManager.Web.Models.ViewModels.VehicleTypeViewModels;

namespace FleetRouteManager.Services.Interfaces
{
    public interface IVehicleTypeService
    {
        Task<IEnumerable<VehicleTypeViewBagListModel>> GetVehicleTypeViewBagListAsync();
    }
}
