using FleetRouteManager.Common.Enums;
using FleetRouteManager.Data.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static FleetRouteManager.Data.Common.Constants.VehicleTypeConstants;

namespace FleetRouteManager.Data.Models.Models
{
    //Type of Vehicle - class for EF entity 
    public class VehicleType : ISoftDeletable
    {
        [Key]
        [Comment("Primary Key for VehicleType")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Vehicle type name")]
        public string TypeName { get; set; } = null!;

        [Required]
        [Comment("Truck type")]
        public CargoType TruckType { get; set; }

        [Required]
        [Comment("Body type")]
        public BodyType BodyType { get; set; }

        [Required]
        [Comment("Vehicle number of axles")]
        public int Axles { get; set; }

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
