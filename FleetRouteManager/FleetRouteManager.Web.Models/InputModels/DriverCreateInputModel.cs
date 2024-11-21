using System.ComponentModel.DataAnnotations;
using static FleetRouteManager.Common.Constants.DriverConstants;
using static FleetRouteManager.Common.ErrorMessages.DriverErrorMessages;

namespace FleetRouteManager.Web.Models.InputModels
{
    public class DriverCreateInputModel
    {
        [Required(ErrorMessage = NameRequiredMsg)]
        [StringLength(DriverNameMaxLength, MinimumLength = DriverNameMinLength, ErrorMessage = NameLengthMsg)]
        [RegularExpression(NameFormatRegex, ErrorMessage = NameFormatMsg)]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = NameRequiredMsg)]
        [StringLength(DriverNameMaxLength, MinimumLength = DriverNameMinLength, ErrorMessage = NameLengthMsg)]
        [RegularExpression(NameFormatRegex, ErrorMessage = NameFormatMsg)]
        public string MiddleName { get; set; } = null!;

        [Required(ErrorMessage = NameRequiredMsg)]
        [StringLength(DriverNameMaxLength, MinimumLength = DriverNameMinLength, ErrorMessage = NameLengthMsg)]
        [RegularExpression(NameFormatRegex, ErrorMessage = NameFormatMsg)]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = PhoneRequiredMsg)]
        [StringLength(DriverPhoneMaxLength, MinimumLength = DriverPhoneMinLength, ErrorMessage = PhoneLengthMsg)]
        [RegularExpression(PhoneFormatRegex, ErrorMessage = PhoneFormatMsg)]
        public string PhoneNumber { get; set; } = null!;

        public int? VehicleId { get; set; }

        [StringLength(DriverPhoneMaxLength, MinimumLength = DriverPhoneMinLength, ErrorMessage = PhoneLengthMsg)]
        [RegularExpression(PhoneFormatRegex, ErrorMessage = PhoneFormatMsg)]
        public string? AdditionalPhoneNumber { get; set; }

        [Required(ErrorMessage = DrivingLicenseRequiredMsg)]
        [StringLength(DriverDrivingLicenseMaxLength, MinimumLength = DriverDrivingLicenseMinLength, ErrorMessage = DrivingLicenseLengthMsg)]
        public string DrivingLicense { get; set; } = null!;

        [Required(ErrorMessage = DateRequiredMsg)]
        [RegularExpression(DateFormatRegex, ErrorMessage = DateValidFormatMsg)]
        public string DrivingLicenseExpirationDate { get; set; } = null!;

        [Required(ErrorMessage = IdentityCardRequiredMsg)]
        [StringLength(DriverIdentityCardMaxLength, MinimumLength = DriverIdentityCardMinLength, ErrorMessage = IdentityCardLengthMsg)]
        public string IdentityCard { get; set; } = null!;

        [Required(ErrorMessage = DateRequiredMsg)]
        [RegularExpression(DateFormatRegex, ErrorMessage = DateValidFormatMsg)]
        public string IdentityCardExpirationDate { get; set; } = null!;

        [Required(ErrorMessage = PersonalIdentificationRequiredMsg)]
        [StringLength(PersonalIdentificationMaxLength, MinimumLength = PersonalIdentificationMinLength, ErrorMessage = PersonalIdentificationLengthMsg)]
        public string PersonalIdentificationNumber { get; set; } = null!;

        [Required(ErrorMessage = ProfessionalQualificationRequiredMsg)]
        [StringLength(ProfessionalQualificationMaxLength, MinimumLength = ProfessionalQualificationMinLength, ErrorMessage = ProfessionalQualificationLengthMsg)]
        public string ProfessionalQualificationCard { get; set; } = null!;

        [Required(ErrorMessage = DateRequiredMsg)]
        [RegularExpression(DateFormatRegex, ErrorMessage = DateValidFormatMsg)]
        public string ProfessionalQualificationCardExpirationDate { get; set; } = null!;

        [Required(ErrorMessage = DateRequiredMsg)]
        [RegularExpression(DateFormatRegex, ErrorMessage = DateValidFormatMsg)]
        public string DateOfBirth { get; set; } = null!;

        [Required(ErrorMessage = DateRequiredMsg)]
        [RegularExpression(DateFormatRegex, ErrorMessage = DateValidFormatMsg)]
        public string EmployedOn { get; set; } = null!;

        [StringLength(DriverMedicalInsuranceMaxLength, MinimumLength = DriverMedicalInsuranceMinLength, ErrorMessage = MedicalInsuranceLengthMsg)]
        public string? MedicalInsurance { get; set; }

        [RegularExpression(DateFormatRegex, ErrorMessage = DateValidFormatMsg)]
        public string? MedicalInsuranceExpirationDate { get; set; }
    }
}
