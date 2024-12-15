using FleetRouteManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetRouteManager.Data.Common.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder
                .HasOne(c => c.Address)
                .WithMany(a => a.Clients)
                .HasForeignKey(c => c.AddressId)
                .OnDelete(deleteBehavior: DeleteBehavior.Restrict);

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
                .HasIndex(c => new { c.Name, c.AddressId, c.TaxNumber })
                .IsUnique();

            builder.HasData(
                new Client
                {
                    Id = 1,
                    Name = "DHL Bulgaria",
                    TaxNumber = "BG11111111",
                    LegalName = "DHL Express Bulgaria EOOD",
                    AddressId = 2,
                    LegalAddressId = 2,
                    PostalAddressId = 2,
                    ContactEmail = "contact@dhl.bg",
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
                    AddressId = 4,
                    LegalAddressId = 5,
                    PostalAddressId = 4,
                    ContactEmail = "contact@schenker.bg",
                    PodEmail = "pod@schenker.bg",
                },
                new Client
                {
                    Id = 3,
                    Name = "LKW Walter",
                    TaxNumber = "AT333333333",
                    LegalName = "LKW WALTER Internationale Transportorganisation AG",
                    AddressId = 3,
                    LegalAddressId = 5,
                    PostalAddressId = 3,
                    ContactEmail = "contact@lkw-walter.at",
                    PodEmail = "pod@lkw-walter.at",
                    InvoicingEmail = "invoicing@lkw-walter.at",
                });
        }
    }
}
