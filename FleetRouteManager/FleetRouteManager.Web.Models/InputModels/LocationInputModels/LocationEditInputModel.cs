using System.ComponentModel.DataAnnotations;
using static FleetRouteManager.Common.Constants.LocationConstants;
using static FleetRouteManager.Common.ErrorMessages.LocationErrorMessages;

namespace FleetRouteManager.Web.Models.InputModels.LocationInputModels
{
    public class LocationEditInputModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = LocationNameRequiredMsg)]
        [StringLength(LocationNameMaxLength, MinimumLength = LocationNameMinLength, ErrorMessage = LocationNameLengthMsg)]
        [RegularExpression(LocationNameFormatRegex, ErrorMessage = LocationNameFormatMsg)]
        public string Name { get; set; } = null!;

        [StringLength(LocationPhoneMaxLength, MinimumLength = LocationPhoneMinLength, ErrorMessage = LocationPhoneNumberLengthMsg)]
        [RegularExpression(LocationPhoneFormatRegex, ErrorMessage = LocationPhoneNumberFormatMsg)]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = LocationStreetNameRequiredMsg)]
        [StringLength(LocationStreetNameMaxLength, MinimumLength = LocationStreetNameMinLength, ErrorMessage = LocationStreetNameLengthMsg)]
        [RegularExpression(LocationStreetNameFormatRegex, ErrorMessage = LocationStreetNameFormatMsg)]
        public string StreetName { get; set; } = null!;

        [StringLength(LocationStreetNumberMaxLength, MinimumLength = LocationStreetNumberMinLength, ErrorMessage = LocationStreetNumberLengthMsg)]
        [RegularExpression(LocationStreetNumberFormatRegex, ErrorMessage = LocationStreetNumberFormatMsg)]
        public string? StreetNumber { get; set; }

        [Required(ErrorMessage = LocationPostCodeRequiredMsg)]
        [StringLength(LocationPostCodeMaxLength, MinimumLength = LocationPostCodeMinLength, ErrorMessage = LocationPostCodeLengthMsg)]
        [RegularExpression(LocationPostCodeFormatRegex, ErrorMessage = LocationPostCodeFormatMsg)]
        public string PostCode { get; set; } = null!;

        [Required(ErrorMessage = LocationCityNameRequiredMsg)]
        [StringLength(LocationCityMaxLength, MinimumLength = LocationCityMinLength, ErrorMessage = LocationCityNameLengthMsg)]
        [RegularExpression(LocationCityFormatRegex, ErrorMessage = LocationCityNameFormatMsg)]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = LocationCountryRequiredMsg)]
        public int CountryId { get; set; }
    }
}
