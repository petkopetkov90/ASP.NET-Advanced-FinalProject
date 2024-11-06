using FleetRouteManager.Web.Models.ViewModels;

namespace FleetRouteManager.Services.Interfaces
{
    public interface IVehicleService
    {
        public Task<IEnumerable<VehicleViewModel>> GetAllVehiclesAsync();
        public Task<VehicleDetailsViewModel?> GetVehicleDetailsAsync(int id);
    }
}
