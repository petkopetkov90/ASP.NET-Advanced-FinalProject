namespace FleetRouteManager.Common.Constants
{
    public static class OrderConstants
    {
        public const int OrderNumberMinLength = 3;
        public const int OrderNumberMaxLength = 50;
        public const string OrderNumberFormatRegex = "^[^?@%]*$";

        public const string OrderDateFormat = "dd-MM-yyyy";
        public const string OrderDateFormatRegex = @"^(0[1-9]|[12][0-9]|3[01])-(0[1-9]|1[0-2])-\d{4}$";

        public const int UsernameMaxLength = 450;

        public const double OrderAmountMin = 0.00;
        public const double OrderAmountMax = 999999.99;

        public const int UserNameMinLength = 6;
        public const int UserNameMaxLength = 254;
        public const string UserNameFormatRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

    }
}
