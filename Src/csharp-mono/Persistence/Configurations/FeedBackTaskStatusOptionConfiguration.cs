using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class FeedBackTaskStatusOptionConfiguration: IEntityTypeConfiguration<FeedBackTaskStatusOption>
    {
        public void Configure(EntityTypeBuilder<FeedBackTaskStatusOption> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}