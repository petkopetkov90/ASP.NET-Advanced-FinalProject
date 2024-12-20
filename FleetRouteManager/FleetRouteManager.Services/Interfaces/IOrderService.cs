using FleetRouteManager.Web.Models.InputModels.OrderInputModels;
using FleetRouteManager.Web.Models.ViewModels.OrderViewModels;

namespace FleetRouteManager.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderViewModel>> GetAllOrdersAsync();
        Task<OrderDetailsViewModel?> GetOrderDetailsAsync(int id);
        Task<OrderDeleteViewModel?> GetOrderDeleteModelAsync(int id);
        Task<bool> DeleteOrderAsync(int id);
        Task<int> CreateNewOrderAsync(OrderCreateInputModel model);
        Task<OrderEditInputModel?> GetOrderEditModelAsync(int id);
        Task<bool> EditOrderAsync(OrderEditInputModel model);
        Task<IEnumerable<OrderViewModel>> GetMyOrdersAsync(string user);
    }
}
