using FleetRouteManager.Data.Models;
using FleetRouteManager.Data.Repositories.Interfaces;
using FleetRouteManager.Services.Interfaces;
using FleetRouteManager.Web.Models.ViewModels.OrderViewModels;
using FleetRouteManager.Web.Models.ViewModels.TripViewModels;
using Microsoft.EntityFrameworkCore;
using static FleetRouteManager.Common.Constants.TripConstants;

namespace FleetRouteManager.Services
{
    public class TripService : ITripService
    {
        private readonly IRepository<Trip, int> repository;

        public TripService(IRepository<Trip, int> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<TripViewModel>> GetAllTripsAsync()
        {
            var trips = await repository.GetWhereAsIQueryable(t => !t.IsDeleted)
                .Include(t => t.Orders)
                .Include(t => t.Vehicle)
                .OrderBy(t => t.TripNumber)
                .AsNoTracking()
                .Select(t => new TripViewModel()
                {
                    Id = t.Id,
                    TripNumber = t.TripNumber,
                    VehicleId = t.VehicleId,
                    Vehicle = t.Vehicle.RegistrationNumber,
                    User = t.User,
                    Amount = t.Orders.Sum(o => o.Amount),
                    Orders = t.Orders
                        .Select(o => new OrderTripViewModel()
                        {
                            Id = o.Id,
                            OrderNumber = o.OrderNumber,
                            Amount = o.Amount,
                        }).ToList()

                })
                .ToListAsync();

            return trips;
        }

        public async Task<TripDetailsViewModel?> GetTripDetailsAsync(int id)
        {
            var model = await repository.GetWhereAsIQueryable(t => t.Id == id && !t.IsDeleted)
                .Include(t => t.StartingLocation)
                .ThenInclude(l => l.Address)
                .ThenInclude(a => a.Country)
                .Include(t => t.EndingLocation)
                .ThenInclude(l => l.Address)
                .ThenInclude(a => a.Country)
                .Include(t => t.Vehicle)
                .Include(t => t.Driver)
                .Include(t => t.SecondDriver)
                .AsNoTracking()
                .Select(t => new TripDetailsViewModel()
                {
                    Id = t.Id,
                    TripNumber = t.TripNumber,
                    Vehicle = t.Vehicle.RegistrationNumber,
                    User = t.User,
                    Amount = t.Orders.Sum(o => o.Amount),
                    Orders = t.Orders
                        .Select(o => new OrderTripViewModel()
                        {
                            Id = o.Id,
                            OrderNumber = o.OrderNumber,
                            Amount = o.Amount,
                        }).ToList(),
                    StartDate = t.StartDate.ToString(TripDateFormat),
                    EndDate = t.EndDate.ToString(TripDateFormat),
                    StartingLocation = FormatLocationToString(t.StartingLocation),
                    EndingLocation = FormatLocationToString(t.EndingLocation),
                    Driver = FormatDriverToString(t.Driver),
                    SecondDriver = FormatDriverToString(t.SecondDriver),

                })
                .FirstOrDefaultAsync();

            return model;
        }

        public async Task<TripDeleteViewModel?> GetTripDeleteModelAsync(int id)
        {
            var model = await repository.GetWhereAsIQueryable(t => t.Id == id && !t.IsDeleted)
                .AsNoTracking()
                .Select(t => new TripDeleteViewModel()
                {
                    Id = t.Id,
                    TripNumber = t.TripNumber,
                    User = t.User
                })
                .FirstOrDefaultAsync();

            return model;
        }

        public async Task<bool> DeleteTripAsync(int id, string? user)
        {
            var trip = await repository.GetByIdAsync(id);

            if (trip == null || trip.IsDeleted)
            {
                return false;
            }

            if (user != "admin@myapp.com" && trip.User != user)
            {
                return false;
            }

            trip.IsDeleted = true;
            trip.DeletedOn = DateTime.Now;

            return await repository.UpdateAsync(trip);
        }

        public async Task<IEnumerable<TripViewModel>> GetMyTripsAsync(string user)
        {
            var trips = await repository.GetWhereAsIQueryable(t => !t.IsDeleted && t.User == user)
                .Include(t => t.Orders)
                .Include(t => t.Vehicle)
                .OrderBy(t => t.TripNumber)
                .AsNoTracking()
                .Select(t => new TripViewModel()
                {
                    Id = t.Id,
                    TripNumber = t.TripNumber,
                    VehicleId = t.VehicleId,
                    Vehicle = t.Vehicle.RegistrationNumber,
                    User = t.User,
                    Amount = t.Orders.Sum(o => o.Amount),
                    Orders = t.Orders
                        .Select(o => new OrderTripViewModel()
                        {
                            Id = o.Id,
                            OrderNumber = o.OrderNumber,
                            Amount = o.Amount,
                        }).ToList()

                })
                .ToListAsync();

            return trips;
        }


        private static string FormatDriverToString(Driver? driver)
        {
            if (driver == null)
            {
                return string.Empty;
            }

            return $"{driver.FirstName} {driver.MiddleName} {driver.LastName}".Trim();
        }

        private static string FormatLocationToString(Location? location)
        {
            if (location?.Address == null)
            {
                return string.Empty;
            }

            return $"{location.Name} - {location.Address.Street} {(location.Address.Number ?? "").Trim()}, {location.Address.PostCode} {location.Address.City}, {location.Address.Country.Name}".Trim();
        }
    }
}
