using FleetRouteManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetRouteManager.Data.Common.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {

            builder.HasData(
                new Client()
                {
                    Id = 1,
                    Name = "DHL Bulgaria",
                    TaxNumber = "BG11111111",
                    LegalAddressId = 4,
                    PostalAddressId = 4,
                    PodEmail = "pod@dhl.bg",
                    InvoicingEmail = "invoices@dhl.bg",
                },
                new Client()
                {
                    Id = 2,
                    Name = "Schenker Bulgaria",
                    TaxNumber = "BG22222222",
                    LegalAddressId = 2,
                    PodEmail = "pod@schenker.bg",
                },
                new Client()
                {
                    Id = 3,
                    Name = "LKW Walter",
                    TaxNumber = "AT333333333",
                    LegalAddressId = 5,
                    PostalAddressId = 3,
                    PodEmail = "pod@lkw-walter.at",
                    InvoicingEmail = "invoicing@lkw-walter.at",
                });
        }
    }
}
