namespace FleetRouteManager.Web.Models.ViewModels.TripViewModels
{
    public class TripDeleteViewModel
    {
        public required int Id { get; set; }

        public required string TripNumber { get; set; }

        public required string User { get; set; }
    }
}
