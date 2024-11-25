using FleetRouteManager.Web.Models.ViewModels;

namespace FleetRouteManager.Services.Interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<LocationViewModel>> GetAllLocationsAsync();
    }
}
