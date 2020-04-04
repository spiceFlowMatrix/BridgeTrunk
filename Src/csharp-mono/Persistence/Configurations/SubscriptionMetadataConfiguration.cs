using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class SubscriptionMetadataConfiguration: IEntityTypeConfiguration<SubscriptionMetadata>
    {
        public void Configure(EntityTypeBuilder<SubscriptionMetadata> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}