using FleetRouteManager.Web.Models.ViewModels.OrderViewModels;

namespace FleetRouteManager.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderViewModel>> GetAllOrdersAsync();
    }
}
