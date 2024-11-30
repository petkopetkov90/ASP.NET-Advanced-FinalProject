namespace FleetRouteManager.Web.Models.ViewModels.AddressViewModels
{
    public class AddressDetailsViewModel
    {
        public required int Id { get; set; }

        public required string StreetName { get; set; }

        public string? StreetNumber { get; set; }

        public required string PostCode { get; set; }

        public required string City { get; set; }

        public required string Country { get; set; }
    }
}
