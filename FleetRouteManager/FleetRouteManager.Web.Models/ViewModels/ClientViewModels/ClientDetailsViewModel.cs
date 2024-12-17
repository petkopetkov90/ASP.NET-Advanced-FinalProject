namespace FleetRouteManager.Web.Models.ViewModels.ClientViewModels
{
    public class ClientDetailsViewModel
    {
        public required int Id { get; set; }

        public required string Name { get; set; }

        public string? PhoneNumber { get; set; }

        public required string ContactEmail { get; set; }

        public required string Address { get; set; }

        public required string LegalName { get; set; }

        public required string TaxNumber { get; set; }

        public required string LegalAddress { get; set; }

        public string? PaymentEmail { get; set; }

        public string? PodEmail { get; set; }

        public string? InvoicingEmail { get; set; }

        public required string PostalLocation { get; set; }

    }
}
