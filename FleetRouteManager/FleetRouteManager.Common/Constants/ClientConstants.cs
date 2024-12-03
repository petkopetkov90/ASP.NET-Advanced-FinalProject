namespace FleetRouteManager.Common.Constants
{
    public static class ClientConstants
    {
        public const int ClientNameMinLength = 5;
        public const int ClientNameMaxLength = 200;
        public const string ClientNameFormatRegex = @"^[A-Za-z0-9](?:([\s'-.&(),]|\.\s|\s&\s)?[A-Za-z0-9]+)*$";

        public const int ClientTaxNumberMinLength = 8;
        public const int ClientTaxNumberMaxLength = 15;
        public const string ClientTaxNumberFormatRegex = @"^[A-Za-z0-9](?:([\s-])?[A-Za-z0-9]+)*$";

        public const int EmailMinLength = 6;
        public const int EmailMaxLength = 254;
        public const string EmailFormatRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        public const int ClientPhoneMinLength = 6;
        public const int ClientPhoneMaxLength = 20;
        public const string ClientPhoneFormatRegex = @"^\+?[0-9]{1,4}?[-.\s]?[0-9]+([-.\s]?[0-9]+)*$";
    }
}
