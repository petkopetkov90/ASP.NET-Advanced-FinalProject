using FleetRouteManager.Web.Models.ViewModels;

namespace FleetRouteManager.Services.Interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<LocationViewModel>> GetAllLocationsAsync();
        Task<LocationDetailsViewModel?> GetLocationDetailsAsync(int id);
        Task<LocationDeleteViewModel?> GetLocationDeleteModelAsync(int id);
        Task<bool> DeleteLocationAsync(int id);
    }
}
