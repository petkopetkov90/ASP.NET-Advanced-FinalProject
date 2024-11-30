using FleetRouteManager.Data.Models;

namespace FleetRouteManager.Services.Interfaces
{
    public interface IAddressService
    {
        Task<int> GetAddressIdAsync(Address address);
    }
}
