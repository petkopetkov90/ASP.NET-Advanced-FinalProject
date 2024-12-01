using FleetRouteManager.Web.Models.InputModels.LocationInputModels;
using FleetRouteManager.Web.Models.ViewModels.LocationViewModels;

namespace FleetRouteManager.Services.Interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<LocationViewModel>> GetAllLocationsAsync();
        Task<LocationDetailsViewModel?> GetLocationDetailsAsync(int id);
        Task<LocationDeleteViewModel?> GetLocationDeleteModelAsync(int id);
        Task<bool> DeleteLocationAsync(int id);
        Task<bool> CreateNewLocationAsync(LocationCreateInputModel model);
        Task<LocationEditInputModel?> GetLocationEditModelAsync(int id);
        Task<bool> EditLocationAsync(LocationEditInputModel model);
    }
}
