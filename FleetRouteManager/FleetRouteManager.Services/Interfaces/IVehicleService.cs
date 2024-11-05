using FleetRouteManager.Web.Models.ViewModels;

namespace FleetRouteManager.Services.Interfaces
{
    public interface IVehicleService
    {
        public Task<IEnumerable<VehicleViewModel>> GetAllVehicles();
        //public Task<VehicleDetailsViewModel> GetVehicleDetails(int id);
    }
}
