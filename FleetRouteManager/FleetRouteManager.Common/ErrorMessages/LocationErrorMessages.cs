namespace FleetRouteManager.Common.ErrorMessages
{
    public static class LocationErrorMessages
    {
        public const string NameRequiredMsg = "Name is required.";
        public const string NameLengthMsg = "Name must be between 2 and 200 characters.";
        public const string NameFormatMsg = "Invalid name. Allowed characters are letters (A-Z, a-z), digits (0-9), spaces ( ), periods (.), apostrophes ('), ampersands (&), and hyphens (-).";
        public const string PhoneLengthMsg = "Phone number must be between 6 and 20 digits.";
        public const string PhoneFormatMsg = "Phone number must contain only digits (0-9) and optionaly can start with \"+\"";

        public const string StreetRequiredMsg = "Street name is required.";
        public const string StreetNameLengthMsg = "Street name must be between 1 and 58 characters.";
        public const string StreetNameFormatMsg = "Invalid street name. Allowed characters are letters (A-Z, a-z),, digits (0-9), spaces ( ), periods (.), apostrophes ('), and hyphens (-).";
        public const string StreetNumberLengthMsg = "Street number must be between 1 and 10 characters.";
        public const string StreetNumberFormatMsg = "Invalid street number. Allowed characters are letters (A-Z, a-z), and digits (0-9).";

        public const string PostCodeRequiredMsg = "Post code is required.";
        public const string PostCodeLengthMsg = "Post code must be between 2 and 10 characters.";
        public const string PostCodeFormatMsg = "Invalid post code. Allowed characters are letters (A-Z, a-z),, digits (0-9), spaces ( ), and hyphens (-).";

        public const string CityRequiredMsg = "City name is required.";
        public const string CityLengthMsg = "City name length must be between 2 and 60 characters.";
        public const string CityFormatMsg = "Invalid city name. Allowed characters are letters (A-Z, a-z),, digits (0-9), spaces ( ), periods (.), apostrophes ('), and hyphens (-).";

        public const string CountryRequiredMsg = "Please select a Country.";
    }
}
