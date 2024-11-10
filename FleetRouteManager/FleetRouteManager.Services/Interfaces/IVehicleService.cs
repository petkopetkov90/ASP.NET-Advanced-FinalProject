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
        public Task<bool> CreateNewVehicle(VehicleCreateInputModel vehicle);
        public Task<VehicleEditInputModel> GetVehicleEditModel(int id);
        public Task<bool> EditVehicle(VehicleEditInputModel model);
    }
}
