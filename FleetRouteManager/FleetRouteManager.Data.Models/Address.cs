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
        [Comment("Primary key of Address entity")]
        public int Id { get; set; }

        [Required]
        [MaxLength(AddressStreetNameMaxLength)]
        [Comment("Street name")]
        public string Street { get; set; } = null!;

        [MaxLength(AddressStreetNumberMaxLength)]
        [Comment("Street number")]
        public string? Number { get; set; }

        [Required]
        [MaxLength(AddressPostCodeMaxLength)]
        [Comment("Post code")]
        public string PostCode { get; set; } = null!;

        [Required]
        [MaxLength(AddressCityMaxLength)]
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

        [InverseProperty(nameof(Client.LegalAddress))]
        public virtual ICollection<Client> LegalClients { get; set; } = new List<Client>();

        [InverseProperty(nameof(Client.Address))]
        public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string ComputedNumber { get; private set; } = null!;
    }
}
