using System.ComponentModel.DataAnnotations;
using static FleetRouteManager.Common.Constants.AddressConstants;
using static FleetRouteManager.Common.Constants.LocationConstants;
using static FleetRouteManager.Common.ErrorMessages.AddressErrorMessages;
using static FleetRouteManager.Common.ErrorMessages.LocationErrorMessages;

namespace FleetRouteManager.Web.Models.InputModels.LocationInputModels
{
    public class LocationCreateInputModel
    {
        [Required(ErrorMessage = LocationNameRequiredMsg)]
        [StringLength(LocationNameMaxLength, MinimumLength = LocationNameMinLength, ErrorMessage = LocationNameLengthMsg)]
        [RegularExpression(LocationNameFormatRegex, ErrorMessage = LocationNameFormatMsg)]
        public string Name { get; set; } = null!;

        [StringLength(LocationPhoneMaxLength, MinimumLength = LocationPhoneMinLength, ErrorMessage = LocationPhoneNumberLengthMsg)]
        [RegularExpression(LocationPhoneFormatRegex, ErrorMessage = LocationPhoneNumberFormatMsg)]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = AddressStreetNameRequiredMsg)]
        [StringLength(AddressStreetNameMaxLength, MinimumLength = AddressStreetNameMinLength, ErrorMessage = AddressStreetNameLengthMsg)]
        [RegularExpression(AddressStreetNameFormatRegex, ErrorMessage = AddressStreetNameFormatMsg)]
        public string StreetName { get; set; } = null!;

        [StringLength(AddressStreetNumberMaxLength, MinimumLength = AddressStreetNumberMinLength, ErrorMessage = AddressStreetNumberLengthMsg)]
        [RegularExpression(AddressStreetNameFormatRegex, ErrorMessage = AddressStreetNameFormatMsg)]
        public string? StreetNumber { get; set; }

        [Required(ErrorMessage = AddressPostCodeRequiredMsg)]
        [StringLength(AddressPostCodeMaxLength, MinimumLength = AddressStreetNameMinLength, ErrorMessage = AddressStreetNameLengthMsg)]
        [RegularExpression(AddressStreetNameFormatRegex, ErrorMessage = AddressStreetNameFormatMsg)]
        public string PostCode { get; set; } = null!;

        [Required(ErrorMessage = AddressCityNameRequiredMsg)]
        [StringLength(AddressStreetNumberMaxLength, MinimumLength = AddressStreetNumberMinLength, ErrorMessage = AddressStreetNameLengthMsg)]
        [RegularExpression(AddressStreetNameFormatRegex, ErrorMessage = AddressStreetNameFormatMsg)]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = AddressCountryRequiredMsg)]
        public int CountryId { get; set; }
    }
}
