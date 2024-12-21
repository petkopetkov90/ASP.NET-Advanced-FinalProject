using FleetRouteManager.Web.Models.ViewModels.OrderViewModels;

namespace FleetRouteManager.Web.Models.ViewModels.TripViewModels
{
    public class TripDetailsViewModel
    {
        public required int Id { get; set; }

        public required string TripNumber { get; set; }

        public required decimal Amount { get; set; }

        public required string Vehicle { get; set; }

        public required string User { get; set; }

        public required string StartDate { get; set; }

        public required string EndDate { get; set; }

        public required string StartingLocation { get; set; }

        public required string EndingLocation { get; set; }

        public required string Driver { get; set; } = null!;

        public string? SecondDriver { get; set; }

        public virtual ICollection<OrderTripViewModel> Orders { get; set; } = new List<OrderTripViewModel>();
    }
}
