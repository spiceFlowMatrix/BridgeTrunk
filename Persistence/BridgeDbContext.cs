using Bridge.Application.Common.Interfaces;
using Bridge.Common;
using Bridge.Domain.Common;
using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Bridge.Persistence
{
    public class BridgeDbContext : DbContext, IBridgeDbContext
    {
        private readonly IDateTime _dateTime;
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        public BridgeDbContext(DbContextOptions<BridgeDbContext> options)
            : base(options)
        {
        }

        public BridgeDbContext(DbContextOptions<BridgeDbContext> options, IDateTime dateTime)
            : base(options)
        {
            _dateTime = dateTime;
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            // TODO: Add audit tracking for user and time of event after integration with auth0 is completed. See clean architecture northwind github example for reference.
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedOn = _dateTime.Now;
                        break;
                }
            }
            
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TODO: Ensure all generated data structure naming follows snake casing.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BridgeDbContext).Assembly);
        }
    }
}