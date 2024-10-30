using FleetRouteManager.Data.Configurations;
using FleetRouteManager.Data.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FleetRouteManager.Data.Data
{
    public class FleetRouteManagerDbContext : IdentityDbContext<IdentityUser>
    {
        public FleetRouteManagerDbContext(DbContextOptions<FleetRouteManagerDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new VehicleConfiguration());
            builder.ApplyConfiguration(new ManufacturerConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
