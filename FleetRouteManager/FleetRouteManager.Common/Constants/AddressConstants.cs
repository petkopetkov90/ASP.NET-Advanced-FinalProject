namespace FleetRouteManager.Common.Constants
{
    public static class AddressConstants
    {
        public const int AddressStreetNameMinLength = 1;
        public const int AddressStreetNameMaxLength = 58;
        public const string AddressStreetNameFormatRegex = @"^[A-Za-z0-9](?:([\s'-.&]|\.\s|\s&\s)?[A-Za-z0-9]+)*(?:\.)?$";

        public const int AddressStreetNumberMinLength = 1;
        public const int AddressStreetNumberMaxLength = 10;
        public const string AddressStreetNumberFormatRegex = @"^[A-Za-z0-9](?:\s?[A-Za-z0-9]+)*$";

        public const int AddressPostCodeMinLength = 2;
        public const int AddressPostCodeMaxLength = 10;
        public const string AddressPostCodeFormatRegex = @"^[A-Za-z0-9](?:[\s-]?[A-Za-z0-9]+)*$";

        public const int AddressCityMinLength = 2;
        public const int AddressCityMaxLength = 60;
        public const string AddressCityFormatRegex = @"^[A-Za-z0-9](?:([\s'-.]|\.\s)?[A-Za-z0-9]+)*$";
    }
}
