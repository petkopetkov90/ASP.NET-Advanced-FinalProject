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
        [MaxLength(NameMaxLength)]
        [Comment("Location name")]
        public string Name { get; set; } = null!;

        [MaxLength(PhoneMaxLength)]
        [Comment("Location phone number")]
        public string? PhoneNumber { get; set; }

        [Comment("Foreign key to Address")]
        public int AddressId { get; set; }
        [ForeignKey(nameof(AddressId))]
        public virtual Address Address { get; set; } = null!;

        [Comment("Indicates if the Location was deleted")]
        public bool IsDeleted { get; set; } = false;

        [Comment("Date and time when the Location was marked as deleted")]
        public DateTime? DeletedOn { get; set; }
    }
}
