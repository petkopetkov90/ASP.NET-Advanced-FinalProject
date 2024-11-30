namespace FleetRouteManager.Common.Constants
{
    public static class LocationConstants
    {
        public const int LocationNameMinLength = 2;
        public const int LocationNameMaxLength = 200;
        public const string LocationNameFormatRegex = @"^[A-Za-z0-9](?:([\s'-.&]|\.\s|\s&\s)?[A-Za-z0-9]+)*$";

        public const int LocationPhoneMinLength = 6;
        public const int LocationPhoneMaxLength = 20;
        public const string LocationPhoneFormatRegex = @"^\+?[0-9]{1,4}?[-.\s]?[0-9]+([-.\s]?[0-9]+)*$";
    }
}
