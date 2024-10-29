using FleetRouteManager.Common.Enums;
using FleetRouteManager.Data.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FleetRouteManager.Common.Constants.VehicleConstants;

namespace FleetRouteManager.Data.Models.Models
{
    public class Vehicle : ISoftDeletable
    {
        [Key]
        [Comment("Primary Key for Vehicle entity")]
        public int Id { get; set; }

        [Required]
        [MaxLength(RegistrationNumberMaxLength)]
        [Comment("Vehicle Registration Number")]
        public string RegistrationNumber { get; set; } = null!;

        [Required]
        [Comment("Type of Vehicle")]
        public int ManufacturerId { get; set; }

        [ForeignKey(nameof(ManufacturerId))]
        public Manufacturer Manufacturer { get; set; } = null!;

        [Required]
        [MaxLength(VinMaxLength)]
        [Column("VIN")]
        [Comment("Vehicle VIN/frame number")]
        public string Vin { get; set; } = null!;

        [Required]
        [Comment("Vehicle first registration")]
        public DateTime FirstRegistration { get; set; }

        [Required]
        [Comment("Vehicle Emission Class")]
        public EuroClass EuroClass { get; set; }

        [Required]
        [Comment("Vehicle Axles count")]
        public int Axles { get; set; }

        [Required]
        [Column("Vehicle weight")]
        public double VehicleWeight { get; set; }

        [Required]
        [Comment("Vehicle Type")]
        public VehicleType VehicleType { get; set; }

        [Required]
        [Comment("Vehicle adding date")]
        public DateTime AddedOn { get; set; } = DateTime.Now.Date;

        [Comment("Soft Delete")]
        public bool IsDeleted { get; set; } = false;

        [Comment("Deletion date")]
        public DateTime? DeletedOn { get; set; }
    }
}
