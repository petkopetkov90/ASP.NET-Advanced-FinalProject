using FleetRouteManager.Data.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static FleetRouteManager.Data.Common.Constants.VehicleTypeConstants;


namespace FleetRouteManager.Data.Models.Models
{
    public class VehicleType : ISoftDeletable
    {
        [Key]
        [Comment("Primary key for Vehicle Type")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Type of vehicle")]
        public string Type { get; set; } = null!;

        [Comment("Indicates if the Type was deleted")]
        public bool IsDeleted { get; set; } = false;

        [Comment("Date and time when the Type was marked as deleted")]
        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
