using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Options;
using IdentityServer4.EntityFramework.Stores;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Bridge.Infrastructure.Identity
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<ApplicationUser>(entity => entity.Property(m => m.Id).HasMaxLength(127));
			modelBuilder.Entity<ApplicationUser>(entity => entity.Property(m => m.UserName).HasMaxLength(127));
			modelBuilder.Entity<ApplicationUser>(entity => entity.Property(m => m.NormalizedUserName).HasMaxLength(127));
			modelBuilder.Entity<ApplicationUser>(entity => entity.Property(m => m.Email).HasMaxLength(127));
			modelBuilder.Entity<IdentityUser>(entity => entity.Property(m => m.Id).HasMaxLength(127));
			modelBuilder.Entity<IdentityUser>(entity => entity.Property(m => m.UserName).HasMaxLength(127));
			modelBuilder.Entity<IdentityUser>(entity => entity.Property(m => m.NormalizedUserName).HasMaxLength(127));
			modelBuilder.Entity<IdentityUser>(entity => entity.Property(m => m.Email).HasMaxLength(127));
			modelBuilder.Entity<IdentityRole>(entity => entity.Property(m => m.Id).HasMaxLength(127));
			modelBuilder.Entity<IdentityRole>(entity => entity.Property(m => m.Name).HasMaxLength(127));
			modelBuilder.Entity<IdentityRole>(entity => entity.Property(m => m.NormalizedName).HasMaxLength(127));
			modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(127));
			modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.ProviderKey).HasMaxLength(127));
			modelBuilder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(127));
			modelBuilder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.RoleId).HasMaxLength(127));
			modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(127));
			modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(127));
			modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.Name).HasMaxLength(127));
			modelBuilder.Entity<PersistedGrant>(entity => entity.Property(m => m.Key).HasMaxLength(127));
			modelBuilder.Entity<PersistedGrant>(entity => entity.Property(m => m.SubjectId).HasMaxLength(127));
			modelBuilder.Entity<PersistedGrant>(entity => entity.Property(m => m.ClientId).HasMaxLength(127));
			modelBuilder.Entity<DeviceFlowCodes>(entity => entity.Property(m => m.ClientId).HasMaxLength(127));
			modelBuilder.Entity<DeviceFlowCodes>(entity => entity.Property(m => m.UserCode).HasMaxLength(127));
			modelBuilder.Entity<DeviceFlowCodes>(entity => entity.Property(m => m.DeviceCode).HasMaxLength(127));
			modelBuilder.Entity<DeviceFlowCodes>(entity => entity.Property(m => m.SubjectId).HasMaxLength(127));
		}
	}
}
