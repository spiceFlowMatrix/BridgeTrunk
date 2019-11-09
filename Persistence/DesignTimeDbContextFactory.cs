using Microsoft.EntityFrameworkCore;

namespace Bridge.Persistence
{
    public class DesignTimeDbContextFactory : DesignTimeDbContextFactoryBase<BridgeDbContext>
    {
        protected override BridgeDbContext CreateNewInstance(DbContextOptions<BridgeDbContext> options)
        {
            return new BridgeDbContext(options);
        }
    }
}