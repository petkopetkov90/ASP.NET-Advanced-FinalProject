using FleetRouteManager.Web.Models.InputModels.VehicleInputModels;
using FleetRouteManager.Web.Models.ViewModels.VehicleViewModels;

namespace FleetRouteManager.Services.Interfaces
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleViewModel>> GetAllVehiclesAsync();
        Task<VehicleDetailsViewModel?> GetVehicleDetailsModelAsync(int id);
        Task<VehicleDeleteViewModel?> GetVehicleDeleteModelAsync(int id);
        Task<bool> DeleteVehicleAsync(int id);
        Task<int> CreateNewVehicleAsync(VehicleCreateInputModel vehicle);
        Task<VehicleEditInputModel?> GetVehicleEditModelAsync(int id);
        Task<bool> EditVehicleAsync(VehicleEditInputModel model);
        Task<IEnumerable<VehicleViewBagListModel>> GetVehicleViewBagListAsync();
    }
}
