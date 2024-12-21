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
        [Comment("Foreign key to Address")]
        public int AddressId { get; set; }
        [ForeignKey(nameof(AddressId))]
        public virtual Address Address { get; set; } = null!;

        [Comment("Indicates if the Location was deleted")]
        public bool IsDeleted { get; set; } = false;

        [Comment("Date and time when the Location was marked as deleted")]
        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

        [InverseProperty(nameof(Trip.StartingLocation))]

        public virtual ICollection<Trip> TripsStart { get; set; } = new List<Trip>();

        [InverseProperty(nameof(Trip.EndingLocation))]

        public virtual ICollection<Trip> TripsEnd { get; set; } = new List<Trip>();

    }
}
