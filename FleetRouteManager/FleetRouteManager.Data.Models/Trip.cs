using FleetRouteManager.Data.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FleetRouteManager.Common.Constants.TripConstants;

namespace FleetRouteManager.Data.Models
{
    public class Trip : ISoftDeletable
    {
        [Key]
        [Comment("Primary Key for Trip entity")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TripNumberMaxLength)]
        [Comment("Trip number")]
        public string TripNumber { get; set; } = null!;

        [NotMapped]
        public decimal Amount => Orders.Sum(o => o.Amount);

        [Required]
        [Comment("Trip start date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Comment("Trip end date")]
        public DateTime EndDate { get; set; }

        [Required]
        [Comment("Foreign key to Location")]
        public int StartLocationId { get; set; }
        [ForeignKey(nameof(StartLocationId))]
        public virtual Location StartingLocation { get; set; } = null!;

        [Required]
        [Comment("Foreign key to Location")]
        public int EndLocationId { get; set; }
        [ForeignKey(nameof(EndLocationId))]
        public virtual Location EndingLocation { get; set; } = null!;

        [Required]
        [Comment("Foreign key to Vehicle")]
        public int VehicleId { get; set; }
        [ForeignKey(nameof(VehicleId))]
        public virtual Vehicle Vehicle { get; set; } = null!;

        [Required]
        [Comment("Foreign key to Driver")]
        public int DriverId { get; set; }
        [ForeignKey(nameof(DriverId))]
        public virtual Driver Driver { get; set; } = null!;

        [Comment("Foreign key to Driver")]
        public int? SecondDriverId { get; set; }
        [ForeignKey(nameof(SecondDriverId))]
        public virtual Driver? SecondDriver { get; set; }

        [Required]
        [MaxLength(TripUserNameMaxLength)]
        [Comment("Person who managing this Trip")]
        public string User { get; set; } = null!;

        [Comment("Indicates if the Trip was deleted")]
        public bool IsDeleted { get; set; }

        [Comment("Date and time when the Trip was marked as deleted")]
        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
