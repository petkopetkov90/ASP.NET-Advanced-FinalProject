namespace FleetRouteManager.Common.Constants
{
    public static class OrderConstants
    {
        public const int OrderNumberMinLength = 3;
        public const int OrderNumberMaxLength = 50;
        public const string OrderNumberFormatRegex = "^[^?@%]*$";

        public const string OrderDateFormat = "dd-MM-yyyy";
        public const string OrderDateFormatRegex = @"^(0[1-9]|[12][0-9]|3[01])-(0[1-9]|1[0-2])-\d{4}$";

        public const int PackagesTypeMinLength = 3;
        public const int PackagesTypeMaxLength = 255;

        public const int UsernameMaxLength = 450;

    }
}
