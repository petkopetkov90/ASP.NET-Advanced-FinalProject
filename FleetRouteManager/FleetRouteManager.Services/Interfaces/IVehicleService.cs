using FleetRouteManager.Web.Models.ViewModels;

namespace FleetRouteManager.Services.Interfaces
{
    public interface IVehicleService
    {
        public Task<IEnumerable<VehicleViewModel>> GetAllVehiclesAsync();
        public Task<VehicleDetailsViewModel?> GetVehicleDetailModelAsync(int id);
        public Task<VehicleDeleteModel?> GetVehicleDeleteModelAsync(int id);
        public Task<bool> DeleteVehicleAsync(int id);
    }
}
