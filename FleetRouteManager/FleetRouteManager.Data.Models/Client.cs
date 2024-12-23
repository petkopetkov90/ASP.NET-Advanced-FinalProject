﻿using FleetRouteManager.Data.Models.Interfaces;
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
        [MaxLength(ClientNameMaxLength)]
        [Comment("Client legal name")]
        public string LegalName { get; set; } = null!;

        [Required]
        [Comment("Foreign key to address used for address of client")]
        public int AddressId { get; set; }
        [ForeignKey(nameof(AddressId))]
        public virtual Address Address { get; set; } = null!;

        [Required]
        [Comment("Foreign key to address used for legal address")]
        public int? LegalAddressId { get; set; }
        [ForeignKey(nameof(LegalAddressId))]
        public virtual Address? LegalAddress { get; set; }

        [Comment("Foreign key to location used for postal address")]
        public int? PostalLocationId { get; set; }
        [ForeignKey(nameof(PostalLocationId))]
        public virtual Location? PostalLocation { get; set; }

        [MaxLength(ClientPhoneMaxLength)]
        [Comment("Client phone number")]
        public string? PhoneNumber { get; set; }

        [Required]
        [MaxLength(ClientEmailMaxLength)]
        [Comment("Email address for contact with client")]
        public string ContactEmail { get; set; } = null!;

        [MaxLength(ClientEmailMaxLength)]
        [Comment("Email address used for sending proofs of deliveries")]
        public string? PodEmail { get; set; }

        [MaxLength(ClientEmailMaxLength)]
        [Comment("Email address used for sending invoices")]
        public string? InvoicingEmail { get; set; }

        [MaxLength(ClientEmailMaxLength)]
        [Comment("Email address used for payment requests")]
        public string? PaymentEmail { get; set; }

        [Comment("Indicates if the Client was deleted")]
        public bool IsDeleted { get; set; } = false;

        [Comment("Date and time when the Client was marked as deleted")]
        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
