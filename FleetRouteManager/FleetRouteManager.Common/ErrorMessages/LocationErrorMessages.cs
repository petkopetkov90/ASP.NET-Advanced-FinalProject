namespace FleetRouteManager.Common.ErrorMessages
{
    public static class LocationErrorMessages
    {
        public const string LocationNameRequiredMsg = "Name is required.";
        public const string LocationNameLengthMsg = "Name must be between 2 and 200 characters.";
        public const string LocationNameFormatMsg = "Name must contain only letters (A-Z, a-z) and digits (0-9).<br>It may optionally contain spaces ( ), periods (.), apostrophes ('), ampersands (&), and hyphens (-) between characters, but only one symbol is allowed in a row.";

        public const string LocationPhoneNumberLengthMsg = "Phone number must be between 6 and 20 digits.";
        public const string LocationPhoneNumberFormatMsg = "Phone number must contain only digits (0-9) and may optionally start with a '+'.<br>It may contain spaces ( ), hyphens (-) or perionds (.) between groups of digits, but only one symbol is allowed in a row.";

        public const string LocationAddressRequiredMsg = "Please select an Address.";

    }
}
