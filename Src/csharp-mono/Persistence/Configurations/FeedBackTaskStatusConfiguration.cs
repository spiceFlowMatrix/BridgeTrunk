using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class FeedBackTaskStatusConfiguration: IEntityTypeConfiguration<FeedBackTaskStatus>
    {
        public void Configure(EntityTypeBuilder<FeedBackTaskStatus> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}