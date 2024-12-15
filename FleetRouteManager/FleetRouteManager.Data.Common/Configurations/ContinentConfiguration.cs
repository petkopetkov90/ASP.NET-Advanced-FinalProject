using FleetRouteManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetRouteManager.Data.Common.Configurations
{
    public class ContinentConfiguration : IEntityTypeConfiguration<Continent>
    {
        public void Configure(EntityTypeBuilder<Continent> builder)
        {
            builder
                .HasIndex(e => e.Name)
                .IsUnique();

            builder.HasData(
                new Continent { Id = 1, Name = "Africa" },
                new Continent { Id = 2, Name = "Antarctica" },
                new Continent { Id = 3, Name = "Asia" },
                new Continent { Id = 4, Name = "Europe" },
                new Continent { Id = 5, Name = "North America" },
                new Continent { Id = 6, Name = "Australia" },
                new Continent { Id = 7, Name = "South America" }
            );
        }
    }
}
