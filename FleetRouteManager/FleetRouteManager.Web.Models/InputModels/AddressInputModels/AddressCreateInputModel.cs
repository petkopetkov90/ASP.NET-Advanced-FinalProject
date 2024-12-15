using System.ComponentModel.DataAnnotations;
using static FleetRouteManager.Common.Constants.AddressConstants;
using static FleetRouteManager.Common.ErrorMessages.AddressErrorMessages;

namespace FleetRouteManager.Web.Models.InputModels.AddressInputModels
{
    public class AddressCreateInputModel
    {
        [Required(ErrorMessage = AddressStreetNameRequiredMsg)]
        [StringLength(AddressStreetNameMaxLength, MinimumLength = AddressStreetNameMinLength, ErrorMessage = AddressStreetNameLengthMsg)]
        [RegularExpression(AddressStreetNameFormatRegex, ErrorMessage = AddressStreetNameFormatMsg)]
        public string StreetName { get; set; } = null!;

        [StringLength(AddressStreetNumberMaxLength, MinimumLength = AddressStreetNumberMinLength, ErrorMessage = AddressStreetNumberLengthMsg)]
        [RegularExpression(AddressStreetNameFormatRegex, ErrorMessage = AddressStreetNumberFormatMsg)]
        public string? StreetNumber { get; set; }

        [Required(ErrorMessage = AddressPostCodeRequiredMsg)]
        [StringLength(AddressPostCodeMaxLength, MinimumLength = AddressStreetNameMinLength, ErrorMessage = AddressStreetNameLengthMsg)]
        [RegularExpression(AddressStreetNameFormatRegex, ErrorMessage = AddressPostCodeFormatMsg)]
        public string PostCode { get; set; } = null!;

        [Required(ErrorMessage = AddressCityNameRequiredMsg)]
        [StringLength(AddressStreetNumberMaxLength, MinimumLength = AddressStreetNumberMinLength, ErrorMessage = AddressStreetNameLengthMsg)]
        [RegularExpression(AddressStreetNameFormatRegex, ErrorMessage = AddressCityNameFormatMsg)]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = AddressCountryRequiredMsg)]
        public int CountryId { get; set; }
    }
}
