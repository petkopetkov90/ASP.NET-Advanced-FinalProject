﻿using FleetRouteManager.Data.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FleetRouteManager.Common.Constants.OrderConstants;

namespace FleetRouteManager.Data.Models
{
    public class Order : ISoftDeletable
    {
        [Key]
        [Comment("Primary Key for Order entity")]
        public int Id { get; set; }

        [Required]
        [MaxLength(OrderNumberMaxLength)]
        [Comment("Order number")]
        public string OrderNumber { get; set; } = null!;

        [Required]
        [Comment("date of issue of the Order")]
        public DateTime OrderDate { get; set; }

        [Required]
        [Comment("Amount in EURO payable for completing the Order")]
        public decimal Amount { get; set; }

        [Required]
        [MaxLength(UserNameMaxLength)]
        [Comment("User who created the Order")]
        public string User { get; set; } = null!;

        [Required]
        [Comment("Foreign key to Client")]
        public int ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        public virtual Client Client { get; set; } = null!;

        [Comment("Foreign key to Trip")]
        public int? TripId { get; set; }
        [ForeignKey(nameof(TripId))]
        public virtual Trip? Trip { get; set; }

        [Comment("Indicates if the Order was deleted")]
        public bool IsDeleted { get; set; }

        [Comment("Date and time when the Order was marked as deleted")]

        public DateTime? DeletedOn { get; set; }


    }
}
