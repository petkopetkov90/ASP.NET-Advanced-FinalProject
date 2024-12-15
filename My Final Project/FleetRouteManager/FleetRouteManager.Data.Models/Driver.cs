using FleetRouteManager.Data.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FleetRouteManager.Common.Constants.DriverConstants;

namespace FleetRouteManager.Data.Models
{
    public class Driver : ISoftDeletable
    {
        [Key]
        [Comment("Primary Key for Driver entity")]
        public int Id { get; set; }

        [Required]
        [MaxLength(DriverNameMaxLength)]
        [Comment("Driver's First Name")]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(DriverNameMaxLength)]
        [Comment("Driver's Middle Name")]
        public string MiddleName { get; set; } = null!;

        [Required]
        [MaxLength(DriverNameMaxLength)]
        [Comment("Driver's Last Name")]
        public string LastName { get; set; } = null!;

        [Required]
        [MaxLength(DriverPhoneMaxLength)]
        [Comment("Driver's main Phone Number")]
        public string PhoneNumber { get; set; } = null!;

        [MaxLength(DriverPhoneMaxLength)]
        [Comment("Driver's second Phone Number, if have")]
        public string? AdditionalPhoneNumber { get; set; }

        [Required]
        [MaxLength(DriverDrivingLicenseMaxLength)]
        [Comment("Driver's Driving License")]
        public string DrivingLicense { get; set; } = null!;

        [Required]
        [Comment("Driver's Driving License expiration date")]
        public DateTime DrivingLicenseExpirationDate { get; set; }

        [Required]
        [MaxLength(DriverIdentityCardMaxLength)]
        [Comment("Driver's Identity Card")]
        public string IdentityCard { get; set; } = null!;

        [Required]
        [Comment("Driver's Identity Card expiration date")]
        public DateTime IdentityCardExpirationDate { get; set; }

        [Required]
        [MaxLength(DriverPersonalIdentificationMaxLength)]
        [Comment("Driver's Personal Identification Number")]
        public string PersonalIdentificationNumber { get; set; } = null!;

        [Required]
        [MaxLength(DriverProfessionalQualificationMaxLength)]
        [Comment("Driver's Professional Qualification Card")]
        public string ProfessionalQualificationCard { get; set; } = null!;

        [Required]
        [Comment("Driver's Professional Qualification Card expiration date")]
        public DateTime ProfessionalQualificationCardExpirationDate { get; set; }

        [Required]
        [Comment("Driver's date of birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Comment("Driver's employing date")]
        public DateTime EmployedOn { get; set; }

        [MaxLength(DriverMedicalInsuranceMaxLength)]
        [Comment("Driver's Medical Insurance")]
        public string? MedicalInsurance { get; set; }

        [Comment("Driver's Medical Insurance expiration date")]
        public DateTime? MedicalInsuranceExpirationDate { get; set; }

        [Comment("Foreign key to Vehicle")]
        public int? VehicleId { get; set; }
        [ForeignKey(nameof(VehicleId))]
        public virtual Vehicle? Vehicle { get; set; }


        [Comment("Indicates if the Driver was released")]
        public bool IsDeleted { get; set; }

        [Comment("Date and time when the Driver was marked as released")]
        public DateTime? DeletedOn { get; set; }
    }
}
