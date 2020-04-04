using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class ProgessSyncConfiguration: IEntityTypeConfiguration<ProgessSync>
    {
        public void Configure(EntityTypeBuilder<ProgessSync> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}