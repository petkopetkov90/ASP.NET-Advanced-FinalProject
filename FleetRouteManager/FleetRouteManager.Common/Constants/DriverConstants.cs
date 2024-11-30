namespace FleetRouteManager.Common.Constants
{
    public static class DriverConstants
    {
        public const int DriverNameMinLength = 3;
        public const int DriverNameMaxLength = 20;
        public const string DriverNameFormatRegex = "^[A-Za-z]+$";

        public const int DriverPhoneMinLength = 9;
        public const int DriverPhoneMaxLength = 20;
        public const string DriverPhoneFormatRegex = @"^\+?[0-9]{1,4}?[-.\s]?[0-9]+([-.\s]?[0-9]+)*$";

        public const int DriverDrivingLicenseMinLength = 8;
        public const int DriverDrivingLicenseMaxLength = 15;
        public const string DriverDrivingLicenseFormatRegex = @"^[A-Za-z0-9](?:\s?[A-Za-z0-9]+)*$";


        public const int DriverIdentityCardMinLength = 8;
        public const int DriverIdentityCardMaxLength = 15;
        public const string DriverIdentityCardFormatRegex = @"^[A-Za-z0-9](?:\s?[A-Za-z0-9]+)*$";

        public const int DriverPersonalIdentificationMinLength = 8;
        public const int DriverPersonalIdentificationMaxLength = 15;
        public const string DriverPersonalIdentificationFormatRegex = "^[A-Za-z0-9]+$";


        public const int DriverProfessionalQualificationMinLength = 8;
        public const int DriverProfessionalQualificationMaxLength = 15;
        public const string DriverProfessionalQualificationFormatRegex = @"^[A-Za-z0-9](?:\s?[A-Za-z0-9]+)*$";

        public const int DriverMedicalInsuranceMinLength = 8;
        public const int DriverMedicalInsuranceMaxLength = 15;
        public const string DriverMedicalInsuranceFormatRegex = @"^[A-Za-z0-9](?:[\s-/]?[A-Za-z0-9]+)*$";

        public const string DriverDateFormat = "dd-MM-yyyy";
        public const string DriverDateFormatRegex = @"^(0[1-9]|[12][0-9]|3[01])-(0[1-9]|1[0-2])-\d{4}$";

    }
}
