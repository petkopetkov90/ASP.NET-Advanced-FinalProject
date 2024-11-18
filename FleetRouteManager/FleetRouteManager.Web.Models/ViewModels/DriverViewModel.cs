namespace FleetRouteManager.Web.Models.ViewModels
{
    public class DriverViewModel
    {
        public required int Id { get; set; }

        public required string FirstName { get; set; }

        public required string MiddleName { get; set; }

        public required string LastName { get; set; }

        public required string PhoneNumber { get; set; }

        public required string LicenseNumber { get; set; }

        public required string EmployedAt { get; set; }
    }
}
