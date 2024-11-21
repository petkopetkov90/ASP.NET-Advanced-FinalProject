namespace FleetRouteManager.Common.Constants
{
    public static class DriverConstants
    {
        public const int DriverNameMinLength = 3;
        public const int DriverNameMaxLength = 20;
        public const int DriverPhoneMinLength = 9;
        public const int DriverPhoneMaxLength = 20;
        public const int DriverDrivingLicenseMinLength = 8;
        public const int DriverDrivingLicenseMaxLength = 15;
        public const int DriverIdentityCardMinLength = 8;
        public const int DriverIdentityCardMaxLength = 15;
        public const int PersonalIdentificationMinLength = 8;
        public const int PersonalIdentificationMaxLength = 15;
        public const int ProfessionalQualificationMinLength = 8;
        public const int ProfessionalQualificationMaxLength = 15;
        public const int DriverMedicalInsuranceMinLength = 8;
        public const int DriverMedicalInsuranceMaxLength = 15;
        public const string DriverDateFormat = "dd-MM-yyyy";
        public const string NameFormatRegex = "^[A-Za-z]+$";
        public const string PhoneFormatRegex = @"^\+?[0-9 ]+$";
        public const string DateFormatRegex = @"^(0[1-9]|[12][0-9]|3[01])-(0[1-9]|1[0-2])-\d{4}$";

    }
}
