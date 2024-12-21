namespace FleetRouteManager.Common.Constants
{
    public static class TripConstants
    {
        public const int TripNumberMinLength = 3;
        public const int TripNumberMaxLength = 20;
        public const string TripNumberFormatRegex = @"^[A-Za-z0-9](?:[\s-/]?[A-Za-z0-9]+)*$";

        public const string TripDateFormat = "dd-MM-yyyy";
        public const string TripDateFormatRegex = @"^(0[1-9]|[12][0-9]|3[01])-(0[1-9]|1[0-2])-\d{4}$";

        public const int TripUserNameMinLength = 6;
        public const int TripUserNameMaxLength = 254;
        public const string TripUserNameFormatRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

    }
}
