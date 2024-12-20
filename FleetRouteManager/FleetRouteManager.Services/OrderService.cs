using FleetRouteManager.Common.Exceptions;
using FleetRouteManager.Data.Models;
using FleetRouteManager.Data.Repositories.Interfaces;
using FleetRouteManager.Services.Interfaces;
using FleetRouteManager.Web.Models.InputModels.OrderInputModels;
using FleetRouteManager.Web.Models.ViewModels.OrderViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static FleetRouteManager.Common.Constants.OrderConstants;
using static FleetRouteManager.Common.ErrorMessages.ExceptionMessages;
using static FleetRouteManager.Common.Parsers.CustomDateParsers;


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

        public async Task<OrderDetailsViewModel?> GetOrderDetailsAsync(int id)
        {
            var model = await repository.GetWhereAsIQueryable(o => o.Id == id && !o.IsDeleted)
                .Include(o => o.Client)
                .AsNoTracking()
                .Select(o => new OrderDetailsViewModel()
                {
                    Id = o.Id,
                    OrderNumber = o.OrderNumber,
                    OrderDate = o.OrderDate.ToString(OrderDateFormat),
                    Amount = o.Amount,
                    User = o.User,
                    Client = o.Client.Name,
                })
                .FirstOrDefaultAsync();

            return model;
        }

        public async Task<OrderDeleteViewModel?> GetOrderDeleteModelAsync(int id)
        {
            var model = await repository.GetWhereAsIQueryable(o => o.Id == id && !o.IsDeleted)
                .AsNoTracking()
                .Select(o => new OrderDeleteViewModel
                {
                    Id = o.Id,
                    OrderNumber = o.OrderNumber,
                    User = o.User
                })
                .FirstOrDefaultAsync();

            return model;
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = await repository.GetByIdAsync(id);

            if (order == null || order.IsDeleted)
            {
                return false;
            }

            order.IsDeleted = true;
            order.DeletedOn = DateTime.Now;

            return await repository.UpdateAsync(order);
        }

        public async Task<int> CreateNewOrderAsync(OrderCreateInputModel model)
        {
            var order = new Order()
            {
                OrderNumber = model.OrderNumber,
                OrderDate = CustomStringToDateParseExact(model.OrderDate, OrderDateFormat, nameof(model.OrderDate)),
                Amount = model.Amount,
                User = model.User,
                ClientId = model.ClientId
            };

            try
            {
                if (await repository.AddAsync(order))
                {
                    return order.Id;
                }

                return 0;
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException is SqlException inner)
                {
                    if (inner.Number is 2601 or 2627)
                    {
                        throw new CustomExistingEntityException(string.Format(ExistingEntityExceptionMsg, order.GetType().Name));
                    }
                }

                throw;
            }
        }

        public async Task<OrderEditInputModel?> GetOrderEditModelAsync(int id)
        {
            var order = await repository.GetByIdAsync(id);

            if (order == null || order.IsDeleted)
            {
                return null;
            }

            var model = new OrderEditInputModel
            {
                Id = order.Id,
                OrderNumber = order.OrderNumber,
                OrderDate = order.OrderDate.ToString(OrderDateFormat),
                Amount = order.Amount,
                User = order.User,
                ClientId = order.ClientId,
                TripId = order.TripId
            };

            return model;
        }

        public async Task<bool> EditOrderAsync(OrderEditInputModel model)
        {
            var order = await repository.GetByIdAsync(model.Id);

            if (order == null || order.IsDeleted)
            {
                return false;
            }

            order.OrderNumber = model.OrderNumber;
            order.OrderDate = CustomStringToDateParseExact(model.OrderDate, OrderDateFormat, nameof(model.OrderDate));
            order.Amount = model.Amount;
            order.User = model.User;
            order.ClientId = model.ClientId;

            try
            {
                return await repository.UpdateAsync(order);
            }
            catch (DbUpdateException e)
            {
                if (e.InnerException is SqlException inner)
                {
                    if (inner.Number is 2601 or 2627)
                    {
                        throw new CustomExistingEntityException(string.Format(ExistingEntityExceptionMsg, order.GetType().Name));
                    }
                }

                throw;
            }
        }

        public async Task<IEnumerable<OrderViewModel>> GetMyOrdersAsync(string user)
        {
            var orders = await repository.GetWhereAsIQueryable(o => !o.IsDeleted && o.User == user)
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
