using FleetRouteManager.Web.Models.ViewModels.TripViewModels;

namespace FleetRouteManager.Services.Interfaces
{
    public interface ITripService
    {
        Task<IEnumerable<TripViewModel>> GetAllTripsAsync();
        Task<TripDetailsViewModel?> GetTripDetailsAsync(int id);
        Task<TripDeleteViewModel?> GetTripDeleteModelAsync(int id);
        Task<bool> DeleteTripAsync(int id, string? user);
        Task<IEnumerable<TripViewModel>> GetMyTripsAsync(string user);
    }
}
