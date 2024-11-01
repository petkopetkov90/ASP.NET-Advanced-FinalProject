namespace FleetRouteManager.Web.Models.ViewModels
{
    public class VehicleViewModel
    {
        public required int Id { get; set; }

        public required string RegistrationNumber { get; set; }

        public required string Vin { get; set; }

        public required string Manufacturer { get; set; }

        public required string Model { get; set; }

        public required string FirstRegistrationDate { get; set; }

        public required string EuroClass { get; set; }

        public required string TruckType { get; set; }
    }
}
