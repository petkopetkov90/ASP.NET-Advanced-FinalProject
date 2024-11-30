using FleetRouteManager.Data.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FleetRouteManager.Common.Constants.LocationConstants;

namespace FleetRouteManager.Data.Models
{
    public class Location : ISoftDeletable
    {
        [Key]
        [Comment("Primary key of Location entity")]
        public int Id { get; set; }

        [Required]
        [MaxLength(LocationNameMaxLength)]
        [Comment("Location name")]
        public string Name { get; set; } = null!;

        [MaxLength(LocationPhoneMaxLength)]
        [Comment("Location phone number")]
        public string? PhoneNumber { get; set; }

        [Required]
        [MaxLength(LocationStreetNameMaxLength)]
        [Comment("Street name")]
        public string Street { get; set; } = null!;

        [MaxLength(LocationStreetNumberMaxLength)]
        [Comment("Street number")]
        public string? Number { get; set; }

        [Required]
        [MaxLength(LocationPostCodeMaxLength)]
        [Comment("Post code")]
        public string PostCode { get; set; } = null!;

        [Required]
        [MaxLength(LocationCityMaxLength)]
        [Comment("City name")]
        public string City { get; set; } = null!;

        [Required]
        [Comment("Foreign key to Country")]
        public int CountryId { get; set; }
        [ForeignKey(nameof(CountryId))]
        public virtual Country Country { get; set; } = null!;

        [Comment("Indicates if the Location was deleted")]
        public bool IsDeleted { get; set; } = false;

        [Comment("Date and time when the Location was marked as deleted")]
        public DateTime? DeletedOn { get; set; }

    }
}
