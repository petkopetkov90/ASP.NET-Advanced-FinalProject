using System.ComponentModel.DataAnnotations;
using FleetRouteManager.Common.Enums;
using static FleetRouteManager.Common.Constants.VehicleConstants;
using static FleetRouteManager.Common.ErrorMessages.VehicleErrorMessages;

namespace FleetRouteManager.Web.Models.InputModels.VehicleInputModels
{
    public class VehicleEditInputModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = VehicleRegistrationNumberRequiredMsg)]
        [StringLength(VehicleRegistrationNumberMaxLength, MinimumLength = VehicleRegistrationNumberMinLength, ErrorMessage = VehicleRegistrationNumberLengthMsg)]
        [RegularExpression(VehicleRegistrationNumberFormatRegex, ErrorMessage = VehicleRegistrationNumberFormatMsg)]
        public string RegistrationNumber { get; set; } = null!;

        [Required(ErrorMessage = VehicleManufacturerRequiredMsg)]
        public int ManufacturerId { get; set; }

        [StringLength(VehicleModelMaxLength, MinimumLength = VehicleModelMinLength, ErrorMessage = VehicleModelLengthMsg)]
        [RegularExpression(VehicleModelFormatRegex, ErrorMessage = VehicleModelFormatMsg)]
        public string? VehicleModel { get; set; }

        [Required(ErrorMessage = VehicleVinRequiredMsg)]
        [StringLength(VehicleVinMaxLength, MinimumLength = VehicleVinMinLength, ErrorMessage = VehicleVinLengthMsg)]
        [RegularExpression(VehicleVinFormatRegex, ErrorMessage = VehicleVinFormatMsg)]
        public string Vin { get; set; } = null!;

        [Required(ErrorMessage = VehicleDateRequiredMsg)]
        [RegularExpression(VehicleDateFormatRegex, ErrorMessage = VehicleDateValidFormatMsg)]
        public string FirstRegistration { get; set; } = null!;

        [Required(ErrorMessage = EuroClassRequiredMsg)]
        public EuroClass EuroClass { get; set; }

        [Required(ErrorMessage = VehicleTypeRequiredMsg)]
        public int VehicleTypeId { get; set; }

        [Required(ErrorMessage = BodyRequiredMsg)]
        public BodyType BodyType { get; set; }

        [Required(ErrorMessage = VehicleAxlesRequiredMsg)]
        [Range(VehicleMinAxles, VehicleMaxAxles, ErrorMessage = VehicleAxlesRangeMsg)]
        public int Axles { get; set; }

        [Required(ErrorMessage = VehicleWeightCapacityRequiredMsg)]
        [Range(VehicleMinWeightCapacity, VehicleMaxWeightCapacity, ErrorMessage = VehicleWeightCapacityRangeMsg)]
        public double WeightCapacity { get; set; }

        [Required(ErrorMessage = VehicleDateRequiredMsg)]
        [RegularExpression(VehicleDateFormatRegex, ErrorMessage = VehicleDateValidFormatMsg)]
        public string AcquiredOn { get; set; } = null!;

        [StringLength(VehicleLiabilityInsuranceMaxLength, MinimumLength = VehicleLiabilityInsuranceMinLength, ErrorMessage = VehicleLiabilityInsuranceLengthMsg)]
        [RegularExpression(VehicleLiabilityInsuranceFormatRegex, ErrorMessage = VehicleLiabilityInsuranceFormatMsg)]
        public string? LiabilityInsurance { get; set; }

        [RegularExpression(VehicleDateFormatRegex, ErrorMessage = VehicleDateValidFormatMsg)]
        public string? LiabilityInsuranceExpirationDate { get; set; }

        [RegularExpression(VehicleDateFormatRegex, ErrorMessage = VehicleDateValidFormatMsg)]
        public string? TechnicalReviewExpirationDate { get; set; }

        [RegularExpression(VehicleDateFormatRegex, ErrorMessage = VehicleDateValidFormatMsg)]
        public string? TachographExpirationDate { get; set; }
    }
}
