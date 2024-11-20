using FleetRouteManager.Common.Enums;
using System.ComponentModel.DataAnnotations;
using static FleetRouteManager.Common.Constants.VehicleConstants;
using static FleetRouteManager.Common.ErrorMessages.VehicleErrorMessages;


namespace FleetRouteManager.Web.Models.InputModels
{
    public class VehicleCreateInputModel
    {
        [Required(ErrorMessage = RegistrationNumberRequiredMsg)]
        [StringLength(RegistrationNumberMaxLength, MinimumLength = RegistrationNumberMinLength, ErrorMessage = RegistrationNumberLengthMsg)]
        public string RegistrationNumber { get; set; } = null!;

        [Required(ErrorMessage = ManufacturerRequiredMsg)]
        public int ManufacturerId { get; set; }

        [StringLength(ModelMaxLength, MinimumLength = ModelMinLength, ErrorMessage = ModelLengthMsg)]
        public string? VehicleModel { get; set; }

        [Required(ErrorMessage = VinRequiredMsg)]
        [StringLength(VinMaxLength, MinimumLength = VinMinLength, ErrorMessage = VinLengthMsg)]
        public string Vin { get; set; } = null!;

        [Required(ErrorMessage = DateRequiredMsg)]
        [RegularExpression(DateFormatRegex, ErrorMessage = DateValidFormatMsg)]
        public string FirstRegistration { get; set; } = null!;

        [Required(ErrorMessage = EuroClassRequiredMsg)]
        public EuroClass EuroClass { get; set; }

        [Required(ErrorMessage = TypeRequiredMsg)]
        public int VehicleTypeId { get; set; }

        [Required(ErrorMessage = BodyRequiredMsg)]
        public BodyType BodyType { get; set; }

        [Required(ErrorMessage = AxlesRequiredMsg)]
        [Range(MinAxles, MaxAxles, ErrorMessage = AxlesRangeMsg)]
        public int Axles { get; set; }

        [Required(ErrorMessage = WeightCapacityRequiredMsg)]
        public double WeightCapacity { get; set; }

        [Required(ErrorMessage = DateRequiredMsg)]
        [RegularExpression(DateFormatRegex, ErrorMessage = DateValidFormatMsg)]
        public string AcquiredOn { get; set; } = null!;

        [StringLength(LiabilityInsuranceMaxLength, MinimumLength = LiabilityInsuranceMinLength, ErrorMessage = LiabilityInsuranceLengthMsg)]
        public string? LiabilityInsurance { get; set; }

        [RegularExpression(DateFormatRegex, ErrorMessage = DateValidFormatMsg)]
        public string? LiabilityInsuranceExpirationDate { get; set; }

        [RegularExpression(DateFormatRegex, ErrorMessage = DateValidFormatMsg)]
        public string? TechnicalReviewExpirationDate { get; set; }

        [RegularExpression(DateFormatRegex, ErrorMessage = DateValidFormatMsg)]
        public string? TachographExpirationDate { get; set; }
    }

}
