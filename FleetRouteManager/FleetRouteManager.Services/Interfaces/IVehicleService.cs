using FleetRouteManager.Web.Models.InputModels;
using FleetRouteManager.Web.Models.ViewModels;

namespace FleetRouteManager.Services.Interfaces
{
    public interface IVehicleService
    {
        public Task<IEnumerable<VehicleViewModel>> GetAllVehiclesAsync();
        public Task<VehicleDetailsViewModel?> GetVehicleDetailsModelAsync(int id);
        public Task<VehicleDeleteModel?> GetVehicleDeleteModelAsync(int id);
        public Task<bool> DeleteVehicleAsync(int id);
        public Task<bool> CreateNewVehicleAsync(VehicleCreateInputModel vehicle);
        public Task<VehicleEditInputModel> GetVehicleEditModelAsync(int id);
        public Task<bool> EditVehicleAsync(VehicleEditInputModel model);
    }
}
