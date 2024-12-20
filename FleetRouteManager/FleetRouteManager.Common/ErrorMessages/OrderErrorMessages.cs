namespace FleetRouteManager.Common.ErrorMessages
{
    public static class OrderErrorMessages
    {
        public const string OrderNumberRequiredMsg = "Order number is required.";
        public const string OrderNumberLengthMsg = "Order number must be between 3 and 50 characters.";
        public const string OrderNumberFormatMsg =
            "Order number can't contain special symbols like question marks (?), at signs (@), or percentage signs (%).";

        public const string OrderDateRequiredMsg = "Date in format \"dd-MM-yyyy\" is required.";
        public const string OrderDateFormatMsg = "Date must be in format: \"dd-MM-yyyy\".";

        public const string OrderAmountRequiredMsg = "Please enter valid ammount.";
        public const string OrderAmountRangeMsg = "Amount must be in between 0.00 and 999999.99.";

        public const string OrderUserNameRequiredMsg = "Username is required.";
        public const string OrderUserNameLengthMsg = "Username must be between 6 and 254 digits.";
        public const string OrderUserNameFormatMsg =
            "Username  must contain only letters (A-Z, a-z), digits (0-9), and may optionally can contain standart special characters for emails.";

        public const string OrderClientRequiredMsg = "Please select a Client.";
    }
}
