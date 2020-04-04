using Bridge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class FeedBackTaskConfiguration: IEntityTypeConfiguration<FeedBackTask>
    {
        public void Configure(EntityTypeBuilder<FeedBackTask> builder)
        {
            builder.HasKey(e => e.Id);
        }
        
    }
}