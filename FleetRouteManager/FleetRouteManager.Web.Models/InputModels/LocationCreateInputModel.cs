using System.ComponentModel.DataAnnotations;
using static FleetRouteManager.Common.Constants.LocationConstants;
using static FleetRouteManager.Common.ErrorMessages.LocationErrorMessages;

namespace FleetRouteManager.Web.Models.InputModels
{
    public class LocationCreateInputModel
    {
        [Required(ErrorMessage = NameRequiredMsg)]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = NameLengthMsg)]
        [RegularExpression(NameFormatRegex, ErrorMessage = NameFormatMsg)]
        public string Name { get; set; } = null!;

        [StringLength(PhoneMaxLength, MinimumLength = PhoneMinLength, ErrorMessage = PhoneLengthMsg)]
        [RegularExpression(PhoneFormatRegex, ErrorMessage = PhoneFormatMsg)]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = StreetRequiredMsg)]
        [StringLength(StreetNameMaxLength, MinimumLength = StreetNameMinLength, ErrorMessage = StreetNameLengthMsg)]
        [RegularExpression(StreetNameFormatRegex, ErrorMessage = StreetNameFormatMsg)]
        public string StreetName { get; set; } = null!;

        [StringLength(StreetNumberMaxLength, MinimumLength = StreetNumberMinLength, ErrorMessage = StreetNumberLengthMsg)]
        [RegularExpression(StreetNumberFormatRegex, ErrorMessage = StreetNumberFormatMsg)]
        public string? StreetNumber { get; set; }

        [Required(ErrorMessage = PostCodeRequiredMsg)]
        [StringLength(PostCodeMaxLength, MinimumLength = PostCodeMinLength, ErrorMessage = PostCodeLengthMsg)]
        [RegularExpression(PostCodeFormatRegex, ErrorMessage = PostCodeFormatMsg)]
        public string PostCode { get; set; } = null!;

        [Required(ErrorMessage = CityRequiredMsg)]
        [StringLength(CityMaxLength, MinimumLength = CityMinLength, ErrorMessage = CityLengthMsg)]
        [RegularExpression(CityFormatRegex, ErrorMessage = CityFormatMsg)]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = CountryRequiredMsg)]
        public int CountryId { get; set; }
    }
}
