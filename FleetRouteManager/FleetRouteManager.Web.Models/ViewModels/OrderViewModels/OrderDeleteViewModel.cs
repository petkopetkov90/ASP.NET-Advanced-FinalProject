namespace FleetRouteManager.Web.Models.ViewModels.OrderViewModels
{
    public class OrderDeleteViewModel
    {
        public required int Id { get; set; }

        public required string OrderNumber { get; set; }

        public required string User { get; set; }
    }
}
