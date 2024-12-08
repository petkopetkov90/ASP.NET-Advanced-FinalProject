namespace FleetRouteManager.Common.ErrorMessages
{
    public static class VehicleErrorMessages
    {
        public const string VehicleRegistrationNumberRequiredMsg = "Registration number is required.";
        public const string VehicleRegistrationNumberLengthMsg = "Registration number must be between 5 and 15 characters.";
        public const string VehicleRegistrationNumberFormatMsg = "Registration number must contain only letters (A-Z, a-z) and digits (0-9).<br>It may optionally contain spaces ( ) and hyphens (-) between characters, but only one symbol is allowed in a row.";

        public const string VehicleManufacturerRequiredMsg = "Please select a valid Manufacturer.";

        public const string VehicleModelLengthMsg = "Model must be between 3 and 10 characters.";
        public const string VehicleModelFormatMsg = "Model must contain only letters (A-Z, a-z) and digits (0-9).<br>It may optionally contain spaces ( ) and periods (.) between characters, but only one symbol is allowed in a row.";

        public const string VehicleVinRequiredMsg = "VIN number is required.";
        public const string VehicleVinLengthMsg = "VIN number must be 17 characters long.";
        public const string VehicleVinFormatMsg = "VIN number must contain only letters (A-Z, a-z) and digits (0-9).";

        public const string VehicleDateRequiredMsg = "Date in format \"dd-MM-yyyy\" is required.";
        public const string VehicleDateValidFormatMsg = "Date must be in format: \"dd-MM-yyyy\".";

        public const string EuroClassRequiredMsg = "Please select a valid Euro Class.";

        public const string VehicleTypeRequiredMsg = "Please select a valid vehicle Type.";

        public const string BodyRequiredMsg = "Please select a valid body Type.";

        public const string VehicleAxlesRequiredMsg = "Please enter Axles count.";
        public const string VehicleAxlesRangeMsg = "Axles count must be between 2 and 5.";

        public const string VehicleWeightCapacityRequiredMsg = "Please enter a legal weight capacity in tons.";
        public const string VehicleWeightCapacityRangeMsg = "Capacity must be between 0.0 and 40 tons.";

        public const string VehicleLiabilityInsuranceLengthMsg = "Insurance number must be between 10 and 50 characters.";
        public const string VehicleLiabilityInsuranceFormatMsg = "Insurance number must contain only letters (A-Z, a-z) and digits (0-9).<br>It may optionally contain spaces ( ), hyphens (-) or slashes (/) between characters, but only one symbol is allowed in a row.";
    }
}
