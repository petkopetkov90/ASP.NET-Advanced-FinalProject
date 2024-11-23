using FleetRouteManager.Data.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FleetRouteManager.Common.Constants.CountryConstants;

namespace FleetRouteManager.Data.Models
{
    public class Country : ISoftDeletable
    {
        [Key]
        [Comment("Primary key of Country entity")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Country name")]
        public string Name { get; set; } = null!;

        [Required]
        [Comment("Foreign key to Continent")]
        public int ContinentId { get; set; }
        [ForeignKey(nameof(ContinentId))]
        public Continent Continent { get; set; } = null!;

        [Comment("Indicates if the Country was deleted")]
        public bool IsDeleted { get; set; }

        [Comment("Date and time when the Country was marked as deleted")]
        public DateTime? DeletedOn { get; set; }
    }
}
