namespace FleetRouteManager.Web.Models.ViewModels
{
    public class DriverViewModel
    {
        public required int Id { get; set; }

        public required string FullName { get; set; }

        public required string PhoneNumber { get; set; }

        public required string DrivingLicense { get; set; }

        public required string EmployedAt { get; set; }

        public string? Vehicle { get; set; }
    }
}
