using FleetRouteManager.Web.Models.ViewModels.OrderViewModels;

namespace FleetRouteManager.Web.Models.ViewModels.TripViewModels
{
    public class TripViewModel
    {
        public required int Id { get; set; }

        public required string TripNumber { get; set; }

        public required decimal Amount { get; set; }

        public int VehicleId { get; set; }

        public required string Vehicle { get; set; }

        public required string User { get; set; }

        public virtual ICollection<OrderTripViewModel> Orders { get; set; } = new List<OrderTripViewModel>();
    }
}
