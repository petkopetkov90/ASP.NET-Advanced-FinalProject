using System.ComponentModel.DataAnnotations;
using static FleetRouteManager.Common.Constants.ClientConstants;
using static FleetRouteManager.Common.ErrorMessages.ClientErrorMessages;

namespace FleetRouteManager.Web.Models.InputModels.ClientInputModels
{
    public class ClientCreateInputModel
    {
        [Required(ErrorMessage = ClientNameRequiredMsg)]
        [StringLength(ClientNameMaxLength, MinimumLength = ClientNameMinLength, ErrorMessage = ClientNameLengthMsg)]
        [RegularExpression(ClientNameFormatRegex, ErrorMessage = ClientNameFormatMsg)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = ClientTaxNumberRequiredMsg)]
        [StringLength(ClientTaxNumberMaxLength, MinimumLength = ClientTaxNumberMinLength, ErrorMessage = ClientTaxNumberLengthMsg)]
        [RegularExpression(ClientTaxNumberFormatRegex, ErrorMessage = ClientTaxNumberFormatMsg)]
        public string TaxNumber { get; set; } = null!;

        [Required(ErrorMessage = ClientNameRequiredMsg)]
        [StringLength(ClientNameMaxLength, MinimumLength = ClientNameMinLength, ErrorMessage = ClientNameLengthMsg)]
        [RegularExpression(ClientNameFormatRegex, ErrorMessage = ClientNameFormatMsg)]
        public string LegalName { get; set; } = null!;

        [Required(ErrorMessage = ClientAddressRequiredMsg)]
        public int AddressId { get; set; }

        public int? LegalAddressId { get; set; }

        public int? PostalAddressId { get; set; }

        [StringLength(ClientPhoneMaxLength, MinimumLength = ClientPhoneMinLength, ErrorMessage = ClientPhoneNumberLengthMsg)]
        [RegularExpression(ClientPhoneFormatRegex, ErrorMessage = ClientPhoneNumberFormatMsg)]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = ClientEmailRequiredMsg)]
        [StringLength(ClientEmailMaxLength, MinimumLength = ClientEmailMinLength, ErrorMessage = ClientEmailLengthMsg)]
        [RegularExpression(ClientEmailFormatRegex, ErrorMessage = ClientEmailFormatMsg)]
        public string ContactEmail { get; set; } = null!;

        [StringLength(ClientEmailMaxLength, MinimumLength = ClientEmailMinLength, ErrorMessage = ClientEmailLengthMsg)]
        [RegularExpression(ClientEmailFormatRegex, ErrorMessage = ClientEmailFormatMsg)]
        public string? PodEmail { get; set; }

        [StringLength(ClientEmailMaxLength, MinimumLength = ClientEmailMinLength, ErrorMessage = ClientEmailLengthMsg)]
        [RegularExpression(ClientEmailFormatRegex, ErrorMessage = ClientEmailFormatMsg)]
        public string? InvoicingEmail { get; set; }

        [StringLength(ClientEmailMaxLength, MinimumLength = ClientEmailMinLength, ErrorMessage = ClientEmailLengthMsg)]
        [RegularExpression(ClientEmailFormatRegex, ErrorMessage = ClientEmailFormatMsg)]
        public string? PaymentEmail { get; set; }
    }
}
