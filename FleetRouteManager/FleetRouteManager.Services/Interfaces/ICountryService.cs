using FleetRouteManager.Web.Models.ViewModels.CountryViewModels;

namespace FleetRouteManager.Services.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryViewBagListModel>> GetCountryViewBagListAsync();
    }
}
