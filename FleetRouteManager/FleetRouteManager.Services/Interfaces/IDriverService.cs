using FleetRouteManager.Web.Models.InputModels.DriverInputModels;
using FleetRouteManager.Web.Models.ViewModels.DriverViewModels;

namespace FleetRouteManager.Services.Interfaces
{
    public interface IDriverService
    {
        Task<IEnumerable<DriverViewModel>> GetAllDriversAsync();
        Task<DriverDetailsViewModel?> GetDriverDetailsAsync(int id);
        Task<DriverDeleteViewModel?> GetDriverDeleteModelAsync(int id);
        Task<bool> DeleteDriverAsync(int id);
        Task<bool> AssignNewDriverAsync(DriverCreateInputModel model);
        Task<DriverEditInputModel> GetDriverEditModelAsync(int id);
        Task<bool> EditDriverAsync(DriverEditInputModel model);
    }
}
