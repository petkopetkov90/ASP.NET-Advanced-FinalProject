namespace FleetRouteManager.Web.Models.ViewModels.OrderViewModels
{
    public class OrderViewModel
    {
        public required int Id { get; set; }

        public required string OrderNumber { get; set; }

        public required string OrderDate { get; set; }

        public required decimal Amount { get; set; }

        public required string User { get; set; }

        public required string Client { get; set; }

        public required int ClientId { get; set; }
    }
}
