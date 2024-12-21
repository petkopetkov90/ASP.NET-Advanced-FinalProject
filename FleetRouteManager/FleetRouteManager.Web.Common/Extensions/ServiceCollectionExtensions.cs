using FleetRouteManager.Data.Models;
using FleetRouteManager.Data.Repositories;
using FleetRouteManager.Data.Repositories.Interfaces;
using FleetRouteManager.Services;
using FleetRouteManager.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FleetRouteManager.Web.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static void AddApplicationRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Vehicle, int>, Repository<Vehicle, int>>();
            services.AddScoped<IRepository<Manufacturer, int>, Repository<Manufacturer, int>>();
            services.AddScoped<IRepository<VehicleType, int>, Repository<VehicleType, int>>();
            services.AddScoped<IRepository<Driver, int>, Repository<Driver, int>>();
            services.AddScoped<IRepository<Continent, int>, Repository<Continent, int>>();
            services.AddScoped<IRepository<Country, int>, Repository<Country, int>>();
            services.AddScoped<IRepository<Location, int>, Repository<Location, int>>();
            services.AddScoped<IRepository<Address, int>, Repository<Address, int>>();
            services.AddScoped<IRepository<Client, int>, Repository<Client, int>>();
            services.AddScoped<IRepository<Order, int>, Repository<Order, int>>();
            services.AddScoped<IRepository<Trip, int>, Repository<Trip, int>>();
        }

        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IManufacturerService, ManufacturerService>();
            services.AddScoped<IVehicleTypeService, VehicleTypeService>();
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ITripService, TripService>();
        }
    }
}
