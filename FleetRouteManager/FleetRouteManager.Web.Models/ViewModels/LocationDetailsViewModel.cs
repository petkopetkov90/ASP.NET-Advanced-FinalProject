namespace FleetRouteManager.Web.Models.ViewModels
{
    public class LocationDetailsViewModel
    {
        public required int Id { get; set; }

        public required string Name { get; set; }

        public string? PhoneNumber { get; set; }

        public required string StreetName { get; set; }

        public string? StreetNumber { get; set; }

        public required string PostCode { get; set; }

        public required string City { get; set; }

        public required string Country { get; set; }
    }
}
