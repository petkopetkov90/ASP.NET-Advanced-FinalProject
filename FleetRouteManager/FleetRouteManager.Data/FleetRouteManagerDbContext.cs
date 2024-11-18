using FleetRouteManager.Data.Configurations;
using FleetRouteManager.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FleetRouteManager.Data
{
    public class FleetRouteManagerDbContext : IdentityDbContext<IdentityUser>
    {
        public FleetRouteManagerDbContext(DbContextOptions<FleetRouteManagerDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<VehicleType> VehicleTypes { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new VehicleConfiguration());
            builder.ApplyConfiguration(new ManufacturerConfiguration());
            builder.ApplyConfiguration(new VehicleTypeConfiguration());
            builder.ApplyConfiguration(new DriverConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
