namespace FleetRouteManager.Common.ErrorMessages
{
    public static class AddressErrorMessages
    {
        public const string AddressStreetNameRequiredMsg = "Street name is required.";
        public const string AddressStreetNameLengthMsg = "Street name must be between 1 and 58 characters.";
        public const string AddressStreetNameFormatMsg = "Street name must contain only letters (A-Z, a-z) and digits (0-9), can also end with a period (.).<br>It may optionally contain spaces ( ), ampersands (&), apostrophes ('), and hyphens (-) between characters, but only one symbol is allowed in a row.";

        public const string AddressStreetNumberLengthMsg = "Street number must be between 1 and 10 characters.";
        public const string AddressStreetNumberFormatMsg = "Street number must contain only letters (A-Z, a-z) and digits (0-9).<br>It may optionally contain spaces ( ) between characters, but only one space is allowed in a row.";

        public const string AddressPostCodeRequiredMsg = "Post code is required.";
        public const string AddressPostCodeLengthMsg = "Post code must be between 2 and 10 characters.";
        public const string AddressPostCodeFormatMsg = "Post code must contain only letters (A-Z, a-z) and digits (0-9).<br>It may optionally contain spaces ( ) and hyphens (-) between characters, but only one symbol is allowed in a row.";

        public const string AddressCityNameRequiredMsg = "City name is required.";
        public const string AddressCityNameLengthMsg = "City name length must be between 2 and 60 characters.";
        public const string AddressCityNameFormatMsg = "City name must contain only letters (A-Z, a-z) and digits (0-9).<br>It may optionally contain spaces ( ), hyphens (-), perionds (.) and apostrophes (') between characters, but only one symbol is allowed in a row.";

        public const string AddressCountryRequiredMsg = "Please select a Country.";
    }
}
