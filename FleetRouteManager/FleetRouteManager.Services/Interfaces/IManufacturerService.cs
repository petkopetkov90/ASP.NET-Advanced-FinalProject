using FleetRouteManager.Web.Models.ViewModels.ManufacturerViewModels;

namespace FleetRouteManager.Services.Interfaces
{
    public interface IManufacturerService
    {
        Task<IEnumerable<ManufacturerViewBagListModel>> GetManufacturersViewBagListAsync();
    }
}
