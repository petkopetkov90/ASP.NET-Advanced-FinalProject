using FleetRouteManager.Web.Models.ViewModels.ClientViewModels;

namespace FleetRouteManager.Services.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientViewModel>> GetAllClientsAsync();
    }
}
