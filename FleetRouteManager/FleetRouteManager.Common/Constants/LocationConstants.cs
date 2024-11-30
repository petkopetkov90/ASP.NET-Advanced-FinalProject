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

        public const int LocationStreetNameMinLength = 1;
        public const int LocationStreetNameMaxLength = 58;
        public const string LocationStreetNameFormatRegex = @"^[A-Za-z0-9](?:([\s'-.&]|\.\s|\s&\s)?[A-Za-z0-9]+)*(?:\.)?$";

        public const int LocationStreetNumberMinLength = 1;
        public const int LocationStreetNumberMaxLength = 10;
        public const string LocationStreetNumberFormatRegex = @"^[A-Za-z0-9](?:\s?[A-Za-z0-9]+)*$";

        public const int LocationPostCodeMinLength = 2;
        public const int LocationPostCodeMaxLength = 10;
        public const string LocationPostCodeFormatRegex = @"^[A-Za-z0-9](?:[\s-]?[A-Za-z0-9]+)*$";

        public const int LocationCityMinLength = 2;
        public const int LocationCityMaxLength = 60;
        public const string LocationCityFormatRegex = @"^[A-Za-z0-9](?:([\s'-.]|\.\s)?[A-Za-z0-9]+)*$";
    }
}
