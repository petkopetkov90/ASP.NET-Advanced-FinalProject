using FleetRouteManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetRouteManager.Data.Common.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.Amount)
                .HasColumnType("decimal(18,2)");

            builder
                .HasOne(o => o.Client)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.ClientId)
                .OnDelete(deleteBehavior: DeleteBehavior.Restrict);

            builder
                .HasIndex(o => o.OrderNumber)
                .IsUnique();

            builder.HasData(
                new Order
                {
                    Id = 1,
                    OrderNumber = "43/ZTE/240412",
                    OrderDate = new DateTime(2024, 04, 12),
                    Amount = 500m,
                    User = "admin@myapp.com",
                    ClientId = 1,
                    TripId = 1,
                },
                new Order
                {
                    Id = 2,
                    OrderNumber = "240613/125",
                    OrderDate = new DateTime(2024, 06, 13),
                    Amount = 220.50m,
                    User = "admin@myapp.com",
                    ClientId = 2,
                    TripId = 1,
                },
                new Order
                {
                    Id = 3,
                    OrderNumber = "1324141",
                    OrderDate = new DateTime(2024, 11, 06),
                    Amount = 1800m,
                    User = "admin@myapp.com",
                    ClientId = 3,
                    TripId = 2,
                },
                new Order
                {
                    Id = 4,
                    OrderNumber = "Z-11111/24",
                    OrderDate = new DateTime(2024, 02, 05),
                    Amount = 333m,
                    User = "petkopetkov900808@gmail.com",
                    ClientId = 2,
                    TripId = 3,
                },
                new Order
                {
                    Id = 5,
                    OrderNumber = "Z-15123/24",
                    OrderDate = new DateTime(2024, 03, 13),
                    Amount = 555.50m,
                    User = "petkopetkov900808@gmail.com",
                    ClientId = 3,
                    TripId = 4,
                },
                new Order
                {
                    Id = 6,
                    OrderNumber = "Z-53235/24",
                    OrderDate = new DateTime(2024, 04, 12),
                    Amount = 770m,
                    User = "petkopetkov900808@gmail.com",
                    ClientId = 1,
                    TripId = 5,
                }
                );
        }
    }
}
