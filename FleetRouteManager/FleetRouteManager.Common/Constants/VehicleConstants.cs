namespace FleetRouteManager.Common.Constants
{
    public static class VehicleConstants
    {
        public const int RegistrationNumberMaxLength = 15;
        public const int RegistrationNumberMinLength = 5;
        public const int VinMaxLength = 30;
        public const int VinMinLength = 10;
        public const int ModelMaxLength = 10;
        public const int ModelMinLength = 3;
        public const int LiabilityInsuranceMaxLength = 50;
        public const int LiabilityInsuranceMinLength = 10;
        public const string VehicleDateFormat = "dd-MM-yyyy";
        public const string DateFormatRegex = @"^(0[1-9]|[12][0-9]|3[01])-(0[1-9]|1[0-2])-\d{4}$";
        public const int MinAxles = 2;
        public const int MaxAxles = 5;

    }
}
