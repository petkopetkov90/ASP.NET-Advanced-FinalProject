using FleetRouteManager.Data.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FleetRouteManager.Common.Constants.ClientConstants;

namespace FleetRouteManager.Data.Models
{
    public class Client : ISoftDeletable
    {
        [Key]
        [Comment("Primary key of Client entity")]
        public int Id { get; set; }

        [Required]
        [MaxLength(ClientNameMaxLength)]
        [Comment("Client name")]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(ClientTaxNumberMaxLength)]
        [Comment("Client VAT for business clients or PIN for private clients")]
        public string TaxNumber { get; set; } = null!;

        [Required]
        [Comment("Foreign key to address")]
        public int LegalAddressId { get; set; }
        [ForeignKey(nameof(LegalAddressId))]
        public Address LegalAddress { get; set; } = null!;

        [Comment("Foreign key to address")]
        public int? PostalAddressId { get; set; }
        [ForeignKey(nameof(PostalAddressId))]
        public Address? PostalAddress { get; set; }

        [MaxLength(EmailMaxLength)]
        [Comment("Email address used for sending proofs of deliveries")]
        public string? PodEmail { get; set; }

        [MaxLength(EmailMaxLength)]
        [Comment("Email address used for sending invoices")]
        public string? InvoicingEmail { get; set; }

        [MaxLength(EmailMaxLength)]
        [Comment("Email address used for payment requests")]
        public string? PaymentEmail { get; set; }

        [Comment("Indicates if the Client was deleted")]
        public bool IsDeleted { get; set; } = false;

        [Comment("Date and time when the Client was marked as deleted")]
        public DateTime? DeletedOn { get; set; }
    }
}
