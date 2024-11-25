namespace FleetRouteManager.Web.Models.ViewModels
{
    public class LocationViewModel
    {
        public required int Id { get; set; }

        public required string Name { get; set; }

        public required string PostCode { get; set; }

        public required string City { get; set; }

        public required string Country { get; set; }
    }
}
