using FleetRouteManager.Data.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static FleetRouteManager.Common.Constants.ManufacturerConstants;

namespace FleetRouteManager.Data.Models.Models
{
    public class Manufacturer : ISoftDeletable
    {
        [Key]
        [Comment("Primary Key for Manufacturer entity")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Manufacturer Name")]
        public string Name { get; set; } = null!;

        [Comment("Soft Delete")]
        public bool IsDeleted { get; set; } = false;

        [Comment("Deletion date")]
        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
