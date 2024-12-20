using System.ComponentModel.DataAnnotations;
using static FleetRouteManager.Common.Constants.LocationConstants;
using static FleetRouteManager.Common.ErrorMessages.LocationErrorMessages;

namespace FleetRouteManager.Web.Models.InputModels.LocationInputModels
{
    public class LocationEditInputModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = LocationNameRequiredMsg)]
        [StringLength(LocationNameMaxLength, MinimumLength = LocationNameMinLength, ErrorMessage = LocationNameLengthMsg)]
        [RegularExpression(LocationNameFormatRegex, ErrorMessage = LocationNameFormatMsg)]
        public string Name { get; set; } = null!;

        [StringLength(LocationPhoneMaxLength, MinimumLength = LocationPhoneMinLength, ErrorMessage = LocationPhoneNumberLengthMsg)]
        [RegularExpression(LocationPhoneFormatRegex, ErrorMessage = LocationPhoneNumberFormatMsg)]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = LocationAddressRequiredMsg)]
        public int AddressId { get; set; }
    }
}
