namespace FleetRouteManager.Common.Constants
{
    public class LocationConstants
    {
        public const int NameMinLength = 2;
        public const int NameMaxLength = 200;
        public const int PhoneMinLength = 6;
        public const int PhoneMaxLength = 20;
        public const string NameFormatRegex = "^[A-Za-z0-9 .&'-]+$";
        public const string PhoneFormatRegex = @"^\+?[0-9 ]+$";
        public const int StreetNameMinLength = 1;
        public const int StreetNameMaxLength = 58;
        public const int StreetNumberMinLength = 1;
        public const int StreetNumberMaxLength = 10;
        public const int PostCodeMinLength = 2;
        public const int PostCodeMaxLength = 10;
        public const int CityMinLength = 2;
        public const int CityMaxLength = 60;
        public const string StreetNameFormatRegex = "^[A-Za-z0-9 .'-]+$";
        public const string StreetNumberFormatRegex = "^[A-Za-z0-9 ]+$";
        public const string PostCodeFormatRegex = "^[A-Za-z0-9 -]+$";
        public const string CityFormatRegex = "^[A-Za-z0-9 .'-]+$";
    }
}
