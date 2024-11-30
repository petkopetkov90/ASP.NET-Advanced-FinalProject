namespace FleetRouteManager.Common.ErrorMessages
{
    public static class LocationErrorMessages
    {
        public const string LocationNameRequiredMsg = "Name is required.";
        public const string LocationNameLengthMsg = "Name must be between 2 and 200 characters.";
        public const string LocationNameFormatMsg = "Name must contain only letters (A-Z, a-z) and digits (0-9).<br>It may optionally contain spaces ( ), periods (.), apostrophes ('), ampersands (&), and hyphens (-) between characters, but only one symbol is allowed in a row.";

        public const string LocationPhoneNumberLengthMsg = "Phone number must be between 6 and 20 digits.";
        public const string LocationPhoneNumberFormatMsg = "Phone number must contain only digits (0-9) and may optionally start with a '+'.<br>It may contain spaces ( ), hyphens (-) or perionds (.) between groups of digits, but only one symbol is allowed in a row.";

        public const string LocationStreetNameRequiredMsg = "Street name is required.";
        public const string LocationStreetNameLengthMsg = "Street name must be between 1 and 58 characters.";
        public const string LocationStreetNameFormatMsg = "Street name must contain only letters (A-Z, a-z) and digits (0-9), can also end with a period (.).<br>It may optionally contain spaces ( ), ampersands (&), apostrophes ('), and hyphens (-) between characters, but only one symbol is allowed in a row.";

        public const string LocationStreetNumberLengthMsg = "Street number must be between 1 and 10 characters.";
        public const string LocationStreetNumberFormatMsg = "Street number must contain only letters (A-Z, a-z) and digits (0-9).<br>It may optionally contain spaces ( ) between characters, but only one space is allowed in a row.";

        public const string LocationPostCodeRequiredMsg = "Post code is required.";
        public const string LocationPostCodeLengthMsg = "Post code must be between 2 and 10 characters.";
        public const string LocationPostCodeFormatMsg = "Post code must contain only letters (A-Z, a-z) and digits (0-9).<br>It may optionally contain spaces ( ) and hyphens (-) between characters, but only one symbol is allowed in a row.";

        public const string LocationCityNameRequiredMsg = "City name is required.";
        public const string LocationCityNameLengthMsg = "City name length must be between 2 and 60 characters.";
        public const string LocationCityNameFormatMsg = "City name must contain only letters (A-Z, a-z) and digits (0-9).<br>It may optionally contain spaces ( ), hyphens (-), perionds (.) and apostrophes (') between characters, but only one symbol is allowed in a row.";

        public const string LocationCountryRequiredMsg = "Please select a Country.";
    }
}
