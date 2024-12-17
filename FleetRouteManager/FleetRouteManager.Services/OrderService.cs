using FleetRouteManager.Data.Models;
using FleetRouteManager.Data.Repositories.Interfaces;
using FleetRouteManager.Services.Interfaces;
using FleetRouteManager.Web.Models.ViewModels.OrderViewModels;
using Microsoft.EntityFrameworkCore;
using static FleetRouteManager.Common.Constants.OrderConstants;

namespace FleetRouteManager.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order, int> repository;

        public OrderService(IRepository<Order, int> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<OrderViewModel>> GetAllOrdersAsync()
        {
            var orders = await repository.GetWhereAsIQueryable(o => !o.IsDeleted)
                .Include(o => o.Client)
                .OrderBy(o => o.OrderDate)
                .AsNoTracking()
                .Select(o => new OrderViewModel()
                {
                    Id = o.Id,
                    OrderNumber = o.OrderNumber,
                    OrderDate = o.OrderDate.ToString(OrderDateFormat),
                    Amount = o.Amount,
                    User = o.User,
                    Client = o.Client.Name,
                    ClientId = o.ClientId

                })
                .ToListAsync();

            return orders;
        }
    }
}
