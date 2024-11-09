using FleetRouteManager.Common.Enums;
using System.ComponentModel.DataAnnotations;
using static FleetRouteManager.Common.Constants.VehicleConstants;
using static FleetRouteManager.Data.Common.ErrorMessages.VehicleErrorMessages;


namespace FleetRouteManager.Web.Models.InputModels
{
    public class VehicleCreateInputModel
    {
        [Required(ErrorMessage = RegistrationNumberRequired)]
        [StringLength(RegistrationNumberMaxLength, MinimumLength = RegistrationNumberMinLength, ErrorMessage = RegistrationNumberLength)]
        public string RegistrationNumber { get; set; } = null!;

        [Required(ErrorMessage = ManufacturerRequired)]
        public int ManufacturerId { get; set; }

        [StringLength(ModelMaxLength, MinimumLength = ModelMinLength, ErrorMessage = ModelLength)]
        public string? VehicleModel { get; set; }

        [Required(ErrorMessage = VinRequired)]
        [StringLength(VinMaxLength, MinimumLength = VinMinLength, ErrorMessage = VinLength)]
        public string Vin { get; set; } = null!;

        [Required(ErrorMessage = DateRequired)]
        [RegularExpression(DateFormatRegex, ErrorMessage = DateValidFormat)]
        public string FirstRegistration { get; set; } = null!;

        [Required(ErrorMessage = EuroClassRequired)]
        public EuroClass EuroClass { get; set; }

        [Required(ErrorMessage = TypeRequired)]
        public int VehicleTypeId { get; set; }

        [Required(ErrorMessage = BodyRequired)]
        public BodyType BodyType { get; set; }

        [Required(ErrorMessage = AxlesRequired)]
        [Range(MinAxles, MaxAxles, ErrorMessage = AxlesRange)]
        public int Axles { get; set; }

        [Required(ErrorMessage = WeightCapacityRequired)]
        public double WeightCapacity { get; set; }

        [Required(ErrorMessage = DateRequired)]
        [RegularExpression(DateFormatRegex, ErrorMessage = DateValidFormat)]
        public string AcquiredOn { get; set; } = null!;

        [StringLength(LiabilityInsuranceMaxLength, MinimumLength = LiabilityInsuranceMinLength, ErrorMessage = LiabilityInsuranceLength)]
        public string? LiabilityInsurance { get; set; }

        [RegularExpression(DateFormatRegex, ErrorMessage = DateValidFormat)]
        public string? LiabilityInsuranceExpirationDate { get; set; }

        [RegularExpression(DateFormatRegex, ErrorMessage = DateValidFormat)]
        public string? TechnicalReviewExpirationDate { get; set; }

        [RegularExpression(DateFormatRegex, ErrorMessage = DateValidFormat)]
        public string? TachographExpirationDate { get; set; }
    }

}
