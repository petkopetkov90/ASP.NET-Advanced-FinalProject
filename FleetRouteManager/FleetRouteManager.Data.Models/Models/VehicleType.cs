using FleetRouteManager.Common.Enums;
using FleetRouteManager.Data.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FleetRouteManager.Data.Models.Models
{
    public class VehicleType : ISoftDeletable
    {
        [Key]
        [Comment("Primary Key for VehicleType")]
        public int Id { get; set; }

        [Required]
        [Comment("Truck type")]
        public TruckType TruckType { get; set; }

        [Required]
        [Comment("Body type")]
        public BodyType BodyType { get; set; }

        [Required]
        [Comment("Total capacity in tons")]
        public double WeightCapacity { get; set; }

        [Comment("Soft Delete")]
        public bool IsDeleted { get; set; } = false;

        [Comment("Deletion date")]
        public DateTime? DeletedOn { get; set; }

        public virtual IEnumerable<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
