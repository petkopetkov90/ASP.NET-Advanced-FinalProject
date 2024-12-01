using FleetRouteManager.Web.Models.InputModels.AddressInputModels;
using FleetRouteManager.Web.Models.ViewModels.AddressViewModels;

namespace FleetRouteManager.Services.Interfaces
{
    public interface IAddressService
    {
        Task<IEnumerable<AddressViewBagListModel>> GetAddressViewBagListAsync();
        Task<bool> AddNewAddressAsync(AddressCreateInputModel model);
    }
}
