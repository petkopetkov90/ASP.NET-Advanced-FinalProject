namespace FleetRouteManager.Common.ErrorMessages
{
    public static class ClientErrorMessages
    {
        public const string ClientNameRequiredMsg = "Name is required.";
        public const string ClientNameLengthMsg = "Name must be between 5 and 200 characters.";
        public const string ClientNameFormatMsg = "Name must contain only letters (A-Z, a-z) and digits (0-9).<br>It may optionally contain spaces ( ), periods (.), apostrophes ('), ampersands (&), and hyphens (-) between characters, but only one symbol is allowed in a row.";

        public const string ClientTaxNumberRequiredMsg = "VAT/TAX number is required.";
        public const string ClientTaxNumberLengthMsg = "VAT/TAX number must be between 8 and 15 digits.";
        public const string ClientTaxNumberFormatMsg = "Name must contain only letters (A-Z, a-z) and digits (0-9).<br>It may optionally include spaces ( ) or hyphens (-) between characters, but only one symbol is allowed in a row.";

        public const string ClientAddressRequiredMsg = "Please select an Address.";

        public const string ClientPhoneNumberLengthMsg = "Phone number must be between 6 and 20 digits.";
        public const string ClientPhoneNumberFormatMsg = "Phone number must contain only digits (0-9) and may optionally start with a '+'.<br>It may contain spaces ( ), hyphens (-) or periods (.) between groups of digits, but only one symbol is allowed in a row.";

        public const string ClientEmailRequiredMsg = "Email for contact is required.";
        public const string ClientEmailLengthMsg = "Email must be between 6 and 254 digits.";
        public const string ClientEmailFormatMsg =
            "Email must contain only letters (A-Z, a-z), digits (0-9), and may optionally can contain standart special characters for emails.<br>It must have exactly one @ symbol, followed by a valid domain name and must end with a valid top-level domain";
    }
}
