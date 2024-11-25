using FleetRouteManager.Web.Models.InputModels;
using FleetRouteManager.Web.Models.ViewModels;

namespace FleetRouteManager.Services.Interfaces
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleViewModel>> GetAllVehiclesAsync();
        Task<VehicleDetailsViewModel?> GetVehicleDetailsModelAsync(int id);
        Task<VehicleDeleteViewModel?> GetVehicleDeleteModelAsync(int id);
        Task<bool> DeleteVehicleAsync(int id);
        Task<bool> CreateNewVehicleAsync(VehicleCreateInputModel vehicle);
        Task<VehicleEditInputModel> GetVehicleEditModelAsync(int id);
        Task<bool> EditVehicleAsync(VehicleEditInputModel model);
        Task<IEnumerable<VehicleListItemViewModel>> GetVehicleList();
    }
}
