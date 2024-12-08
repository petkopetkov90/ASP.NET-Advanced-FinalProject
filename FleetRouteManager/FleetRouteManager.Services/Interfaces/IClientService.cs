using FleetRouteManager.Web.Models.InputModels.ClientInputModels;
using FleetRouteManager.Web.Models.ViewModels.ClientViewModels;

namespace FleetRouteManager.Services.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientViewModel>> GetAllClientsAsync();
        Task<ClientDetailsViewModel?> GetClientDetailsAsync(int id);
        Task<ClientDeleteViewModel?> GetClientDeleteModelAsync(int id);
        Task<bool> DeleteClientAsync(int id);
        Task<int> CrateNewClientAsync(ClientCreateInputModel model);
        Task<ClientEditInputModel?> GetClientEditModelAsync(int id);
        Task<bool> EditClientAsync(ClientEditInputModel model);
    }
}
