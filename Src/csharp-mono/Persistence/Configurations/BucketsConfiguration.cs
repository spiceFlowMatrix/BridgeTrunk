using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class BucketsConfiguration: IEntityTypeConfiguration<Buckets>
    {
        public void Configure(EntityTypeBuilder<Buckets> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}