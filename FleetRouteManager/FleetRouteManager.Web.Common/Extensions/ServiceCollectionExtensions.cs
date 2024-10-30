using FleetRouteManager.Data.Models.Models;
using FleetRouteManager.Data.Repositories;
using FleetRouteManager.Data.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FleetRouteManager.Web.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSoftDeleteRepositories(this IServiceCollection services)
        {
            services.AddScoped<ISoftDeleteRepository<Vehicle, int>, SoftDeleteRepository<Vehicle, int>>();
            services.AddScoped<ISoftDeleteRepository<Manufacturer, int>, SoftDeleteRepository<Manufacturer, int>>();
            services.AddScoped<ISoftDeleteRepository<VehicleType, int>, SoftDeleteRepository<VehicleType, int>>();

            return services;
        }
    }
}
