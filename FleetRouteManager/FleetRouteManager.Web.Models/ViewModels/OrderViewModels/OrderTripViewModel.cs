namespace FleetRouteManager.Web.Models.ViewModels.OrderViewModels
{
    public class OrderTripViewModel
    {
        public required int Id { get; set; }

        public required string OrderNumber { get; set; }

        public required decimal Amount { get; set; }
    }
}
