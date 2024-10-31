using FleetRouteManager.Common.Enums;
using FleetRouteManager.Data.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FleetRouteManager.Data.Common.Constants.VehicleConstants;


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
        [Comment("Vehicle Manufacturer")]
        public int ManufacturerId { get; set; }
        [ForeignKey(nameof(ManufacturerId))]
        public Manufacturer Manufacturer { get; set; } = null!;

        [MaxLength(ModelMaxLength)]
        [Comment("Vehicle Model")]
        public string? Model { get; set; }

        [Required]
        [MaxLength(VinMaxLength)]
        [Column("VIN")]
        [Comment("Vehicle VIN/Frame number")]
        public string Vin { get; set; } = null!;

        [Required]
        [Comment("Vehicle First Registration")]
        public DateTime FirstRegistration { get; set; }

        [Required]
        [Comment("Vehicle Emission Class")]
        public EuroClass EuroClass { get; set; }

        [Required]
        [Comment("Vehicle Axles count")]
        public int Axles { get; set; }

        [Required]
        [Comment("Type of Vehicle")]
        public int VehicleTypeId { get; set; }
        [ForeignKey(nameof(VehicleTypeId))]
        public VehicleType VehicleType { get; set; } = null!;

        [Required]
        [Comment("Vehicle date of bought")]
        public DateTime AddedOn { get; set; } = DateTime.Now.Date;

        [Comment("Soft Delete")]
        public bool IsDeleted { get; set; } = false;

        [Comment("Deletion date")]
        public DateTime? DeletedOn { get; set; }
    }
}
