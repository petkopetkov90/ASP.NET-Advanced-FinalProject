using FleetRouteManager.Data.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FleetRouteManager.Common.Constants.AddressConstants;

namespace FleetRouteManager.Data.Models
{
    public class Address : ISoftDeletable
    {
        [Key]
        [Comment("Primary Key of Address Entity")]
        public int Id { get; set; }

        [Required]
        [MaxLength(StreetMaxLength)]
        [Comment("Street name")]
        public string Street { get; set; } = null!;

        [MaxLength(NumberMaxLength)]
        [Comment("Street number")]
        public string? Number { get; set; }

        [Required]
        [MaxLength(CodeMaxLength)]
        [Comment("Post code")]
        public string PostCode { get; set; } = null!;

        [Required]
        [MaxLength(CityMaxLength)]
        [Comment("City name")]
        public string City { get; set; } = null!;

        [Required]
        [Comment("Foreign key to Country")]
        public int CountryId { get; set; }
        [ForeignKey(nameof(CountryId))]
        public virtual Country Country { get; set; } = null!;

        [Comment("Indicates if the Address was deleted")]
        public bool IsDeleted { get; set; } = false;

        [Comment("Date and time when the Address was marked as deleted")]
        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
    }
}
