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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
