namespace FleetRouteManager.Web.Models.ViewModels
{
    public class DriverDetailsViewModel
    {
        public required int Id { get; set; }

        public required string FirstName { get; set; }

        public required string MiddleName { get; set; }

        public required string LastName { get; set; }

        public required string PhoneNumber { get; set; }

        public string? Vehicle { get; set; }

        public string? AdditionalPhoneNumber { get; set; }

        public required string DrivingLicense { get; set; }

        public required string DrivingLicenseExpirationDate { get; set; }

        public required string IdentityCard { get; set; }

        public required string IdentityCardExpirationDate { get; set; }

        public required string PersonalIdentificationNumber { get; set; }

        public required string ProfessionalQualificationCard { get; set; }

        public required string ProfessionalQualificationCardExpirationDate { get; set; }

        public string? MedicalInsurance { get; set; }

        public string? MedicalInsuranceExpirationDate { get; set; }

        public required string DateOfBirth { get; set; }

        public required string EmployedOn { get; set; }
    }
}
