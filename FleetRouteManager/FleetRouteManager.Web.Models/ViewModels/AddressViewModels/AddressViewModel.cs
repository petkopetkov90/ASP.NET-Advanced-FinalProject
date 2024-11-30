namespace FleetRouteManager.Web.Models.ViewModels.AddressViewModels
{
    public class AddressViewModel
    {
        public required int Id { get; set; }

        public required string PostCode { get; set; }

        public required string City { get; set; }

        public required string Country { get; set; }
    }
}
