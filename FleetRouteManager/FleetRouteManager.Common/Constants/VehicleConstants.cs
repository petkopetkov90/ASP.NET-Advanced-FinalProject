namespace FleetRouteManager.Common.Constants
{
    public static class VehicleConstants
    {
        public const int VehicleRegistrationNumberMaxLength = 15;
        public const int VehicleRegistrationNumberMinLength = 5;
        public const string VehicleRegistrationNumberFormatRegex = @"^[A-Za-z0-9](?:[\s-]?[A-Za-z0-9]+)*$";

        public const int VehicleModelMaxLength = 10;
        public const int VehicleModelMinLength = 3;
        public const string VehicleModelFormatRegex = @"^[A-Za-z0-9](?:[\s.]?[A-Za-z0-9]+)*$";

        public const int VehicleVinMaxLength = 17;
        public const int VehicleVinMinLength = 17;
        public const string VehicleVinFormatRegex = "^[A-Za-z0-9]*$";

        public const string VehicleDateFormat = "dd-MM-yyyy";
        public const string VehicleDateFormatRegex = @"^(0[1-9]|[12][0-9]|3[01])-(0[1-9]|1[0-2])-\d{4}$";

        public const int VehicleMinAxles = 2;
        public const int VehicleMaxAxles = 5;

        public const double VehicleMinWeightCapacity = 0.1;
        public const double VehicleMaxWeightCapacity = 40.0;

        public const int VehicleLiabilityInsuranceMaxLength = 50;
        public const int VehicleLiabilityInsuranceMinLength = 10;
        public const string VehicleLiabilityInsuranceFormatRegex = @"^[A-Za-z0-9](?:[\s-/]?[A-Za-z0-9]+)*$";


    }
}
