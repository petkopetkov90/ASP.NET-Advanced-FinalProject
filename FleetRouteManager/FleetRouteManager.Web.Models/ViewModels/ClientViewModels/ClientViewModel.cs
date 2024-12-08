namespace FleetRouteManager.Web.Models.ViewModels.ClientViewModels
{
    public class ClientViewModel
    {
        public required int Id { get; set; }

        public required string Name { get; set; }

        public string? PhoneNumber { get; set; }

        public required string ContactEmail { get; set; }

        public required string Address { get; set; }
    }
}
