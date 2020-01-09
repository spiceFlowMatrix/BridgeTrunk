using Microsoft.EntityFrameworkCore;

namespace Bridge.Infrastructure.Identity
{
    public class IdentityDbContext : DbContext
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
            : base(options) { }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
