using System.ComponentModel.DataAnnotations;
using static FleetRouteManager.Common.Constants.DriverConstants;
using static FleetRouteManager.Common.ErrorMessages.DriverErrorMessages;

namespace FleetRouteManager.Web.Models.InputModels.DriverInputModels
{
    public class DriverEditInputModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = DriverNameRequiredMsg)]
        [StringLength(DriverNameMaxLength, MinimumLength = DriverNameMinLength, ErrorMessage = DriverNameLengthMsg)]
        [RegularExpression(DriverNameFormatRegex, ErrorMessage = DriverNameFormatMsg)]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = DriverNameRequiredMsg)]
        [StringLength(DriverNameMaxLength, MinimumLength = DriverNameMinLength, ErrorMessage = DriverNameLengthMsg)]
        [RegularExpression(DriverNameFormatRegex, ErrorMessage = DriverNameFormatMsg)]
        public string MiddleName { get; set; } = null!;

        [Required(ErrorMessage = DriverNameRequiredMsg)]
        [StringLength(DriverNameMaxLength, MinimumLength = DriverNameMinLength, ErrorMessage = DriverNameLengthMsg)]
        [RegularExpression(DriverNameFormatRegex, ErrorMessage = DriverNameFormatMsg)]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = DriverPhoneRequiredMsg)]
        [StringLength(DriverPhoneMaxLength, MinimumLength = DriverPhoneMinLength, ErrorMessage = DriverPhoneLengthMsg)]
        [RegularExpression(DriverPhoneFormatRegex, ErrorMessage = DriverPhoneFormatMsg)]
        public string PhoneNumber { get; set; } = null!;

        public int? VehicleId { get; set; }

        [StringLength(DriverPhoneMaxLength, MinimumLength = DriverPhoneMinLength, ErrorMessage = DriverPhoneLengthMsg)]
        [RegularExpression(DriverPhoneFormatRegex, ErrorMessage = DriverPhoneFormatMsg)]
        public string? AdditionalPhoneNumber { get; set; }

        [Required(ErrorMessage = DriverDrivingLicenseRequiredMsg)]
        [StringLength(DriverDrivingLicenseMaxLength, MinimumLength = DriverDrivingLicenseMinLength, ErrorMessage = DriverDrivingLicenseLengthMsg)]
        [RegularExpression(DriverDrivingLicenseFormatRegex, ErrorMessage = DriverDrivingLicenseFormatMsg)]
        public string DrivingLicense { get; set; } = null!;

        [Required(ErrorMessage = DriverDateRequiredMsg)]
        [RegularExpression(DriverDateFormatRegex, ErrorMessage = DriverDateFormatMsg)]
        public string DrivingLicenseExpirationDate { get; set; } = null!;

        [Required(ErrorMessage = DriverIdentityCardRequiredMsg)]
        [StringLength(DriverIdentityCardMaxLength, MinimumLength = DriverIdentityCardMinLength, ErrorMessage = DriverIdentityCardLengthMsg)]
        [RegularExpression(DriverIdentityCardFormatRegex, ErrorMessage = DriverIdentityCardFormatMsg)]
        public string IdentityCard { get; set; } = null!;

        [Required(ErrorMessage = DriverDateRequiredMsg)]
        [RegularExpression(DriverDateFormatRegex, ErrorMessage = DriverDateFormatMsg)]
        public string IdentityCardExpirationDate { get; set; } = null!;

        [Required(ErrorMessage = DriverPersonalIdentificationRequiredMsg)]
        [StringLength(DriverPersonalIdentificationMaxLength, MinimumLength = DriverPersonalIdentificationMinLength, ErrorMessage = DriverPersonalIdentificationLengthMsg)]
        [RegularExpression(DriverPersonalIdentificationFormatRegex, ErrorMessage = DriverPersonalIdentificationFormatMsg)]
        public string PersonalIdentificationNumber { get; set; } = null!;

        [Required(ErrorMessage = DriverProfessionalQualificationRequiredMsg)]
        [StringLength(DriverProfessionalQualificationMaxLength, MinimumLength = DriverProfessionalQualificationMinLength, ErrorMessage = DriverProfessionalQualificationLengthMsg)]
        [RegularExpression(DriverProfessionalQualificationFormatRegex, ErrorMessage = DriverProfessionalQualificationFormatMsg)]
        public string ProfessionalQualificationCard { get; set; } = null!;

        [Required(ErrorMessage = DriverDateRequiredMsg)]
        [RegularExpression(DriverDateFormatRegex, ErrorMessage = DriverDateFormatMsg)]
        public string ProfessionalQualificationCardExpirationDate { get; set; } = null!;

        [Required(ErrorMessage = DriverDateRequiredMsg)]
        [RegularExpression(DriverDateFormatRegex, ErrorMessage = DriverDateFormatMsg)]
        public string DateOfBirth { get; set; } = null!;

        [Required(ErrorMessage = DriverDateRequiredMsg)]
        [RegularExpression(DriverDateFormatRegex, ErrorMessage = DriverDateFormatMsg)]
        public string EmployedOn { get; set; } = null!;

        [StringLength(DriverMedicalInsuranceMaxLength, MinimumLength = DriverMedicalInsuranceMinLength, ErrorMessage = DriverMedicalInsuranceLengthMsg)]
        [RegularExpression(DriverMedicalInsuranceFormatRegex, ErrorMessage = DriverMedicalInsuranceFormatMsg)]
        public string? MedicalInsurance { get; set; }

        [RegularExpression(DriverDateFormatRegex, ErrorMessage = DriverDateFormatMsg)]
        public string? MedicalInsuranceExpirationDate { get; set; }
    }
}
