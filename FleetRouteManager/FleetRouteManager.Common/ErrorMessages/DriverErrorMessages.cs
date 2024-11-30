namespace FleetRouteManager.Common.ErrorMessages
{
    public static class DriverErrorMessages
    {
        public const string DriverNameRequiredMsg = "Name is required.";
        public const string DriverNameLengthMsg = "Name must be between 3 and 20 characters.";
        public const string DriverNameFormatMsg = "Name must contain only letters.";

        public const string DriverPhoneRequiredMsg = "Phone number is required.";
        public const string DriverPhoneLengthMsg = "Phone number must be between 9 and 20 digits.";
        public const string DriverPhoneFormatMsg = "Phone number must contain only digits (0-9) and may optionally start with a '+'.<br>It may contain spaces ( ), hyphens (-) or perionds (.) between groups of digits, but only one symbol is allowed in a row.";

        public const string DriverDrivingLicenseRequiredMsg = "Driving license is required.";
        public const string DriverDrivingLicenseLengthMsg = "Driving license must be between 8 and 15 characters.";
        public const string DriverDrivingLicenseFormatMsg = "Driving licens must contain only letters(A-Z, a-z) and digits(0-9).<br>It may optionally contain spaces( ) between characters, but only one space is allowed in a row.";


        public const string DriverIdentityCardRequiredMsg = "Identity card is required.";
        public const string DriverIdentityCardLengthMsg = "Identity card must be between 8 and 15 characters.";
        public const string DriverIdentityCardFormatMsg = "Identity card must contain only letters(A-Z, a-z) and digits(0-9).<br>It may optionally contain spaces( ) between characters, but only one space is allowed in a row.";

        public const string DriverPersonalIdentificationRequiredMsg = "Personal indentification is required.";
        public const string DriverPersonalIdentificationLengthMsg = "Pesonal identification must be between 8 and 15 digits.";
        public const string DriverPersonalIdentificationFormatMsg =
            "Personal indentification must contain only letters(A-Z, a-z) and digits(0-9).";


        public const string DriverProfessionalQualificationRequiredMsg = "Prefessional qualification is required.";
        public const string DriverProfessionalQualificationLengthMsg = "Professional qualification must be between 8 and 15 characters.";
        public const string DriverProfessionalQualificationFormatMsg = "Personal indentification must contain only letters(A-Z, a-z) and digits(0-9).<br>It may optionally contain spaces( ) between characters, but only one space is allowed in a row.";

        public const string DriverMedicalInsuranceLengthMsg = "Medical insurance must be between 8 and 15 cahracters.";
        public const string DriverMedicalInsuranceFormatMsg = "Medical insurance must contain only letters (A-Z, a-z) and digits (0-9).<br>It may optionally contain spaces ( ), hyphens (-) or slashes (/) between characters, but only one symbol is allowed in a row.";

        public const string DriverDateRequiredMsg = "Date in format \"dd-MM-yyyy\" is required.";
        public const string DriverDateFormatMsg = "Date must be in format: \"dd-MM-yyyy\".";

    }
}
