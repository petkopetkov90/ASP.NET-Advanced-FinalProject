namespace FleetRouteManager.Common.ErrorMessages
{
    public static class VehicleErrorMessages
    {
        public const string RegistrationNumberRequired = "Please enter Registration number";
        public const string RegistrationNumberLength = "Registration number must be between 5 and 15 characters";
        public const string ManufacturerRequired = "Please select valid Manufacturer";
        public const string ModelLength = "Model must be between 3 and 10 characters";
        public const string VinRequired = "Please enter VIN number";
        public const string VinLength = "VIN must be between 10 and 30 characters";
        public const string DateRequired = "Please enter a valid date in format \"dd-MM-yyyy\"";
        public const string DateValidFormat = "Date must be in format: \"dd-MM-yyyy\"";
        public const string InvalidDate = "Date {0} is invalid. Please enter a valid date in format \"{1}\".";
        public const string EuroClassRequired = "Please select valid Euro Class";
        public const string TypeRequired = "Please select valid vehicle Type";
        public const string BodyRequired = "Please select valid body Type";
        public const string AxlesRequired = "Please enter number of Axles";
        public const string AxlesRange = "Number of Axles must be between 2 and 5";
        public const string WeightCapacityRequired = "Please enter legal weight capacity in tons";
        public const string LiabilityInsuranceLength = "Insurance number must be between 10 and 50 characters";

    }
}
