﻿using FleetRouteManager.Common.Enums;
using FleetRouteManager.Data.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FleetRouteManager.Common.Constants.VehicleConstants;


namespace FleetRouteManager.Data.Models
{
    public class Vehicle : ISoftDeletable
    {
        [Key]
        [Comment("Primary Key for Vehicle entity")]
        public int Id { get; set; }

        [Required]
        [MaxLength(VehicleRegistrationNumberMaxLength)]
        [Comment("Vehicle Registration Number")]
        public string RegistrationNumber { get; set; } = null!;

        [Required]
        [Comment("Foreign key to the Manufacturer")]
        public int ManufacturerId { get; set; }
        [ForeignKey(nameof(ManufacturerId))]
        public virtual Manufacturer Manufacturer { get; set; } = null!;

        [MaxLength(VehicleModelMaxLength)]
        [Comment("Vehicle Model")]
        public string? Model { get; set; }

        [Required]
        [MaxLength(VehicleVinMaxLength)]
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
        [Comment("Vehicle type foreign key")]
        public int VehicleTypeId { get; set; }
        [ForeignKey(nameof(VehicleTypeId))]
        public virtual VehicleType VehicleType { get; set; } = null!;

        [Required]
        [Comment("Body type")]
        public BodyType BodyType { get; set; }

        [Required]
        [Comment("Vehicle number of axles")]
        public int Axles { get; set; }

        [Required]
        [Comment("Total capacity in tons")]
        public double WeightCapacity { get; set; }

        [Required]
        [Comment("Vehicle Date of Purchase")]
        public DateTime AcquiredOn { get; set; }

        [MaxLength(VehicleLiabilityInsuranceMaxLength)]
        [Comment("Vehicle Liability Insurance policy number")]
        public string? LiabilityInsurance { get; set; }

        [Comment("Vehicle Liability Insurance expiration date")]
        public DateTime? LiabilityInsuranceExpirationDate { get; set; }

        [Comment("Vehicle Technical Review expiration date")]
        public DateTime? TechnicalReviewExpirationDate { get; set; }

        [Comment("Vehicle Tachograph Certification expiration date")]
        public DateTime? TachographExpirationDate { get; set; }

        [Comment("Indicates if the Vehicle was deleted")]
        public bool IsDeleted { get; set; } = false;

        [Comment("Date and time when the Vehicle was marked as deleted")]
        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<Driver> CurrentDrivers { get; set; } = new List<Driver>();
        public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
    }
}
