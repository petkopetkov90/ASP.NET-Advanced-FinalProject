using FleetRouteManager.Common.Enums;

namespace FleetRouteManager.Web.Models.ViewModels
{
    public class VehicleDetailsViewModel
    {
        public required int Id { get; set; }

        public required string RegistrationNumber { get; set; }

        public required string Vin { get; set; }

        public required string Manufacturer { get; set; }

        public string? Model { get; set; }

        public required string FirstRegistrationDate { get; set; }

        public required EuroClass EuroClass { get; set; }

        public required string Type { get; set; }

        public required BodyType BodyType { get; set; }

        public required int Axles { get; set; }

        public required double WeightCapacity { get; set; }

        public required string AcquiredOn { get; set; }


        public IEnumerable<string> Drivers = new List<string>();

        public required string? LiabilityInsurance { get; set; }

        public string? LiabilityInsuranceExpirationDate { get; set; }

        public string? TechnicalReviewExpirationDate { get; set; }

        public string? TachographExpirationDate { get; set; }
    }
}
