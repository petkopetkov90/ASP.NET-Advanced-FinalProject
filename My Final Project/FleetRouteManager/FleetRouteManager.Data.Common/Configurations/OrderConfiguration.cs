using FleetRouteManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetRouteManager.Data.Common.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasOne(o => o.Client)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.ClientId)
                .OnDelete(deleteBehavior: DeleteBehavior.Cascade);

            builder
                .HasIndex(o => o.OrderNumber)
                .IsUnique();

            builder.HasData(
                new Order
                {
                    Id = 1,
                    OrderNumber = "43/ZTE/240412",
                    OrderDate = new DateTime(2024, 04, 12),
                    ClientId = 1
                },
                new Order
                {
                    Id = 2,
                    OrderNumber = "240613/125",
                    OrderDate = new DateTime(2024, 06, 13),
                    ClientId = 2
                },
                new Order
                {
                    Id = 3,
                    OrderNumber = "1324141",
                    OrderDate = new DateTime(2024, 11, 06),
                    ClientId = 3
                });
        }
    }
}
