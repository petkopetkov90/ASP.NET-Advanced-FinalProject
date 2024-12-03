﻿using FleetRouteManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetRouteManager.Data.Common.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder
                .HasOne(c => c.LegalAddress)
                .WithMany(a => a.LegalClients)
                .HasForeignKey(c => c.LegalAddressId)
                .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull);

            builder
                .HasOne(c => c.PostalLocation)
                .WithMany(a => a.PostClients)
                .HasForeignKey(c => c.PostalAddressId)
                .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull);

            builder
                .HasIndex(c => c.TaxNumber)
                .IsUnique();

            builder.HasData(
                new Client
                {
                    Id = 1,
                    Name = "DHL Bulgaria",
                    TaxNumber = "BG11111111",
                    LegalName = "DHL Express Bulgaria EOOD",
                    LegalAddressId = 2,
                    PostalAddressId = 2,
                    PodEmail = "pod@dhl.bg",
                    InvoicingEmail = "invoices@dhl.bg",
                    PaymentEmail = "payments@dhl.bg",
                },
                new Client
                {
                    Id = 2,
                    Name = "Schenker Bulgaria",
                    LegalName = "Schenker EOOD",
                    TaxNumber = "BG22222222",
                    LegalAddressId = 5,
                    PostalAddressId = 4,
                    PodEmail = "pod@schenker.bg",
                },
                new Client
                {
                    Id = 3,
                    Name = "LKW Walter",
                    TaxNumber = "AT333333333",
                    LegalName = "LKW WALTER Internationale Transportorganisation AG",
                    LegalAddressId = 5,
                    PostalAddressId = 3,
                    PodEmail = "pod@lkw-walter.at",
                    InvoicingEmail = "invoicing@lkw-walter.at",
                });
        }
    }
}