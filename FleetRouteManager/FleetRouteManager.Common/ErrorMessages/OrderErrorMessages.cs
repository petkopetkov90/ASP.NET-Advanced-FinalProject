namespace FleetRouteManager.Common.ErrorMessages
{
    public static class OrderErrorMessages
    {
        public const string OrderNumberRequiredMsg = "Order number is required.";
        public const string OrderNumberLengthMsg = "Order number must be between 3 and 50 characters.";
        public const string OrderNumberFormatMsg =
            "Order number can't contain special symbols like question marks (?), at signs (@), or percentage signs (%).";

        public const string DriverDateRequiredMsg = "Date in format \"dd-MM-yyyy\" is required.";
        public const string DriverDateFormatMsg = "Date must be in format: \"dd-MM-yyyy\".";
    }
}
