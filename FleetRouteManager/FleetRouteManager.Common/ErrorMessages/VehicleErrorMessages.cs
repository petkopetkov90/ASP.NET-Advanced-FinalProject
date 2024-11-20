namespace FleetRouteManager.Common.ErrorMessages
{
    public static class VehicleErrorMessages
    {
        public const string RegistrationNumberRequiredMsg = "Registration number is required.";
        public const string RegistrationNumberLengthMsg = "Registration number must be between 5 and 15 characters.";
        public const string ManufacturerRequiredMsg = "Please select valid Manufacturer.";
        public const string ModelLengthMsg = "Model must be between 3 and 10 characters.";
        public const string VinRequiredMsg = "VIN number is required.";
        public const string VinLengthMsg = "VIN must be between 10 and 30 characters.";
        public const string DateRequiredMsg = "Date in format \"dd-MM-yyyy\" is required.";
        public const string DateValidFormatMsg = "Date must be in format: \"dd-MM-yyyy\".";
        public const string EuroClassRequiredMsg = "Please select valid Euro Class.";
        public const string TypeRequiredMsg = "Please select valid vehicle Type.";
        public const string BodyRequiredMsg = "Please select valid body Type.";
        public const string AxlesRequiredMsg = "Please enter number of Axles.";
        public const string AxlesRangeMsg = "Number of Axles must be between 2 and 5.";
        public const string WeightCapacityRequiredMsg = "Please enter legal weight capacity in tons.";
        public const string LiabilityInsuranceLengthMsg = "Insurance number must be between 10 and 50 characters.";
    }
}
